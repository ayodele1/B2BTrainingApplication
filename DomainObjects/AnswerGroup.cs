
namespace DomainObjects
{
    public class AnswerGroup
    {
        private string _questionString;
        private int _questionNumber;
        private string _answerString;
        private bool _iscorrectAnswer;
        private int _exerciseNumber;

        public AnswerGroup(int exerciseNumber, int questionNo, string question, string answer, bool isCorrect)
        {
            _questionNumber = questionNo;
            _questionString = question;
            _answerString = answer;
            _iscorrectAnswer = isCorrect;
            _exerciseNumber = exerciseNumber;
        }

        public bool IsCorrectAnswer
        {
            get { return _iscorrectAnswer; }
            set { _iscorrectAnswer = value; }
        }

        public string Answer
        {
            get { return _answerString; }
            set { _answerString = value; }
        }

        public int QuestionNumber
        {
            get { return _questionNumber; }
            set { _questionNumber = value; }
        }
        public int ExerciseNumber
        {
            get { return _exerciseNumber; }
            set { _exerciseNumber = value; }
        }

        public string Question
        {
            get { return _questionString; }
            set { _questionString = value; }
        }

    }
}
