namespace Q_Bank.View
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
            this.TransactionSearchButtonCancel = new System.Windows.Forms.Button();
            this.TransactionSearchButtonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TransactionSearchCombobox = new System.Windows.Forms.ComboBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.beginDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelBeginDate = new System.Windows.Forms.Label();
            this.TransactionSearchAccountCombobox = new System.Windows.Forms.ComboBox();
            this.orderByLabel = new System.Windows.Forms.Label();
            this.TransactionSearchOrderByCombobobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TransactionSearchButtonCancel
            // 
            this.TransactionSearchButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionSearchButtonCancel.Location = new System.Drawing.Point(244, 239);
            this.TransactionSearchButtonCancel.Name = "TransactionSearchButtonCancel";
            this.TransactionSearchButtonCancel.Size = new System.Drawing.Size(136, 39);
            this.TransactionSearchButtonCancel.TabIndex = 1;
            this.TransactionSearchButtonCancel.Text = "Annuleren";
            this.TransactionSearchButtonCancel.UseVisualStyleBackColor = true;
            this.TransactionSearchButtonCancel.Click += new System.EventHandler(this.TransactionSearchButtonCancel_Click);
            // 
            // TransactionSearchButtonSearch
            // 
            this.TransactionSearchButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionSearchButtonSearch.Location = new System.Drawing.Point(102, 239);
            this.TransactionSearchButtonSearch.Name = "TransactionSearchButtonSearch";
            this.TransactionSearchButtonSearch.Size = new System.Drawing.Size(136, 39);
            this.TransactionSearchButtonSearch.TabIndex = 2;
            this.TransactionSearchButtonSearch.Text = "Zoeken";
            this.TransactionSearchButtonSearch.UseVisualStyleBackColor = true;
            this.TransactionSearchButtonSearch.Click += new System.EventHandler(this.TransactionSearchButtonSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zoeken naar transacties";
            // 
            // TransactionSearchCombobox
            // 
            this.TransactionSearchCombobox.FormattingEnabled = true;
            this.TransactionSearchCombobox.Items.AddRange(new object[] {
            "Zoeken op naam",
            "Zoeken op datum"});
            this.TransactionSearchCombobox.Location = new System.Drawing.Point(44, 67);
            this.TransactionSearchCombobox.Name = "TransactionSearchCombobox";
            this.TransactionSearchCombobox.Size = new System.Drawing.Size(336, 21);
            this.TransactionSearchCombobox.TabIndex = 4;
            this.TransactionSearchCombobox.SelectedIndexChanged += new System.EventHandler(this.TransactionSearchCombobox_SelectedIndexChanged);
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(41, 131);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(55, 13);
            this.labelFirstName.TabIndex = 5;
            this.labelFirstName.Text = "Voornaam";
            this.labelFirstName.UseWaitCursor = true;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(180, 134);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(200, 20);
            this.textBoxFirstName.TabIndex = 6;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(180, 170);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(200, 20);
            this.textBoxLastName.TabIndex = 8;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(41, 167);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(64, 13);
            this.labelLastName.TabIndex = 7;
            this.labelLastName.Text = "Achternaam";
            this.labelLastName.UseWaitCursor = true;
            // 
            // beginDatePicker
            // 
            this.beginDatePicker.Location = new System.Drawing.Point(180, 131);
            this.beginDatePicker.Name = "beginDatePicker";
            this.beginDatePicker.Size = new System.Drawing.Size(200, 20);
            this.beginDatePicker.TabIndex = 9;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(180, 167);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);
            this.endDatePicker.TabIndex = 10;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(41, 167);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(57, 13);
            this.labelEndDate.TabIndex = 12;
            this.labelEndDate.Text = "Einddatum";
            this.labelEndDate.UseWaitCursor = true;
            // 
            // labelBeginDate
            // 
            this.labelBeginDate.AutoSize = true;
            this.labelBeginDate.Location = new System.Drawing.Point(41, 131);
            this.labelBeginDate.Name = "labelBeginDate";
            this.labelBeginDate.Size = new System.Drawing.Size(63, 13);
            this.labelBeginDate.TabIndex = 11;
            this.labelBeginDate.Text = "Begindatum";
            this.labelBeginDate.UseWaitCursor = true;
            // 
            // TransactionSearchAccountCombobox
            // 
            this.TransactionSearchAccountCombobox.FormattingEnabled = true;
            this.TransactionSearchAccountCombobox.Location = new System.Drawing.Point(44, 94);
            this.TransactionSearchAccountCombobox.Name = "TransactionSearchAccountCombobox";
            this.TransactionSearchAccountCombobox.Size = new System.Drawing.Size(336, 21);
            this.TransactionSearchAccountCombobox.TabIndex = 13;
            // 
            // orderByLabel
            // 
            this.orderByLabel.AutoSize = true;
            this.orderByLabel.Location = new System.Drawing.Point(41, 203);
            this.orderByLabel.Name = "orderByLabel";
            this.orderByLabel.Size = new System.Drawing.Size(47, 13);
            this.orderByLabel.TabIndex = 14;
            this.orderByLabel.Text = "Sorteren";
            // 
            // TransactionSearchOrderByCombobobox
            // 
            this.TransactionSearchOrderByCombobobox.FormattingEnabled = true;
            this.TransactionSearchOrderByCombobobox.Items.AddRange(new object[] {
            "Oplopend",
            "Aflopend"});
            this.TransactionSearchOrderByCombobobox.Location = new System.Drawing.Point(180, 203);
            this.TransactionSearchOrderByCombobobox.Name = "TransactionSearchOrderByCombobobox";
            this.TransactionSearchOrderByCombobobox.Size = new System.Drawing.Size(200, 21);
            this.TransactionSearchOrderByCombobobox.TabIndex = 15;
            // 
            // TransactionSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(398, 286);
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
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TransactionSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TransactionSearchButtonCancel;
        private System.Windows.Forms.Button TransactionSearchButtonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelBeginDate;
        public System.Windows.Forms.ComboBox TransactionSearchCombobox;
        public System.Windows.Forms.TextBox textBoxFirstName;
        public System.Windows.Forms.TextBox textBoxLastName;
        public System.Windows.Forms.DateTimePicker beginDatePicker;
        public System.Windows.Forms.DateTimePicker endDatePicker;
        public System.Windows.Forms.ComboBox TransactionSearchAccountCombobox;
        private System.Windows.Forms.Label orderByLabel;
        public System.Windows.Forms.ComboBox TransactionSearchOrderByCombobobox;
    }
}