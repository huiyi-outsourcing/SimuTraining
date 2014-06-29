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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimuTraining.control
{
    /// <summary>
    /// ExamResult.xaml 的交互逻辑
    /// </summary>
    public partial class ExamResult : UserControl
    {
        public ExamResult()
        {
            InitializeComponent();
        }

        public ExamResult(int sc, String wr)
        {
            InitializeComponent();

            score.Text = sc.ToString();
            wrong.Text += wr;
        }
    }
}
