using GAM.Connections;
using GAM.Forms.Login;
using GAM.Forms.Main;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GAM
{
    public static class Program
    {
        public static string Guid = "{9006f149-aa49-4b8e-ba69-386d945fa738}";
        static System.Threading.Mutex mutex = new System.Threading.Mutex(true, Guid);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                OLEDB.Startup("KRZ-7687634", "Data$", string.Empty);
                OLEDB.ConnectionMode = OLEDB.ConnectionModeType.Master;

                System.IO.File.WriteAllBytes(Application.StartupPath + @"\updater.exe", GAM.Properties.Resources.updater);
                if (!IsNewVersionAvailable())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
                    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                    DevExpress.Utils.AppearanceObject.DefaultMenuFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Application.Run(new frmLogin());
                    mutex.ReleaseMutex();
                }
                else
                {
                    Process.Start(Application.StartupPath + @"\updater.exe");
                    Process process = Process.GetCurrentProcess();
                    process.Kill();
                }
            }
        }

        private static bool IsNewVersionAvailable()
        {
            if (OLEDB.ConnectionMode != OLEDB.ConnectionModeType.Local)
            {
                try
                {
                    string filePath = OLEDB.GetInstallFile("GAM.exe").LocalPath;
                    if (System.IO.File.Exists(filePath))
                    {
                        FileVersionInfo newVerion = System.Diagnostics.FileVersionInfo.GetVersionInfo(filePath);
                        long ver1 = long.Parse(Numeral.ExtractDigits(Application.ProductVersion));
                        long ver2 = long.Parse(Numeral.ExtractDigits(newVerion.ProductVersion));
                        if (ver2 > ver1)
                            return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        //static void CreateShortcut() 
        //{
        //    //Import [Windows Script Host Object Model] dll from References>COM
        //    string startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        //    if (!System.IO.File.Exists(startUpFolderPath + @"\Etebarat.lnk"))
        //    {
        //        var shell = new IWshRuntimeLibrary.WshShell();
        //        var windowsApplicationShortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(startUpFolderPath + "\\" + Application.ProductName + ".lnk");
        //        windowsApplicationShortcut.Description = "Etebarat Shortcut File";
        //        windowsApplicationShortcut.WorkingDirectory = Application.StartupPath;
        //        windowsApplicationShortcut.TargetPath = Application.ExecutablePath;
        //        windowsApplicationShortcut.Save();
        //    }
        //}
    }
}
