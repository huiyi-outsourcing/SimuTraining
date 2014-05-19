using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            if (body.Children.OfType<Player>().Count<Player>() > 0)
            {
                Player player = body.Children[0] as Player;
                player.player.Stop();
                player.player.Source = null;
                GC.Collect();
                Thread.Sleep(100);
                if (File.Exists(current.Filelocation))
                {
                    VideoUtil.encode(current.Filelocation);
                }
            }

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

            if (node.Leaf)
            {
                if (node.ExceptionDescription.Length > 0)
                {
                    generateDescriptionPage();
                }
                else
                {
                    generateMediaPage();
                }
            }
            else
            {
                if (!node.Leaf && node.Description.Length > 0)
                {
                    generateDescriptionPage();
                }
                else
                {
                    generateDirectoryPage();
                }
            }
        }

        private void generateMediaPage()
        {
            Player player = new Player(current);
            body.Children.Add(player);
        }

        private void generateDirectoryPage()
        {
            int children = current.Children.Count;

            if (current.Level == 0)
            {
                IndexPage();
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

        private void generateDescriptionPage()
        {
            Grid grid = new Grid() { Margin = new Thickness(40) };
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(80) });
            grid.RowDefinitions.Add(new RowDefinition());

            Label title = new Label() { Content = current.Name };
            ScrollViewer sv = new ScrollViewer() { VerticalScrollBarVisibility = ScrollBarVisibility.Auto };
            TextBlock description = new TextBlock() { TextWrapping = TextWrapping.Wrap, LineHeight = 30 };
            if (current.Leaf)
            {
                description.Text = current.ExceptionDescription;
            }
            else
            {
                description.Text = current.Description;
            }
            ScrollViewer.SetCanContentScroll(description, true);
            ScrollViewer.SetVerticalScrollBarVisibility(description, ScrollBarVisibility.Auto);
            ScrollViewer.SetHorizontalScrollBarVisibility(description, ScrollBarVisibility.Disabled);

            sv.Content = description;
            Grid.SetRow(title, 0);
            Grid.SetRow(sv, 1);

            grid.Children.Add(title);
            grid.Children.Add(sv);

            body.Children.Add(grid);

            nextPage.Visibility = Visibility.Visible;
        }

        #region Column region
        private void IndexPage()
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Margin = new Thickness(10, 10, 10, 10);
            StackPanel one = new StackPanel();
            one.Orientation = Orientation.Horizontal;
            one.Margin = new Thickness(10, 40, 10, 40);
            StackPanel two = new StackPanel();
            two.Orientation = Orientation.Horizontal;
            two.Margin = new Thickness(10, 40, 10, 40);

            List<Node> nodes = current.Children;

            for (int i = 0; i < 4; ++i)
            {
                Image img = createImage(nodes[i], nodes.Count);
                img.Margin = new Thickness(90, 0, 90, 0);

                if (i < 2)
                {
                    one.Children.Add(img);
                }
                else
                {
                    two.Children.Add(img);
                }
            }

            panel.Children.Add(one);
            panel.Children.Add(two);
            body.Children.Add(panel);
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
            one.Margin = new Thickness(10, 20, 10, 20);
            StackPanel two = new StackPanel();
            two.Orientation = Orientation.Horizontal;
            two.Margin = new Thickness(10, 20, 10, 20);

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
        #endregion

        private Image createImage(Node node, int children)
        {
            Image img = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("res/img/" + node.ImageName + ".png", UriKind.Relative);
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
            if (body.Children.OfType<Player>().Count<Player>() > 0)
            {
                Player player = body.Children[0] as Player;
                player.player.Stop();
                player.player.Source = null;
                Thread.Sleep(100);
                VideoUtil.encode(current.Filelocation);
            }

            body.Children.RemoveRange(0, body.Children.Count);

            //Window main = new MainWindow();
            //main.Show();
            //this.Close();
            //GC.Collect();
            Node index = current;
            while (index.Parent != null)
            {
                index = index.Parent;
            }

            refreshLayout(index);
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

        private void nextPage_Click(object sender, RoutedEventArgs e)
        {
            if (current.Leaf)
            {
                String tmp = current.ExceptionDescription;
                current.ExceptionDescription = "";
                nextPage.Visibility = Visibility.Hidden;
                refreshBody(current);
                current.ExceptionDescription = tmp;
            }
            else
            {
                String tmp = current.Description;
                current.Description = "";
                nextPage.Visibility = Visibility.Hidden;
                refreshBody(current);
                current.Description = tmp;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (body.Children.OfType<Player>().Count<Player>() > 0)
            {
                Player player = body.Children[0] as Player;
                player.player.Stop();
                player.player.Source = null;
                Thread.Sleep(100);
                VideoUtil.encode(current.Filelocation);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("您确定要退出本程序吗？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        private void mainPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back && current.Parent != null)
            {
                refreshLayout(current.Parent);
            }
            else if (e.Key == Key.D0 ||
                     e.Key == Key.D1 ||
                     e.Key == Key.D2 ||
                     e.Key == Key.D3 ||
                     e.Key == Key.D4 ||
                     e.Key == Key.D5 ||
                     e.Key == Key.D6 ||
                     e.Key == Key.D7 ||
                     e.Key == Key.D8 ||
                     e.Key == Key.D9)
            {
                int input = Int32.Parse(e.Key.ToString().Substring(1));
                input = input == 0 ? 10 : input;
                if (input < current.Children.Count)
                    refreshLayout(current.Children[input - 1]);
            }
            else if (e.Key == Key.Escape)
            {
                if (MessageBox.Show("您确定要退出本程序吗？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}