namespace Q_Bank_Administration.View
{
    partial class TransactionSearch
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
            this.TransactionSearchOrderByCombobobox = new System.Windows.Forms.ComboBox();
            this.orderByLabel = new System.Windows.Forms.Label();
            this.TransactionSearchAccountCombobox = new System.Windows.Forms.ComboBox();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelBeginDate = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.beginDatePicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.TransactionSearchCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TransactionSearchButtonSearch = new System.Windows.Forms.Button();
            this.TransactionSearchButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TransactionSearchOrderByCombobobox
            // 
            this.TransactionSearchOrderByCombobobox.FormattingEnabled = true;
            this.TransactionSearchOrderByCombobobox.Items.AddRange(new object[] {
            "Oplopend",
            "Aflopend"});
            this.TransactionSearchOrderByCombobobox.Location = new System.Drawing.Point(152, 188);
            this.TransactionSearchOrderByCombobobox.Name = "TransactionSearchOrderByCombobobox";
            this.TransactionSearchOrderByCombobobox.Size = new System.Drawing.Size(200, 21);
            this.TransactionSearchOrderByCombobobox.TabIndex = 30;
            // 
            // orderByLabel
            // 
            this.orderByLabel.AutoSize = true;
            this.orderByLabel.Location = new System.Drawing.Point(13, 188);
            this.orderByLabel.Name = "orderByLabel";
            this.orderByLabel.Size = new System.Drawing.Size(47, 13);
            this.orderByLabel.TabIndex = 29;
            this.orderByLabel.Text = "Sorteren";
            // 
            // TransactionSearchAccountCombobox
            // 
            this.TransactionSearchAccountCombobox.FormattingEnabled = true;
            this.TransactionSearchAccountCombobox.Location = new System.Drawing.Point(16, 79);
            this.TransactionSearchAccountCombobox.Name = "TransactionSearchAccountCombobox";
            this.TransactionSearchAccountCombobox.Size = new System.Drawing.Size(336, 21);
            this.TransactionSearchAccountCombobox.TabIndex = 28;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(13, 152);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(57, 13);
            this.labelEndDate.TabIndex = 27;
            this.labelEndDate.Text = "Einddatum";
            this.labelEndDate.UseWaitCursor = true;
            // 
            // labelBeginDate
            // 
            this.labelBeginDate.AutoSize = true;
            this.labelBeginDate.Location = new System.Drawing.Point(13, 116);
            this.labelBeginDate.Name = "labelBeginDate";
            this.labelBeginDate.Size = new System.Drawing.Size(63, 13);
            this.labelBeginDate.TabIndex = 26;
            this.labelBeginDate.Text = "Begindatum";
            this.labelBeginDate.UseWaitCursor = true;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(152, 152);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);
            this.endDatePicker.TabIndex = 25;
            // 
            // beginDatePicker
            // 
            this.beginDatePicker.Location = new System.Drawing.Point(152, 116);
            this.beginDatePicker.Name = "beginDatePicker";
            this.beginDatePicker.Size = new System.Drawing.Size(200, 20);
            this.beginDatePicker.TabIndex = 24;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(152, 155);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(200, 20);
            this.textBoxLastName.TabIndex = 23;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(13, 152);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(64, 13);
            this.labelLastName.TabIndex = 22;
            this.labelLastName.Text = "Achternaam";
            this.labelLastName.UseWaitCursor = true;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(152, 119);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(200, 20);
            this.textBoxFirstName.TabIndex = 21;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(13, 116);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(55, 13);
            this.labelFirstName.TabIndex = 20;
            this.labelFirstName.Text = "Voornaam";
            this.labelFirstName.UseWaitCursor = true;
            // 
            // TransactionSearchCombobox
            // 
            this.TransactionSearchCombobox.FormattingEnabled = true;
            this.TransactionSearchCombobox.Items.AddRange(new object[] {
            "Zoeken op naam",
            "Zoeken op datum"});
            this.TransactionSearchCombobox.Location = new System.Drawing.Point(16, 52);
            this.TransactionSearchCombobox.Name = "TransactionSearchCombobox";
            this.TransactionSearchCombobox.Size = new System.Drawing.Size(336, 21);
            this.TransactionSearchCombobox.TabIndex = 19;
            this.TransactionSearchCombobox.SelectedIndexChanged += new System.EventHandler(this.TransactionSearchCombobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Zoeken naar transacties";
            // 
            // TransactionSearchButtonSearch
            // 
            this.TransactionSearchButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionSearchButtonSearch.Location = new System.Drawing.Point(16, 239);
            this.TransactionSearchButtonSearch.Name = "TransactionSearchButtonSearch";
            this.TransactionSearchButtonSearch.Size = new System.Drawing.Size(136, 39);
            this.TransactionSearchButtonSearch.TabIndex = 17;
            this.TransactionSearchButtonSearch.Text = "Zoeken";
            this.TransactionSearchButtonSearch.UseVisualStyleBackColor = true;
            this.TransactionSearchButtonSearch.Click += new System.EventHandler(this.TransactionSearchButtonSearch_Click);
            // 
            // TransactionSearchButtonCancel
            // 
            this.TransactionSearchButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionSearchButtonCancel.Location = new System.Drawing.Point(216, 239);
            this.TransactionSearchButtonCancel.Name = "TransactionSearchButtonCancel";
            this.TransactionSearchButtonCancel.Size = new System.Drawing.Size(136, 39);
            this.TransactionSearchButtonCancel.TabIndex = 16;
            this.TransactionSearchButtonCancel.Text = "Annuleren";
            this.TransactionSearchButtonCancel.UseVisualStyleBackColor = true;
            this.TransactionSearchButtonCancel.Click += new System.EventHandler(this.TransactionSearchButtonCancel_Click);
            // 
            // TransactionSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 290);
            this.ControlBox = false;
            this.Controls.Add(this.TransactionSearchOrderByCombobobox);
            this.Controls.Add(this.orderByLabel);
            this.Controls.Add(this.TransactionSearchAccountCombobox);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelBeginDate);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.beginDatePicker);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.TransactionSearchCombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TransactionSearchButtonSearch);
            this.Controls.Add(this.TransactionSearchButtonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransactionSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox TransactionSearchOrderByCombobobox;
        private System.Windows.Forms.Label orderByLabel;
        public System.Windows.Forms.ComboBox TransactionSearchAccountCombobox;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelBeginDate;
        public System.Windows.Forms.DateTimePicker endDatePicker;
        public System.Windows.Forms.DateTimePicker beginDatePicker;
        public System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelLastName;
        public System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelFirstName;
        public System.Windows.Forms.ComboBox TransactionSearchCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TransactionSearchButtonSearch;
        private System.Windows.Forms.Button TransactionSearchButtonCancel;

    }
}