using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PictureSorter
{

partial class MainForm : Form
{
  public MainForm()
  {
    InitializeComponent();
  }

  protected override void OnClosed(EventArgs e)
  {
    base.OnClosed(e);
    FinishSavingImages();
    SaveChangedImages();
  }

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);

    SettingsForm form = new SettingsForm();
    if(form.ShowDialog() == DialogResult.OK)
    {
      outputDir = form.OutputDirectory;

      lstFiles.Groups.Add("Uncategorized", "Uncategorized");
      lstFiles.LargeImageList = new ImageList();
      lstFiles.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
      lstFiles.LargeImageList.ImageSize = new Size(64, 64);

      foreach(string path in form.Pictures) lstFiles.Items.Add(new FileItem(path));

      BeginLoadingThumbnails();
      BeginSavingImages();

      hsplit.SplitterDistance = hsplit.Width - 200;
      vsplit.SplitterDistance = 240;
      Enabled = true;
    }
    else Close();
  }

  class FileItem : ListViewItem
  {
    public FileItem(string path)
    {
      originalPath = path;
      Text = FileName;
      group = -1;
    }

    public bool Changed
    {
      get { return ImageChanged || ThumbnailChanged; }
    }

    public string FileName
    {
      get { return System.IO.Path.GetFileName(Path); }
    }

    public int GroupIndex
    {
      get { return group; }
      set { group = value; }
    }

    public bool HasOutputFile
    {
      get { return path != null; }
    }

    public bool HasIcon
    {
      get { return hasIcon; }
      set { hasIcon = value; }
    }

    public bool HasThumbnail
    {
      get { return !string.IsNullOrEmpty(ThumbnailPath); }
    }

    public bool ImageChanged
    {
      get { return imageChanged; }
      set { imageChanged = value; }
    }

    public ImageFormat ImageFormat
    {
      get { return format; }
      set { format = value; }
    }

    public string OriginalPath
    {
      get { return originalPath; }
    }

    public string Path
    {
      get { return path == null ? OriginalPath : path; }
      set { path = value; }
    }

    public bool ThumbnailChanged
    {
      get { return thumbnailChanged; }
      set { thumbnailChanged = value; }
    }

    public string ThumbnailPath
    {
      get { return thumbnailPath; }
      set { thumbnailPath = value; }
    }

    public string ThumbnailScheme
    {
      get { return thumbnailScheme; }
      set { thumbnailScheme = value; }
    }

    public Size ThumbnailSize
    {
      get { return thumbnailSize; }
      set { thumbnailSize = value; }
    }

    readonly string originalPath;
    string path, thumbnailPath, thumbnailScheme;
    Size thumbnailSize;
    int group;
    ImageFormat format;
    bool imageChanged, hasIcon, thumbnailChanged;
  }

  static bool AreSameFile(string file1, string file2)
  {
    return string.Equals(NormalizePath(file1), NormalizePath(file2), StringComparison.Ordinal);
  }

  void AssignImagesToGroup(int index)
  {
    AssignImagesToGroup(index, lstFiles.SelectedItems, false);
  }

  void AssignImagesToGroup(int index, System.Collections.ICollection items, bool forceReassign)
  {
    string groupName = GetGroupFilename(index), sep = groupName.IndexOf(' ') == -1 ? null : " ";
    if(chkLowerCase.Checked) groupName = groupName.ToLower();

    foreach(FileItem item in items)
    {
      if(item.GroupIndex != index || forceReassign)
      {
        string dir = outputDir;
        if(chkCreateGroupDirs.Checked)
        {
          dir = Path.Combine(dir, groupName);
          Directory.CreateDirectory(dir);
        }

        string newPath = chkAutoRename.Checked
          ? GetUniqueFilename(Path.Combine(dir, groupName + Path.GetExtension(item.FileName)), sep, true)
          : GetUniqueFilename(Path.Combine(dir, item.FileName));

        MoveItem(item, newPath);
        item.GroupIndex = index;
        item.Group = lstFiles.Groups[index+1];
      }
    }
  }

  void BeginLoadingThumbnails()
  {
    loadThread = new Thread(LoadThumbnails);
    loadThread.IsBackground = true;
    loadThread.Priority = ThreadPriority.BelowNormal;
    loadThread.Start();
  }

  void BeginSavingImages()
  {
    saveThread = new Thread(SaveImagesInBackground);
    saveThread.Priority = ThreadPriority.BelowNormal;
    saveThread.Start();
  }

  void CleanupCache()
  {
    while(cacheSize > 100*1024*1024 && imageCache.Count > 1) // use up to 100 mb for the cache
    {
      LinkedListNode<KeyValuePair<FileItem, Image>> node = imageCache.Last;
      SaveItemImage(node.Value.Key, node.Value.Value);
      DisposeCacheNode(node);
    }
  }

  void CreateGroup()
  {
    ListViewItem item = lstGroups.Items.Add("NEW GROUP");
    item.Tag = item.Text;
    item.BeginEdit();
  }

  string CreateFilenameByScheme(string path, string namingScheme)
  {
    if(string.IsNullOrEmpty(namingScheme)) return path;

    string directory = Path.GetDirectoryName(path), filename = Path.GetFileNameWithoutExtension(path);
    string extension = Path.GetExtension(path);

    if(directory.Length != 0)
    {
      char lastChar = directory[directory.Length-1];
      if(lastChar != Path.DirectorySeparatorChar && lastChar != Path.AltDirectorySeparatorChar)
      {
        directory += Path.DirectorySeparatorChar.ToString();
      }
    }

    return renameRe.Replace(namingScheme, delegate(Match m)
    {
      switch(char.ToLowerInvariant(m.Value[1]))
      {
        case '%': return "%";
        case 'd': return directory;
        case 'e': return extension;
        case 'f': return filename;
        case 'n': return indexNumber++.ToString(CultureInfo.InvariantCulture);
        default: return string.Empty;
      }
    });
  }

  Image CreateThumbnail(Image image, int width, int height, Color fillColor, bool highQuality)
  {
    double idealAspect = height == 0 ? 0 : (double)width / height;

    Bitmap newImage = null;
    double aspectRatio = (double)image.Width / image.Height;
    int newWidth, newHeight;

    if(width == 0 || height != 0 && aspectRatio < idealAspect)
    {
      newWidth  = (int)Math.Round(height * aspectRatio);
      newHeight = height;
    }
    else
    {
      newWidth  = width;
      newHeight = (int)Math.Round(width / aspectRatio);
    }

    newImage = fillColor == Color.Transparent ? new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb)
                                              : new Bitmap(width, height, PixelFormat.Format24bppRgb);
    if(image.PixelFormat == PixelFormat.Format1bppIndexed || image.PixelFormat == PixelFormat.Format4bppIndexed ||
       image.PixelFormat == PixelFormat.Format8bppIndexed)
    {
      newImage.Palette = image.Palette; // copy the palette, if there is one
    }

    using(Graphics g = Graphics.FromImage(newImage))
    {
      g.CompositingMode = CompositingMode.SourceCopy;
      if(highQuality)
      {
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.InterpolationMode  = InterpolationMode.HighQualityBicubic;
      }
      else
      {
        g.CompositingQuality = CompositingQuality.HighSpeed;
        g.InterpolationMode  = chkLowQuality.Checked ?
          InterpolationMode.Bilinear : InterpolationMode.HighQualityBilinear;
      }

      if(fillColor != Color.Transparent)
      {
        using(Brush brush = new SolidBrush(fillColor)) g.FillRectangle(brush, 0, 0, newImage.Width, newImage.Height);
      }

      g.DrawImage(image, new Rectangle((newImage.Width-newWidth)/2, (newImage.Height-newHeight)/2,
                                       newWidth, newHeight));
    }

    return newImage;
  }

  void DeleteGroup(int index)
  {
    if(lstFiles.Groups.Count > index) lstFiles.Groups.RemoveAt(index+1);
    lstGroups.Items.RemoveAt(index);
  }

  void DeleteImages(bool confirm)
  {
    if(lstFiles.SelectedItems.Count != 0)
    {
      if(confirm)
      {
        string description = lstFiles.SelectedItems.Count == 1
          ? "'"+lstFiles.SelectedItems[0].Text+"'"
          : lstFiles.SelectedItems.Count.ToString(CultureInfo.InvariantCulture) + " files";
        if(MessageBox.Show("Delete " + description + "?", "Delete files?", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
        {
          return;
        }
      }

      while(lstFiles.SelectedItems.Count != 0)
      {
        FileItem item = (FileItem)lstFiles.SelectedItems[0];

        for(LinkedListNode<KeyValuePair<FileItem, Image>> node = imageCache.First; node != null; node = node.Next)
        {
          if(node.Value.Key == item)
          {
            DisposeCacheNode(node);
            break;
          }
        }

        File.Delete(item.Path);
        item.Remove();
      }
    }
  }

  void DisposeCacheNode(LinkedListNode<KeyValuePair<FileItem, Image>> node)
  {
    cacheSize -= GetImageSize(node.Value.Value);
    node.Value.Value.Dispose();
    imageCache.Remove(node);
  }

  void EnsureOutputFile(FileItem item)
  {
    if(!item.HasOutputFile)
    {
      string newPath = Path.Combine(outputDir, item.FileName);
      if(!AreSameFile(newPath, item.OriginalPath)) newPath = GetUniqueFilename(newPath);
      MoveItem(item, newPath);
    }
  }

  void FinishSavingImages()
  {
    if(saveThread != null)
    {
      quitting = true;
      quitEvent.Set();
      saveThread.Join();
    }
  }

  Image GetCachedImage(FileItem item)
  {
    for(LinkedListNode<KeyValuePair<FileItem, Image>> node = imageCache.First; node != null; node = node.Next)
    {
      if(node.Value.Key == item)
      {
        imageCache.Remove(node);
        imageCache.AddFirst(node);
        return node.Value.Value;
      }
    }

    Image image = LoadImage(item);
    imageCache.AddFirst(new KeyValuePair<FileItem, Image>(item, image));
    cacheSize += GetImageSize(image);
    CleanupCache();
    return image;
  }

  string GetGroupFilename(int index)
  {
    string filename = (string)lstGroups.Items[index].Tag;
    foreach(char c in Path.GetInvalidPathChars()) filename = filename.Replace(c.ToString(), "");
    if(filename.Length == 0) filename = "Group" + (index+1).ToString(CultureInfo.InvariantCulture);
    return filename;
  }

  static string GetGroupIndexText(int index)
  {
    if(index < 10)
    {
      return (index == 9 ? "0" : (index+1).ToString(CultureInfo.InvariantCulture)) + ". ";
    }
    else if(index < 20)
    {
      return "C-" + (index == 19 ? "0" : (index-10+1).ToString(CultureInfo.InvariantCulture)) + ". ";
    }
    else return "";
  }

  static int GetImageSize(Image image)
  {
    int depth;
    switch(image.PixelFormat)
    {
      case PixelFormat.Format16bppArgb1555: case PixelFormat.Format16bppGrayScale: case PixelFormat.Format16bppRgb555:
      case PixelFormat.Format16bppRgb565:
        depth = 16;
        break;
      case PixelFormat.Format1bppIndexed:
        depth = 1;
        break;
      case PixelFormat.Format32bppArgb: case PixelFormat.Format32bppPArgb: case PixelFormat.Format32bppRgb:
        depth = 32;
        break;
      case PixelFormat.Format48bppRgb:
        depth = 48;
        break;
      case PixelFormat.Format4bppIndexed:
        depth = 4;
        break;
      case PixelFormat.Format64bppArgb: case PixelFormat.Format64bppPArgb:
        depth = 64;
        break;
      case PixelFormat.Format8bppIndexed:
        depth = 8;
        break;
      case PixelFormat.Format24bppRgb: default:
        depth = 24;
        break;
    }

    return image.Width * image.Height * depth / 8;
  }

  static string GetUniqueFilename(string path)
  {
    return GetUniqueFilename(path, null, false);
  }

  static string GetUniqueFilename(string path, string sep, bool startWithSuffix)
  {
    string dir = Path.GetDirectoryName(path), filename = Path.GetFileNameWithoutExtension(path);
    string ext = Path.GetExtension(path).ToLower();
    int suffix = 0;

    while(startWithSuffix || File.Exists(path))
    {
      path = Path.Combine(dir, filename + sep + (++suffix).ToString(CultureInfo.InvariantCulture) + ext);
      startWithSuffix = false;
    }

    return path;
  }

  void IncrementProgress()
  {
    progress.Value++;
    Application.DoEvents();
  }

  static Image LoadImage(FileItem item)
  {
    using(FileStream stream = File.OpenRead(item.Path))
    {
      Image image = Image.FromStream(stream);
      if(item.ImageFormat == null) item.ImageFormat = image.RawFormat;
      return image;
    }
  }

  void LoadThumbnails()
  {
    bool allThumbnailsLoaded;
    do
    {
      allThumbnailsLoaded = true;
      for(int i=0; i<lstFiles.Items.Count; i++)
      {
        FileItem item = null;
        lstFiles.Invoke((ThreadStart)delegate { item = (FileItem)lstFiles.Items[i]; });

        if(!item.HasIcon)
        {
          item.HasIcon = true;
          Image img, thumbnail;
          try
          {
            img = LoadImage(item);
            using(img) thumbnail = CreateThumbnail(img, 64, 64, Color.White, false);
            lstFiles.Invoke((ThreadStart)delegate
            {
              lstFiles.LargeImageList.Images.Add(thumbnail);
              item.ImageIndex = lstFiles.LargeImageList.Images.Count-1;
              lstFiles.Invalidate(lstFiles.GetItemRect(item.Index));
            });
          }
          catch { }

          allThumbnailsLoaded = false;
        }
      }
    } while(!allThumbnailsLoaded);
  }

  void MoveItem(FileItem item, string newPath)
  {
    if(!AreSameFile(item.Path, newPath))
    {
      if(!item.HasOutputFile) File.Copy(item.OriginalPath, newPath);
      else File.Move(item.Path, newPath);
      item.Path = newPath;
      item.Text = item.FileName;

      if(item.HasThumbnail && File.Exists(item.ThumbnailPath))
      {
        string newThumbnailPath = CreateFilenameByScheme(item.Path, item.ThumbnailScheme);
        if(!AreSameFile(item.ThumbnailPath, newThumbnailPath))
        {
          newThumbnailPath = GetUniqueFilename(newThumbnailPath);
          File.Move(item.ThumbnailPath, newThumbnailPath);
          item.ThumbnailPath = newThumbnailPath;
        }
      }
    }
  }

  static string NormalizePath(string path)
  {
    return new FileInfo(path).FullName.ToLower();
  }

  void OnImageChanged(FileItem item, bool recreateIcon)
  {
    if(recreateIcon)
    {
      lstFiles.LargeImageList.Images[item.ImageIndex] =
        CreateThumbnail(GetCachedImage(item), 64, 64, Color.White, false);
    }

    lstFiles.Invalidate(lstFiles.GetItemRect(item.Index));
    item.ImageChanged = item.ThumbnailChanged = true;

    if(item.Selected && lstFiles.SelectedItems.Count == 1) UpdatePictureBox();
  }

  void OnThumbnailChanged(FileItem item)
  {
    item.ThumbnailChanged = true;
  }

  void ResetProgress()
  {
    lblStatus.Text = "";
    progress.Value = 0;
  }

  void ResizeAndRenameFiles(int width, int height, string namingScheme, bool createThumbnails)
  {
    System.Collections.ICollection items = lstFiles.SelectedItems.Count == 0 ?
      (System.Collections.ICollection)lstFiles.Items : lstFiles.SelectedItems;

    SetupProgress(width >= 0 || height >= 0 ? createThumbnails ? "Thumbnailing..." : "Resizing..." : "Renaming...",
                  items.Count);

    foreach(FileItem item in items)
    {
      EnsureOutputFile(item);
      string newPath = CreateFilenameByScheme(item.Path, namingScheme);

      if(width >= 0 || height >= 0)
      {
        if(createThumbnails)
        {
          if(!item.HasThumbnail || !AreSameFile(item.ThumbnailPath, newPath)) newPath = GetUniqueFilename(newPath);
          item.ThumbnailScheme = namingScheme;
          item.ThumbnailPath   = newPath;
          item.ThumbnailSize   = new Size(width, height);
          OnThumbnailChanged(item);
        }
        else
        {
          Image image = GetCachedImage(item);
          if(image.Width != width || image.Height != height)
          {
            SetCachedImage(item, CreateThumbnail(image, width, height, Color.Transparent, true), false);
          }
          if(!AreSameFile(item.Path, newPath)) MoveItem(item, GetUniqueFilename(newPath));
        }
      }
      else
      {
        if(!AreSameFile(item.Path, newPath)) MoveItem(item, GetUniqueFilename(newPath));
      }

      IncrementProgress();
    }
    
    ResetProgress();
    txtIndex.Text = indexNumber.ToString(CultureInfo.InvariantCulture);
  }

  void RotateImages(int degrees)
  {
    SetupProgress("Rotating...", lstFiles.SelectedItems.Count);

    foreach(FileItem item in lstFiles.SelectedItems)
    {
      try
      {
        EnsureOutputFile(item);
        Image img = GetCachedImage(item);
        switch(degrees)
        {
          case 90: img.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
          case 180: img.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
          case 270: img.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
        }
        OnImageChanged(item, true);
      }
      catch { }

      IncrementProgress();
    }

    ResetProgress();
  }

  void SaveChangedImages()
  {
    SetupProgress("Saving...", imageCache.Count + lstFiles.Items.Count);

    for(LinkedListNode<KeyValuePair<FileItem, Image>> node = imageCache.First; node != null; node = node.Next)
    {
      if(node.Value.Key.Changed) SaveItemImage(node.Value.Key, node.Value.Value);
      IncrementProgress();
    }

    foreach(FileItem item in lstFiles.Items)
    {
      if(item.ThumbnailChanged) SaveItemImage(item, null);
      IncrementProgress();
    }

    ResetProgress();
  }

  void SaveItemImage(FileItem item, Image image)
  {
    ImageFormat format = item.ImageFormat == null ? image.RawFormat : item.ImageFormat;
    if(item.ImageChanged)
    {
      image.Save(item.Path, format);
      item.ImageChanged = false;
    }

    if(item.HasThumbnail && item.ThumbnailChanged)
    {
      Image baseImage = image != null ? image : GetCachedImage(item);
      Image thumbnail = CreateThumbnail(baseImage, item.ThumbnailSize.Width, item.ThumbnailSize.Height,
                                        Color.Transparent, true);
      thumbnail.Save(item.ThumbnailPath, format);
      item.ThumbnailChanged = false;
    }
  }

  void SaveImagesInBackground()
  {
    while(!quitting)
    {
      bool savedImages = false;

      for(LinkedListNode<KeyValuePair<FileItem, Image>> node = imageCache.First;
          node != null && !quitting; node = node.Next)
      {
        if(node.Value.Key.Changed)
        {
          try
          {
            lstFiles.Invoke((ThreadStart)delegate { SaveItemImage(node.Value.Key, node.Value.Value); });
            break;
          }
          catch { }
        }
      }

      lstFiles.Invoke((ThreadStart)delegate {
        foreach(FileItem item in lstFiles.Items)
        {
          if(quitting) break;

          if(!item.ImageChanged && item.ThumbnailChanged)
          {
            try 
            {
              SaveItemImage(item, null);
              break;
            }
            catch { }
          }
        }
      });

      if(!savedImages) quitEvent.WaitOne(15000, false);
    }
  }

  void SetCachedImage(FileItem item, Image image, bool recreateIcon)
  {
    if(image != GetCachedImage(item)) // this moves the image to the front of the linked list
    {
      cacheSize = cacheSize - GetImageSize(imageCache.First.Value.Value) + GetImageSize(image);
      imageCache.First.Value.Value.Dispose();
      imageCache.First.Value = new KeyValuePair<FileItem, Image>(imageCache.First.Value.Key, image);
      OnImageChanged(item, recreateIcon);
      CleanupCache();
    }
  }

  void SetupProgress(string status, int count)
  {
    lblStatus.Text = status;
    progress.Value = 0;
    progress.Maximum = count;
  }

  void ShowHelp()
  {
    string htmlFile = Path.Combine(Program.DataPath, "help.html")
                        .Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(htmlFile);
    psi.UseShellExecute = true;
    System.Diagnostics.Process.Start(psi);
  }

  void UpdatePictureBox()
  {
    if(picture.Image != null) lblStatus.Text = "";
    picture.Image = null;

    if(lstFiles.SelectedItems.Count == 1)
    {
      Image image = GetCachedImage((FileItem)lstFiles.SelectedItems[0]);
      lblStatus.Text = image.Width.ToString(CultureInfo.InvariantCulture) + "x" +
                       image.Height.ToString(CultureInfo.InvariantCulture);
      picture.SizeMode = image.Width <= picture.Width && image.Height <= picture.Height ?
        PictureBoxSizeMode.CenterImage : PictureBoxSizeMode.Zoom;
      picture.Image = image;
    }
  }

  void lstGroups_BeforeLabelEdit(object sender, LabelEditEventArgs e)
  {
    ListViewItem item = lstGroups.Items[e.Item];
    item.Text = (string)item.Tag;
  }

  void lstGroups_AfterLabelEdit(object sender, LabelEditEventArgs e)
  {
    ListViewItem item = lstGroups.Items[e.Item];
    if(e.Label != null)
    {
      string oldText = item.Text;

      item.Tag = e.Label;
      item.Text = GetGroupIndexText(item.Index) + e.Label;
      e.CancelEdit = true; // we've done the rename ourselves, so don't let the system overwrite our change

      if(string.IsNullOrEmpty(e.Label))
      {
        DeleteGroup(item.Index);
      }
      else if(lstFiles.Groups.Count > item.Index+1)
      {
        if(!string.Equals(oldText, (string)e.Label, StringComparison.OrdinalIgnoreCase))
        {
          ListViewGroup group = lstFiles.Groups[item.Index+1];
          group.Name = group.Header = e.Label;
          if(chkAutoRename.Checked) AssignImagesToGroup(item.Index, group.Items, true);
        }
      }
      else
      {
        lstFiles.Groups.Add(e.Label, e.Label);
      }
    }
    else
    {
      item.Text = GetGroupIndexText(item.Index) + item.Text; // edit was canceled
      e.CancelEdit = true;
    }
  }

  void groupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
  {
    renameGroupMenuItem.Enabled = deleteGroupMenuItem.Enabled = lstGroups.SelectedIndices.Count != 0;
  }

  void newGroupMenuItem_Click(object sender, EventArgs e)
  {
    CreateGroup();
  }

  void lstGroups_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    if(lstGroups.GetItemAt(e.X, e.Y) == null) CreateGroup();
  }

  void lstGroups_SizeChanged(object sender, EventArgs e)
  {
    lstGroups.Columns[0].Width = lstGroups.Width - 4;
  }

  void lstGroups_KeyDown(object sender, KeyEventArgs e)
  {
    if(e.KeyCode == Keys.F2 && e.Modifiers == Keys.None && lstGroups.SelectedIndices.Count != 0)
    {
      lstGroups.SelectedItems[0].BeginEdit();
    }
  }

  void MainForm_KeyDown(object sender, KeyEventArgs e)
  {
    if(e.KeyCode == Keys.F1 && e.Modifiers == Keys.None)
    {
      ShowHelp();
    }
    else if(e.KeyCode == Keys.F3 && e.Modifiers == Keys.None)
    {
      CreateGroup();
    }
  }

  void iconView_Click(object sender, EventArgs e)
  {
    lstFiles.View = View.LargeIcon;
    iconView.Checked = true;
    listView.Checked = false;
  }

  void listView_Click(object sender, EventArgs e)
  {
    lstFiles.View = View.List;
    iconView.Checked = false;
    listView.Checked = true;
  }

  void lstFiles_KeyDown(object sender, KeyEventArgs e)
  {
    if(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
    {
      int groupNum = -1;
      if(e.Modifiers == Keys.None) groupNum = e.KeyCode == Keys.D0 ? 9 : e.KeyCode - Keys.D1;
      else if(e.Modifiers == Keys.Control) groupNum = (e.KeyCode == Keys.D0 ? 9 : e.KeyCode - Keys.D1) + 10;
      if(groupNum != -1) AssignImagesToGroup(groupNum);
    }
    else if(e.KeyCode == Keys.F2 && e.Modifiers == Keys.None)
    {
      if(lstFiles.SelectedItems.Count == 1) lstFiles.SelectedItems[0].BeginEdit();
    }
    else if(e.KeyCode == Keys.Delete && (e.Modifiers == Keys.None || e.Modifiers == Keys.Shift))
    {
      DeleteImages(e.Modifiers == Keys.None);
    }
    else if(e.KeyCode == Keys.Left && e.Modifiers == Keys.Alt)
    {
      RotateImages(270);
    }
    else if(e.KeyCode == Keys.Right && e.Modifiers == Keys.Alt)
    {
      RotateImages(90);
    }
    else if(e.KeyCode == Keys.Down && e.Modifiers == Keys.Alt)
    {
      RotateImages(180);
    }
    else if(e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
    {
      foreach(ListViewItem item in lstFiles.Items) item.Selected = true;
    }
  }

  void lstFiles_BeforeLabelEdit(object sender, LabelEditEventArgs e)
  {
    FileItem item = (FileItem)lstFiles.Items[e.Item];
    item.Text = Path.GetFileNameWithoutExtension(item.Path);
  }

  void lstFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
  {
    FileItem item = (FileItem)lstFiles.Items[e.Item];
    if(e.CancelEdit || e.Label == null || string.Equals(item.Text, e.Label, StringComparison.OrdinalIgnoreCase))
    {
      item.Text = item.FileName;
    }
    else
    {
      string itemExtension = Path.GetExtension(item.Path).ToLower(), label = e.Label;
      
      if(string.Equals(Path.GetExtension(e.Label), itemExtension, StringComparison.OrdinalIgnoreCase))
      {
        label = Path.GetFileNameWithoutExtension(label);
      }

      MoveItem(item, GetUniqueFilename(Path.Combine(Path.GetDirectoryName(item.Path), label + itemExtension)));
    }

    e.CancelEdit = true;
  }

  void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
  {
    UpdatePictureBox();
  }

  void btnResize_Click(object sender, EventArgs e)
  {
    int width, height;

    if(string.IsNullOrEmpty(txtWidth.Text.Trim())) width = 0;
    else if(!int.TryParse(txtWidth.Text, out width)) width = -1;

    if(string.IsNullOrEmpty(txtHeight.Text.Trim())) height = 0;
    else if(!int.TryParse(txtHeight.Text, out height)) height = -1;

    if(width < 0 || height < 0)
    {
      MessageBox.Show("Invalid width or height.", "Invalid dimensions", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if(string.IsNullOrEmpty(txtIndex.Text.Trim())) indexNumber = 0;
    else if(!int.TryParse(txtIndex.Text, out indexNumber)) indexNumber = -1;
    
    if(indexNumber < 0)
    {
      MessageBox.Show("Invalid index number.", "Invalid index", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    ResizeAndRenameFiles(width, height, txtNamingScheme.Text.Trim(),
                         chkCreateThumbnails.Enabled && chkCreateThumbnails.Checked);
  }

  void txtDimensions_TextChanged(object sender, EventArgs e)
  {
    int width, height;

    if(string.IsNullOrEmpty(txtWidth.Text.Trim())) width = 0;
    else if(!int.TryParse(txtWidth.Text, out width)) width = -1;

    if(string.IsNullOrEmpty(txtHeight.Text.Trim())) height = 0;
    else if(!int.TryParse(txtHeight.Text, out height)) height = -1;

    chkCreateThumbnails.Enabled = width >= 0 || height >= 0;
  }

  void picture_SizeChanged(object sender, EventArgs e)
  {
    UpdatePictureBox();
  }

  readonly LinkedList<KeyValuePair<FileItem, Image>> imageCache = new LinkedList<KeyValuePair<FileItem,Image>>();
  Thread loadThread, saveThread;
  string outputDir;
  ManualResetEvent quitEvent = new ManualResetEvent(false);
  int cacheSize, indexNumber;
  bool quitting;

  static Regex renameRe = new Regex(@"%[defn%]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
}

} // namespace PictureSorter