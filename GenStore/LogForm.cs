using GenStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenStore
{
    public partial class LogForm : Form
    {
        private BindingList<string> logMessages = new BindingList<string>();

        public LogForm()
        {
            InitializeComponent();
            lstLog.DataSource = logMessages;
        }

        public void AddLogMessage(string message)
        {
            // Add the log message to the BindingList
            logMessages.Add(message);
            // Scroll to the last item in the ListBox
            lstLog.SelectedIndex = logMessages.Count - 1;
        }

        // Override the FormClosing event to prevent the form from closing when the "OK" button in the MessageBox is clicked
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                logMessages.Clear();
                e.Cancel = true; // Set the Cancel property to true to prevent the form from closing
                Hide(); // Hide the form instead of closing it
            }
        }

        private void lstLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clear the log messages when the form is closing
            logMessages.Clear();
        }

        public void ClearLog()
        {
            // Clear the log messages
            logMessages.Clear();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            // Lấy kích thước màn hình của hiển thị form
            Rectangle screenSize = Screen.FromControl(this).Bounds;
            // Thiết lập kích thước form phù hợp với màn hình
            this.Size = new Size(screenSize.Width, screenSize.Height);
            // CenterToScreen();
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Clear the log messages when the form is closing
            logMessages.Clear();
        }
    }
}
