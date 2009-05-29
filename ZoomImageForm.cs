using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PictureSorter
{

partial class ZoomImageForm : Form
{
  public ZoomImageForm()
  {
    InitializeComponent();
  }

  public ZoomImageForm(MainForm mainForm, IList<MainForm.FileItem> items) : this()
  {
    if(mainForm == null || items == null) throw new ArgumentNullException();
    if(items.Count == 0) throw new ArgumentException();
    this.mainForm = mainForm;
    this.items    = items;
    SelectImage(0);
  }

  protected override void OnResize(EventArgs e)
  {
    base.OnResize(e);
    SetSizeMode();
  }

  void SetSizeMode()
  {
    if(pictureBox.Image != null)
    {
      if(pictureBox.Image.Width <= pictureBox.Width && pictureBox.Image.Height <= pictureBox.Height)
      {
        pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
      }
      else
      {
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
      }
    }
  }

  void SelectImage(int index)
  {
    MainForm.FileItem item = items[index];
    Text = item.Text;
    pictureBox.Image = mainForm.GetCachedImage(item);
    SetSizeMode();
    selectedItem = index;
  }

  void ZoomImageForm_KeyDown(object sender, KeyEventArgs e)
  {
    if(e.Modifiers == Keys.None)
    {
      if(e.KeyCode == Keys.Left)
      {
        if(selectedItem > 0) SelectImage(selectedItem-1);
      }
      else if(e.KeyCode == Keys.Right)
      {
        if(selectedItem < items.Count-1) SelectImage(selectedItem+1);
      }
      else if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape || e.KeyCode == Keys.Space)
      {
        Close();
      }
    }
  }

  readonly MainForm mainForm;
  readonly IList<MainForm.FileItem> items;
  int selectedItem;
}

} // namespace PictureSorter
