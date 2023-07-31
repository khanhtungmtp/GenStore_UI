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
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ricktxtConStr = new RichTextBox();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(283, 18);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(242, 31);
            label1.TabIndex = 0;
            label1.Text = "Gen Store Procedure";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 166);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(190, 23);
            label2.TabIndex = 1;
            label2.Text = "Connection String (*)";
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(348, 52);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(104, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // ricktxtConStr
            // 
            ricktxtConStr.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ricktxtConStr.Location = new Point(202, 150);
            ricktxtConStr.Name = "ricktxtConStr";
            ricktxtConStr.Size = new Size(570, 62);
            ricktxtConStr.TabIndex = 4;
            ricktxtConStr.Text = "";
            ricktxtConStr.TextChanged += ricktxtConStr_TextChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 365);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(228, 23);
            label3.TabIndex = 5;
            label3.Text = "Namespace (Default: API)";
            label3.Click += label3_Click;
            // 
            // txtNamespace
            // 
            txtNamespace.Location = new Point(276, 362);
            txtNamespace.Name = "txtNamespace";
            txtNamespace.Size = new Size(496, 32);
            txtNamespace.TabIndex = 6;
            txtNamespace.TextChanged += txtNamespace_TextChanged;
            txtNamespace.Enter += txtNamespace_Enter;
            txtNamespace.Leave += txtNamespace_Leave;
            // 
            // txtContext
            // 
            txtContext.Location = new Point(276, 409);
            txtContext.Name = "txtContext";
            txtContext.Size = new Size(496, 32);
            txtContext.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 412);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(264, 23);
            label4.TabIndex = 7;
            label4.Text = "Context (Default: DBContext)";
            // 
            // txtEntityPath
            // 
            txtEntityPath.Location = new Point(276, 456);
            txtEntityPath.Name = "txtEntityPath";
            txtEntityPath.Size = new Size(496, 32);
            txtEntityPath.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 459);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(255, 23);
            label5.TabIndex = 9;
            label5.Text = "Entity path (Default: Models)";
            // 
            // txtSchema
            // 
            txtSchema.Location = new Point(276, 228);
            txtSchema.Name = "txtSchema";
            txtSchema.Size = new Size(496, 32);
            txtSchema.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 231);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(260, 23);
            label6.TabIndex = 11;
            label6.Text = "Schema (+ or Name Store) (*)";
            // 
            // txtPathOutput
            // 
            txtPathOutput.Location = new Point(276, 274);
            txtPathOutput.Name = "txtPathOutput";
            txtPathOutput.Size = new Size(496, 32);
            txtPathOutput.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(4, 277);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(245, 23);
            label7.TabIndex = 13;
            label7.Text = "Path output (Current folder)";
            // 
            // txtNameFileOutPut
            // 
            txtNameFileOutPut.Location = new Point(276, 319);
            txtNameFileOutPut.Name = "txtNameFileOutPut";
            txtNameFileOutPut.Size = new Size(496, 32);
            txtNameFileOutPut.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(4, 322);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(247, 23);
            label8.TabIndex = 15;
            label8.Text = "File name output (Result.cs)";
            // 
            // btnStartGen
            // 
            btnStartGen.Location = new Point(348, 510);
            btnStartGen.Name = "btnStartGen";
            btnStartGen.Size = new Size(132, 39);
            btnStartGen.TabIndex = 17;
            btnStartGen.Text = "Start Gen";
            btnStartGen.UseVisualStyleBackColor = true;
            btnStartGen.Click += btnStartGen_Click;
            // 
            // MainGenSP
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 571);
            Controls.Add(btnStartGen);
            Controls.Add(txtNameFileOutPut);
            Controls.Add(label8);
            Controls.Add(txtPathOutput);
            Controls.Add(label7);
            Controls.Add(txtSchema);
            Controls.Add(label6);
            Controls.Add(txtEntityPath);
            Controls.Add(label5);
            Controls.Add(txtContext);
            Controls.Add(label4);
            Controls.Add(txtNamespace);
            Controls.Add(label3);
            Controls.Add(ricktxtConStr);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "MainGenSP";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gen Store Procedure";
            Load += MainGenSP_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private RichTextBox ricktxtConStr;
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
    }
}