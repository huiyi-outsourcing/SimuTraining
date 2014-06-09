using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SimuTraining.util
{
    public class RecoveryHelper
    {
        public void performRecovery(String fileLocation)
        {
            VideoUtil.encode(fileLocation);
        }

        public void readLog()
        {
            String[] allLines = File.ReadAllLines("app.log");
            File.Delete("app.log");
            if (allLines.Length == 0)
                return;

            String end = allLines[allLines.Length - 1];

            String []info = end.Split(' ');
            if (info[info.Length - 1].Equals("read"))
            {
                performRecovery(info[info.Length - 2]);
            }
        }


    }
}
