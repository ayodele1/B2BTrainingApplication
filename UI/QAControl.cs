
using Helpers;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class QAControl : UserControl
    {
        private QAMgr QABot = QAMgr.Instance;
        public QAControl()
        {
            InitializeComponent();
        }

        private static QAControl _instance;

        public static QAControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QAControl();
                return _instance;
            }
        }

        private void onGoToPreviousQuestion(object sender, EventArgs e)
        {
            LoadNewQuestion(sender);
        }

        private void onLoad(object sender, EventArgs e)
        {
            Application.Idle += onIdle;
            QABot.IncrementQuestionCount();
            _questiontextBox.Text = QABot.GetQuestion(QABot.ExerciseCount, QABot.QuestionCount);
        }

        void onIdle(object sender, EventArgs e)
        {
            _prevbutton.Enabled = QABot.QuestionCount > 1;
        }

        private void onGoToNextQuestion(object sender, EventArgs e)
        {
            LoadNewQuestion(sender);
        }

        private void ClearControls()
        {
            _answerRichTextBox.Clear();
            _questiontextBox.Clear();
        }

        /// <summary>
        /// Template method to simulate the previous and next button click
        /// </summary>
        /// <param name="buttonPressed"></param>
        private void LoadNewQuestion(object buttonPressed)
        {
            QABot.SaveCurrentAnswer(_answerRichTextBox.Text);
            if (((Button)buttonPressed).Text.Equals("NEXT"))
            {
                QABot.IncrementQuestionCount();
            }
            else if (((Button)buttonPressed).Text.Equals("PREV"))
            {
                QABot.DecrementQuestionCount();
            }

            if (!String.IsNullOrEmpty(QABot.GetQuestion(QABot.ExerciseCount, QABot.QuestionCount)))
            {
                ClearControls();
                _questiontextBox.Text = QABot.GetQuestion(QABot.ExerciseCount, QABot.QuestionCount);
                _nextbutton.Enabled = true;
            }
            else
            {
                QABot.DecrementQuestionCount(); //This takes care of the "EOF" null value returned
                _nextbutton.Enabled = false;
            }
            _answerRichTextBox.Text = QABot.GetUserAnswer(QABot.QuestionCount);
        }

        private void onSubmitExercise(object sender, EventArgs e)
        {
            DialogResult dr = MessageBoxHelper.QuestionYesNo(this, "Do you want to Submit now?");
            if (dr == DialogResult.No)
                return;
            QABot.VetExercise();
            DisplayExerciseResult();
        }

        private void DisplayExerciseResult()
        {
            using (AnswerDisplayForm adf = new AnswerDisplayForm())
            {
                adf.ShowDialog();
            }
        }
    }
}
