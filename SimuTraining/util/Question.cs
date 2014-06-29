using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimuTraining.util
{
    public class Question
    {
        private String description;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private List<Option> options;

        public List<Option> Options
        {
            get { return options; }
            set { options = value; }
        }

        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public enum STATUS
        {
            EMPTY ,
            DONE,
            DOUBT
        }

        private STATUS status;

        public STATUS Status
        {
            get { return status; }
            set { status = value; }
        }

        private int selectedOption;

        public int SelectedOption
        {
            get { return selectedOption; }
            set { selectedOption = value; }
        }

        public Question(String description, List<Option> options)
        {
            this.description = description;
            this.options = options;
            status = STATUS.EMPTY;
            selectedOption = -1;
        }
    }
}
