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
        int total = 0;
        private bool isLoading;
        bool isEnable = true;
        public ICommand OutputAgeCommand { get; private set; }
        public string SelectedItemText { get; private set; }
      

        Questions question = new Questions();
        List<Questions> lstQuestion = new List<Questions>();
        SubQuestions subQuestions = new SubQuestions();
        List<SubQuestions> lstSubQuestion = new List<SubQuestions>();
        List<SubQuestions> lstSubQuestionStore = new List<SubQuestions>();

        public QuestionViewModel()
        {
            IsLoading = true;
            BindList();
            isEnable = true;
            Question = lstQuestion[0];
            Total = 0;
            LstSubQuestion = lstSubQuestionStore.Where(a => a.QuestionID == 0).ToList();
            NextCommand = new Command(ExecuteNext);
            OutputAgeCommand = new Command<SubQuestions>(OutputAge);
            IsLoading = false;
        }

        void OutputAge(SubQuestions subQuestion)
        {

            SelectedItemText = string.Format("{0} ", subQuestion.SubQuestionID);
            OnPropertyChanged("SelectedItemText");

            LstSubQuestion = lstSubQuestionStore.Where(a => a.QuestionID == subQuestion.QuestionID).ToList();
            foreach (var item in LstSubQuestion)
            {
                if (item.SubQuestionID == 2 && item.SubQuestionID == subQuestion.SubQuestionID)
                {
                    Total = Total + 1;
                    item.CellColor = Color.Green;
                }
                else if (item.SubQuestionID == subQuestion.SubQuestionID)
                {
                    item.CellColor = Color.Blue;
                }
                else if (item.SubQuestionID == 2)
                {
                    item.CellColor = Color.Red;
                }
            }

            IsEnable = false;
        }

        void ExecuteNext()
        {
            IsEnable = true;
            if (IsLoading) return;
            IsLoading = true;
            
            Index += 1;
            if (Index < 20)
            {
                Question = lstQuestion[index];
                LstSubQuestion = lstSubQuestionStore.Where(a => a.QuestionID == index).ToList();
            }

            IsLoading = false;

        }

        private void BindList()
        {
            for (int i = 0; i < 20; i++)
            {
                question = new Questions();
                question.ID = i;
                question.Question = "Test" + i.ToString();
                lstQuestion.Add(question);

                for (int j = 0; j < 3; j++)
                {
                    subQuestions = new SubQuestions();
                    subQuestions.QuestionID = i;
                    subQuestions.SubQuestion = "Sub Test" + j + "Of " + i;
                    subQuestions.SubQuestionID = j;
                    subQuestions.CellColor = Color.White;
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

        public int Total
        {
            private set
            {
                SetProperty(ref total, value);
            }
            get
            {
                return total;
            }
        }
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                SetProperty(ref isLoading, value);
            }
        }

        public bool IsEnable
        {
            private set
            {
                SetProperty(ref isEnable, value);
            }
            get
            {
                return isEnable;
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
