namespace Q_Bank_Administration.View
{
    partial class AccountOverview
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
            this.TransactionOverviewSearchButton = new System.Windows.Forms.Button();
            this.TransactionOverviewBalanceLabel = new System.Windows.Forms.Label();
            this.TransactionOverviewAccountsCombobox = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.TransactionOverviewTable = new System.Windows.Forms.TableLayoutPanel();
            this.TransactionOverviewSearchLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TransactionOverviewSearchButton
            // 
            this.TransactionOverviewSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionOverviewSearchButton.Location = new System.Drawing.Point(744, 62);
            this.TransactionOverviewSearchButton.Name = "TransactionOverviewSearchButton";
            this.TransactionOverviewSearchButton.Size = new System.Drawing.Size(75, 23);
            this.TransactionOverviewSearchButton.TabIndex = 12;
            this.TransactionOverviewSearchButton.Text = "Zoeken";
            this.TransactionOverviewSearchButton.UseVisualStyleBackColor = true;
            // 
            // TransactionOverviewBalanceLabel
            // 
            this.TransactionOverviewBalanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionOverviewBalanceLabel.AutoSize = true;
            this.TransactionOverviewBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionOverviewBalanceLabel.Location = new System.Drawing.Point(433, 62);
            this.TransactionOverviewBalanceLabel.Name = "TransactionOverviewBalanceLabel";
            this.TransactionOverviewBalanceLabel.Size = new System.Drawing.Size(98, 20);
            this.TransactionOverviewBalanceLabel.TabIndex = 11;
            this.TransactionOverviewBalanceLabel.Text = "Saldo: €0,00";
            // 
            // TransactionOverviewAccountsCombobox
            // 
            this.TransactionOverviewAccountsCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionOverviewAccountsCombobox.FormattingEnabled = true;
            this.TransactionOverviewAccountsCombobox.Location = new System.Drawing.Point(36, 61);
            this.TransactionOverviewAccountsCombobox.Name = "TransactionOverviewAccountsCombobox";
            this.TransactionOverviewAccountsCombobox.Size = new System.Drawing.Size(363, 21);
            this.TransactionOverviewAccountsCombobox.TabIndex = 10;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(32, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(165, 20);
            this.label23.TabIndex = 9;
            this.label23.Text = "Transactieoverzicht";
            // 
            // TransactionOverviewTable
            // 
            this.TransactionOverviewTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionOverviewTable.AutoScroll = true;
            this.TransactionOverviewTable.BackColor = System.Drawing.Color.Transparent;
            this.TransactionOverviewTable.ColumnCount = 5;
            this.TransactionOverviewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.TransactionOverviewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.TransactionOverviewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.TransactionOverviewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TransactionOverviewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TransactionOverviewTable.Location = new System.Drawing.Point(36, 130);
            this.TransactionOverviewTable.Name = "TransactionOverviewTable";
            this.TransactionOverviewTable.RowCount = 1;
            this.TransactionOverviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 472F));
            this.TransactionOverviewTable.Size = new System.Drawing.Size(883, 472);
            this.TransactionOverviewTable.TabIndex = 13;
            // 
            // TransactionOverviewSearchLabel
            // 
            this.TransactionOverviewSearchLabel.AutoSize = true;
            this.TransactionOverviewSearchLabel.Location = new System.Drawing.Point(42, 96);
            this.TransactionOverviewSearchLabel.Name = "TransactionOverviewSearchLabel";
            this.TransactionOverviewSearchLabel.Size = new System.Drawing.Size(0, 13);
            this.TransactionOverviewSearchLabel.TabIndex = 14;
            // 
            // AccountOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 517);
            this.Controls.Add(this.TransactionOverviewSearchLabel);
            this.Controls.Add(this.TransactionOverviewTable);
            this.Controls.Add(this.TransactionOverviewSearchButton);
            this.Controls.Add(this.TransactionOverviewBalanceLabel);
            this.Controls.Add(this.TransactionOverviewAccountsCombobox);
            this.Controls.Add(this.label23);
            this.Name = "AccountOverview";
            this.Text = "AccountOverview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button TransactionOverviewSearchButton;
        public System.Windows.Forms.Label TransactionOverviewBalanceLabel;
        public System.Windows.Forms.ComboBox TransactionOverviewAccountsCombobox;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.TableLayoutPanel TransactionOverviewTable;
        public System.Windows.Forms.Label TransactionOverviewSearchLabel;
    }
}