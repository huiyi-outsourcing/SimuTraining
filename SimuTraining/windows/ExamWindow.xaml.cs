using System;
using System.Collections.Generic;
using System.IO;
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

using SimuTraining.util;

namespace SimuTraining.windows
{
    /// <summary>
    /// ExamWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ExamWindow : Window
    {
        private Exam exam;

        public ExamWindow()
        {
            InitializeComponent();
        }

        public ExamWindow(String name)
        {
            InitializeComponent();

            exam = new Exam(name);
            exam.loadExam();
        }

        #region Layout
        #endregion

        #region EventHandlers
        private void prev_question(object sender, RoutedEventArgs e)
        {

        }

        private void next_question(object sender, RoutedEventArgs e)
        {

        }

        private void submit_exam(object sender, RoutedEventArgs e)
        { 
        
        }

        private void question_list(object sender, RoutedEventArgs e)
        { 
            
        }

        private void tag_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mainPage_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("您确定要退出本次考试回到首页吗？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Window main = new MainWindow();
                main.Show();
                this.Close();
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
    }
}
