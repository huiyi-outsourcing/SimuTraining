using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using ExcelLibrary.SpreadSheet;

namespace SimuTraining.util {
    public class Exam {
        private String name;

        public String Name {
            get { return name; }
            set { name = value; }
        }
        private List<Question> questions;

        public List<Question> Questions {
            get { return questions; }
            set { questions = value; }
        }

        public Exam(String name) {
            this.name = name;
        }

        public int getScore() {
            int score = 0;
            foreach (Question q in questions) {
                int index = q.SelectedOption;
                if (index == -1)
                    continue;

                if (q.Options[index].Correct) {
                    score += q.Score;
                }
            }

            return score;
        }

        public String getCorrect() {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < questions.Count; ++i) {
                int index = questions[i].SelectedOption;
                if (index == -1)
                    continue;

                if (questions[i].Options[index].Correct) {
                    builder.Append(i + 1 + ", ");
                }
            }

            return builder.ToString();
        }

        public String getWrong() {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < questions.Count; ++i) {
                int index = questions[i].SelectedOption;
                if (index == -1) {
                    builder.Append(i + 1 + ", ");
                    continue;
                }
                if (!questions[i].Options[index].Correct) {
                    builder.Append(i + 1 + ", ");
                }
            }

            return builder.ToString();
        }

        public void loadExam() {
            string path = Path.GetFullPath("exam/" + name);
            if (File.Exists(path + ".xls"))
                path += ".xls";
            else
                throw new FileNotFoundException();

            DataSet ds = new DataSet();

            Workbook book = Workbook.Load(path);
            Worksheet sheet = book.Worksheets[0];

            questions = new List<Question>();
            for (int i = sheet.Cells.FirstRowIndex + 1; i <= sheet.Cells.LastRowIndex; ++i) {
                Row row = sheet.Cells.GetRow(i);

                String description = row.GetCell(0).StringValue;
                String correct = row.GetCell(5).StringValue;
                int score = Int32.Parse(row.GetCell(6).StringValue);
                Option A = new Option("A." + row.GetCell(1).StringValue, correct.Equals("A"));
                Option B = new Option("B." + row.GetCell(2).StringValue, correct.Equals("B"));
                Option C = new Option("C." + row.GetCell(3).StringValue, correct.Equals("C"));
                Option D = new Option("D." + row.GetCell(4).StringValue, correct.Equals("D"));

                List<Option> options = new List<Option>();
                options.Add(A);
                options.Add(B);
                options.Add(C);
                options.Add(D);

                Question q = new Question(description, options, score);
                questions.Add(q);
            }
        }
    }
}
