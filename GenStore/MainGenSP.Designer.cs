namespace GenStore
{
    partial class MainGenSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGenSP));
            label1 = new Label();
            lbNameConnectionString = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            txtNamespace = new TextBox();
            txtContext = new TextBox();
            label4 = new Label();
            txtEntityPath = new TextBox();
            label5 = new Label();
            txtSchema = new TextBox();
            label6 = new Label();
            txtPathOutput = new TextBox();
            label7 = new Label();
            txtNameFileOutPut = new TextBox();
            label8 = new Label();
            btnStartGen = new Button();
            tabConnection = new TabControl();
            tabMain = new TabPage();
            comboBoxConnectionStrings = new ComboBox();
            tabLog = new TabPage();
            richTextBoxLog = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabConnection.SuspendLayout();
            tabMain.SuspendLayout();
            tabLog.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(247, 9);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(242, 31);
            label1.TabIndex = 0;
            label1.Text = "Gen Store Procedure";
            // 
            // lbNameConnectionString
            // 
            lbNameConnectionString.AutoSize = true;
            lbNameConnectionString.Location = new Point(5, 12);
            lbNameConnectionString.Margin = new Padding(5, 0, 5, 0);
            lbNameConnectionString.Name = "lbNameConnectionString";
            lbNameConnectionString.Size = new Size(244, 23);
            lbNameConnectionString.TabIndex = 1;
            lbNameConnectionString.Text = "Name Connection String (*)";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(312, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(104, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 193);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(228, 23);
            label3.TabIndex = 9;
            label3.Text = "Namespace (Default: API)";
            // 
            // txtNamespace
            // 
            txtNamespace.Location = new Point(272, 190);
            txtNamespace.Name = "txtNamespace";
            txtNamespace.Size = new Size(450, 32);
            txtNamespace.TabIndex = 10;
            // 
            // txtContext
            // 
            txtContext.Location = new Point(272, 237);
            txtContext.Name = "txtContext";
            txtContext.Size = new Size(450, 32);
            txtContext.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 240);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(264, 23);
            label4.TabIndex = 11;
            label4.Text = "Context (Default: DBContext)";
            // 
            // txtEntityPath
            // 
            txtEntityPath.Location = new Point(272, 284);
            txtEntityPath.Name = "txtEntityPath";
            txtEntityPath.Size = new Size(450, 32);
            txtEntityPath.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 287);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(255, 23);
            label5.TabIndex = 13;
            label5.Text = "Entity path (Default: Models)";
            // 
            // txtSchema
            // 
            txtSchema.Location = new Point(272, 56);
            txtSchema.Name = "txtSchema";
            txtSchema.PlaceholderText = "nameStore";
            txtSchema.Size = new Size(450, 32);
            txtSchema.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 59);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(222, 23);
            label6.TabIndex = 3;
            label6.Text = "Schema (GetAll if empty)";
            // 
            // txtPathOutput
            // 
            txtPathOutput.Location = new Point(272, 102);
            txtPathOutput.Name = "txtPathOutput";
            txtPathOutput.Size = new Size(450, 32);
            txtPathOutput.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 105);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(245, 23);
            label7.TabIndex = 5;
            label7.Text = "Path output (Current folder)";
            // 
            // txtNameFileOutPut
            // 
            txtNameFileOutPut.Location = new Point(272, 147);
            txtNameFileOutPut.Name = "txtNameFileOutPut";
            txtNameFileOutPut.Size = new Size(450, 32);
            txtNameFileOutPut.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 150);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(247, 23);
            label8.TabIndex = 7;
            label8.Text = "File name output (Result.cs)";
            // 
            // btnStartGen
            // 
            btnStartGen.Location = new Point(308, 323);
            btnStartGen.Name = "btnStartGen";
            btnStartGen.Size = new Size(132, 39);
            btnStartGen.TabIndex = 15;
            btnStartGen.Text = "Start Gen";
            btnStartGen.UseVisualStyleBackColor = true;
            btnStartGen.Click += btnStartGen_Click;
            // 
            // tabConnection
            // 
            tabConnection.Controls.Add(tabMain);
            tabConnection.Controls.Add(tabLog);
            tabConnection.Location = new Point(0, 135);
            tabConnection.Name = "tabConnection";
            tabConnection.SelectedIndex = 0;
            tabConnection.Size = new Size(741, 406);
            tabConnection.TabIndex = 16;
            // 
            // tabMain
            // 
            tabMain.Controls.Add(comboBoxConnectionStrings);
            tabMain.Controls.Add(lbNameConnectionString);
            tabMain.Controls.Add(label3);
            tabMain.Controls.Add(btnStartGen);
            tabMain.Controls.Add(txtNamespace);
            tabMain.Controls.Add(txtNameFileOutPut);
            tabMain.Controls.Add(label4);
            tabMain.Controls.Add(label8);
            tabMain.Controls.Add(txtContext);
            tabMain.Controls.Add(txtPathOutput);
            tabMain.Controls.Add(label5);
            tabMain.Controls.Add(label7);
            tabMain.Controls.Add(txtEntityPath);
            tabMain.Controls.Add(txtSchema);
            tabMain.Controls.Add(label6);
            tabMain.Location = new Point(4, 32);
            tabMain.Name = "tabMain";
            tabMain.Padding = new Padding(3);
            tabMain.Size = new Size(733, 370);
            tabMain.TabIndex = 0;
            tabMain.Text = "Connection";
            tabMain.UseVisualStyleBackColor = true;
            // 
            // comboBoxConnectionStrings
            // 
            comboBoxConnectionStrings.FormattingEnabled = true;
            comboBoxConnectionStrings.Location = new Point(272, 9);
            comboBoxConnectionStrings.Name = "comboBoxConnectionStrings";
            comboBoxConnectionStrings.Size = new Size(450, 31);
            comboBoxConnectionStrings.TabIndex = 16;
            comboBoxConnectionStrings.SelectedIndexChanged += comboBoxConnectionStrings_SelectedIndexChanged;
            // 
            // tabLog
            // 
            tabLog.Controls.Add(richTextBoxLog);
            tabLog.Location = new Point(4, 24);
            tabLog.Name = "tabLog";
            tabLog.Padding = new Padding(3);
            tabLog.Size = new Size(733, 378);
            tabLog.TabIndex = 1;
            tabLog.Text = "Log";
            tabLog.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            richTextBoxLog.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxLog.Location = new Point(-2, 0);
            richTextBoxLog.Name = "richTextBoxLog";
            richTextBoxLog.ReadOnly = true;
            richTextBoxLog.Size = new Size(735, 371);
            richTextBoxLog.TabIndex = 0;
            richTextBoxLog.Text = "";
            // 
            // MainGenSP
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 538);
            Controls.Add(tabConnection);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainGenSP";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gen Store Procedure";
            Load += MainGenSP_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabConnection.ResumeLayout(false);
            tabMain.ResumeLayout(false);
            tabMain.PerformLayout();
            tabLog.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbNameConnectionString;
        private PictureBox pictureBox1;
        private Label label3;
        private TextBox txtNamespace;
        private TextBox txtContext;
        private Label label4;
        private TextBox txtEntityPath;
        private Label label5;
        private TextBox txtSchema;
        private Label label6;
        private TextBox txtPathOutput;
        private Label label7;
        private TextBox txtNameFileOutPut;
        private Label label8;
        private Button btnStartGen;
        private TabControl tabConnection;
        private TabPage tabMain;
        private TabPage tabLog;
        private RichTextBox richTextBoxLog;
        private ComboBox comboBoxConnectionStrings;
    }
}