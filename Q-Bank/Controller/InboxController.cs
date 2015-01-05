using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank.View;
using System.Windows.Forms;
using System.Drawing;

namespace Q_Bank.Controller
{
    public class InboxController
    {
        public FormMain formMain { get; set; }
        public List<CheckBox> checkBoxList { get; set; }
        public Boolean deletedMessages { get; set; }

        public InboxController(FormMain formMain)
        {
            this.formMain = formMain;
            deletedMessages = false;
            formMain.inboxLabelToInbox.Visible = false;
            formMain.inboxTable.CellPaint += new TableLayoutCellPaintEventHandler(inboxTable_CellPaint);
            formMain.inboxLabelRead.LinkClicked += new LinkLabelLinkClickedEventHandler(inboxLabelRead_LinkClicked);
            formMain.inboxLabelUnread.LinkClicked += new LinkLabelLinkClickedEventHandler(inboxLabelUnread_LinkClicked);
            formMain.inboxLabelDeleted.LinkClicked += new LinkLabelLinkClickedEventHandler(inboxLabelDeleted_LinkClicked);
            formMain.inboxLabelInbox.LinkClicked += new LinkLabelLinkClickedEventHandler(inboxLabelInbox_LinkClicked);
            formMain.inboxLabelDelete.LinkClicked += new LinkLabelLinkClickedEventHandler(inboxLabelDelete_LinkClicked);
            formMain.inboxLabelToInbox.LinkClicked += new LinkLabelLinkClickedEventHandler(inboxLabelToInbox_LinkClicked);
            checkBoxList = new List<CheckBox>();
            FillInboxTable();
        }

        private void FillInboxTable()
        {
            formMain.inboxTable.Controls.Clear();
            formMain.inboxTable.RowStyles.Clear();
            formMain.inboxTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            checkBoxList.Clear();
            AddDefaultLabels();
            using (var con = new Q_BANKEntities())
            {
                int i = 1;
                var messageCol = from cm in con.customermessages
                                 where cm.customerId == formMain.id
                                 select cm;

                if (deletedMessages)
                {
                    messageCol = messageCol.Where(cm => cm.deleted == true && cm.permDeleted == false);
                }
                else
                {
                    messageCol = messageCol.Where(cm => cm.deleted == false && cm.permDeleted == false);
                }

                messageCol = messageCol.OrderByDescending(cm => cm.datetimeSent);

                foreach (customermessage m in messageCol)
                {
                    AddItemInTable(m, i);
                    i++;
                }
            }
        }

        private void AddDefaultLabels()
        {
            Label tempLabel;
            CheckBox tempCheckbox;

            tempCheckbox = new CheckBox();
            tempCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempCheckbox.Checked = false;
            tempCheckbox.CheckedChanged += tempCheckbox_CheckedChanged;
            formMain.inboxTable.Controls.Add(tempCheckbox, 0, 0);

            tempLabel = new Label();
            tempLabel.Text = "Van";
            tempLabel.Font = new Font("Arial", 9, FontStyle.Bold | FontStyle.Underline);
            formMain.inboxTable.Controls.Add(tempLabel, 1, 0);

            tempLabel = new Label();
            tempLabel.Text = "Onderwerp";
            tempLabel.Font = new Font("Arial", 9, FontStyle.Bold | FontStyle.Underline);
            formMain.inboxTable.Controls.Add(tempLabel, 2, 0);

            tempLabel = new Label();
            tempLabel.Text = "Datum";
            tempLabel.Font = new Font("Arial", 9, FontStyle.Bold | FontStyle.Underline);
            formMain.inboxTable.Controls.Add(tempLabel, 3, 0);
        }

        private void AddItemInTable(customermessage m, int i)
        {
            Label tempLabel;
            CheckBox tempCheckbox;

            tempLabel = new Label();
            tempCheckbox = new CheckBox();

            tempCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempCheckbox.Checked = false;
            tempCheckbox.Tag = m.customerMessageId;
            checkBoxList.Add(tempCheckbox);
            formMain.inboxTable.Controls.Add(tempCheckbox, 0, i);

            tempLabel = new Label();
            tempLabel.Text = m.employee.firstName + " " + m.employee.lastName;
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempLabel.Tag = m.customerMessageId;
            tempLabel.Click += InboxTableItem_Click;
            if (m.read == false)
            {
                tempLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            }
            formMain.inboxTable.Controls.Add(tempLabel, 1, i);

            tempLabel = new Label();
            tempLabel.Text = m.subject;
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempLabel.Tag = m.customerMessageId;
            tempLabel.Click += InboxTableItem_Click;
            if (m.read == false)
            {
                tempLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            }
            formMain.inboxTable.Controls.Add(tempLabel, 2, i);

            tempLabel = new Label();
            if (m.datetimeSent.Date.Equals(DateTime.Today.Date))
            {
                tempLabel.Text = m.datetimeSent.ToShortTimeString();
            }
            else
            {
                tempLabel.Text = m.datetimeSent.ToShortDateString();
            }
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempLabel.Tag = m.customerMessageId;
            tempLabel.Click += InboxTableItem_Click;
            if (m.read == false)
            {
                tempLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            }
            formMain.inboxTable.Controls.Add(tempLabel, 3, i);
            formMain.inboxTable.RowCount = i + 2;
        }

        private void InboxTableItem_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                using (MessageDetails m = new MessageDetails(Convert.ToInt32(clickedLabel.Tag)))
                {
                    m.ShowDialog();
                    if (m.ClosedForm)
                    {
                        FillInboxTable();
                    }
                }
            }
        }

        private void tempCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckBox c in checkBoxList)
            {
                c.Checked = !c.Checked;
            }
        }

        private void inboxTable_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Row == 1 || e.Row % 2 == 1) && formMain.inboxTable.RowCount - 1 > e.Row)
            {
                Graphics g = e.Graphics;
                Rectangle r = e.CellBounds;
                g.FillRectangle(Brushes.LightGray, r);
            }
        }

        private void inboxLabelRead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (CheckBox c in checkBoxList)
            {
                if (c.Checked)
                {
                    UpdateMessageRead(Convert.ToInt32(c.Tag), true);
                }
            }
            FillInboxTable();
        }

        private void inboxLabelUnread_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (CheckBox c in checkBoxList)
            {
                if (c.Checked)
                {
                    UpdateMessageRead(Convert.ToInt32(c.Tag), false);
                }
            }
            FillInboxTable();
        }

        private void UpdateMessageRead(int messageId, Boolean read)
        {
            using (var con = new Q_BANKEntities())
            {
                var messageCol = from cm in con.customermessages
                                 where cm.customerMessageId == messageId
                                 select cm;

                customermessage c = messageCol.First();

                c.read = read;

                // Submit the changes to the database. 
                try
                {
                    con.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }
            }
        }

        private void inboxLabelDeleted_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!deletedMessages)
            {
                formMain.inboxLabelRead.Location = new Point(formMain.inboxLabelRead.Location.X + 137, formMain.inboxLabelRead.Location.Y);
                formMain.inboxLabelUnread.Location = new Point(formMain.inboxLabelUnread.Location.X + 137, formMain.inboxLabelUnread.Location.Y);
            }
            deletedMessages = true;
            formMain.inboxLabelToInbox.Visible = true;
            FillInboxTable();
        }

        private void inboxLabelInbox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (deletedMessages)
            {
                formMain.inboxLabelRead.Location = new Point(formMain.inboxLabelRead.Location.X - 137, formMain.inboxLabelRead.Location.Y);
                formMain.inboxLabelUnread.Location = new Point(formMain.inboxLabelUnread.Location.X - 137, formMain.inboxLabelUnread.Location.Y);
            }
            deletedMessages = false;
            formMain.inboxLabelToInbox.Visible = false;
            FillInboxTable();
        }

        private void inboxLabelDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (CheckBox c in checkBoxList)
            {
                if (c.Checked)
                {
                    UpdateMessageDelete(Convert.ToInt32(c.Tag), true);
                }
            }
            FillInboxTable();
        }

        private void inboxLabelToInbox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (CheckBox c in checkBoxList)
            {
                if (c.Checked)
                {
                    UpdateMessageDelete(Convert.ToInt32(c.Tag), false);
                }
            }
            FillInboxTable();
        }

        private void UpdateMessageDelete(int messageId, Boolean delete)
        {
            using (var con = new Q_BANKEntities())
            {
                var messageCol = from cm in con.customermessages
                                 where cm.customerMessageId == messageId
                                 select cm;

                customermessage c = messageCol.First();

                if (deletedMessages)
                {
                    if (delete)
                    {
                        c.permDeleted = delete;
                    }
                    else
                    {
                        c.permDeleted = delete;
                        c.deleted = delete;
                    }
                }
                else
                {
                    c.deleted = delete;
                }

                // Submit the changes to the database. 
                try
                {
                    con.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }
            }
        }
    }
}
