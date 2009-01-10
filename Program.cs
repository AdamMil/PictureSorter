using System;
using System.Collections.Generic;
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

  public static string DataPath
  {
    get { return dataPath; }
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