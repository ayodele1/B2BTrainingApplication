using Helpers;
using System;
using System.Windows.Forms;

namespace UI
{
    public class RetakeState : AppState
    {
        QAMgr QABot = QAMgr.Instance;
        QAControl _currentControl;

        public RetakeState(Control userControl)
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
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.GetFailedQuestion(QABot.QuestionCount - 1));
            QABot.IncrementQuestionCount();
            LoadNewQuestion();

        }

        public void PreviousButtonClicked(string currentAnswerString)
        {
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.GetFailedQuestion(QABot.QuestionCount - 1));
            QABot.DecrementQuestionCount();
            LoadNewQuestion();
        }

        #region private methods
        /// <summary>
        /// Generic method for simulating both the next and prev button clicks
        /// </summary>
        private void LoadNewQuestion()
        {
            if (!String.IsNullOrEmpty(QABot.GetQuestion(QABot.ExerciseCount, QABot.GetFailedQuestion(QABot.QuestionCount - 1))))
            {
                _currentControl.ClearControls();
                _currentControl.setQuestionString(QABot.GetQuestion(QABot.ExerciseCount, QABot.GetFailedQuestion(QABot.QuestionCount - 1)));
                _currentControl.EnableButton("_nextbutton");
            }
            else
            {
                QABot.DecrementQuestionCount(); //This takes care of the "EOF" null value returned
                _currentControl.DisableButton("_nextbutton");
                _currentControl.EnableButton("_submitBtn");
            }
            _currentControl.setAnswerString(QABot.GetUserAnswer(QABot.GetFailedQuestion(QABot.QuestionCount - 1)));
        }

        private void DisplayExerciseResult()
        {
            using (AnswerDisplayForm adf = new AnswerDisplayForm())
            {
                adf.ShowDialog();
            }
            _currentControl.ClearControls();
            QABot.ResetQuestionCount();
            QABot.ResetFailedQuestionCount();
            _currentControl.EnableButton("_nextbutton");
            _currentControl.setQuestionString(QABot.GetQuestion(1, QABot.GetFailedQuestion(QABot.QuestionCount - 1)));
            _currentControl.DisableButton("_submitBtn");

        }
        #endregion
    }
}
