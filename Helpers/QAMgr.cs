
using DomainObjects;
using System.Collections.Generic;
namespace Helpers
{
    public class QAMgr
    {
        private int _currentQuestionNo = 0;
        private int _exerciseCount = 1;
        private int _questCount = 0;
        private int _failedQuestionCount = 0;
        private string _currentQuestionString;
        private List<AnswerGroup> _answersGroupList;

        public IEnumerable<AnswerGroup> AnswersGroupList
        {
            get { return _answersGroupList as IEnumerable<AnswerGroup>; }
        }


        private static QAMgr _instance = null;
        private static QADataReader _reader = new QADataReader();
        private Dictionary<int, string> savedAnswers = new Dictionary<int, string>();

        private QAMgr()
        {

        }

        public static QAMgr Instance
        {
            //Load the QAMgr as a singleton
            get
            {
                if (_instance == null)
                    _instance = new QAMgr();

                return _instance;
            }
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
            _questCount = 0;
        }

        public void IncreaseExerciseNumber()
        {
            _exerciseCount++;
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
        public void SaveCurrentAnswer(string currentAnswer)
        {
            if (!savedAnswers.ContainsKey(_questCount))
            {
                savedAnswers.Add(_questCount, currentAnswer);
            }
            else
            {
                savedAnswers[_questCount] = currentAnswer;
            }
        }

        public string GetUserAnswer(int questionNumber)
        {
            if (savedAnswers.ContainsKey(questionNumber))
            {
                return savedAnswers[questionNumber];
            }
            return "";
        }

        public string GetCorrectAnswer(int exerciseNumber, int questionNumber)
        {
            return _reader.ReadCorrectAnswerFromFile(exerciseNumber, questionNumber);

        }

        public bool isAnswerCorrect(string userAnswer)
        {
            string correctAnswer = GetCorrectAnswer(_exerciseCount, _questCount);
            if (string.Compare(userAnswer, correctAnswer, true) == 0)
            {
                return true;
            }
            return false;
        }

        public void VetExercise()
        {
            _answersGroupList = new List<AnswerGroup>();
            foreach (KeyValuePair<int, string> userAnswer in savedAnswers)
            {
                bool passString = true;
                string question = GetQuestion(_exerciseCount, userAnswer.Key);
                if (!isAnswerCorrect(userAnswer.Value))
                {
                    passString = false;
                    _failedQuestionCount++;
                }
                //Create an answer group for display in the AnswerDisplayControl.

                AnswerGroup ag = new AnswerGroup(_exerciseCount, userAnswer.Key, question, userAnswer.Value, passString);
                _answersGroupList.Add(ag);
            }
        }
    }
}
