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

namespace SimuTraining.windows
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (checkValid())
            {
                Window main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入正确的用户名/密码");
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool checkValid()
        {
            String un = username.Text.ToString();
            String pw = password.Text.ToString();

            return un != "" && pw != "";
        }
    }
}
