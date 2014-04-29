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

namespace SimuTraining.windows
{
    /// <summary>
    /// MediaPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();
            mediaPlayer.Source = new Uri("media/test.mp4", UriKind.Relative);
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void fullscreen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rewind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shutdown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void volume_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
