using System;
using System.Windows.Forms;

namespace PictureSorter
{

public partial class NameDialog : Form
{
  public NameDialog()
  {
    InitializeComponent();
  }

  public string Filename
  {
    get { return txtName.Text; }
  }

  void txtName_TextChanged(object sender, EventArgs e)
  {
    btnOK.Enabled = Name.Trim().Length != 0;
  }

  void txtName_KeyPress(object sender, KeyPressEventArgs e)
  {
    if(!e.Handled && Array.IndexOf(invalidChars, e.KeyChar) != -1) e.Handled = true;
  }

  readonly char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
}

} // namespace PictureSorter