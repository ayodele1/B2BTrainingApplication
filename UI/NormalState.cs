using DomainObjects;
using Helpers;
using System;
using System.Windows.Forms;

namespace UI
{
    public class NormalState : IAppState
    {
        QAMgr QABot = QAMgr.Instance;
        QAControl _currentControl;

        public NormalState(Control userControl)
        {
            _currentControl = (userControl as QAControl);
        }

        public void SubmitButtonClicked(string currentAnswerString)
        {
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.QuestionCount);
            QABot.VetExercise();
            if (QABot.FailedQuestionCount > 0)
            {
                //Failed questions have to be retaken, hence::
                _currentControl.ApplicationState = new RetakeState(_currentControl);
            }
            else
            {
                QABot.ExerciseCount++;
            }
        }

        public void InitializeNew()
        {
            _currentControl.EnableButton("_nextbutton");
            _currentControl.setQuestionString(QABot.GetQuestion(QABot.ExerciseCount, QABot.QuestionCount));
            _currentControl.DisableButton("_submitBtn");
            _currentControl.setAnswerString(QABot.GetCorrectAnswer(QABot.ExerciseCount, QABot.QuestionCount));//remember to remove.
        }

        public void NextButtonClicked(string currentAnswerString)
        {


            QABot.SaveCurrentAnswer(currentAnswerString, QABot.QuestionCount);
            if (LoadNewQuestion(QABot.QuestionCount + 1)) { QABot.IncrementQuestionCount(); }//This loads data for the next question
            _currentControl.setAnswerString(QABot.GetCorrectAnswer(QABot.ExerciseCount, QABot.QuestionCount));//for testing purpose!. remember to remove.
        }

        public void PreviousButtonClicked(string currentAnswerString)
        {
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.QuestionCount);
            if (LoadNewQuestion(QABot.QuestionCount - 1)) { QABot.DecrementQuestionCount(); }
        }

        #region private methods

        private bool LoadNewQuestion(int nextQuestionNumber)
        {
            var nextQuestion = QABot.GetQuestion(QABot.ExerciseCount, nextQuestionNumber);
            if (!String.IsNullOrEmpty(nextQuestion))
            {
                _currentControl.ClearControls();
                _currentControl.setQuestionString(nextQuestion);
                _currentControl.EnableButton("_nextbutton");
                _currentControl.setAnswerString(QABot.GetUserAnswer(nextQuestionNumber));
                return true;
            }
            else
            {
                _currentControl.DisableButton("_nextbutton");
                _currentControl.EnableButton("_submitBtn");
                return false;
            }
        }
        #endregion


        /// <summary>
        /// This initializes the state from a saved file
        /// </summary>

        public void InitializeLoad()
        {
            _currentControl.EnableButton("_nextbutton");
            _currentControl.setQuestionString(QABot.GetQuestion(QABot.ExerciseCount, QABot.QuestionCount));
            _currentControl.DisableButton("_submitBtn");
            _currentControl.setAnswerString(QABot.GetCorrectAnswer(QABot.ExerciseCount, QABot.QuestionCount));//remember to remove.
        }


        public AppStateInfo GetCurrentStateVariables()
        {

            return new AppStateInfo(QABot.QuestionCount, QABot.ExerciseCount, QABot.SavedAnswers);
        }

        public override string ToString()
        {
            return "NormalState";
        }

        public void SaveAnswer(string currentAnswerString)
        {
            QABot.SaveCurrentAnswer(currentAnswerString, QABot.QuestionCount);
        }
    }
}
