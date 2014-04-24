using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace SimuTraining
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen sp = new SplashScreen("res/img/welcome.png");
            sp.Show(true, true);
            sp.Close(new TimeSpan(0, 0, 3));

            Window main = new MainWindow();
            main.ShowActivated = false;
            Thread.Sleep(3000);
            main.Show();

            base.OnStartup(e);
        }
    }
}
