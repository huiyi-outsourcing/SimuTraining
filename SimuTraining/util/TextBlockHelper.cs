using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SimuTraining.util
{
    public class TextBlockHelper
    {
        public static void formatTextBlock(TextBlock tb, String description)
        {
            String[] paras = description.Split('\n');

            foreach (String item in paras)
            {
                String tmp = item.Trim();

                if (tmp.StartsWith("适用范围："))
                {
                    tb.Inlines.Add(new Bold(new Italic(new Run("        适用范围："))));
                    tb.Inlines.Add(new Run(tmp.Substring(5)));
                }
                else if (tmp.StartsWith("操作方法："))
                {
                    tb.Inlines.Add(new Bold(new Italic(new Run("        操作方法："))));
                    tb.Inlines.Add(new Run(tmp.Substring(5)));
                }
                else if (tmp.StartsWith("要领："))
                {
                    tb.Inlines.Add(new Bold(new Italic(new Run("        要领："))));
                    tb.Inlines.Add(new Run(tmp.Substring(3)));
                }
                else if (tmp.StartsWith("要点："))
                {
                    tb.Inlines.Add(new Bold(new Italic(new Run("        要点："))));
                    tb.Inlines.Add(new Run(tmp.Substring(3)));
                }
                else if (tmp.StartsWith("注意事项："))
                {
                    tb.Inlines.Add(new Bold(new Italic(new Run("        注意事项："))));
                    tb.Inlines.Add(new Run(tmp.Substring(5)));
                }
                else
                { 
                    tb.Inlines.Add(new Run("        " + tmp));
                }
                tb.Inlines.Add(new LineBreak());
            }
        }
    }
}
