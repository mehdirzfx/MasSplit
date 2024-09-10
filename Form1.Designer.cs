namespace MassSplit
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBrowseInput = new Button();
            btnSaveAs = new Button();
            btnSplit = new Button();
            btnCalculate = new Button();
            btnReset = new Button();
            txtInput = new TextBox();
            txtOutput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            nudThread = new NumericUpDown();
            label3 = new Label();
            groupBox1 = new GroupBox();
            lblElapsed = new Label();
            lblRemaining = new Label();
            label7 = new Label();
            lblThread = new Label();
            label6 = new Label();
            lblNumbers = new Label();
            label5 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudThread).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnBrowseInput
            // 
            btnBrowseInput.Location = new Point(269, 12);
            btnBrowseInput.Name = "btnBrowseInput";
            btnBrowseInput.Size = new Size(34, 23);
            btnBrowseInput.TabIndex = 0;
            btnBrowseInput.Text = "...";
            btnBrowseInput.UseVisualStyleBackColor = true;
            // 
            // btnSaveAs
            // 
            btnSaveAs.Location = new Point(269, 43);
            btnSaveAs.Name = "btnSaveAs";
            btnSaveAs.Size = new Size(34, 23);
            btnSaveAs.TabIndex = 1;
            btnSaveAs.Text = "...";
            btnSaveAs.UseVisualStyleBackColor = true;
            // 
            // btnSplit
            // 
            btnSplit.Location = new Point(208, 72);
            btnSplit.Name = "btnSplit";
            btnSplit.Size = new Size(95, 72);
            btnSplit.TabIndex = 2;
            btnSplit.Text = "Start Split";
            btnSplit.UseVisualStyleBackColor = true;
            btnSplit.Click += btnSplit_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(89, 112);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(109, 32);
            btnCalculate.TabIndex = 3;
            btnCalculate.Text = "Calculate IPs";
            btnCalculate.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(8, 112);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 32);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(76, 12);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(187, 23);
            txtInput.TabIndex = 5;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(76, 43);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(187, 23);
            txtOutput.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 17);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 7;
            label1.Text = "Input IPs : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 46);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 8;
            label2.Text = "Save As : ";
            // 
            // nudThread
            // 
            nudThread.Location = new Point(144, 78);
            nudThread.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudThread.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudThread.Name = "nudThread";
            nudThread.Size = new Size(54, 23);
            nudThread.TabIndex = 9;
            nudThread.Value = new decimal(new int[] { 350, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 82);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 10;
            label3.Text = "Number of Thread : ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblElapsed);
            groupBox1.Controls.Add(lblRemaining);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblThread);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblNumbers);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(9, 152);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 110);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Statistic";
            // 
            // lblElapsed
            // 
            lblElapsed.AutoSize = true;
            lblElapsed.Location = new Point(97, 83);
            lblElapsed.Name = "lblElapsed";
            lblElapsed.Size = new Size(49, 15);
            lblElapsed.TabIndex = 0;
            lblElapsed.Text = "00:00:00";
            // 
            // lblRemaining
            // 
            lblRemaining.AutoSize = true;
            lblRemaining.ForeColor = Color.Red;
            lblRemaining.Location = new Point(97, 43);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(13, 15);
            lblRemaining.TabIndex = 0;
            lblRemaining.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 83);
            label7.Name = "label7";
            label7.Size = new Size(82, 15);
            label7.TabIndex = 0;
            label7.Text = "Elapsed Time :";
            // 
            // lblThread
            // 
            lblThread.AutoSize = true;
            lblThread.Location = new Point(97, 63);
            lblThread.Name = "lblThread";
            lblThread.Size = new Size(25, 15);
            lblThread.TabIndex = 0;
            lblThread.Text = "350";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 43);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 0;
            label6.Text = "Remaining : ";
            // 
            // lblNumbers
            // 
            lblNumbers.AutoSize = true;
            lblNumbers.ForeColor = Color.Green;
            lblNumbers.Location = new Point(97, 23);
            lblNumbers.Name = "lblNumbers";
            lblNumbers.Size = new Size(13, 15);
            lblNumbers.TabIndex = 0;
            lblNumbers.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 63);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 0;
            label5.Text = "Threads : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 23);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 0;
            label4.Text = "All IPs : ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(312, 271);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(nudThread);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtOutput);
            Controls.Add(txtInput);
            Controls.Add(btnReset);
            Controls.Add(btnCalculate);
            Controls.Add(btnSplit);
            Controls.Add(btnSaveAs);
            Controls.Add(btnBrowseInput);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MassSplit ~ Coded By s3nat0r";
            ((System.ComponentModel.ISupportInitialize)nudThread).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBrowseInput;
        private Button btnSaveAs;
        private Button btnSplit;
        private Button btnCalculate;
        private Button btnReset;
        private TextBox txtInput;
        private TextBox txtOutput;
        private Label label1;
        private Label label2;
        private NumericUpDown nudThread;
        private Label label3;
        private GroupBox groupBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label lblElapsed;
        private Label lblRemaining;
        private Label lblThread;
        private Label lblNumbers;
    }
}
