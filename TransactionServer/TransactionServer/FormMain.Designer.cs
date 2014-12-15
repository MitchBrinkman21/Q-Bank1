namespace TransactionServer
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxChecksum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTransactions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxErrors = new System.Windows.Forms.TextBox();
            this.timerInvalidateForm = new System.Windows.Forms.Timer(this.components);
            this.textBoxQueue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(580, 320);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(303, 111);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start Server";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(12, 320);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(303, 111);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop Server";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBoxChecksum
            // 
            this.textBoxChecksum.Enabled = false;
            this.textBoxChecksum.Location = new System.Drawing.Point(277, 34);
            this.textBoxChecksum.Name = "textBoxChecksum";
            this.textBoxChecksum.ReadOnly = true;
            this.textBoxChecksum.Size = new System.Drawing.Size(606, 31);
            this.textBoxChecksum.TabIndex = 2;
            this.textBoxChecksum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Checksum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Executed transactions";
            // 
            // textBoxTransactions
            // 
            this.textBoxTransactions.Enabled = false;
            this.textBoxTransactions.Location = new System.Drawing.Point(277, 108);
            this.textBoxTransactions.Name = "textBoxTransactions";
            this.textBoxTransactions.ReadOnly = true;
            this.textBoxTransactions.Size = new System.Drawing.Size(606, 31);
            this.textBoxTransactions.TabIndex = 4;
            this.textBoxTransactions.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Errors";
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.Enabled = false;
            this.textBoxErrors.Location = new System.Drawing.Point(277, 145);
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.ReadOnly = true;
            this.textBoxErrors.Size = new System.Drawing.Size(606, 31);
            this.textBoxErrors.TabIndex = 6;
            this.textBoxErrors.Text = "0";
            // 
            // timerInvalidateForm
            // 
            this.timerInvalidateForm.Enabled = true;
            this.timerInvalidateForm.Tick += new System.EventHandler(this.timerInvalidateForm_Tick);
            // 
            // textBoxQueue
            // 
            this.textBoxQueue.Enabled = false;
            this.textBoxQueue.Location = new System.Drawing.Point(277, 71);
            this.textBoxQueue.Name = "textBoxQueue";
            this.textBoxQueue.ReadOnly = true;
            this.textBoxQueue.Size = new System.Drawing.Size(606, 31);
            this.textBoxQueue.TabIndex = 8;
            this.textBoxQueue.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Queue";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 443);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxQueue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxErrors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTransactions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxChecksum);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormMain";
            this.Text = "Transaction Server Q-Bank";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxChecksum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTransactions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxErrors;
        private System.Windows.Forms.Timer timerInvalidateForm;
        private System.Windows.Forms.TextBox textBoxQueue;
        private System.Windows.Forms.Label label4;
    }
}

