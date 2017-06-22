using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    public class Questions
    {
        public int ID { get; set; }
        public string Question { get; set; }

       
    }

    public class SubQuestions
    {
        public int SubQuestionID { get; set; }
        public string SubQuestion { get; set; }

        public int QuestionID { get; set; }

    }
}
