using System;
using System.IO;
using System.Windows.Forms;

namespace PictureSorter
{

public partial class SettingsForm : Form
{
  public SettingsForm()
  {
    InitializeComponent();
  }

  public bool CopyAllImages
  {
    get { return chkCopyAll.Checked; }
  }

  public string[] Pictures
  {
    get { return pics; } 
  }

  public string OutputDirectory
  {
    get { return txtOutputDir.Text; }
  }

  void btnBrowsePics_Click(object sender, EventArgs e)
  {
    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files (*.*)|*.*";
    ofd.Multiselect = true;
    ofd.SupportMultiDottedExtensions = true;
    ofd.Title = "Select images to edit...";

    if(ofd.ShowDialog() == DialogResult.OK)
    {
      pics = ofd.FileNames;
      txtPics.Text = string.Join("; ", pics);
      if(pics.Length != 0 && string.IsNullOrEmpty(txtOutputDir.Text))
      {
        txtOutputDir.Text = Path.GetDirectoryName(pics[0]);
        btnOK.Focus();
      }
    }
  }

  void btnBrowseOutput_Click(object sender, EventArgs e)
  {
    FolderBrowserDialog fbd = new FolderBrowserDialog();
    fbd.Description = "Select where the new images will be saved...";
    if(pics != null && pics.Length != 0) fbd.SelectedPath = Path.GetDirectoryName(pics[0]);
    if(fbd.ShowDialog() == DialogResult.OK)
    {
      txtOutputDir.Text = fbd.SelectedPath;
      btnOK.Focus();
    }
  }

  void btnOK_Click(object sender, EventArgs e)
  {
    if(pics == null || pics.Length == 0)
    {
      MessageBox.Show("No images were selected.", "No images selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else if(string.IsNullOrEmpty(txtOutputDir.Text))
    {
      MessageBox.Show("No output directory was selected.", "No output directory",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else if(!Directory.Exists(txtOutputDir.Text))
    {
      MessageBox.Show("The output directory '" + txtOutputDir.Text +"' does not exist.", "Invalid output directory",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else DialogResult = DialogResult.OK;
  }

  void SettingsForm_KeyDown(object sender, KeyEventArgs e)
  {
    if(e.KeyCode == Keys.F1 && e.Modifiers == Keys.None) Program.ShowHelp();
  }

  string[] pics;
}

} // namespace PictureSorter