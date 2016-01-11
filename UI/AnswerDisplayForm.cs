using DomainObjects;
using Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class AnswerDisplayForm : Form
    {
        private QAMgr QABot = QAMgr.Instance;
        public AnswerDisplayForm()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, EventArgs e)
        {

        }

        private void onFormShown(object sender, EventArgs e)
        {
            TableLayoutPanel tlp = (this.Controls["tableLayoutPanel2"] as TableLayoutPanel);
            _descriptionLabel.Text = "EXERICSE MARKING";
            if (QABot.FailedQuestionCount > 0)
            {
                _continueBtn.Enabled = false;
            }

            foreach (AnswerGroup ag in QABot.AnswersGroupList)
            {
                var questionString = string.Format("Question {0}.{1}: {2}", ag.ExerciseNumber, ag.QuestionNumber, ag.Question);
                var answerString = string.Format("Your Answer: {0}", ag.Answer);

                TextBox tb = AddTextBox(string.Concat(questionString, Environment.NewLine, answerString), ag.IsCorrectAnswer);
                int rowIndex = AddTableRow(tlp);
                tlp.Controls.Add(tb, 0, rowIndex);
                tb.Dock = DockStyle.Top;
            }
        }

        private int AddTableRow(TableLayoutPanel tlp)
        {
            tlp.RowStyles.Clear();
            int index = tlp.RowCount++;
            RowStyle style = new RowStyle(SizeType.AutoSize);
            tlp.RowStyles.Add(style);
            return index;
        }

        private TextBox AddTextBox(string text, bool passedQuestion)
        {
            TextBox tb = new TextBox();
            tb.Height = 40;
            tb.Multiline = true;
            tb.Text = text;
            if (passedQuestion)
            {
                tb.ForeColor = Color.Green;
            }
            else
            {
                tb.ForeColor = Color.Red;
            }
            tb.ReadOnly = true;
            tb.BackColor = Color.White;
            return tb;
        }

        private void onRetake(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
