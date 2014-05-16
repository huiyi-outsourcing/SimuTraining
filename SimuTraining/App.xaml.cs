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

namespace SimuTraining
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //SplashScreen sp = new SplashScreen("res/img/welcome.png");
            //sp.Show(true, true);
            //sp.Close(new TimeSpan(0, 0, 3));
            //Thread.Sleep(3000);

            //VideoUtil.encode("media/test.mp4");

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
