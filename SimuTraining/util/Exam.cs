using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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

        public Exam loadExam()
        {
            ExcelHelper helper = new ExcelHelper();
            DataTable dt = helper.LoadExcel("exam/" + name);

            Exam exam = new Exam(name);
            questions = new List<Question>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                String description = dt.Rows[i][0].ToString();
                String correct = dt.Rows[i][5].ToString();
                Option A = new Option(dt.Rows[i][1].ToString(), correct.Equals("A"));
                Option B = new Option(dt.Rows[i][2].ToString(), correct.Equals("B"));
                Option C = new Option(dt.Rows[i][3].ToString(), correct.Equals("C"));
                Option D = new Option(dt.Rows[i][4].ToString(), correct.Equals("D"));

                List<Option> options = new List<Option>();
                options.Add(A);
                options.Add(B);
                options.Add(C);
                options.Add(D);

                Question q = new Question(description, options);
                questions.Add(q);
            }

            return exam;
        }
    }
}
