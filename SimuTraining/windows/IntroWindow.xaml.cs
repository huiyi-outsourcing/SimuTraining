using SimuTraining.util;
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
using System.Windows.Shapes;
using System.IO;

namespace SimuTraining.windows
{
    /// <summary>
    /// IntroWindow.xaml 的交互逻辑
    /// </summary>
    public partial class IntroWindow : Window
    {
        public IntroWindow()
        {
            InitializeComponent();

            //web.Source = new Uri("app_intro.html", UriKind.Relative);
            //web.IsTransparent = true;

            //title.Text = "《数字化战（现）场急救技术模拟训练系统 》介绍";
            //TextBlockHelper.formatTitle(title, "《数字化战（现）场急救技术模拟训练系统 》介绍");

            //frame.Source = new Uri("../app_intro.html", UriKind.Relative);
            browser.Navigate(System.IO.Path.GetFullPath("app_intro.html"));
            
            //TextBlockHelper.formatContent(content, "战（现）场急救是我军“急救链”开端，及时有效的战（现）场急救既可以最大限度维持伤（病）员生命、防止再损伤、减轻痛苦，也为后续治疗创造了条件、赢得了时间，对提高抢救成功率、降低死亡率和伤残率意义极大。\n\n及时有效地对伤（病）员实施急救，必须掌握科学的急救知识和方法。为满足部队需求，我们依据《战伤救治规则》、《陆军军事训练与考核大纲》，结合常见损伤、常见危重急症等，精心选编内容，制作了图、文、声、像并茂战（现）场急救技术多媒体教学软件。多媒体教材具有系统性、规范性、交互性强、军事特色鲜明等特点。旨在帮助毫无急救经验的官兵、军校学员迅速掌握科学急救方法，帮助基层卫生人员巩固和提高战（现）场急救水平 。\n\n多媒体教材分“组织指挥”、“基本技术”、“技能应用”、“战术急救装备”等4个章节，共173教学单元，总片长6小时10分30秒。 其中组织指挥介绍了战（现）场急救、突发事件现场医疗救援的“组织与实施” ；基本急救技术详细介绍了各种战（现）场基本急救技术的“适用范围、操作方法、操作要点、注意事项”；技能应用详细介绍了各部位伤、、特殊武器伤、常见危重急症、常见损伤的“判断、急救措施、注意事项”； 战术急救装备详细介绍了新型“战术急救装备的适用” （详见“索引”） 。\n\n章节之间即相互关联，也独立成章。单位或个人即可以根据上级要求进行系统的学习，也可以根据岗位和个人的需求进行选学。 软件可控性强，每个学习单元可单独、反复播放，学习者可根据自己的具体情况控制学习进度。\n\n");
        }

        private void exit_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("您确定要退出本程序吗？", "提醒", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void enter_Click_1(object sender, RoutedEventArgs e)
        {
            IndexWindow index = new IndexWindow(BreadCrumb.getRoot());
            index.Show();
            this.Close();
        }
    }
}
