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
            this.label1 = new System.Windows.Forms.Label();
            this.eigenrekeningLabel = new System.Windows.Forms.Label();
            this.Uitvoerdatum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tegenrekeningLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.OmschrijvingBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uitvoerdatumLabel = new System.Windows.Forms.Label();
            this.uitgevoerdedatumLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tegenrekeningNaamLabel = new System.Windows.Forms.Label();
            this.typeTransactieLabel = new System.Windows.Forms.Label();
            this.bedragLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(645, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Details Transactie";
            // 
            // eigenrekeningLabel
            // 
            this.eigenrekeningLabel.AutoSize = true;
            this.eigenrekeningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eigenrekeningLabel.Location = new System.Drawing.Point(153, 84);
            this.eigenrekeningLabel.Name = "eigenrekeningLabel";
            this.eigenrekeningLabel.Size = new System.Drawing.Size(289, 16);
            this.eigenrekeningLabel.TabIndex = 2;
            this.eigenrekeningLabel.Text = "IBAN-NL67 QBAN 0583 9348 91-Betaalrekening";
            // 
            // Uitvoerdatum
            // 
            this.Uitvoerdatum.AutoSize = true;
            this.Uitvoerdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Uitvoerdatum.Location = new System.Drawing.Point(174, 120);
            this.Uitvoerdatum.Name = "Uitvoerdatum";
            this.Uitvoerdatum.Size = new System.Drawing.Size(91, 16);
            this.Uitvoerdatum.TabIndex = 3;
            this.Uitvoerdatum.Text = "Uitvoerdatum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(174, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tegenrekening:";
            // 
            // tegenrekeningLabel
            // 
            this.tegenrekeningLabel.AutoSize = true;
            this.tegenrekeningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tegenrekeningLabel.Location = new System.Drawing.Point(174, 188);
            this.tegenrekeningLabel.Name = "tegenrekeningLabel";
            this.tegenrekeningLabel.Size = new System.Drawing.Size(153, 16);
            this.tegenrekeningLabel.TabIndex = 5;
            this.tegenrekeningLabel.Text = "NL86 INGB 0002 4455 88";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(174, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Type transactie";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(174, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Bedrag:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(174, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Omschrijving:";
            // 
            // OmschrijvingBox
            // 
            this.OmschrijvingBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OmschrijvingBox.Location = new System.Drawing.Point(177, 329);
            this.OmschrijvingBox.Name = "OmschrijvingBox";
            this.OmschrijvingBox.ReadOnly = true;
            this.OmschrijvingBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.OmschrijvingBox.ShortcutsEnabled = false;
            this.OmschrijvingBox.Size = new System.Drawing.Size(413, 162);
            this.OmschrijvingBox.TabIndex = 10;
            this.OmschrijvingBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(174, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Uitgevoerdedatum:";
            // 
            // uitvoerdatumLabel
            // 
            this.uitvoerdatumLabel.AutoSize = true;
            this.uitvoerdatumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uitvoerdatumLabel.Location = new System.Drawing.Point(340, 120);
            this.uitvoerdatumLabel.Name = "uitvoerdatumLabel";
            this.uitvoerdatumLabel.Size = new System.Drawing.Size(72, 16);
            this.uitvoerdatumLabel.TabIndex = 13;
            this.uitvoerdatumLabel.Text = "20-11-2014";
            // 
            // uitgevoerdedatumLabel
            // 
            this.uitgevoerdedatumLabel.AutoSize = true;
            this.uitgevoerdedatumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uitgevoerdedatumLabel.Location = new System.Drawing.Point(340, 145);
            this.uitgevoerdedatumLabel.Name = "uitgevoerdedatumLabel";
            this.uitgevoerdedatumLabel.Size = new System.Drawing.Size(72, 16);
            this.uitgevoerdedatumLabel.TabIndex = 14;
            this.uitgevoerdedatumLabel.Text = "20-11-2014";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(174, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 15;
            this.label11.Text = "Status:";
            // 
            // tegenrekeningNaamLabel
            // 
            this.tegenrekeningNaamLabel.AutoSize = true;
            this.tegenrekeningNaamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tegenrekeningNaamLabel.Location = new System.Drawing.Point(340, 172);
            this.tegenrekeningNaamLabel.Name = "tegenrekeningNaamLabel";
            this.tegenrekeningNaamLabel.Size = new System.Drawing.Size(100, 16);
            this.tegenrekeningNaamLabel.TabIndex = 16;
            this.tegenrekeningNaamLabel.Text = "Belastingdienst";
            // 
            // typeTransactieLabel
            // 
            this.typeTransactieLabel.AutoSize = true;
            this.typeTransactieLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeTransactieLabel.Location = new System.Drawing.Point(340, 220);
            this.typeTransactieLabel.Name = "typeTransactieLabel";
            this.typeTransactieLabel.Size = new System.Drawing.Size(79, 16);
            this.typeTransactieLabel.TabIndex = 17;
            this.typeTransactieLabel.Text = "Bijschrijving";
            // 
            // bedragLabel
            // 
            this.bedragLabel.AutoSize = true;
            this.bedragLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bedragLabel.Location = new System.Drawing.Point(340, 236);
            this.bedragLabel.Name = "bedragLabel";
            this.bedragLabel.Size = new System.Drawing.Size(49, 16);
            this.bedragLabel.TabIndex = 18;
            this.bedragLabel.Text = "€ 72,00";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(340, 268);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(132, 16);
            this.statusLabel.TabIndex = 19;
            this.statusLabel.Text = "Bezig met verwerken";
            // 
            // TransactionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(810, 530);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.bedragLabel);
            this.Controls.Add(this.typeTransactieLabel);
            this.Controls.Add(this.tegenrekeningNaamLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.uitgevoerdedatumLabel);
            this.Controls.Add(this.uitvoerdatumLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OmschrijvingBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tegenrekeningLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Uitvoerdatum);
            this.Controls.Add(this.eigenrekeningLabel);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label eigenrekeningLabel;
        private System.Windows.Forms.Label Uitvoerdatum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tegenrekeningLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox OmschrijvingBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label uitvoerdatumLabel;
        private System.Windows.Forms.Label uitgevoerdedatumLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label tegenrekeningNaamLabel;
        private System.Windows.Forms.Label typeTransactieLabel;
        private System.Windows.Forms.Label bedragLabel;
        private System.Windows.Forms.Label statusLabel;
    }
}