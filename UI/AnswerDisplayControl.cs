using System.Windows.Forms;

namespace UI
{
    public partial class AnswerDisplayControl : UserControl
    {
        private static AnswerDisplayControl _instance;
        public AnswerDisplayControl()
        {
            InitializeComponent();
        }

        public static AnswerDisplayControl Instance
        {
            get
            {
                
                    _instance = new AnswerDisplayControl();
                return _instance;
            }
        }
    }
}
