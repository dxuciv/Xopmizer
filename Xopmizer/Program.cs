using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Xopmizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            if (vs.Major != 10)
            {
                MessageBox.Show("Xopmizer only supports Windows 10.", "Unsupported OS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }

            Globals.winrelease = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "DisplayVersion", "").ToString();
            Globals.winbuild = Int32.Parse(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "").ToString());


            if (Globals.winbuild >= 22000)
            {
                Globals.winmajor = "11";
            }
            else
            {
                Globals.winmajor = "10";
            }

            if (Globals.winbuild != 19045)
            {
                MessageBox.Show($"Xopmizer 1.8 is developed for Windows 10 (22H2).\nThis PC is running Windows {Globals.winmajor} ({Globals.winrelease}).\nPlease proceed with caution.", "Untested OS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Application.Run(new MainForm(args));
        }
    }
}
