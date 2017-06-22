using FormsBook.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstApp
{
    class QuestionViewModel : ViewModelBase
    {
        public ICommand NextCommand { private set; get; }
        public ICommand PreCommand { private set; get; }
        int index = 0;

        Questions question = new Questions();
        List<Questions> lstQuestion = new List<Questions>();
        SubQuestions subQuestions = new SubQuestions();
        List<SubQuestions> lstSubQuestion = new List<SubQuestions>();
        List<SubQuestions> lstSubQuestionStore = new List<SubQuestions>();
        public QuestionViewModel()
        {
            BindList();
            Question = lstQuestion[0];
            LstSubQuestion = lstSubQuestionStore.Where(a => a.QuestionID == 0).ToList();
            NextCommand = new Command(ExecuteNext);
        }

        void ExecuteNext()
        {
            Index += 1;
            if (Index < 20)
            {
                Question = lstQuestion[index];
                LstSubQuestion = lstSubQuestionStore.Where(a => a.QuestionID == index).ToList();
            }

        }

        private void BindList()
        {
            for (int i = 0; i < 20; i++)
            {
                question = new Questions();
                question.ID = i;
                question.Question = "Test" + i.ToString();
                lstQuestion.Add(question);

                for (int j  = 0; j < 2; j++)
                {
                    subQuestions = new SubQuestions();
                    subQuestions.QuestionID = i;
                    subQuestions.SubQuestion = "Sub Test" + j + "Of "+i;
                    subQuestions.SubQuestionID = j;
                    lstSubQuestionStore.Add(subQuestions);
                }
                
            }
        }

        public int Index
        {
            private set
            {
                SetProperty(ref index, value);
            }
            get
            {
                return index;
            }
        }


        public Questions Question
        {
            private set
            {
                SetProperty(ref question, value);
            }
            get
            {
                return question;
            }
        }

        public List<SubQuestions> LstSubQuestion
        {
            private set
            {
                SetProperty(ref lstSubQuestion, value);
            }
            get
            {
                return lstSubQuestion;
            }
        }


    }
}
