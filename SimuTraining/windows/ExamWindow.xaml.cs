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
using System.Windows.Media.Effects;

namespace SimuTraining.windows {
    /// <summary>
    /// ExamWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ExamWindow : Window {
        private Exam exam;

        public ExamWindow() {
            InitializeComponent();
        }

        public ExamWindow(String name) {
            InitializeComponent();

            exam = new Exam(name);
            exam.loadExam();

            initLayout();
        }

        #region Layout
        private void initLayout() {
            // init question list
            for (int i = 0; i < exam.Questions.Count; ++i) {
                Question q = exam.Questions.ElementAt(i);
                Border border = new Border() { SnapsToDevicePixels = true, BorderBrush = Brushes.LightGray, BorderThickness = new Thickness(4), CornerRadius = new CornerRadius(5), Width = 40, Height = 40 };
                border.Effect = new DropShadowEffect() { Color = Colors.Black, BlurRadius = 16, ShadowDepth = 0, Opacity = 1 };

                TextBlock tb = new TextBlock() { Text = (i + 1).ToString(), HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
                border.Child = tb;
                ListBoxItem item = new ListBoxItem() { Margin = new Thickness(10) };
                item.Content = border;
                item.Tag = q;

                qlist.Items.Add(item);
            }

            qlist.SelectedIndex = 0;

            // init content
            refreshQuestion(0);
        }

        private void refreshQuestion(int index) {
            Question q = exam.Questions[index];
            description.Text = index + 1 + ". " + q.Description;
            options.Items.Clear();

            for (int i = 0; i < q.Options.Count; ++i) {
                ListBoxItem item = new ListBoxItem() { Margin = new Thickness(10)};
                TextBlock tb = new TextBlock() { Text = q.Options[i].Description, TextWrapping = TextWrapping.Wrap };

                item.Content = tb;
                item.MouseDoubleClick += new MouseButtonEventHandler(next_question);

                options.Items.Add(item);
            }

            options.SelectedIndex = q.SelectedOption;
            if (options.SelectedIndex != -1)
                (options.SelectedItem as ListBoxItem).Focus();
        }

        private void drawColor() {
            foreach (ListBoxItem item in qlist.Items) {
                Border border = item.Content as Border;
                Question q = item.Tag as Question;
                if (q.Status == Question.STATUS.DOUBT) {
                    border.Background = Brushes.OrangeRed;
                } else {
                    if (q.SelectedOption == -1)
                        border.Background = Brushes.Transparent;
                    else
                        border.Background = Brushes.Green;
                }
            }
        }
        #endregion

        #region EventHandlers
        private void prev_question(object sender, RoutedEventArgs e) {
            int index = qlist.SelectedIndex;
            if (index == 0) {
                MessageBox.Show("已经是第一题");
                return;
            }

            qlist.SelectedIndex = index - 1;
        }

        private void next_question(object sender, RoutedEventArgs e) {
            int index = qlist.SelectedIndex;
            if (index == qlist.Items.Count - 1) {
                if (MessageBox.Show("已到最后一题，是否提交试卷？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                    showScore();
                }
            }
            qlist.SelectedIndex = index + 1;
        }

        private void submit_exam(object sender, RoutedEventArgs e) {
            int count = 0;
            foreach (Question q in exam.Questions) {
                if (q.SelectedOption != -1)
                    count++;
            }

            if (count != exam.Questions.Count) {
                if (MessageBox.Show("还有题目没有完成，确认提交？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                    showScore();
                }
            } else {
                showScore();
            }
        }

        private void showScore() {
            body.Children.Clear();
            body.ColumnDefinitions.Clear();

            control.ExamResult result = new control.ExamResult(exam.getScore(), exam.getWrong());

            body.Children.Add(result);
        }

        private void tag_Click(object sender, RoutedEventArgs e) {
            int index = qlist.SelectedIndex;
            ListBoxItem item = qlist.Items[index] as ListBoxItem;
            Question q = item.Tag as Question;
            if (q.Status == Question.STATUS.DOUBT) {
                if (options.SelectedIndex >= 0)
                    q.Status = Question.STATUS.DONE;
                else
                    q.Status = Question.STATUS.EMPTY;
            } else {
                q.Status = Question.STATUS.DOUBT;
            }

            drawColor();
        }

        private void qlist_SelectionChanged_1(object sender, SelectionChangedEventArgs e) {
            int index = qlist.SelectedIndex;
            refreshQuestion(index);
        }

        private void options_SelectionChanged_1(object sender, SelectionChangedEventArgs e) {
            int index = qlist.SelectedIndex;
            ListBoxItem item = qlist.Items[index] as ListBoxItem;
            Question q = item.Tag as Question;
            if (q.Status == Question.STATUS.EMPTY)
                q.Status = Question.STATUS.DONE;
                
            if (options.SelectedIndex != -1)
                q.SelectedOption = options.SelectedIndex;

            drawColor();
        }

        private void ScrollViewer_PreviewMouseWheel_1(object sender, MouseWheelEventArgs e) {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void mainPage_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("您确定要退出本次考试回到首页吗？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                Window main = new MainWindow();
                main.Show();
                this.Close();
            }
        }

        private void return_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("您确定要退出本次考试回到试题选择吗？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                Window examList = new ExamListWindow();
                examList.Show();
                this.Close();
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("您确定要退出本程序吗？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                this.Close();
            }
        }
        #endregion

        private void Window_KeyDown_1(object sender, KeyEventArgs e) {
            if (e.Key == Key.Back) {
                if (MessageBox.Show("您确定要退出本次考试回到试题选择吗？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                    Window examList = new ExamListWindow();
                    examList.Show();
                    this.Close();
                }
            }
            if (e.Key == Key.Escape) {
                if (MessageBox.Show("您确定要退出本程序吗？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                    this.Close();
                }
            }
        }
    }
}
