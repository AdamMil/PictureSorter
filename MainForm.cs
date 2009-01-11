/*
PictureSorter is a program that assists in the orientation, resizing, and
renaming of images.

Copyright (C) 2009 Adam Milazzo
http://www.adammil.net/

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/

using System;
using System.Collections;
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
    Icon = Properties.Resources.CameraIcon;
    iconTool.Image = Icon.ToBitmap();

    vsplit.Panel1MinSize = 380;
    vsplit.Panel2MinSize = 200;
    vsplit.SplitterDistance = vsplit.Width - 200;
    hsplit.SplitterDistance = 240;
  }

  protected override void OnClosed(EventArgs e)
  {
    base.OnClosed(e);
    CloseImages();
  }

  protected override void OnShown(EventArgs e)
  {
    base.OnShown(e);

    if(OpenImages()) Enabled = true;
    else Close();
  }

  const int DefaultGroup = -1, IgnoreGroup = -2;

  class FileItem : ListViewItem
  {
    public FileItem(string path)
    {
      originalPath = path;
      Text = FileName;
      group = DefaultGroup;
    }

    public bool BadImage
    {
      get { return badImage; }
      set { badImage = value; }
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
    bool badImage, imageChanged, hasIcon, thumbnailChanged;
  }

  static bool AreSameFile(string file1, string file2)
  {
    return string.Equals(NormalizePath(file1), NormalizePath(file2), StringComparison.Ordinal);
  }

  void AssignImagesToGroup(int index)
  {
    AssignImagesToGroup(index, lstFiles.SelectedItems, false);
  }

  void AssignImagesToGroup(int index, IEnumerable items, bool forceReassign)
  {
    string groupName = null;
    if(index != DefaultGroup)
    {
      groupName = GetGroupFilename(index);
      if(chkLowerCase.Checked) groupName = groupName.ToLower();
    }
    RenameAndRegroupImages(items, groupName, index, forceReassign);
  }

  void BeginLoadingIcons()
  {
    iconThread = new Thread(LoadIconsInBackground);
    iconThread.IsBackground = true;
    iconThread.Priority = ThreadPriority.BelowNormal;
    iconThread.Start();
  }

  void BeginSavingImages()
  {
    saveThread = new Thread(SaveImagesInBackground);
    saveThread.Priority = ThreadPriority.BelowNormal;
    saveThread.Start();
  }

  void CleanupCache()
  {
    while(cacheSize > maxCacheSize && imageCache.Count > 1) // leave at least one item (the one we're operating upon)
    {
      LinkedListNode<KeyValuePair<FileItem, Image>> node = imageCache.Last;
      SaveItem(node.Value.Key, node.Value.Value);
      DisposeCacheNode(node);
    }
  }

  void CloseImages()
  {
    StopLoadingIcons();
    StopSavingImagesInBackground();
    SaveChangedImages();

    imageCache.Clear();
    cacheSize = 0;

    lstFiles.Items.Clear();
    while(lstFiles.Groups.Count > 1) lstFiles.Groups.RemoveAt(1);
    lstFiles.LargeImageList = null;
    lstGroups.Items.Clear();

    UpdatePictureBox();

    quitting = false;
    quitEvent.Reset();
  }

  void ConvertImages(ImageFormat format, string extension)
  {
    if(chkConfirmConvert.Checked &&
       MessageBox.Show("Convert these images to ." + extension + "?", "Convert images?", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
    {
      return;
    }

    ICollection items = lstFiles.SelectedItems.Count == 0 ? (ICollection)lstFiles.Items : lstFiles.SelectedItems;

    SetupProgress("Converting...", items.Count);

    foreach(FileItem item in items)
    {
      ImageFormat itemFormat;
      if(item.ImageFormat != null)
      {
        itemFormat = item.ImageFormat;
      }
      else
      {
        Image image = GetCachedImage(item);
        if(image == null) continue;
        else itemFormat = image.RawFormat;
      }

      if(!itemFormat.Equals(format))
      {
        EnsureOutputFile(item);
        string filename = Path.Combine(Path.GetDirectoryName(item.Path),
                                       Path.GetFileNameWithoutExtension(item.Path) + "." + extension);
        MoveItem(item, filename, true);
        item.ImageFormat = format;
        OnImageChanged(item, false);
      }
      IncrementProgress();
    }

    ResetProgress();
  }

  void CreateGroup()
  {
    ListViewItem item = lstGroups.Items.Add("NEW GROUP");
    item.Tag = item.Text;
    item.BeginEdit();
  }

  Image CreateIcon(Image image)
  {
    return ResizeImage(image, 64, 64, true);
  }

  string CreateFilenameByScheme(string path, string namingScheme)
  {
    if(string.IsNullOrEmpty(namingScheme)) return path;

    string filename = Path.GetFileNameWithoutExtension(path), extension = Path.GetExtension(path);

    return Path.Combine(outputDir,
      renameRe.Replace(namingScheme, delegate(Match m)
      {
        switch(char.ToLowerInvariant(m.Value[1]))
        {
          case '%': return "%";
          case 'e': return extension;
          case 'f': return filename;
          case 'n': return indexNumber++.ToString(CultureInfo.InvariantCulture);
          default: return string.Empty;
        }
      }));
  }

  void DeleteGroup(int index)
  {
    if(lstFiles.Groups.Count > index) lstFiles.Groups.RemoveAt(index+1);
    lstGroups.Items.RemoveAt(index);

    // now renumber the groups after it
    for(int i=index; i<lstGroups.Items.Count; i++)
    {
      lstGroups.Items[i].Text = GetGroupIndexText(i) + (string)lstGroups.Items[i].Tag;
    }
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

        item.Remove();
        File.Delete(item.Path);
        if(item.HasThumbnail) File.Delete(item.ThumbnailPath);
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
      MoveItem(item, newPath, true);
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
    if(image != null)
    {
      imageCache.AddFirst(new KeyValuePair<FileItem, Image>(item, image));
      cacheSize += GetImageSize(image);
      CleanupCache();
    }
    return image;
  }

  string GetGroupFilename(int index)
  {
    string filename = GetSafeFilename((string)lstGroups.Items[index].Tag);
    if(filename.Length == 0) filename = "Group" + (index+1).ToString(CultureInfo.InvariantCulture) + "_";
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
      return "C" + (index == 19 ? "0" : (index-10+1).ToString(CultureInfo.InvariantCulture)) + ". ";
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

  static string GetSafeFilename(string filename)
  {
    foreach(char c in Path.GetInvalidFileNameChars()) filename = filename.Replace(c.ToString(), "");
    return filename;
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

  Image LoadImage(FileItem item)
  {
    if(item.BadImage) return null;

    using(FileStream stream = File.OpenRead(item.Path)) // FIXME: the docs say the stream needs to be kept open
    {                                                   // (but it seems to work as-is?)
      Image image;
      try { image = Image.FromStream(stream); }
      catch(ArgumentException)
      {
        item.BadImage = true;
        Invoke((ThreadStart)delegate
        {
          MessageBox.Show("The file '" + item.FileName + "' is not a valid image file.", "Not an image",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        });
        return null;
      }

      if(item.ImageFormat == null) item.ImageFormat = image.RawFormat;
      return image;
    }
  }

  void LoadIconsInBackground()
  {
    bool allIconsLoaded;
    do
    {
      allIconsLoaded = true;
      for(int i=0; i<lstFiles.Items.Count && !quitting; i++)
      {
        FileItem item = null;
        lstFiles.Invoke((ThreadStart)delegate { item = (FileItem)lstFiles.Items[i]; });

        if(!item.HasIcon && !quitting)
        {
          item.HasIcon = true;

          Image image, icon;
          try
          {
            image = LoadImage(item);
            if(image == null)
            {
              lstFiles.Invoke((ThreadStart)delegate
              {
                item.ImageIndex = 0;
                lstFiles.Invalidate(lstFiles.GetItemRect(item.Index));
              });
            }
            else
            {
              using(image) icon = CreateIcon(image);

              lstFiles.Invoke((ThreadStart)delegate
              {
                lstFiles.LargeImageList.Images.Add(icon);
                item.ImageIndex = lstFiles.LargeImageList.Images.Count-1;
                lstFiles.Invalidate(lstFiles.GetItemRect(item.Index));
              });
            }
          }
          catch { }

          allIconsLoaded = false;
        }
      }
    } while(!allIconsLoaded && !quitting);
  }

  void MoveItem(FileItem item, string newPath, bool makeUnique)
  {
    MoveItem(item, newPath, makeUnique, false);
  }

  void MoveItem(FileItem item, string newPath, bool makeUnique, bool forceMove)
  {
    bool sameFile = AreSameFile(item.Path, newPath);
    if(forceMove || !sameFile)
    {
      if(makeUnique && !sameFile) newPath = GetUniqueFilename(newPath);

      if(!item.HasOutputFile && !sameFile) File.Copy(item.OriginalPath, newPath);
      else if(!sameFile || !string.Equals(item.Path, newPath, StringComparison.Ordinal)) File.Move(item.Path, newPath);
      item.Path = newPath;
      item.Text = item.FileName;

      if(item.HasThumbnail)
      {
        string newThumbnailPath = CreateFilenameByScheme(item.Path, item.ThumbnailScheme);
        sameFile = AreSameFile(item.ThumbnailPath, newThumbnailPath);
        if(!sameFile || forceMove && !string.Equals(item.ThumbnailPath, newThumbnailPath, StringComparison.Ordinal))
        {
          Directory.CreateDirectory(Path.GetDirectoryName(newThumbnailPath));
          if(!sameFile) newThumbnailPath = GetUniqueFilename(newThumbnailPath);
          if(File.Exists(item.ThumbnailPath)) File.Move(item.ThumbnailPath, newThumbnailPath);
          item.ThumbnailPath = newThumbnailPath;
        }
      }
    }
  }

  static string NormalizePath(string path)
  {
    return new FileInfo(path).FullName.ToLower();
  }

  void OnImageChanged(FileItem item, bool imageContentsChanged)
  {
    System.Diagnostics.Debug.Assert(!item.BadImage);

    if(imageContentsChanged) // if the image contents changed significantly...
    {
      lstFiles.LargeImageList.Images[item.ImageIndex] = CreateIcon(GetCachedImage(item));
      lstFiles.Invalidate(lstFiles.GetItemRect(item.Index));
      if(item.Selected && lstFiles.SelectedItems.Count == 1) UpdatePictureBox();
    }

    item.ImageChanged = item.ThumbnailChanged = true;

    if(!chkSaveInBackground.Checked) SaveItem(item);
  }

  void OnThumbnailChanged(FileItem item)
  {
    System.Diagnostics.Debug.Assert(!item.BadImage);
    item.ThumbnailChanged = true;
    if(!chkSaveInBackground.Checked) SaveItem(item);
  }

  bool OpenImages()
  {
    SettingsForm form = new SettingsForm();
    if(form.ShowDialog() != DialogResult.OK) return false;

    CloseImages();

    outputDir = form.OutputDirectory;

    lstFiles.LargeImageList = new ImageList();
    lstFiles.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
    lstFiles.LargeImageList.TransparentColor = Color.Magenta;
    lstFiles.LargeImageList.ImageSize = new Size(64, 64);
    lstFiles.LargeImageList.Images.Add(Properties.Resources.ErrorImage);

    foreach(string path in form.Pictures) lstFiles.Items.Add(new FileItem(path));

    BeginLoadingIcons();
    BeginSavingImages();
    Enabled = true;

    if(form.CopyAllImages)
    {
      SetupProgress("Copying images...", lstFiles.Items.Count);
      foreach(FileItem item in lstFiles.Items)
      {
        EnsureOutputFile(item);
        IncrementProgress();
      }
      ResetProgress();
    }
    else
    {
      // for image files that we're editing directly (ie, that are already in the output directory), set their Path
      // property so that they will be edited directly rather than copied and renamed
      foreach(FileItem item in lstFiles.Items)
      {
        if(AreSameFile(item.OriginalPath, Path.Combine(outputDir, item.FileName))) item.Path = item.OriginalPath;
      }
    }

    return true;
  }

  void RenameImages()
  {
    if(lstFiles.SelectedItems.Count == 1)
    {
      lstFiles.SelectedItems[0].BeginEdit();
    }
    else if(lstFiles.SelectedItems.Count > 1)
    {
      NameDialog form = new NameDialog();
      if(form.ShowDialog() == DialogResult.OK)
      {
        RenameAndRegroupImages(lstFiles.SelectedItems, form.Filename, IgnoreGroup, false);
      }
    }
  }

  void RenameAndRegroupImages(IEnumerable items, string baseName, int groupIndex, bool forceReassign)
  {
    string sep = baseName == null || baseName.IndexOf(' ') == -1 ? null : " ";
    bool useBaseName = baseName != null && (groupIndex == IgnoreGroup || chkAutoRename.Checked);

    foreach(FileItem item in items)
    {
      if(groupIndex == IgnoreGroup || item.GroupIndex != groupIndex || forceReassign)
      {
        string dir = outputDir;

        if(groupIndex >= 0 && chkCreateGroupDirs.Checked)
        {
          dir = Path.Combine(dir, baseName);
          Directory.CreateDirectory(dir);
        }

        string newPath = useBaseName ? Path.Combine(dir, baseName + Path.GetExtension(item.FileName))
                                     : Path.Combine(dir, item.FileName);
        if(!AreSameFile(newPath, item.Path))
        {
          newPath = useBaseName ? GetUniqueFilename(newPath, sep, true) : GetUniqueFilename(newPath);
        }

        MoveItem(item, newPath, false, true);

        if(groupIndex != IgnoreGroup)
        {
          item.GroupIndex = groupIndex;
          item.Group = groupIndex == DefaultGroup ? null : lstFiles.Groups[groupIndex+1];
        }
      }
    }
  }

  void ResetProgress()
  {
    lblStatus.Text = "";
    progress.Value = 0;
  }

  Image ResizeImage(Image image, int width, int height, bool isIcon)
  {
    double idealAspect = height == 0 ? 0 : (double)width / height;

    Bitmap newImage = null;
    double aspectRatio = (double)image.Width / image.Height;
    int newWidth, newHeight;

    if(!isIcon)
    {
      // if the image aspect ratio is very nearly equal to the inverse of the desired aspect ratio, assume that the
      // image has been rotated. in that case, swap the ideal dimensions
      if(width != 0 && height != 0 && chkDetectRotated.Checked && Math.Abs(idealAspect - 1/aspectRatio) < 0.0001)
      {
        int temp = width;
        width  = height;
        height = temp;
        idealAspect = (double)width / height;
      }

      // skip images that are already smaller than the desired size
      if(chkSkipSmaller.Checked && (width == 0 || image.Width <= width) && (height == 0 || image.Height <= height))
      {
        return image;
      }
    }

    // if the image is already the correct size, just return it
    if(width == image.Width && height == image.Height) return image;

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

    newImage = isIcon ? new Bitmap(width, height, PixelFormat.Format24bppRgb)
                      : new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

    if(image.PixelFormat == PixelFormat.Format1bppIndexed || image.PixelFormat == PixelFormat.Format4bppIndexed ||
       image.PixelFormat == PixelFormat.Format8bppIndexed)
    {
      newImage.Palette = image.Palette; // copy the palette, if there is one
    }

    using(Graphics g = Graphics.FromImage(newImage))
    {
      g.CompositingMode = CompositingMode.SourceCopy;

      if(isIcon)
      {
        g.CompositingQuality = CompositingQuality.HighSpeed;
        g.InterpolationMode  = chkLowQuality.Checked ?
          InterpolationMode.Bilinear : InterpolationMode.HighQualityBilinear;
        g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
      }
      else
      {
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.InterpolationMode  = InterpolationMode.HighQualityBicubic;
      }

      g.DrawImage(image, new Rectangle((newImage.Width-newWidth)/2, (newImage.Height-newHeight)/2,
                                       newWidth, newHeight));
    }

    return newImage;
  }

  void ResizeAndRenameFiles(int width, int height, string namingScheme, bool createThumbnails)
  {
    ICollection items = lstFiles.SelectedItems.Count == 0 ? (ICollection)lstFiles.Items : lstFiles.SelectedItems;

    SetupProgress(width > 0 || height > 0 ? createThumbnails ? "Thumbnailing..." : "Resizing..." : "Renaming...",
                  items.Count);

    foreach(FileItem item in items)
    {
      EnsureOutputFile(item);
      string newPath = CreateFilenameByScheme(item.Path, namingScheme);
      Directory.CreateDirectory(Path.GetDirectoryName(newPath));

      if(width >= 0 || height >= 0)
      {
        if(createThumbnails)
        {
          if(!chkOverwriteThumbnails.Checked &&
             (!item.HasThumbnail || !AreSameFile(item.ThumbnailPath, newPath)))
          {
            newPath = GetUniqueFilename(newPath);
          }
          item.ThumbnailScheme = namingScheme;
          item.ThumbnailPath   = newPath;
          item.ThumbnailSize   = new Size(width, height);
          OnThumbnailChanged(item);
        }
        else
        {
          MoveItem(item, newPath, true);
          Image image = GetCachedImage(item);
          if(image != null) SetCachedImage(item, ResizeImage(image, width, height, false), false);
        }
      }
      else
      {
        MoveItem(item, newPath, true);
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
        Image image = GetCachedImage(item);
        if(image != null)
        {
          switch(degrees)
          {
            case 90: image.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
            case 180: image.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
            case 270: image.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
          }
          OnImageChanged(item, true);
        }
      }
      catch { }

      IncrementProgress();
    }

    ResetProgress();
  }

  void SaveChangedImages()
  {
    Dictionary<string, KeyValuePair<FileItem, Image>> itemsToSave =
      new Dictionary<string, KeyValuePair<FileItem, Image>>(StringComparer.Ordinal);

    for(LinkedListNode<KeyValuePair<FileItem, Image>> node = imageCache.First; node != null; node = node.Next)
    {
      if(node.Value.Key.Changed) itemsToSave.Add(node.Value.Key.Path, node.Value);
    }

    foreach(FileItem item in lstFiles.Items)
    {
      if(item.ThumbnailChanged && !itemsToSave.ContainsKey(item.Path))
      {
        itemsToSave.Add(item.Path, new KeyValuePair<FileItem, Image>(item, null));
      }
    }

    SetupProgress("Saving...", itemsToSave.Count);
    foreach(KeyValuePair<FileItem,Image> pair in itemsToSave.Values)
    {
      SaveItem(pair.Key, pair.Value);
      IncrementProgress();
    }
    ResetProgress();
  }

  void SaveItem(FileItem item)
  {
    SaveItem(item, null);
  }

  void SaveItem(FileItem item, Image image)
  {
    if(!item.Changed) return;

    if(image == null) image = GetCachedImage(item);
    ImageFormat format = item.ImageFormat != null ? item.ImageFormat : image.RawFormat;

    if(item.ImageChanged)
    {
      SaveImage(image, item.Path, format);
      item.ImageChanged = false;
    }

    if(item.HasThumbnail && item.ThumbnailChanged)
    {
      Image thumbnail = ResizeImage(image, item.ThumbnailSize.Width, item.ThumbnailSize.Height, false);
      SaveImage(thumbnail, item.ThumbnailPath, format); 
      item.ThumbnailChanged = false;
    }
  }

  void SaveImage(Image image, string path, ImageFormat format)
  {
    if(!format.Equals(image.RawFormat)) SaveImageWithInMemoryBuffer(image, path, format);
    else image.Save(path, format);
  }

  void SaveImageWithInMemoryBuffer(Image image, string path, ImageFormat format)
  {
    PixelFormat pixelFormat;
    switch(image.PixelFormat)
    {
      case PixelFormat.Format1bppIndexed:
      case PixelFormat.Format4bppIndexed:
      case PixelFormat.Format8bppIndexed:
        pixelFormat = image.PixelFormat;
        break;
      default:
        pixelFormat = PixelFormat.Format24bppRgb;
        break;
    }

    Bitmap tempImage = new Bitmap(image.Width, image.Height, pixelFormat);
    if(pixelFormat != PixelFormat.Format24bppRgb) tempImage.Palette = image.Palette;

    using(Graphics g = Graphics.FromImage(tempImage))
    {
      g.CompositingMode    = CompositingMode.SourceCopy;
      g.CompositingQuality = CompositingQuality.HighQuality;
      g.DrawImageUnscaled(image, 0, 0);
    }

    tempImage.Save(path, format);
  }

  void SaveImagesInBackground()
  {
    while(!quitting)
    {
      bool savedImages = false;

      if(chkSaveInBackground.Checked)
      {
        lstFiles.Invoke((ThreadStart)delegate
        {
          for(LinkedListNode<KeyValuePair<FileItem, Image>> node = imageCache.First;
              node != null && !quitting; node = node.Next)
          {
            if(node.Value.Key.Changed)
            {
              try
              {
                SaveItem(node.Value.Key, node.Value.Value);
                savedImages = true;
                break;
              }
              catch { }
            }
          }
        });

        lstFiles.Invoke((ThreadStart)delegate
        {
          foreach(FileItem item in lstFiles.Items)
          {
            if(quitting) break;

            if(!item.ImageChanged && item.ThumbnailChanged)
            {
              try 
              {
                SaveItem(item);
                savedImages = true;
                break;
              }
              catch { }
            }
          }
        });
      }

      quitEvent.WaitOne(savedImages ? 50 : 15000, false);
    }
  }

  void SelectGroup(int index, bool addToSelection)
  {
    if(!addToSelection) lstFiles.SelectedIndices.Clear();

    if(index != DefaultGroup)
    {
      foreach(ListViewItem item in lstFiles.Groups[index+1].Items) item.Selected = true;
    }
    else
    {
      foreach(ListViewItem item in lstFiles.Items)
      {
        if(!item.Selected && item.Group == null) item.Selected = true;
      }
    }
  }

  void SetCachedImage(FileItem item, Image image, bool imageContentsChanged)
  {
    if(image != GetCachedImage(item)) // this moves the image to the front of the linked list
    {
      cacheSize = cacheSize - GetImageSize(imageCache.First.Value.Value) + GetImageSize(image);
      imageCache.First.Value.Value.Dispose();
      imageCache.First.Value = new KeyValuePair<FileItem, Image>(imageCache.First.Value.Key, image);
      OnImageChanged(item, imageContentsChanged);
      CleanupCache();
    }
  }

  void SetupProgress(string status, int count)
  {
    lblStatus.Text = status;
    progress.Value = 0;
    progress.Maximum = count;
  }

  void StopLoadingIcons()
  {
    StopThread(iconThread);
  }

  void StopSavingImagesInBackground()
  {
    StopThread(saveThread);
  }

  void StopThread(Thread thread)
  {
    quitting = true;
    quitEvent.Set();
    if(thread != null && !thread.Join(1000)) thread.Abort();
  }

  void UpdatePictureBox()
  {
    if(picture.Image != null) lblStatus.Text = "";
    picture.Image = null;

    if(lstFiles.SelectedItems.Count == 1)
    {
      Image image = GetCachedImage((FileItem)lstFiles.SelectedItems[0]);
      if(image == null) return;

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
    string oldText = (string)item.Tag, newText = e.Label != null ? e.Label : oldText;

    e.CancelEdit = true; // we'll do the rename ourselves, so don't let the system overwrite our change

    if(e.Label != null && e.Label.Length == 0) // if the name is erased, treat it as a deletion
    {
      DeleteGroup(item.Index);
    }
    else
    {
      // make sure there are no other groups with the same name
      for(int i=0; i<lstGroups.Items.Count; i++)
      {
        if(i != item.Index && string.Equals((string)lstGroups.Items[i].Tag, newText, StringComparison.Ordinal))
        {
          if(e.Label != null)
          {
            MessageBox.Show("A group named '" + newText + "' already exists.", "Duplicate group",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

          // if this was a new group, delete it
          if(string.Equals(oldText, "NEW GROUP", StringComparison.Ordinal)) lstGroups.Items.RemoveAt(e.Item);
          else item.Text = GetGroupIndexText(item.Index) + oldText; // otherwise just revert the text

          return;
        }
      }

      item.Tag  = newText;
      item.Text = GetGroupIndexText(item.Index) + newText;

      if(lstFiles.Groups.Count <= item.Index+1) // the group doesn't exist in the image list yet, so add it
      {
        lstFiles.Groups.Add(newText, newText);
      }
      else if(!string.Equals(oldText, newText, StringComparison.Ordinal)) // if the name actually changed
      {
        ListViewGroup group = lstFiles.Groups[item.Index+1];
        group.Name = group.Header = e.Label;
        if(chkAutoRename.Checked) AssignImagesToGroup(item.Index, group.Items, true);
      }
    }
  }

  void groupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
  {
    renameGroupMenuItem.Enabled = deleteGroupMenuItem.Enabled = selectGroupMenuItem.Enabled =
      assignSelectedImagesMenuItem.Enabled = lstGroups.SelectedIndices.Count != 0;

    if(assignSelectedImagesMenuItem.Enabled && lstFiles.SelectedItems.Count == 0)
    {
      assignSelectedImagesMenuItem.Enabled = false;
    }
  }

  void newGroupMenuItem_Click(object sender, EventArgs e)
  {
    CreateGroup();
  }

  void renameGroupMenuItem_Click(object sender, EventArgs e)
  {
    if(lstGroups.SelectedItems.Count != 0) lstGroups.SelectedItems[0].BeginEdit();
  }

  void deleteGroupMenuItem_Click(object sender, EventArgs e)
  {
    if(lstGroups.SelectedIndices.Count != 0) DeleteGroup(lstGroups.SelectedIndices[0]);
  }

  void selectGroupMenuItem_Click(object sender, EventArgs e)
  {
    if(lstGroups.SelectedIndices.Count != 0)
    {
      SelectGroup(lstGroups.SelectedIndices[0], (Control.ModifierKeys & Keys.Shift) != 0);
    }
  }

  void assignSelectedImagesMenuItem_Click(object sender, EventArgs e)
  {
    if(lstGroups.SelectedIndices.Count != 0) AssignImagesToGroup(lstGroups.SelectedIndices[0]);
  }

  void lstGroups_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    if(lstGroups.GetItemAt(e.X, e.Y) == null) CreateGroup();
  }

  void vsplit_Panel2_Layout(object sender, LayoutEventArgs e)
  {
    lstGroups.Columns[0].Width = vsplit.Panel2.Width - lstGroups.Left*2 - 6;
  }

  void lstGroups_KeyDown(object sender, KeyEventArgs e)
  {
    if(e.KeyCode == Keys.F2 && e.Modifiers == Keys.None)
    {
      if(lstGroups.SelectedItems.Count != 0) lstGroups.SelectedItems[0].BeginEdit();
    }
    else if(e.KeyCode == Keys.Delete && e.Modifiers == Keys.None)
    {
      if(lstGroups.SelectedIndices.Count != 0) DeleteGroup(lstGroups.SelectedIndices[0]);
    }
  }

  void MainForm_KeyDown(object sender, KeyEventArgs e)
  {
    if(e.Modifiers == Keys.None)
    {
      if(e.KeyCode == Keys.F1) Program.ShowHelp();
      else if(e.KeyCode == Keys.F3) CreateGroup();
      else if(e.KeyCode == Keys.Escape) lstFiles.Focus();
    }
    else if(e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
    {
      OpenImages();
    }
  }

  void iconTool_Click(object sender, EventArgs e)
  {
    if(lstFiles.View == View.LargeIcon)
    {
      lstFiles.View = View.List;
      iconTool.Text = "Show Icons";
    }
    else
    {
      lstFiles.View = View.LargeIcon;
      iconTool.Text = "Hide Icons";
    }
  }

  void openImagesTool_Click(object sender, EventArgs e)
  {
    OpenImages();
  }

  void lstFiles_KeyDown(object sender, KeyEventArgs e)
  {
    if(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
    {
      int groupNum = e.KeyCode == Keys.D0 ? 9 : e.KeyCode - Keys.D1;
      if((e.Modifiers & Keys.Control) != 0) groupNum += 10;

      if(e.Modifiers == Keys.Alt || e.Modifiers == (Keys.Alt|Keys.Shift))
      {
        SelectGroup(groupNum, e.Modifiers == (Keys.Alt|Keys.Shift));
      }
      
      if(e.Modifiers == Keys.None || e.Modifiers == Keys.Control) AssignImagesToGroup(groupNum);
    }
    else if(e.KeyCode == Keys.OemMinus)
    {
      if(e.Modifiers == Keys.None)
      {
        AssignImagesToGroup(DefaultGroup);
      }
      else if(e.Modifiers == Keys.Alt || e.Modifiers == (Keys.Alt|Keys.Shift))
      {
        SelectGroup(DefaultGroup, e.Modifiers == (Keys.Alt|Keys.Shift));
      }
    }
    else if(e.KeyCode == Keys.F2 && e.Modifiers == Keys.None)
    {
      RenameImages();
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
    if(e.CancelEdit || e.Label == null || string.Equals(item.Text, e.Label, StringComparison.Ordinal))
    {
      item.Text = item.FileName;
    }
    else
    {
      string itemExtension = Path.GetExtension(item.Path).ToLower(), label = GetSafeFilename(e.Label);
      
      if(string.Equals(Path.GetExtension(e.Label), itemExtension, StringComparison.OrdinalIgnoreCase))
      {
        label = Path.GetFileNameWithoutExtension(label);
      }

      if(label.Length == 0) label = "Image";
      MoveItem(item, Path.Combine(Path.GetDirectoryName(item.Path), label + itemExtension), true, true);
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

    ResizeAndRenameFiles(width, height, txtNamingScheme.Text.Trim(), chkCreateThumbnails.Checked);
  }

  void txtDimensions_TextChanged(object sender, EventArgs e)
  {
    int width, height;

    if(string.IsNullOrEmpty(txtWidth.Text.Trim())) width = 0;
    else if(!int.TryParse(txtWidth.Text, out width)) width = -1;

    if(string.IsNullOrEmpty(txtHeight.Text.Trim())) height = 0;
    else if(!int.TryParse(txtHeight.Text, out height)) height = -1;

    chkCreateThumbnails.Enabled = width > 0 || height > 0;
    chkDetectRotated.Enabled = width > 0 && height > 0;

    if(!chkCreateThumbnails.Enabled) chkCreateThumbnails.Checked = false;
    if(!chkDetectRotated.Enabled) chkDetectRotated.Checked = false;
  }

  void picture_SizeChanged(object sender, EventArgs e)
  {
    UpdatePictureBox();
  }

  void btnJPEG_Click(object sender, EventArgs e)
  {
    ConvertImages(ImageFormat.Jpeg, "jpg");
  }

  void btnPNG_Click(object sender, EventArgs e)
  {
    ConvertImages(ImageFormat.Png, "png");
  }

  void chkCreateThumbnails_CheckedChanged(object sender, EventArgs e)
  {
    if(!chkCreateThumbnails.Enabled) return; // ignore changes that occur while the checkbox is disabled

    if(chkCreateThumbnails.Checked)
    {
      if(string.Equals(txtNamingScheme.Text, @"%f%e", StringComparison.Ordinal))
      {
        if(string.Equals(txtWidth.Text, "1024", StringComparison.Ordinal) &&
           string.Equals(txtHeight.Text, "768", StringComparison.Ordinal))
        {
          txtWidth.Text  = "";
          txtHeight.Text = "160";
        }

        txtNamingScheme.Text = @"%f_t%e";
      }
    }
    else if(string.Equals(txtNamingScheme.Text, @"%f_t%e", StringComparison.Ordinal))
    {
      if(string.Equals(txtWidth.Text, "", StringComparison.Ordinal) &&
         string.Equals(txtHeight.Text, "160", StringComparison.Ordinal))
      {
        txtWidth.Text  = "1024";
        txtHeight.Text = "768";
        chkDetectRotated.Checked = chkDetectRotated.Enabled;
      }

      txtNamingScheme.Text = @"%f%e";
    }

    chkOverwriteThumbnails.Enabled = chkCreateThumbnails.Checked;
  }

  void txtCacheSize_Leave(object sender, EventArgs e)
  {
    int size;
    if(!int.TryParse(txtCacheSize.Text, out size) || size < 0 || size > 1024)
    {
      MessageBox.Show("'" + txtCacheSize.Text + "' is not a valid cache size. Please enter a number from 0 to 1024",
                      "Invalid cache size", MessageBoxButtons.OK, MessageBoxIcon.Error);
      txtCacheSize.Focus();
      return;
    }

    size *= 1024*1024;

    bool cleanupCache = size < maxCacheSize;
    maxCacheSize = size;
    if(cleanupCache) CleanupCache();
  }

  void sizeDropPic_Click(object sender, EventArgs e)
  {
    sizeMenu.Show((Control)sender, 0, 0);
  }

  void sizeMenuItem_Click(object sender, EventArgs e)
  {
    ToolStripMenuItem item = (ToolStripMenuItem)sender;
    string text = item.Text;
    int xPos = text.IndexOf('x');
    txtWidth.Text  = text.Substring(0, xPos);
    txtHeight.Text = text.Substring(xPos+1);
  }

  readonly LinkedList<KeyValuePair<FileItem, Image>> imageCache = new LinkedList<KeyValuePair<FileItem,Image>>();
  Thread iconThread, saveThread;
  string outputDir;
  ManualResetEvent quitEvent = new ManualResetEvent(false);
  int maxCacheSize=100*1024*1024, cacheSize, indexNumber;
  bool quitting;

  static Regex renameRe = new Regex(@"%[defn%]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
}

} // namespace PictureSorter