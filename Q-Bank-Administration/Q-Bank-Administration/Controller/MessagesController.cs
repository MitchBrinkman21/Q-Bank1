using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank_Administration.View;

namespace Q_Bank_Administration.Controller
{
    public class MessagesController
    {
        public FormMain formMain { get; set; }
        public MessageAddUsers  mau { get; set; }

        public MessagesController(FormMain formMain)
        {
            this.formMain = formMain;
            this.formMain.messageSendButton.MouseClick += MouseClickMessageSendButton;
            this.formMain.messageSendCancel.MouseClick += MouseClickMessageCancelButton;
            this.formMain.messageAddUsers.MouseClick += MouseClickAddUsersButton;
        }

        private void MouseClickMessageSendButton(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Wilt u het bericht versturen?", "Weet u het zeker", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                MessageBox.Show("Het bericht is verzonden!");
            }
        }

        private void MouseClickMessageCancelButton(object sender, EventArgs e)
        {

        }

        private void MouseClickAddUsersButton(object sender, EventArgs e)
        {
            using (mau = new MessageAddUsers())
            {
                mau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
                mau.ShowDialog();
                if (mau.CloseForm)
                {
                    MessageBox.Show("asdas");
                }
            }
        }
    }
}
