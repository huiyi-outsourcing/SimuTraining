using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Text;

using SimuTraining.windows;
using SimuTraining.util;
using System.Reflection;
using System.Security.AccessControl;
using System.Diagnostics;

namespace SimuTraining
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Get Reference to the current Process
            Process thisProc = Process.GetCurrentProcess();
            // Check how many total processes have the same name as the current one
            if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1) {
                // If ther is more than one, than it is already running.
                MessageBox.Show("程序已经在运行");
                Application.Current.Shutdown();
                return;
            }

            RecoveryHelper helper = new RecoveryHelper();
            helper.readLog();

            if (confirmAuthorization())
            {
                Window index = new IndexWindow(BreadCrumb.getRoot());
                index.Show();
            }
            else
            {
                Window auth = new AuthWindow();
                auth.Show();
            }

            base.OnStartup(e);

            //Window index = new IndexWindow(BreadCrumb.getRoot());
            //index.Show();
        }

        private Boolean confirmAuthorization()
        {
            RegistryKey key = Registry.LocalMachine;
            RegistryKey SimuTraining = key.OpenSubKey("SOFTWARE\\SimuTraining");
            if (SimuTraining != null && SimuTraining.GetValue("authcode") != null)
            {
                String id = AuthUtil.getMachineID();
                return AuthUtil.authorize(id, SimuTraining.GetValue("authcode").ToString());
            }
            else
            {
                return false;
            }
        }

    }
}
