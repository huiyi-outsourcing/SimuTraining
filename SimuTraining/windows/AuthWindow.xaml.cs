using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

using SimuTraining.util;

namespace SimuTraining.windows
{
    /// <summary>
    /// auth.xaml 的交互逻辑
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            String id = AuthUtil.getMachineID();
            machine_code.Content = AuthUtil.getMachineID();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void authorize_Click(object sender, RoutedEventArgs e)
        {
            String authcode = auth_code.Text;
            String id = machine_code.Content.ToString();

            if (AuthUtil.authorize(id, authcode))
            {
                writeRegistry(authcode);
                Window main = new MainWindow();
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("错误的验证码");
            }
        }

        private void writeRegistry(String authcode)
        {
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\SimuTraining", RegistryKeyPermissionCheck.ReadWriteSubTree);

            RegistryKey SimuTraining = Registry.LocalMachine.OpenSubKey("SOFTWARE\\SimuTraining", true);
            SimuTraining.SetValue("authcode", authcode);
            SimuTraining.Close();
        }
    }
}
