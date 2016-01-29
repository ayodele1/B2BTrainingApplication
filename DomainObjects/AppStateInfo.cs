using System;
using System.Collections.Generic;

namespace DomainObjects
{
    /// <summary>
    /// This class represents a data object to Save the state of the application before closing the file
    /// </summary>
    [Serializable]
    public class AppStateInfo
    {
        private int _currentQuestionNo;

        private int _currentExerciseNo;

        private List<int> _failedQuestionsList;

        private Dictionary<int, string> _savedAnswers;

        private string _currentState = string.Empty;

        public AppStateInfo(int currentquestionnumber, int currentexercisenumber, List<int> failedquestionsList, Dictionary<int, string> savedanswers)
        {
            //Retake state would Invoke this method
            _currentExerciseNo = currentexercisenumber;
            _currentQuestionNo = currentquestionnumber;
            _failedQuestionsList = failedquestionsList;
            _savedAnswers = savedanswers;
            _currentState = "RetakeState";
        }

        public AppStateInfo(int currentquestionnumber, int currentexercisenumber, Dictionary<int, string> savedanswers)
        {
            //Normal State would invoke this since there would be no failed questions.
            _currentExerciseNo = currentexercisenumber;
            _currentQuestionNo = currentquestionnumber;
            _savedAnswers = savedanswers;
            _currentState = "NormalState";//Determines what state the App would be in when loaded.
        }

        public Dictionary<int, string> SavedAnswers
        {
            get { return _savedAnswers; }
            set { _savedAnswers = value; }
        }


        public List<int> FailedQuestionsList
        {
            get { return _failedQuestionsList; }
            set { _failedQuestionsList = value; }
        }


        public int CurrentExerciseNo
        {
            get { return _currentExerciseNo; }
            set { _currentExerciseNo = value; }
        }

        public int CurrentQuestionNo
        {
            get { return _currentQuestionNo; }
            set { _currentQuestionNo = value; }
        }

        public string CurrentState
        {
            get { return _currentState; }

        }



    }
}
