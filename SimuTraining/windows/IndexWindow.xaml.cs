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
using System.IO;

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
                label.Margin = new Thickness(5, 0, 0, 0);
                label.Tag = top;
                label.MouseLeftButtonDown += gotoPrev;
                breadcrumb.Children.Add(label);

                --count;
                if (count != 0)
                {
                    Label arrow = new Label();
                    arrow.Content = ">";
                    arrow.Margin = new Thickness(5, 0, 0, 0);
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
            int children = current.Children.Count;

            if (current.Level == 0)
            {
                TwoRow();
            }
            else
            {
                if (children <= 4)
                {
                    OneRow();
                }
                else if (children <= 6)
                {
                    TwoRow();
                }
                else if (children <= 8)
                {
                    TwoRow();
                }
                else
                {
                    MultiRow();
                }
            }
        }

        private void OneRow()
        {
            StackPanel panel = new StackPanel();
            StackPanel one = new StackPanel();
            one.Orientation = Orientation.Horizontal;

            List<Node> children = current.Children;
            foreach (Node node in children)
            {
                Image img = createImage(node, children.Count);

                one.Children.Add(img);
            }

            panel.Children.Add(one);
            body.Children.Add(panel);
        }

        private void TwoRow()
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Margin = new Thickness(10, 10, 10, 10);
            StackPanel one = new StackPanel();
            one.Orientation = Orientation.Horizontal;
            one.Margin = new Thickness(0, 20, 0, 20);
            StackPanel two = new StackPanel();
            two.Orientation = Orientation.Horizontal;
            two.Margin = new Thickness(0, 20, 0, 20);

            List<Node> nodes = current.Children;
            if (current.Children.Count == 4)
            {
                for (int i = 0; i < 4; ++i)
                {
                    Image img = createImage(nodes[i], nodes.Count);

                    if (i < 2)
                        one.Children.Add(img);
                    else
                        two.Children.Add(img);
                }
            }
            else if (current.Children.Count < 8)
            {
                for (int i = 0; i < nodes.Count; ++i)
                {
                    Image img = createImage(nodes[i], nodes.Count);

                    if (i < 3)
                        one.Children.Add(img);
                    else
                        two.Children.Add(img);
                }
            }
            else
            {
                for (int i = 0; i < nodes.Count; ++i)
                {
                    Image img = createImage(nodes[i], nodes.Count);

                    if (i < 4)
                        one.Children.Add(img);
                    else
                        two.Children.Add(img);
                }
            }

            panel.Children.Add(one);
            panel.Children.Add(two);
            body.Children.Add(panel);
        }

        private void MultiRow()
        {
            StackPanel panel = new StackPanel() { Orientation = Orientation.Vertical };
            panel.Margin = new Thickness(10);
            StackPanel one = new StackPanel() { Orientation = Orientation.Horizontal };
            //one.Margin = new Thickness(0, 10, 0, 10);
            StackPanel two = new StackPanel() { Orientation = Orientation.Horizontal };
            //two.Margin = new Thickness(0, 10, 0, 10);
            StackPanel three = new StackPanel() { Orientation = Orientation.Horizontal };
            three.HorizontalAlignment = HorizontalAlignment.Left;
            //three.Margin = new Thickness(0, 10, 0, 10);

            List<Node> nodes = current.Children;
            for (int i = 0; i < nodes.Count; ++i)
            {
                Image img = createImage(nodes[i], nodes.Count);
                //if (img == null)
                //{
                //    Label label = new Label();
                //    label.Content = nodes[i].Name;
                //    label.Width = 209;
                //    label.Height = 200;

                //    if (i < 3)
                //        one.Children.Add(label);
                //    else if (i < 6)
                //        two.Children.Add(label);
                //    else
                //        three.Children.Add(label);

                //    continue;
                //}

                if (i < 4)
                    one.Children.Add(img);
                else if (i < 8)
                    two.Children.Add(img);
                else
                    three.Children.Add(img);
            }

            panel.Children.Add(one);
            panel.Children.Add(two);
            if (nodes.Count > 8)
                panel.Children.Add(three);
            body.Children.Add(panel);
        }

        private Image createImage(Node node, int children)
        {
            //if (!File.Exists("res/img/" + node.Name + ".png"))
            //{
            //    return null;
            //}

            Image img = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("res/img/" + node.Name + ".png", UriKind.Relative);
            bi.EndInit();
            bi.Freeze();

            img.Source = bi;
            if (node.Level == 1)
            {
                img.Height = 118;
                img.Width = 258;
            }
            else
            {
                if (children <= 6)
                {
                    img.Height = 200;
                    img.Width = 209;
                }
                else
                {
                    img.Height = 150;
                    img.Width = 153;
                }
            }

            img.Margin = new Thickness(10, 0, 80, 0);
            img.Tag = node;
            img.MouseLeftButtonDown += gotoNext;

            return img;
        }
        #endregion

        #region EventHandlers
        private void gotoPrev(object sender, MouseButtonEventArgs e)
        {
            Node node = (sender as Label).Tag as Node;

            refreshLayout(node);
        }

        private void gotoNext(object sender, MouseButtonEventArgs e)
        {
            Node node = (sender as Image).Tag as Node;

            refreshLayout(node);
        }

        private void mainPage_Click(object sender, RoutedEventArgs e)
        {
            Window main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            if (current.Parent != null)
            {
                refreshLayout(current.Parent);
            }
            else
            {
                refreshLayout(current);
            }
        }
        #endregion
    }
}