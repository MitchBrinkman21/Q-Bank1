using Q_Bank_Administration.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Q_Bank_Administration.Controller
{
    public class MessageAddUsersController
    {
        public MessageAddUsers mau { get; set; }
        public List<CheckBox> checkBoxList { get; set; }
        public Boolean search { get; set; }

        public MessageAddUsersController(MessageAddUsers mau)
        {
            this.mau = mau;
            checkBoxList = new List<CheckBox>();
            AddUsersToTable();

            mau.toUsers = ReplaceLastOccurence(mau.toUsers, ", ", ""); 
            mau.toUsers = ReplaceLastOccurence(mau.toUsers, ",", "");
            mau.ToUsersTextBox.Text = mau.toUsers;

            mau.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            mau.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            mau.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            mau.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            mau.messageAddUsersSearchTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.messageAddUsersSearchTextbox_KeyPress);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            mau.Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            mau.CloseForm = true;
            mau.Close();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(mau.messageAddUsersSearchTextbox.Text))
            {
                search = true;
            }
            AddUsersToTable();
        }

        private void checkBoxStateChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (!String.IsNullOrEmpty(mau.toUsers))
            {
                i = 1;
            }
            mau.ToUsersTextBox.Text = mau.toUsers;
            foreach (CheckBox c in checkBoxList)
            {
                if (c.Checked)
                {
                    if (i > 0)
                    {
                        mau.ToUsersTextBox.Text += ", ";
                    }
                    mau.ToUsersTextBox.Text += Regex.Replace(c.Tag.ToString(), @"[\d-]", string.Empty);
                    i++;
                }
            }
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            Boolean checkBoxChecked = false;
            if (mau.checkBoxSelectAll.Checked == true)
            {
                checkBoxChecked = true;
            }
                
            foreach (CheckBox c in checkBoxList)
            {
                c.Checked = checkBoxChecked;
            }
        }

        private void messageAddUsersSearchTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ButtonSearch_Click(sender, e);
            }
        }

        private void AddUsersToTable()
        {
            mau.usersTable.Controls.Clear();
            mau.usersTable.RowStyles.Clear();
            mau.usersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            checkBoxList.Clear();

            using (var con = new Q_BANKEntities())
            {
                int i = 1;
                IQueryable<customer> customerCol = null;
                if (search)
                {
                    string[] names = mau.messageAddUsersSearchTextbox.Text.Split(null);
                    customerCol = from c in con.customers
                                  where names.Any(n => c.firstName.ToLower().Contains(n.ToLower()) || c.lastName.ToLower().Contains(n.ToLower()))
                                  select c;
                    search = false;
                }
                else
                {
                    customerCol = from c in con.customers
                                  select c;
                }

                if (customerCol != null)
                {
                    Label tempLabel;
                    CheckBox tempCheckBox;
                    foreach (customer c in customerCol)
                    {
                        tempCheckBox = new CheckBox();
                        tempCheckBox.Checked = false;
                        tempCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                        tempCheckBox.Tag = c.firstName + " " + c.lastName + c.customerId;
                        tempCheckBox.CheckStateChanged += checkBoxStateChanged;
                        checkBoxList.Add(tempCheckBox);
                        mau.usersTable.Controls.Add(tempCheckBox, 0, i);

                        tempLabel = new Label();
                        tempLabel.Text = c.firstName + " " + c.lastName;
                        tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                        mau.usersTable.Controls.Add(tempLabel, 1, i);

                        mau.usersTable.RowCount = i + 2;
                        i++;
                    }
                }
            }
        }

        public string ReplaceLastOccurence(string originalValue, string occurenceValue, string newValue)
        {
            if (string.IsNullOrEmpty(originalValue))
                return string.Empty;
            if (string.IsNullOrEmpty(occurenceValue))
                return originalValue;
            if (string.IsNullOrEmpty(newValue))
                return originalValue;
            int startindex = originalValue.LastIndexOf(occurenceValue);
            return originalValue.Remove(startindex, occurenceValue.Length).Insert(startindex, newValue);
        }
    }
}
