namespace Q_Bank_Administration.View
{
    partial class MessageDetails
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
            this.labelMessageSubject = new System.Windows.Forms.Label();
            this.fromUserLabel = new System.Windows.Forms.Label();
            this.datetimeSentLabel = new System.Windows.Forms.Label();
            this.toUserLabel = new System.Windows.Forms.Label();
            this.messageTextbox = new System.Windows.Forms.RichTextBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMessageSubject
            // 
            this.labelMessageSubject.AutoSize = true;
            this.labelMessageSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessageSubject.Location = new System.Drawing.Point(39, 22);
            this.labelMessageSubject.Name = "labelMessageSubject";
            this.labelMessageSubject.Size = new System.Drawing.Size(143, 20);
            this.labelMessageSubject.TabIndex = 2;
            this.labelMessageSubject.Text = "Berichtgegevens";
            // 
            // fromUserLabel
            // 
            this.fromUserLabel.AutoSize = true;
            this.fromUserLabel.Location = new System.Drawing.Point(40, 61);
            this.fromUserLabel.Name = "fromUserLabel";
            this.fromUserLabel.Size = new System.Drawing.Size(26, 13);
            this.fromUserLabel.TabIndex = 3;
            this.fromUserLabel.Text = "Van";
            // 
            // datetimeSentLabel
            // 
            this.datetimeSentLabel.AutoSize = true;
            this.datetimeSentLabel.Location = new System.Drawing.Point(227, 61);
            this.datetimeSentLabel.Name = "datetimeSentLabel";
            this.datetimeSentLabel.Size = new System.Drawing.Size(71, 13);
            this.datetimeSentLabel.TabIndex = 4;
            this.datetimeSentLabel.Text = "DatetimeSent";
            // 
            // toUserLabel
            // 
            this.toUserLabel.AutoSize = true;
            this.toUserLabel.Location = new System.Drawing.Point(40, 87);
            this.toUserLabel.Name = "toUserLabel";
            this.toUserLabel.Size = new System.Drawing.Size(26, 13);
            this.toUserLabel.TabIndex = 5;
            this.toUserLabel.Text = "Aan";
            // 
            // messageTextbox
            // 
            this.messageTextbox.Location = new System.Drawing.Point(43, 103);
            this.messageTextbox.Name = "messageTextbox";
            this.messageTextbox.Size = new System.Drawing.Size(643, 422);
            this.messageTextbox.TabIndex = 6;
            this.messageTextbox.Text = "";
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.Location = new System.Drawing.Point(600, 531);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(86, 39);
            this.ButtonOk.TabIndex = 24;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            // 
            // MessageDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 594);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.messageTextbox);
            this.Controls.Add(this.toUserLabel);
            this.Controls.Add(this.datetimeSentLabel);
            this.Controls.Add(this.fromUserLabel);
            this.Controls.Add(this.labelMessageSubject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelMessageSubject;
        public System.Windows.Forms.Label fromUserLabel;
        public System.Windows.Forms.Label datetimeSentLabel;
        public System.Windows.Forms.Button ButtonOk;
        public System.Windows.Forms.Label toUserLabel;
        public System.Windows.Forms.RichTextBox messageTextbox;

    }
}