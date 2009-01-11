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
using System.IO;
using System.Windows.Forms;

namespace PictureSorter
{

static class Program
{
  static Program()
  {
    dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    #if DEBUG
    dataPath = System.IO.Path.Combine(dataPath, "../..");
    #endif
  }

  public static void ShowHelp()
  {
    // we need to replace / with \, otherwise firefox chokes on it
    string htmlFile = Path.Combine(dataPath, "help.html")
                        .Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(htmlFile);
    psi.UseShellExecute = true;
    System.Diagnostics.Process.Start(psi);
  }

  [STAThread]
  static void Main()
  {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new MainForm());
  }

  static readonly string dataPath;
}

} // namespace PictureSorter