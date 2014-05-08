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
        }

        public Player(Node current)
        {
            InitializeComponent();

            if (!File.Exists(current.Filelocation))
            {
                MessageBox.Show("文件不存在！！");
            }
            else
            {
                VideoUtil.encode(current.Filelocation);
            }

            wpfMediaPlayer.URL = current.Filelocation;
            title.Content = current.Name;
            description.Content = current.Description;
        }
    }
}
