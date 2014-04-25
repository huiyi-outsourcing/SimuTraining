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

            initMainPage();
        }

        private void mainPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void return_Click(object sender, RoutedEventArgs e)
        {

        }

        private void initMainPage()
        {
            // first remove previous children
            body.Children.RemoveRange(0, body.Children.Count);

            // add main page material
            StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };

            Image b1 = new Image() { Margin = new Thickness(100) };
            b1.Source = new BitmapImage(new Uri("res/img/main_1.png", UriKind.Relative));
            b1.Width = 128;
            b1.Height = 128;
            b1.MouseLeftButtonDown += new MouseButtonEventHandler(enterMainList);

            Image b2 = new Image() { Margin = new Thickness(100) };
            b2.Source = new BitmapImage(new Uri("res/img/main_2.png", UriKind.Relative));
            b2.Width = 128;
            b2.Height = 128;

            Image b3 = new Image() { Margin = new Thickness(100) };
            b3.Source = new BitmapImage(new Uri("res/img/main_3.png", UriKind.Relative));
            b3.Width = 128;
            b3.Height = 128;

            sp.Children.Add(b1);
            sp.Children.Add(b2);
            sp.Children.Add(b3);

            body.Children.Add(sp);
        }

        private void initList()
        {
            // first remove previous children
            body.Children.RemoveRange(0, body.Children.Count);

            // add main page material
            StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };

            Image b1 = new Image() { Margin = new Thickness(100) };
            b1.Source = new BitmapImage(new Uri("res/img/main_1.png", UriKind.Relative));
            b1.Width = 128;
            b1.Height = 128;
            b1.MouseLeftButtonDown += new MouseButtonEventHandler(enterMainList);

            sp.Children.Add(b1);

            body.Children.Add(sp);
        }

        private void enterMainList(object sender, MouseButtonEventArgs e)
        {
            initList();
        }
    }
}
