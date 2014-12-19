using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank_Administration.View;
using Q_Bank;

namespace Q_Bank_Administration.Controller
{
    public class MessagesController
    {
        public FormMain formMain { get; set; }
        public MessageAddUsers mau { get; set; }
        public String errorText { get; set; }
        public Boolean validText { get; set; }
        public Boolean validUsers { get; set; }
        public List<int> customerIds { get; set; }

        public MessagesController(FormMain formMain)
        {
            customerIds = new List<int>();
            mau = null;
            this.formMain = formMain;
            this.formMain.messageSendButton.Click += messageSendButton_Click;
            this.formMain.messageSendCancel.Click += messageSendCancel_Click;
            this.formMain.messageAddUsers.Click += messageAddUsers_Click;
        }

        private void messageSendButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Wilt u het bericht versturen?", "Weet u het zeker", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            Boolean sent = false;
            if (result == DialogResult.OK)
            {
                if (CheckAllFields())
                {
                    using (var con = new Q_BANKEntities())
                    {
                        if (mau != null)
                        {
                            customerIds = mau.mauc.customerIds;
                            mau = null;
                        }
                        else
                        {
                            customerIds = GetCustomerIdsFromTextBox();
                        }

                        if (!validUsers)
                        {
                            result = MessageBox.Show("De volgende gebruikers zijn niet gevonden:\n" + errorText + "Toch doorgaan?", "Weet u het zeker", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                validUsers = true;
                            }
                        }

                        if (validUsers) 
                        { 
                            if (customerIds != null)
                            {
                                if (customerIds.Count > 0)
                                {
                                    foreach (int id in customerIds)
                                    {
                                        customermessage newMessage = new customermessage()
                                        {
                                            customerId = id,
                                            employeeId = formMain.id,
                                            messageText = formMain.messageMessageTextbox.Text.Replace("\n", "[Enter]"),
                                            title = formMain.messageTitleTextbox.Text,
                                            read = 0,
                                            deleted = 0
                                        };
                                        con.customermessages.Add(newMessage);
                                        con.SaveChanges();
                                    }
                                    sent = true;
                                }
                            }
                            if (sent)
                            {
                                ClearAllFields();
                                MessageBox.Show("Het bericht is verzonden!");
                            }
                            else
                            {
                                MessageBox.Show("Er is iets mis gegaan!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(errorText);
                }
            }
        }

        private void messageSendCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Weet u zeker dat u het bericht wilt annuleren?", "Weet u het zeker", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearAllFields();
            }
        }

        private void messageAddUsers_Click(object sender, EventArgs e)
        {
            using (mau = new MessageAddUsers())
            {
                mau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
                mau.ShowDialog();
                if (mau.CloseForm)
                {
                    formMain.messageToUserTextbox.Enabled = false;
                    formMain.messageToUserTextbox.Text = mau.toUser.Text;
                    validUsers = true;
                }
                else
                {
                    formMain.messageToUserTextbox.Text = "";
                    formMain.messageToUserTextbox.Enabled = true;
                    mau = null;
                }
            }
        }

        private void ClearAllFields()
        {
            formMain.messageToUserTextbox.Enabled = true;
            formMain.messageMessageTextbox.Text = "";
            formMain.messageTitleTextbox.Text = "";
            formMain.messageToUserTextbox.Text = "";
        }

        public Boolean CheckAllFields()
        {
            errorText = "";
            validText = true;
            if (String.IsNullOrEmpty(formMain.messageToUserTextbox.Text))
            {
                errorText += "Geen begunstige geselecteerd.\n";
                validText = false;
            }

            if (String.IsNullOrEmpty(formMain.messageTitleTextbox.Text))
            {
                errorText += "Geen titel gegeven.\n";
                validText = false;
            }

            if (String.IsNullOrEmpty(formMain.messageMessageTextbox.Text))
            {
                errorText += "Geen bericht gemaakt.\n";
                validText = false;
            }

            if (formMain.messageTitleTextbox.Text.Count() > 100)
            {
                errorText += "Titel heeft meer dan 100 tekens.\n";
                validText = false;
            }
            return validText;
        }

        public List<int> GetCustomerIdsFromTextBox()
        {
            List<int> customerIds = new List<int>();
            string[] names = formMain.messageToUserTextbox.Text.Split(',');
            validUsers = true;
            using (var con = new Q_BANKEntities())
            {
                foreach (string name in names)
                {
                    if (!String.IsNullOrEmpty(name.TrimStart().TrimEnd().ToLower()))
                    {
                        IQueryable<customer> customerCol = null;
                        customerCol = from c in con.customers
                                      where name.TrimStart().TrimEnd().ToLower().Equals(c.firstName.ToLower() + " " + c.lastName.ToLower())
                                      select c;

                        if (customerCol.Count() > 0)
                        {
                            foreach (customer c in customerCol)
                            {
                                customerIds.Add(c.customerId);
                            }
                        }
                        else
                        {
                            validUsers = false;
                            errorText += name.TrimStart().TrimEnd() + "\n";
                        }
                    }
                }
            }
            return customerIds;
        }
    }
}
