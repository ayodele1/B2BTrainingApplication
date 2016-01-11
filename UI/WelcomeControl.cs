using DomainObjects;
using Helpers;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class WelcomeControl : UserControl
    {
        private bool _firstTimeUser = true;

        private static WelcomeControl _instance;
        public WelcomeControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns a new instance of the control and dynamically adds it to the mainform.
        /// </summary>
        public static WelcomeControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WelcomeControl();
                return _instance;
            }
        }


        private void onLoad(object sender, EventArgs e)
        {
            if (_firstTimeUser)
            {
                _startBtn.Text = "START";
                _emailtextBox.Text = "aawoleye@b2bgateway.net";
            }
            else
            {
                _emailtextBox.Enabled = false;
            }

        }

        private bool ValidateB2BEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.ToLower().Contains("@b2bgateway.net"))
            {
                return false;
            }
            return true;
        }

        private void onLaunchApp(object sender, EventArgs e)
        {
            if (!ValidateB2BEmail(_emailtextBox.Text))
            {
                MessageBoxHelper.Error(this, "Email does not have a valid Format");
                return;
            }
            B2BProgrammer programmer = new B2BProgrammer(_emailtextBox.Text);
            StatusMgr.CurrentProgrammer = programmer;
            LoadControlToView(QAControl.Instance, 0);
        }

        /// <summary>
        /// Dynamically adds a control to the Mainform
        /// </summary>
        /// <param name="controlInstance"></param>
        /// <param name="layoutPanelName"></param>
        private void LoadControlToView(Control controlInstance, int tableLayoutPosition)
        {
            if (!this.ParentForm.Controls.Contains(controlInstance))
            {
                this.Visible = false;
                ((TableLayoutPanel)this.ParentForm.Controls["tableLayoutPanel1"]).Controls.Add(controlInstance, tableLayoutPosition, 0);
                controlInstance.Dock = DockStyle.Fill;
                controlInstance.BringToFront();                
            }
            else
            {
                QAControl.Instance.BringToFront();
            }
        }
    }
}
