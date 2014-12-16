namespace Q_Bank.View
{
    partial class TransactionDetails
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
            this.button1 = new System.Windows.Forms.Button();
            this.accountLabel = new System.Windows.Forms.Label();
            this.Uitvoerdatum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.remarkLabel = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datetimeLabel = new System.Windows.Forms.Label();
            this.executeDateLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.fromAccountLabel = new System.Windows.Forms.Label();
            this.transactionTypeLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.transactionStateLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(396, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Afsluiten";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountLabel.Location = new System.Drawing.Point(41, 72);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(66, 16);
            this.accountLabel.TabIndex = 2;
            this.accountLabel.Text = "Rekening";
            // 
            // Uitvoerdatum
            // 
            this.Uitvoerdatum.AutoSize = true;
            this.Uitvoerdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Uitvoerdatum.Location = new System.Drawing.Point(44, 112);
            this.Uitvoerdatum.Name = "Uitvoerdatum";
            this.Uitvoerdatum.Size = new System.Drawing.Size(82, 16);
            this.Uitvoerdatum.TabIndex = 3;
            this.Uitvoerdatum.Text = "Invoerdatum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tegenrekening:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Type transactie";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Bedrag:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(44, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Omschrijving:";
            // 
            // remarkLabel
            // 
            this.remarkLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.remarkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.remarkLabel.Location = new System.Drawing.Point(47, 317);
            this.remarkLabel.Name = "remarkLabel";
            this.remarkLabel.ReadOnly = true;
            this.remarkLabel.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.remarkLabel.ShortcutsEnabled = false;
            this.remarkLabel.Size = new System.Drawing.Size(484, 162);
            this.remarkLabel.TabIndex = 10;
            this.remarkLabel.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Uitvoerdatum:";
            // 
            // datetimeLabel
            // 
            this.datetimeLabel.AutoSize = true;
            this.datetimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimeLabel.Location = new System.Drawing.Point(230, 112);
            this.datetimeLabel.Name = "datetimeLabel";
            this.datetimeLabel.Size = new System.Drawing.Size(82, 16);
            this.datetimeLabel.TabIndex = 13;
            this.datetimeLabel.Text = "Invoerdatum";
            // 
            // executeDateLabel
            // 
            this.executeDateLabel.AutoSize = true;
            this.executeDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeDateLabel.Location = new System.Drawing.Point(230, 137);
            this.executeDateLabel.Name = "executeDateLabel";
            this.executeDateLabel.Size = new System.Drawing.Size(88, 16);
            this.executeDateLabel.TabIndex = 14;
            this.executeDateLabel.Text = "Uitvoerdatum";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(44, 262);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 15;
            this.label11.Text = "Status:";
            // 
            // fromAccountLabel
            // 
            this.fromAccountLabel.AutoSize = true;
            this.fromAccountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromAccountLabel.Location = new System.Drawing.Point(230, 162);
            this.fromAccountLabel.Name = "fromAccountLabel";
            this.fromAccountLabel.Size = new System.Drawing.Size(66, 16);
            this.fromAccountLabel.TabIndex = 16;
            this.fromAccountLabel.Text = "Rekening";
            // 
            // transactionTypeLabel
            // 
            this.transactionTypeLabel.AutoSize = true;
            this.transactionTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionTypeLabel.Location = new System.Drawing.Point(230, 212);
            this.transactionTypeLabel.Name = "transactionTypeLabel";
            this.transactionTypeLabel.Size = new System.Drawing.Size(40, 16);
            this.transactionTypeLabel.TabIndex = 17;
            this.transactionTypeLabel.Text = "Type";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountLabel.Location = new System.Drawing.Point(230, 237);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(53, 16);
            this.amountLabel.TabIndex = 18;
            this.amountLabel.Text = "Bedrag";
            // 
            // transactionStateLabel
            // 
            this.transactionStateLabel.AutoSize = true;
            this.transactionStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionStateLabel.Location = new System.Drawing.Point(230, 262);
            this.transactionStateLabel.Name = "transactionStateLabel";
            this.transactionStateLabel.Size = new System.Drawing.Size(58, 16);
            this.transactionStateLabel.TabIndex = 19;
            this.transactionStateLabel.Text = "Voltooid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Transactiegegevens";
            // 
            // TransactionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(544, 539);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.transactionStateLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.transactionTypeLabel);
            this.Controls.Add(this.fromAccountLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.executeDateLabel);
            this.Controls.Add(this.datetimeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.remarkLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Uitvoerdatum);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TransactionDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.Label Uitvoerdatum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox remarkLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label datetimeLabel;
        private System.Windows.Forms.Label executeDateLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label fromAccountLabel;
        private System.Windows.Forms.Label transactionTypeLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label transactionStateLabel;
        private System.Windows.Forms.Label label2;
    }
}