namespace Q_Bank_Administration.View
{
    partial class CreateAccount
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
            this.labelCreateAccount = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelNameText = new System.Windows.Forms.Label();
            this.comboBoxAccountType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelCreateAccount
            // 
            this.labelCreateAccount.AutoSize = true;
            this.labelCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreateAccount.Location = new System.Drawing.Point(123, 43);
            this.labelCreateAccount.Name = "labelCreateAccount";
            this.labelCreateAccount.Size = new System.Drawing.Size(233, 29);
            this.labelCreateAccount.TabIndex = 1;
            this.labelCreateAccount.Text = "Rekening aanmaken";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(125, 125);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 17);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Naam:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type rekening:";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(417, 248);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(139, 47);
            this.buttonSubmit.TabIndex = 4;
            this.buttonSubmit.Text = "Bevestigen";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            // 
            // labelNameText
            // 
            this.labelNameText.AutoSize = true;
            this.labelNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameText.Location = new System.Drawing.Point(284, 125);
            this.labelNameText.Name = "labelNameText";
            this.labelNameText.Size = new System.Drawing.Size(49, 17);
            this.labelNameText.TabIndex = 5;
            this.labelNameText.Text = "Naam";
            // 
            // comboBoxAccountType
            // 
            this.comboBoxAccountType.FormattingEnabled = true;
            this.comboBoxAccountType.Location = new System.Drawing.Point(284, 172);
            this.comboBoxAccountType.Name = "comboBoxAccountType";
            this.comboBoxAccountType.Size = new System.Drawing.Size(148, 24);
            this.comboBoxAccountType.TabIndex = 6;
            this.comboBoxAccountType.Text = "Kies:";
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 307);
            this.Controls.Add(this.comboBoxAccountType);
            this.Controls.Add(this.labelNameText);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelCreateAccount);
            this.Name = "CreateAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rekening aanmaken";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCreateAccount;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonSubmit;
        public System.Windows.Forms.Label labelNameText;
        public System.Windows.Forms.ComboBox comboBoxAccountType;
    }
}