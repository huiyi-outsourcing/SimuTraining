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
using System.Diagnostics;

using SimuTraining.windows;
using SimuTraining.util;
using System.Reflection;
using System.Security.AccessControl;

namespace SimuTraining
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            RecoveryHelper helper = new RecoveryHelper();
            helper.readLog();

            if (confirmAuthorization())
            {
                Window main = new MainWindow();
                main.Show();

                //Window exam = new ExamWindow("试题格式");
                //exam.Show();
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
