
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class QAControl : UserControl
    {
        private QAMgr QABot = QAMgr.Instance;
        private AppState _currentAppState;
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

        public AppState ApplicationState
        {
            get { return _currentAppState; }
            set { _currentAppState = value; }
        }


        private void onGoToPreviousQuestion(object sender, EventArgs e)
        {
            _currentAppState.PreviousButtonClicked(_answerRichTextBox.Text);//Simulate the button click according to the current state            
        }

        private void onLoad(object sender, EventArgs e)
        {
            Application.Idle += onIdle;
            _currentAppState = new NormalState(this);
            _currentAppState.Initialize();
        }

        void onIdle(object sender, EventArgs e)
        {
            _prevbutton.Enabled = QABot.QuestionCount > 1;
        }

        private void onGoToNextQuestion(object sender, EventArgs e)
        {
            _currentAppState.NextButtonClicked(_answerRichTextBox.Text);
        }

        public void ClearControls()
        {
            _answerRichTextBox.Clear();
            _questiontextBox.Clear();
        }

        public void setAnswerString(string answerString)
        {
            _answerRichTextBox.Text = answerString;
        }

        public void setQuestionString(string questionString)
        {
            _questiontextBox.Text = questionString;
        }

        public void EnableButton(string buttonName)
        {
            var buttonControls = GetAllButtonControls(this);
            foreach (Control c in buttonControls)
            {
                if (c.Name == buttonName)
                {
                    c.Enabled = true;
                }
            }
        }

        public void DisableButton(string buttonName)
        {
            var buttonControls = GetAllButtonControls(this);
            foreach (Control c in buttonControls)
            {
                if (c.Name == buttonName)
                {
                    c.Enabled = false;
                }
            }
        }

        private IEnumerable<Control> GetAllButtonControls(Control c)
        {
            var controls = c.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllButtonControls(ctrl))
                                      .Concat(controls)
                                      .Where(ctr => ctr.GetType() == typeof(Button));
        }

        private void onSubmitExercise(object sender, EventArgs e)
        {
            _currentAppState.SubmitButtonClicked(_answerRichTextBox.Text);
            QABot.ClearAnswerGroupList();
            QABot.VetExercise();
            DialogResult dr = MessageBoxHelper.QuestionYesNo(this, "Do you want to Submit now?");
            if (dr == DialogResult.No)
            {
                return;
            }
            DisplayExerciseResult();
            //QABot.SaveCurrentAnswer(_answerRichTextBox.Text, QABot.QuestionCount);
            
            if (QABot.FailedQuestionCount > 0)
            {
                //Failed questions have to be retaken, hence::
                _currentAppState = new RetakeState(this);
            }
            //else
            //{

            //    //programmer can continue to next exercise
            //    _currentAppState = new NormalState(this);

            //}
            _currentAppState.Initialize();
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
