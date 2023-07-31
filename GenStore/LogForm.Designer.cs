namespace GenStore
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            lstLog = new ListBox();
            SuspendLayout();
            // 
            // lstLog
            // 
            resources.ApplyResources(lstLog, "lstLog");
            lstLog.FormattingEnabled = true;
            lstLog.Name = "lstLog";
            lstLog.SelectedIndexChanged += lstLog_SelectedIndexChanged;
            // 
            // LogForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lstLog);
            Name = "LogForm";
            WindowState = FormWindowState.Maximized;
            FormClosed += LogForm_FormClosed;
            Load += LogForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstLog;
    }
}