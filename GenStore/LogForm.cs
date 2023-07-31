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
        public LogForm()
        {
            InitializeComponent();
        }

        private void lstLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void AddLogMessage(string logMessage)
        {
            lstLog.Items.Add(logMessage);
            lstLog.TopIndex = lstLog.Items.Count - 1;
        }

        public void DisplayExceptions(List<SpException> exceptionList, string outputPhysicalFolder)
        {
            StringBuilder sb = new StringBuilder();

            int i = 1;
            foreach (var e in exceptionList)
            {
                sb.AppendLine($"{DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss")} - EXCEPTION {i} / {exceptionList.Count}: {e.StoreProcedure} - {e.Message}");
                i++;
            }

            // Display the log messages in the ListBox
            AddLogMessage(sb.ToString());

            // Write the exceptions to the log file
            string logFilePath = Path.Combine(outputPhysicalFolder, "GenSP_log.txt");
            File.WriteAllText(logFilePath, sb.ToString());
        }

    }
}
