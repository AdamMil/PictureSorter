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