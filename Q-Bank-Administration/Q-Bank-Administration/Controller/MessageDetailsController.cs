using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank_Administration.View;
using Q_Bank;

namespace Q_Bank_Administration.Controller
{
    public class MessageDetailsController
    {
        public MessageDetails md { get; set; }
        public MessageDetailsController(MessageDetails md)
        {
            this.md = md;
            md.ButtonOk.Click += ButtonOk_Click;
            md.messageTextbox.Enabled = false;
            GetMessageDetails();
            UpdateMessageRead();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            md.ClosedForm = true;
            md.Close();
        }

        private void GetMessageDetails()
        {
            using (var con = new Q_BANKEntities())
            {
                var messageCol = from cm in con.customermessages
                                 where cm.customerMessageId == md.messageId
                                 select cm;

                customermessage c = messageCol.First();

                md.labelMessageSubject.Text = c.subject;
                md.fromUserLabel.Text = c.employee.firstName + " " + c.employee.lastName;
                md.datetimeSentLabel.Text = c.datetimeSent.ToString();
                md.toUserLabel.Text = c.customer.firstName + " " + c.customer.lastName;
                md.messageTextbox.Text = c.messageText.Replace("[Enter]", "\n");
            }
        }

        private void UpdateMessageRead()
        {
            using (var con = new Q_BANKEntities())
            {
                var messageCol = from cm in con.customermessages
                                 where cm.customerMessageId == md.messageId
                                 select cm;

                customermessage c = messageCol.First();

                c.read = true;

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
