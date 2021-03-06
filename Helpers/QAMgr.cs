﻿
using DomainObjects;
using System.Collections.Generic;
namespace Helpers
{
    /*
     Future: This class needs to be rewritten as an entire static class. No point for the .Instance property.
     */
    public class QAMgr
    {
        private int _currentQuestionNo = 0;
        private int _exerciseCount = 1;
        private int _questCount = 1;
        private int _failedQuestionCount = 0;
        private string _currentQuestionString;
        private List<AnswerGroup> _answersGroupList;
        private List<int> failedQuestions;
        public static bool isRetaking = false;


        public IEnumerable<AnswerGroup> AnswersGroupList
        {
            get { return _answersGroupList as IEnumerable<AnswerGroup>; }
        }


        private static QAMgr _instance = null;
        private static QADataReader _reader = new QADataReader();
        private Dictionary<int, string> _savedAnswers = new Dictionary<int, string>();

        private QAMgr()
        {

        }

        public static QAMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QAMgr();

                }

                return _instance;
            }
        }

        public Dictionary<int, string> SavedAnswers
        {
            get { return _savedAnswers; }
            set { _savedAnswers = value; }
        }
        public int CurrentQuestionNo
        {
            get { return _currentQuestionNo; }
            set { _currentQuestionNo = value; }
        }

        public int ExerciseCount
        {
            get { return _exerciseCount; }
            set { _exerciseCount = value; }
        }

        public int QuestionCount
        {
            get { return _questCount; }
            set { _questCount = value; }
        }
        public string CurrentQuestionString
        {
            get { return _currentQuestionString; }
            set { _currentQuestionString = value; }
        }

        public void IncrementQuestionCount()
        {
            _questCount++;
        }

        public void DecrementQuestionCount()
        {
            _questCount--;
        }

        public void ResetQuestionCount()
        {
            _questCount = 1;
        }

        public void ResetFailedQuestionCount()
        {
            _failedQuestionCount = 0;
        }

        public void IncreaseExerciseNumber()
        {
            _exerciseCount++;
        }


        public int FailedQuestionCount
        {
            get { return _failedQuestionCount; }
        }


        public List<int> FailedQuestions
        {
            get { return failedQuestions; }
            set { failedQuestions = value; }
        }



        /// <summary>
        /// Uses the Question Count to get the next question
        /// </summary>
        /// <returns></returns>
        public string GetQuestion(int exerciseNumber, int questionNumber)
        {
            _currentQuestionString = _reader.ReadQuestionFromFile(exerciseNumber, questionNumber);
            return _currentQuestionString;
        }

        /// <summary>
        /// Saves the user answer to a dictionary
        /// </summary>
        /// <param name="currentAnswer"></param>
        public void SaveCurrentAnswer(string currentAnswer, int questionNumber)
        {
            if (!_savedAnswers.ContainsKey(questionNumber))
            {
                _savedAnswers.Add(questionNumber, currentAnswer);
            }
            else
            {
                _savedAnswers[questionNumber] = currentAnswer;
            }
        }

        public string GetUserAnswer(int questionNumber)
        {
            if (_savedAnswers.ContainsKey(questionNumber))
            {
                return _savedAnswers[questionNumber];
            }
            return "";
        }

        public string GetCorrectAnswer(int exerciseNumber, int questionNumber)
        {
            return _reader.ReadCorrectAnswerFromFile(exerciseNumber, questionNumber);

        }

        public bool isAnswerCorrect(string userAnswer, int questionNumber)
        {
            string correctAnswer = GetCorrectAnswer(_exerciseCount, questionNumber);
            if (string.Compare(userAnswer, correctAnswer, true) == 0)
            {
                return true;
            }
            return false;
        }

        public void ClearInitAnswerGroupList()
        {
            if (_answersGroupList != null)
            {
                _answersGroupList.Clear();
            }
            _answersGroupList = new List<AnswerGroup>();

        }

        public void VetExercise()
        {
            ClearInitAnswerGroupList();
            failedQuestions = new List<int>();
            foreach (KeyValuePair<int, string> userAnswer in _savedAnswers)
            {
                bool isCorrect = true;
                string question = GetQuestion(_exerciseCount, userAnswer.Key);
                if (!isAnswerCorrect(userAnswer.Value, userAnswer.Key))
                {
                    isCorrect = false;
                    _failedQuestionCount++;
                    failedQuestions.Add(userAnswer.Key);//Store the failed question numbers in a list
                }
                //Create an answer group for display in the AnswerDisplayControl.

                AnswerGroup ag = new AnswerGroup(_exerciseCount, userAnswer.Key, question, userAnswer.Value, isCorrect);
                _answersGroupList.Add(ag);
            }
            _savedAnswers.Clear();
        }

        /// <summary>
        /// Returns a failed question number by array index
        /// </summary>
        /// <param name="arrayIndex"></param>
        /// <returns></returns>
        public int GetNextFailedQuestion(int arrayIndex)
        {
            if (arrayIndex >= 0 && arrayIndex < failedQuestions.ToArray().Length)
            {
                return failedQuestions.ToArray()[arrayIndex];
            }
            return 0;
        }
    }
}
