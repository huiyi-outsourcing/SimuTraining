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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Authentication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void auth(object sender, RoutedEventArgs e)
        {
            String code = machineCode.Text.ToString();
            if (code.Equals("") || code == null)
            {
                MessageBox.Show("机器码不能为空!");
            }
            else
            {
                String result = AuthUtil.generateAuthrizationCode(code);
                authCode.Text = result.Substring(0, 8);
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
