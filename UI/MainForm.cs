using System;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, EventArgs e)
        {

            if (!this.Controls.Contains(WelcomeControl.Instance))
            {
                this.Controls.Add(WelcomeControl.Instance);
                WelcomeControl.Instance.Dock = DockStyle.Fill;
                WelcomeControl.Instance.BringToFront();
            }
            else
            {
                WelcomeControl.Instance.BringToFront();
            }
        }
    }
}
