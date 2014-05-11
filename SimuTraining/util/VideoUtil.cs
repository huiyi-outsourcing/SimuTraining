using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimuTraining.util
{
    public class VideoUtil
    {
        private static readonly byte[] KEYVALUE = System.Text.Encoding.UTF8.GetBytes("6^)(9-p35@%3#4S!4S0)$Y%%^&5(j.&^&o(*0)$Y%!#O@*GpG@=+@j.&6^)(0-=+");

        public static void encode(String name)
        {   
            if (!File.Exists(name))
            {
                return;
            }

            int size = KEYVALUE.Length;
            FileStream fs = new FileStream(name, FileMode.Open, FileAccess.ReadWrite);
            long exLength = fs.Length;

            byte[] content = new byte[size];
            int result = fs.Read(content, 0, size);
            if (result != -1)
            {
                for (int i = 0; i < size; ++i)
                {
                    byte tmp = content[i];
                    content[i] ^= KEYVALUE[i];
                    byte after = content[i];
                }
            }

            fs.Seek(0, SeekOrigin.Begin);
            fs.Write(content, 0, size);
            fs.Flush();
            fs.Close();
            fs = null;
            GC.Collect();
        }
    }
}
