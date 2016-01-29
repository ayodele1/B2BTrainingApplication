
using DomainObjects;
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
        private IAppState _currentAppState;
        private string _currentAnswer = string.Empty;
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

        public bool isInitialized()
        {
            if (this != null)
                return true;
            return false;
        }

        public IAppState ApplicationState
        {
            get { return _currentAppState; }
            set { _currentAppState = value; }
        }

        public String CurrentAnswer
        {
            get { return _answerRichTextBox.Text; }
        }


        private void onGoToPreviousQuestion(object sender, EventArgs e)
        {
            _currentAppState.PreviousButtonClicked(_answerRichTextBox.Text);//Simulate the button click according to the current state            
        }

        private void onLoad(object sender, EventArgs e)
        {
            Application.Idle += onIdle;
            AppStateInfo _savedStateData = StatusMgr.LoadSavedStateVariables();
            if (_savedStateData != null)
            {
                InitializeLoadedState(_savedStateData);
            }
            else
            {
                _currentAppState = new NormalState(this);//Application starts in the normal state for new user.
                _currentAppState.InitializeNew();
            }
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
            DialogResult dr = MessageBoxHelper.QuestionYesNo(this, "Do you want to Submit now?");
            if (dr == DialogResult.No)
            {
                return;
            }
            DisplayExerciseResult();
            //QABot.SaveCurrentAnswer(_answerRichTextBox.Text, QABot.QuestionCount);
            this.ClearControls();
            QABot.ResetQuestionCount();
            QABot.ResetFailedQuestionCount();
            _currentAppState.InitializeNew();
        }

        private void DisplayExerciseResult()
        {
            using (AnswerDisplayForm adf = new AnswerDisplayForm())
            {
                adf.ShowDialog();
            }
        }

        private void InitializeLoadedState(AppStateInfo loadedState)
        {
            if (string.Compare(loadedState.CurrentState, "RetakeState") == 0)
            {
                _currentAppState = new RetakeState(this);
                QABot.FailedQuestions = loadedState.FailedQuestionsList;
            }
            else if (string.Compare(loadedState.CurrentState, "NormalState") == 0)
            {
                _currentAppState = new NormalState(this);
            }
            QABot.ExerciseCount = loadedState.CurrentExerciseNo;
            QABot.QuestionCount = loadedState.CurrentQuestionNo;
            QABot.SavedAnswers = loadedState.SavedAnswers;
            _currentAppState.InitializeNew();
        }

    }
}
