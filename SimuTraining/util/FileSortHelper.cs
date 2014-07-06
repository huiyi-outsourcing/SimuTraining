using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SimuTraining.util {
    public enum SortOption { 
        FileName,
        Extension,
        CreationTime
    }

    public class FileSortHelper:IComparer<FileInfo> {
        SortOption   mso;
        public FileSortHelper(SortOption so) {
            mso = so;
        }

        int IComparer<FileInfo>.Compare(FileInfo a, FileInfo b) {
            switch (mso) { 
                case SortOption.FileName:
                    int ia = Int32.Parse(Path.GetFileNameWithoutExtension(a.Name.Substring(2)));
                    int ib = Int32.Parse(Path.GetFileNameWithoutExtension(b.Name.Substring(2)));
                    if (ia > ib) return +1;
                    else if (ia < ib) return -1;
                    else return 0;
                default:
                    break;
            }
            return 0;
        }
    }
}
