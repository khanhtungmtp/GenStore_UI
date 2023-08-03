using System.Text;

namespace GenStore
{
    public partial class LogForm : Form
    {
        private readonly StringBuilder logBuilder = new StringBuilder();
        private object logLock = new object();
        private const int MAX_LOG_BUFFER_SIZE = 5000;

        public LogForm()
        {
            InitializeComponent();
        }

        public void AddLogMessage(string logMessage)
        {
            lock (logLock)
            {
                logBuilder.AppendLine(logMessage);
                if (logBuilder.Length > MAX_LOG_BUFFER_SIZE)
                {
                    FlushLogBuffer();
                }
            }

            if (richTextBoxLog.InvokeRequired)
            {
                BeginInvoke(new Action(FlushLogBuffer));
            }
            else
            {
                FlushLogBuffer();
            }
        }

        private void FlushLogBuffer()
        {
            lock (logLock)
            {
                // Append the new log messages to the existing content in the RichTextBox
                richTextBoxLog.AppendText(logBuilder.ToString());
                logBuilder.Clear();

                // Ensure that the log does not exceed the maximum buffer size
                if (richTextBoxLog.TextLength > MAX_LOG_BUFFER_SIZE)
                {
                    int excessTextLength = richTextBoxLog.TextLength - MAX_LOG_BUFFER_SIZE;
                    richTextBoxLog.Select(0, excessTextLength);
                    richTextBoxLog.SelectedText = "";
                }

                // Scroll to the end to keep the latest log visible
                richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;
                richTextBoxLog.ScrollToCaret();
            }
        }

        // Override the FormClosing event to prevent the form from closing when the "OK" button in the MessageBox is clicked
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Set the Cancel property to true to prevent the form from closing
                Hide();
            }
        }

        public void ClearLog()
        {
            lock (logLock)
            {
                richTextBoxLog.Clear();
                logBuilder.Clear();
            }
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearLog();
        }
    }
}
