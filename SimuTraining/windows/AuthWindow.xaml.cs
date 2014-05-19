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
using System.Security.AccessControl;

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
            machine_code.Text = AuthUtil.getMachineID();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void authorize_Click(object sender, RoutedEventArgs e)
        {
            String authcode = auth_code.Text;
            String id = machine_code.Text.ToString();

            if (AuthUtil.authorize(id, authcode))
            {
                writeRegistry(authcode);
                Window index = new IndexWindow(BreadCrumb.getRoot());
                this.Close();
                index.Show();
            }
            else
            {
                MessageBox.Show("错误的验证码");
            }
        }

        private void writeRegistry(String authcode)
        {
            RegistrySecurity rs = new RegistrySecurity();

            // Allow the current user to read and delete the key. 
            //
            string user = Environment.UserDomainName + "\\" + Environment.UserName;

            rs.AddAccessRule(new RegistryAccessRule(user, 
            RegistryRights.ReadKey | RegistryRights.Delete, 
            InheritanceFlags.None, 
            PropagationFlags.None, 
            AccessControlType.Allow));

            Registry.LocalMachine.CreateSubKey("SOFTWARE\\SimuTraining", RegistryKeyPermissionCheck.ReadWriteSubTree);

            RegistryKey SimuTraining = Registry.LocalMachine.CreateSubKey("SOFTWARE\\SimuTraining");
            SimuTraining.SetValue("authcode", authcode);
            SimuTraining.Close();
        }
    }
}
