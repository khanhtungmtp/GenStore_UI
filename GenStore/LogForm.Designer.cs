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
            lstLog = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(0, 56);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(799, 394);
            lstLog.TabIndex = 0;
            lstLog.SelectedIndexChanged += lstLog_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(317, 9);
            label1.Name = "label1";
            label1.Size = new Size(158, 31);
            label1.TabIndex = 1;
            label1.Text = "GenStore log";
            // 
            // LogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(lstLog);
            Name = "LogForm";
            Text = "LogForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstLog;
        private Label label1;
    }
}