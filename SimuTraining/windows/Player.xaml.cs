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
using System.ComponentModel;
using System.IO;

using SimuTraining.util;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace SimuTraining.windows
{
    /// <summary>
    /// MediaPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class Player : UserControl
    {
        private Node current;
        private bool userIsDraggingSlider = false;
        private bool isPlaying = false;

        public bool IsPlaying
        {
            get { return isPlaying; }
            set { isPlaying = value; }
        }

        private void close(object sender, RoutedEventArgs e)
        {
            player.Stop();
            player.Source = null;
        }

        public Player()
        {
            InitializeComponent();
        }

        public Player(Node current)
        {
            InitializeComponent();

            player.Width = SystemParameters.WorkArea.Width;
            player.Height = SystemParameters.VirtualScreenHeight - 270;

            if (!File.Exists(current.Filelocation))
            {
                MessageBox.Show("文件不存在！！");
            }
            else
            {
                VideoUtil.encode(current.Filelocation);
            }

            this.current = current;
            title.Content = current.Name;
            description.Content = current.Description;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            if (player.Source == null)
            {
                player.Source = new Uri(current.Filelocation, UriKind.Relative);
            }
            player.Play();
            isPlaying = true;
            //this.AddHandler(IndexWindow.closeEvent, new RoutedEventHandler(close));
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
            if (!isPlaying)
            {
                if (player.Source == null)
                {
                    player.Source = new Uri(current.Filelocation, UriKind.Relative);
                }
                player.Play();
                isPlaying = true;
            }
        }

        private void rewind_Click_1(object sender, RoutedEventArgs e)
        {
            player.Stop();
            if (player.Source == null)
            {
                player.Source = new Uri(current.Filelocation, UriKind.Relative);
            }
            player.Play();
        }

        private void stop_Click_1(object sender, RoutedEventArgs e)
        {
            player.Stop();
            player.Source = null;
            isPlaying = false;
        }

        private void pause_Click_1(object sender, RoutedEventArgs e)
        {
            player.Pause();
            isPlaying = false;
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
            if (isPlaying)
            {
                player.Pause();
            }

            TimeSpan ts = player.Position;
            Window fullscreen = new FullScreenPlayer(current, this, player, ts);
            fullscreen.Show();
            isPlaying = false;
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
            isPlaying = false;
        }
    }
}
