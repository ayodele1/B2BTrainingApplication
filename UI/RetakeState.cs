using Helpers;
using System;
using System.Windows.Forms;

namespace UI
{
    public class RetakeState : IAppState
    {
        QAMgr QABot = QAMgr.Instance;
        QAControl _currentControl;
        int count = 0;
        public RetakeState(Control userControl)
        {
            _currentControl = (userControl as QAControl);
        }

        public void SubmitButtonClicked(string currentAnswerString)
        {
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.GetNextFailedQuestion(count));
            QABot.VetExercise();
            if (QABot.FailedQuestionCount < 1)
            {
                //Failed questions have to be retaken, hence::
                _currentControl.ApplicationState = new NormalState(_currentControl);
            }
        }

        public void Initialize()
        {
            _currentControl.ClearControls();
            QABot.ResetQuestionCount();
            QABot.ResetFailedQuestionCount();
            _currentControl.EnableButton("_nextbutton");
            _currentControl.setQuestionString(QABot.GetQuestion(QABot.ExerciseCount, QABot.GetNextFailedQuestion(QABot.QuestionCount - 1)));
            _currentControl.DisableButton("_submitBtn");
            //_currentControl.setQuestionString(QABot.GetQuestion(QABot.ExerciseCount, QABot.QuestionCount));
        }

        public void NextButtonClicked(string currentAnswerString)
        {
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.GetNextFailedQuestion(count));
            //QABot.IncrementQuestionCount();
            if (LoadNewQuestion(QABot.GetNextFailedQuestion(count + 1))) { QABot.IncrementQuestionCount(); count++; }

        }

        public void PreviousButtonClicked(string currentAnswerString)
        {
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.GetNextFailedQuestion(count));
            //QABot.DecrementQuestionCount();
            if (LoadNewQuestion(QABot.GetNextFailedQuestion(count - 1))) { QABot.DecrementQuestionCount(); count--; }
        }

        #region private methods
        /// <summary>
        /// Generic method for simulating both the next and prev button clicks
        /// </summary>
        private bool LoadNewQuestion(int nextQuestionNumber)
        {
            if (nextQuestionNumber > 0 && !String.IsNullOrEmpty(QABot.GetQuestion(QABot.ExerciseCount, nextQuestionNumber)))
            {
                _currentControl.ClearControls();
                _currentControl.setQuestionString(QABot.GetQuestion(QABot.ExerciseCount, nextQuestionNumber));
                _currentControl.EnableButton("_nextbutton");
                _currentControl.setAnswerString(QABot.GetUserAnswer(nextQuestionNumber));
                return true;
            }
            else
            {
                //QABot.DecrementQuestionCount(); //This takes care of the "EOF" null value returned
                _currentControl.DisableButton("_nextbutton");
                _currentControl.EnableButton("_submitBtn");
                return false;
            }
        }
        #endregion
    }
}
