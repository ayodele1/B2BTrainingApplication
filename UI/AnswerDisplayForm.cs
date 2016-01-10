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


            foreach (AnswerGroup ag in QABot.AnswersGroupList)
            {

                var questionString = string.Format("Question {0}.{1}: {2}", ag.ExerciseNumber, ag.QuestionNumber, ag.Question);
                var answerString = string.Format("Your Answer: {0}", ag.Answer);

                TextBox tb = AddTextBox(string.Concat(questionString, Environment.NewLine, answerString));
                int rowIndex = AddTableRow();
                TableLayoutPanel tlp = (this.Controls["tableLayoutPanel2"] as TableLayoutPanel);
                tlp.Controls.Add(tb, 0, rowIndex);

                //tlp.RowCount++;
                tb.Dock = DockStyle.Top;
            }
        }

        private int AddTableRow()
        {
            TableLayoutPanel tlp = (this.Controls["tableLayoutPanel2"] as TableLayoutPanel);
            tlp.RowStyles.Clear();
            int index = tlp.RowCount++;
            RowStyle style = new RowStyle(SizeType.AutoSize);
            tlp.RowStyles.Add(style);
            //detailTable.RowStyles.Add(style);
            return index;
        }

        private TextBox AddTextBox(string text)
        {
            TextBox tb = new TextBox();
            tb.Height = 40;
            tb.Multiline = true;
            tb.Enabled = false;
            tb.BackColor = Color.White;
            tb.Text = text;
            return tb;
        }
    }
}
