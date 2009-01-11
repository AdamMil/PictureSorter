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
    btnOK.Enabled = Filename.Trim().Length != 0;
  }

  void txtName_KeyPress(object sender, KeyPressEventArgs e)
  {
    if(!e.Handled && e.KeyChar >= ' ' && Array.IndexOf(invalidChars, e.KeyChar) != -1) e.Handled = true;
  }

  readonly char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
}

} // namespace PictureSorter