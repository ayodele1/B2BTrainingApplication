using Helpers;
using System;
using System.Windows.Forms;

namespace UI
{
    public class NormalState : AppState
    {
        QAMgr QABot = QAMgr.Instance;
        QAControl _currentControl;

        public NormalState()
        {

        }

        public NormalState(Control userControl)
        {
            _currentControl = (userControl as QAControl);
        }




        public void SubmitButtonClicked()
        {
            DialogResult dr = MessageBoxHelper.QuestionYesNo(_currentControl, "Do you want to Submit now?");
            if (dr == DialogResult.No)
            {
                return;
            }
            DisplayExerciseResult();
        }

        public void Initialize()
        {
            _currentControl.setQuestionString(QABot.GetQuestion(QABot.ExerciseCount, QABot.QuestionCount));
        }

        public void NextButtonClicked(string currentAnswerString)
        {
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.QuestionCount);
            QABot.IncrementQuestionCount();
            LoadNewQuestion();
        }

        public void PreviousButtonClicked(string currentAnswerString)
        {
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.QuestionCount);
            QABot.DecrementQuestionCount();
            LoadNewQuestion();
        }

        #region private methods

        private void LoadNewQuestion()
        {
            if (!String.IsNullOrEmpty(QABot.GetQuestion(QABot.ExerciseCount, QABot.QuestionCount)))
            {
                _currentControl.ClearControls();
                _currentControl.setQuestionString(QABot.GetQuestion(QABot.ExerciseCount, QABot.QuestionCount));
                _currentControl.EnableButton("_nextbutton");
            }
            else
            {
                QABot.DecrementQuestionCount(); //This takes care of the "EOF" null value returned
                _currentControl.DisableButton("_nextbutton");
                _currentControl.EnableButton("_submitBtn");
            }
            _currentControl.setAnswerString(QABot.GetUserAnswer(QABot.QuestionCount));
        }

        private void DisplayExerciseResult()
        {
            using (AnswerDisplayForm adf = new AnswerDisplayForm())
            {
                adf.ShowDialog();
            }
        }
        #endregion

    }
}
