using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// Displays MessageBox Messages
    /// </summary>
    public static class MessageBoxHelper
    {
        /// <summary>
        /// Displays an Informational MessageBox centered with owner
        /// </summary>
        /// <returns></returns>
        public static DialogResult Info(IWin32Window owner, string format, params object[] args)
        {
            string message = string.Format(format, args);
            return MessageBox.Show(owner, message, MyCompany.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Displays a MessageBox informing user of an error
        /// </summary>
        /// <returns></returns>
        public static DialogResult Error(IWin32Window owner, string format, params object[] args)
        {
            string message = string.Format(format, args);
            return MessageBox.Show(owner, message, MyCompany.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays a formatted message with Yes/No buttons(centered with owner)
        /// </summary>
        /// <returns></returns>
        public static DialogResult QuestionYesNo(IWin32Window owner, string format, params object[] args)
        {
            string message = string.Format(format, args);
            return MessageBox.Show(owner, message, MyCompany.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Displays a formatted message with Yes/No/Cancel buttons(centered with owner)
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DialogResult QuestionYesNoCancel(IWin32Window owner, string format, params object[] args)
        {
            string message = string.Format(format, args);
            return MessageBox.Show(owner, message, MyCompany.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static DialogResult Warning(IWin32Window owner, string format, params object[] args)
        {
            string message = string.Format(format, args);
            return MessageBox.Show(owner, message, MyCompany.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
