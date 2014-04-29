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

using SimuTraining.util;

namespace SimuTraining.windows
{
    /// <summary>
    /// IndexWindow.xaml 的交互逻辑
    /// </summary>
    public partial class IndexWindow : Window
    {
        private Node current;

        public IndexWindow()
        {
            InitializeComponent();
        }

        public IndexWindow(Node current)
        {
            InitializeComponent();

            this.current = current;

            refreshLayout(current);
        }

        #region Layout
        private void refreshLayout(Node node)
        {
            this.current = node;
            refreshBreadCrumb(node);
            refreshBody(node);
        }

        private void refreshBreadCrumb(Node node)
        {
            breadcrumb.Children.RemoveRange(0, breadcrumb.Children.Count);
            Stack<Node> stack = new Stack<Node>();

            Node tmp = node;
            while (tmp != null)
            {
                stack.Push(tmp);
                if (tmp.Parent == null)
                {
                    break;
                }
                else
                {
                    tmp = tmp.Parent;
                }
            }

            int count = stack.Count;
            foreach (Node top in stack)
            {
                Label label = new Label();
                label.Content = top.Name;
                label.Margin = new Thickness(20, 0, 0, 0);
                label.MouseLeftButtonDown += gotoPrev;
                breadcrumb.Children.Add(label);

                --count;
                if (count != 0)
                {
                    Label arrow = new Label();
                    arrow.Content = ">";
                    arrow.Margin = new Thickness(20, 0, 0, 0);
                    breadcrumb.Children.Add(arrow);
                }

            }
        }

        private void refreshBody(Node node)
        {
            body.Children.RemoveRange(0, body.Children.Count);

            if (node.Children == null || node.Children.Count == 0)
            {
                generateMediaPage();
            }
            else
            {
                generateDirectoryPage();
            }
        }

        private void generateMediaPage()
        { 
            
        }

        private void generateDirectoryPage()
        {
            if (current.Children.Count <= 3)
            {
                OneColumn();
            }
            else if (current.Children.Count <= 6)
            {
                TwoColumn();
            }
            else
            {
                MultiColumn();
            }
        }

        private void OneColumn()
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;

            List<Node> children = current.Children;
            foreach (Node node in children)
            {
                Image img = new Image();
                BitmapImage bi = new BitmapImage(new Uri("res/img/" + node.Name + ".png"));
                img.Source = bi;

                img.Height = bi.PixelHeight;
                img.Width = bi.PixelWidth;
                img.Margin = new Thickness(10);

                panel.Children.Add(img);
            }

            body.Children.Add(panel);
        }

        private void TwoColumn()
        {
            StackPanel one = new StackPanel();
            one.Orientation = Orientation.Horizontal;
            StackPanel two = new StackPanel();
            two.Orientation = Orientation.Horizontal;

            List<Node> nodes = current.Children;
            if (current.Children.Count == 4)
            {
                for (int i = 0; i < 4; ++i)
                {
                    Image img = new Image();
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri("../res/img/" + nodes[i].Name + ".png", UriKind.Relative);
                    bi.EndInit();

                    img.Source = bi;
                    img.Height = bi.PixelHeight;
                    img.Width = bi.PixelWidth;
                    img.Margin = new Thickness(10);

                    if (i < 2)
                        one.Children.Add(img);
                    else
                        two.Children.Add(img);
                }
            }
            else
            {
                for (int i = 0; i < nodes.Count; ++i)
                {
                    Image img = new Image();
                    BitmapImage bi = new BitmapImage(new Uri("res/img/" + nodes[i].Name + ".png"));
                    img.Source = bi;
                    img.Height = bi.PixelHeight;
                    img.Width = bi.PixelWidth;
                    img.Margin = new Thickness(10);

                    if (i < 3)
                        one.Children.Add(img);
                    else
                        two.Children.Add(img);
                }
            }

            body.Children.Add(one);
            body.Children.Add(two);
        }

        private void MultiColumn()
        { 
            
        }
        #endregion

        #region EventHandlers
        private void gotoPrev(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;
            String content = label.Content.ToString();

            Node tmp = current;
            Node result = null;
            while (tmp != null)
            {
                if (tmp.Name.Equals(content))
                {
                    result = tmp;
                    break;
                }

                tmp = tmp.Parent;
            }

            refreshLayout(result);
        }

        private void gotoNext(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void mainPage_Click(object sender, RoutedEventArgs e)
        {
            Window main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            refreshLayout(current.Parent);
        }
        #endregion
    }
}