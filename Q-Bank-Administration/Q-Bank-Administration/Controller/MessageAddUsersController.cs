using Q_Bank_Administration.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank;
using System.Windows.Forms;

namespace Q_Bank_Administration.Controller
{
    public class MessageAddUsersController
    {
        public MessageAddUsers mau { get; set; }

        public MessageAddUsersController(MessageAddUsers mau)
        {
            this.mau = mau;
            AddUsersToTable();
            mau.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            mau.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
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

        private void AddUsersToTable()
        {
            using (var con = new Q_BANKEntities())
            {
                IQueryable<customer> customerCol = null;
                int i = 1;

                customerCol = from c in con.customers
                                select c;

                Label tempLabel;
                CheckBox tempCheckBox;
                foreach (customer c in customerCol)
                {
                    tempCheckBox = new CheckBox();
                    tempCheckBox.Checked = false;
                    tempCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                    mau.usersTable.Controls.Add(tempCheckBox, 0, i);

                    tempLabel = new Label();
                    tempLabel.Text = c.firstName + " " + c.lastName;
                    tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                    mau.usersTable.Controls.Add(tempLabel, 1, i);
                    i++;
                }
            }
        }
    }
}
