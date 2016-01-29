using DomainObjects;
using Helpers;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        private WelcomeControl _welcomeControl;
        private QAControl _qaControl;
        public MainForm()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, EventArgs e)
        {
            _welcomeControl = WelcomeControl.Instance;
            _qaControl = QAControl.Instance;

            if (!this.Controls.Contains(_welcomeControl))
            {
                this.Controls.Add(_welcomeControl);
                _welcomeControl.Dock = DockStyle.Fill;
                _welcomeControl.BringToFront();
            }
            else
            {
                _welcomeControl.BringToFront();
            }
            LoadControlToView(_qaControl, 0);
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_qaControl.isInitialized())
            {
                onSaveProgress(sender, e);
            }

        }


        /// <summary>
        /// Dynamically adds a control to the Mainform
        /// </summary>
        /// <param name="controlInstance"></param>
        /// <param name="layoutPanelName"></param>
        private void LoadControlToView(Control controlInstance, int tableLayoutPosition)
        {
            if (!this.Controls.Contains(controlInstance))
            {
                //this.Visible = false;
                ((TableLayoutPanel)this.Controls["tableLayoutPanel1"]).Controls.Add(controlInstance, tableLayoutPosition, 0);
                controlInstance.Dock = DockStyle.Fill;
                controlInstance.BringToFront();
            }
            else
            {
                QAControl.Instance.BringToFront();
            }
        }

        private void onExit(object sender, EventArgs e)
        {
            onSaveProgress(sender, e);
            Close();
        }

        private void onSaveProgress(object sender, EventArgs e)
        {
            _qaControl.ApplicationState.SaveAnswer(_qaControl.CurrentAnswer);//Save the last answer before exiting
            AppStateInfo currentStateVariables = QAControl.Instance.ApplicationState.GetCurrentStateVariables();//Get the data to save.
            if (currentStateVariables != null)
            {
                try
                {
                    StatusMgr.SaveCurrrentStateVariables(currentStateVariables);
                    MessageBoxHelper.Info(this, "Progress Saved!");
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Error(this, "Something went Wrong! Your Progress is not Saved" + ex.Message);
                    //Create artificial exit.
                }
            }
        }
    }
}
