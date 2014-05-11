using SimuTraining.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SimuTraining.windows
{
    /// <summary>
    /// FullScreenPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class FullScreenPlayer : Window
    {
        private Node current;
        private bool userIsDraggingSlider = false;
        MediaElement parent;

        public FullScreenPlayer()
        {
            InitializeComponent();
        }

        public FullScreenPlayer(Node current, MediaElement parent, TimeSpan now)
        {
            InitializeComponent();

            //if (!File.Exists(current.Filelocation))
            //{
            //    MessageBox.Show("文件不存在！！");
            //}
            //else
            //{
            //    VideoUtil.encode(current.Filelocation);
            //}
            this.parent = parent;
            this.current = current;
            player.Width = SystemParameters.VirtualScreenWidth;
            player.Height = SystemParameters.VirtualScreenHeight - 45;
            
            //wpfMediaPlayer.URL = current.Filelocation;
            
            //player.Play();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            player.Source = new Uri(current.Filelocation, UriKind.Relative);
            player.Position = now;
            player.Play();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((player.Source != null) && (player.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = player.Position.TotalSeconds;
            }
        }

        private void play_Click_1(object sender, RoutedEventArgs e)
        {
            if (player.Source == null)
            {
                player.Source = new Uri(current.Filelocation, UriKind.Relative);
            }
            player.Play();
        }

        private void rewind_Click_1(object sender, RoutedEventArgs e)
        {
            player.Stop();
            player.Play();
        }

        private void stop_Click_1(object sender, RoutedEventArgs e)
        {
            player.Stop();
            player.Source = null;
        }

        private void pause_Click_1(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void volume_Click_1(object sender, RoutedEventArgs e)
        {
            if (volumeSlider.Visibility == Visibility.Visible)
            {
                volumeSlider.Visibility = Visibility.Hidden;
            }
            else
            {
                volumeSlider.Visibility = Visibility.Visible;
            }
        }

        private void fullscreen_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

            TimeSpan ts = player.Position;
            parent.Position = ts;
            parent.Play();
        }

        private void volumeSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = (double)volumeSlider.Value;
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            player.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void Grid_MouseEnter_1(object sender, MouseEventArgs e)
        {
            bar.Visibility = Visibility.Visible;
        }

        private void Grid_MouseLeave_1(object sender, MouseEventArgs e)
        {
            bar.Visibility = Visibility.Hidden;
        }

        private void player_MediaEnded(object sender, RoutedEventArgs e)
        {
            player.Stop();
            player.Source = null;
        }
    }
}
