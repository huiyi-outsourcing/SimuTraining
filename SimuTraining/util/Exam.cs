using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using ExcelLibrary.SpreadSheet;

namespace SimuTraining.util
{
    public class Exam
    {
        private String name;
        private List<Question> questions;

        public Exam(String name)
        {
            this.name = name;    
        }

        public void loadExam()
        {
            string path = Path.GetFullPath("exam/" + name);
            if (File.Exists(path + ".xls"))
                path += ".xls";
            else if (File.Exists(path + ".xlsx"))
                path += ".xlsx";
            else
                throw new FileNotFoundException();

            DataSet ds = new DataSet();

            Workbook book = Workbook.Load(path);
            Worksheet sheet = book.Worksheets[0];

            questions = new List<Question>();
            for (int i = sheet.Cells.FirstRowIndex + 1; i <= sheet.Cells.LastRowIndex; ++i)
            {
                Row row = sheet.Cells.GetRow(i);

                String description = row.GetCell(0).StringValue;
                String correct = row.GetCell(5).StringValue;
                int score = Int32.Parse(row.GetCell(6).StringValue);
                Option A = new Option(row.GetCell(1).StringValue, correct.Equals("A"));
                Option B = new Option(row.GetCell(2).StringValue, correct.Equals("B"));
                Option C = new Option(row.GetCell(3).StringValue, correct.Equals("C"));
                Option D = new Option(row.GetCell(4).StringValue, correct.Equals("D"));

                List<Option> options = new List<Option>();
                options.Add(A);
                options.Add(B);
                options.Add(C);
                options.Add(D);

                Question q = new Question(description, options);
                questions.Add(q);
            }
        }
    }
}
