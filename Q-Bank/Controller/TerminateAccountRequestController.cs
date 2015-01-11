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
    public class TerminateAccountRequestController
    {
        public FormMain formMain { get; set; }
        public TerminateAccountRequest tac { get; set; }
        public List<RadioButton> radioButtonList { get; set; }

        public TerminateAccountRequestController(FormMain formMain)
        {
            this.formMain = formMain;
            this.radioButtonList = new List<RadioButton>();

            tac = new TerminateAccountRequest();

            tac.buttonCancel.Click += buttonCancel_Click;
            tac.buttonConfirm.Click += buttonConfirm_Click;

            FillAccountsTable();
            tac.ShowDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            tac.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Boolean rbChecked = false;
            int id = 0;
            foreach (RadioButton rb in radioButtonList)
            {
                if (rb.Checked)
                {
                    rbChecked = true;
                    id = Convert.ToInt32(rb.Tag);
                }
            }

            if (rbChecked)
            {
                DialogResult result = MessageBox.Show("Weet u zeker dat u deze aanvraag wilt doorvoeren?", "Weet u het zeker", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SetDeleteRequest(id);
                }
            }
            else
            {
                MessageBox.Show("Er is geen rekening geselecteerd.\nProbeer opnieuw.", "Geen rekening geselecteerd");
            }
        }

        private void AddItemsInTable(account a, int i)
        {
            Label tempLabel;
            RadioButton tempRadio;

            tempLabel = new Label();
            tempLabel.Text = a.iban;
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tac.tableAccounts.Controls.Add(tempLabel, 0, i);

            tempLabel = new Label();
            tempLabel.Text = a.accounttype.accountTypeName;
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tac.tableAccounts.Controls.Add(tempLabel, 1, i);

            tempLabel = new Label();
            tempLabel.Text = "€ " + String.Format("{0:0,00}", a.balance.ToString("f2"));
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tac.tableAccounts.Controls.Add(tempLabel, 2, i);

            if (a.deleteRequest)
            {
                tempLabel = new Label();
                tempLabel.Text = "Aangevraagd";
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tac.tableAccounts.Controls.Add(tempLabel, 3, i);
            }
            else
            {
                tempRadio = new RadioButton();
                tempRadio.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempRadio.Tag = a.accountId;
                tac.tableAccounts.Controls.Add(tempRadio, 3, i);
                this.radioButtonList.Add(tempRadio);
            }
            tac.tableAccounts.RowCount = i + 2;
        }

        /// <summary>
        /// Adds the default labels.
        /// </summary>
        private void AddDefaultLabels()
        {
            Label tempLabel;

            tempLabel = new Label();
            tempLabel.Text = "Rekening";
            tempLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tac.tableAccounts.Controls.Add(tempLabel, 0, 0);

            tempLabel = new Label();
            tempLabel.Text = "Type";
            tempLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tac.tableAccounts.Controls.Add(tempLabel, 1, 0);

            tempLabel = new Label();
            tempLabel.Text = "Saldo";
            tempLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tac.tableAccounts.Controls.Add(tempLabel, 2, 0);

            tempLabel = new Label();
            tempLabel.Text = "Beëindigen";
            tempLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tac.tableAccounts.Controls.Add(tempLabel, 4, 0);
        }
        private void FillAccountsTable()
        {
            using (var con = new Q_BANKEntities())
            {
                this.radioButtonList.Clear();
                tac.tableAccounts.Controls.Clear();
                tac.tableAccounts.RowStyles.Clear();
                tac.tableAccounts.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                AddDefaultLabels();

                IQueryable<account> accountCol = null;
                int i = 1;

                accountCol = from a in con.accounts
                             where a.customerId == formMain.id
                             select a;

                if (accountCol != null)
                {
                    foreach (account a in accountCol)
                    {
                        AddItemsInTable(a, i);
                        i++;
                    }
                }
            }
        }

        private void SetDeleteRequest(int id)
        {
            using (var con = new Q_BANKEntities())
            {
                var accountCol = from a in con.accounts
                                 where a.accountId == id
                                 select a;

                account acc = accountCol.First();

                acc.deleteRequest = true;

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
            FillAccountsTable();
        }
    }
}
