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

using SimuTraining.util;
using SimuTraining.windows;

namespace SimuTraining
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

        private void mainPage_Click(object sender, RoutedEventArgs e)
        {
            // do nothing.. already in main window
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            // return to login window
            Window login = new windows.LoginWindow();
            login.Show();
            this.Close();
        }

        private void enterSimuTraining(object sender, MouseButtonEventArgs e)
        {
            //Node root = BreadCrumb.getRoot();
            //Window index = new windows.IndexWindow(root);
            //index.Show();
            Window intro = new IntroWindow();
            intro.Show();
            this.Close();
        }

    }
}
