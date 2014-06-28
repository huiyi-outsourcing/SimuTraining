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

        public Question(String description, List<Option> options)
        {
            this.description = description;
            this.options = options;
        }
    }
}
