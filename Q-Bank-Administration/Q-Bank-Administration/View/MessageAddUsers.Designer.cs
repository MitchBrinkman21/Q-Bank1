namespace Q_Bank_Administration.View
{
    partial class MessageAddUsers
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
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.messageAddUsersSearchTextbox = new System.Windows.Forms.TextBox();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usersTable = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Gebruikers toevoegen aan bericht";
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAdd.Location = new System.Drawing.Point(185, 503);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(136, 39);
            this.ButtonAdd.TabIndex = 23;
            this.ButtonAdd.Text = "Toevoegen";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.Location = new System.Drawing.Point(327, 503);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(136, 39);
            this.ButtonCancel.TabIndex = 22;
            this.ButtonCancel.Text = "Annuleren";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // messageAddUsersSearchTextbox
            // 
            this.messageAddUsersSearchTextbox.Location = new System.Drawing.Point(82, 111);
            this.messageAddUsersSearchTextbox.Name = "messageAddUsersSearchTextbox";
            this.messageAddUsersSearchTextbox.Size = new System.Drawing.Size(298, 20);
            this.messageAddUsersSearchTextbox.TabIndex = 24;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(386, 111);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 25;
            this.ButtonSearch.Text = "Zoeken";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Aan";
            // 
            // toUser
            // 
            this.toUser.Location = new System.Drawing.Point(82, 72);
            this.toUser.Name = "toUser";
            this.toUser.ReadOnly = true;
            this.toUser.Size = new System.Drawing.Size(298, 20);
            this.toUser.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Zoeken";
            // 
            // usersTable
            // 
            this.usersTable.AutoScroll = true;
            this.usersTable.ColumnCount = 2;
            this.usersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.usersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.usersTable.Location = new System.Drawing.Point(82, 159);
            this.usersTable.Name = "usersTable";
            this.usersTable.RowCount = 1;
            this.usersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.usersTable.Size = new System.Drawing.Size(341, 338);
            this.usersTable.TabIndex = 29;
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(85, 139);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSelectAll.TabIndex = 30;
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            // 
            // MessageAddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(475, 554);
            this.Controls.Add(this.checkBoxSelectAll);
            this.Controls.Add(this.usersTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.messageAddUsersSearchTextbox);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageAddUsers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageAddUsers";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MessageAddUsers_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button ButtonAdd;
        public System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox toUser;
        public System.Windows.Forms.TableLayoutPanel usersTable;
        public System.Windows.Forms.Button ButtonSearch;
        public System.Windows.Forms.TextBox messageAddUsersSearchTextbox;
        public System.Windows.Forms.CheckBox checkBoxSelectAll;
    }
}