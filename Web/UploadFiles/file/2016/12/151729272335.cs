using Common;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Agent
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.CurrentDomain_UnhandledException);
            Program.SetWebBrowserInIE8Mode();
            Process process = Program.AIIS();
            if (process == null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                return;
            }
            Program.BIIS(process);
        }

        public static void BIIS(Process instance)
        {
            Program.ShowWindowAsync(instance.MainWindowHandle, 3);
            Program.SetForegroundWindow(instance.MainWindowHandle);
        }

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.WriteLog(e.Exception, e.Exception.Message, new object[0]);
            MessageBox.Show(e.Exception.Message);
        }

        public static void SetWebBrowserInIE8Mode()
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Version Vector");
                if (decimal.Parse(registryKey.GetValue("IE", 0).ToString()) >= 8m)
                {
                    string name = Application.ExecutablePath.Substring(Application.ExecutablePath.LastIndexOf('\\') + 1);
                    RegistryKey registryKey2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION");
                    if (registryKey2.GetValue(name, 0).ToString() == "0")
                    {
                        registryKey2.SetValue(name, 8000, RegistryValueKind.DWord);
                    }
                    registryKey2.Close();
                }
                registryKey.Close();
            }
            catch (Exception)
            {
            }
        }

        public static Process AIIS()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
            Process[] array = processesByName;
            for (int i = 0; i < array.Length; i++)
            {
                Process process = array[i];
                if (process.Id != currentProcess.Id && Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == currentProcess.MainModule.FileName)
                {
                    return process;
                }
            }
            return null;
        }
    }
}
