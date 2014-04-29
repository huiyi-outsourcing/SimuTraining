using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimuTraining.util
{
    public class NameHelper
    {
        private NameHelper() { }

        public static String trim(String name)
        {
            String[] list = name.Split('（', '）', '“', '”');

            String ret = String.Concat(list);

            return ret;
        }
    }
}
