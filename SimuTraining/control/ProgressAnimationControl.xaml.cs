using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimuTraining.windows
{
    /// <summary>
    /// ProgressAnimationControl.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressAnimationControl : UserControl
    {
        Storyboard progressAnimation;

        public ProgressAnimationControl()
        {
            InitializeComponent();
            progressAnimation = (Storyboard)FindResource("progressAnimation");
        }

        public void StartAnimation()
        {
            this.Visibility = System.Windows.Visibility.Visible;
            if (progressAnimation != null)
            {
                progressAnimation.Begin();
            }
        }

        public void StopAnimation()
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
            if (progressAnimation != null)
            {
                progressAnimation.Stop();
            }
        }
    }
}
