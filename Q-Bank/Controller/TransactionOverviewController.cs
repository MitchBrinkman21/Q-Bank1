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
    public class TransactionOverviewController
    {
        public FormMain formMain { get; set; }
        private Label lDate, lFromAccount, lRemark, lAddWithdraw, lAmount;
        public TransactionOverviewController(FormMain formMain)
        {
            this.formMain = formMain;
            formMain.TransactionOverviewAccountsCombobox.SelectedIndexChanged += TransactionOverviewAccountComboboxChanged;
            formMain.TransactionOverviewSearchTextbox.MouseDown += TransactionOverviewSearchTextboxMouseDown;
            formMain.TransactionOverviewSearchTextbox.KeyPress += new KeyPressEventHandler(TransactionOverviewSearchTextboxKeyPress);
            FillAccountsCombobox();
        }

        /// <summary>
        /// Fills the accounts combobox.
        /// </summary>
        private void FillAccountsCombobox()
        {
            using (var con = new Q_BANKEntities())
            {
                int customerId = 1;
                formMain.TransactionOverviewAccountsCombobox.Items.Clear();
                var accountsCol = from a in con.accounts
                                  where a.customerId == customerId
                                  select a;

                if (accountsCol.Count() > 0)
                {
                    formMain.TransactionOverviewAccountsCombobox.Items.Add(new ComboBoxItem(0, "Alle rekeningen"));
                    formMain.TransactionOverviewAccountsCombobox.SelectedIndex = 0;
                    foreach (account a in accountsCol)
                    {
                        formMain.TransactionOverviewAccountsCombobox.Items.Add(new ComboBoxItem(a.accountId, a.iban.ToString()));
                    }
                }
                else
                {
                    formMain.TransactionOverviewAccountsCombobox.Items.Add(new ComboBoxItem(-1, "Geen rekeningen gevonden"));
                    formMain.TransactionOverviewAccountsCombobox.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Adds the items in table.
        /// </summary>
        /// <param name="t">The transaction.</param>
        /// <param name="i">The rownumber.</param>
        private void AddItemsInTable(transaction t, int i)
        {
            Label tempLabel;

            tempLabel = new Label();
            tempLabel.Text = t.datetime.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 0, i + 1);

            tempLabel = new Label();
            tempLabel.Text = t.nameReceiver.ToString() + " " + t.ibanReceiver.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 1, i + 1);

            tempLabel = new Label();
            tempLabel.Text = t.remark.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 2, i + 1);

            String addWithdraw = "Bij";
            if (t.amount < 0)
            {
                addWithdraw = "Af";
            }
            tempLabel = new Label();
            tempLabel.Text = addWithdraw;
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 3, i + 1);

            double amount = t.amount;
            if (t.amount < 0)
            {
                amount *= -1;
            }

            tempLabel = new Label();
            tempLabel.Text = "€" + String.Format("{0:0,00}", amount.ToString("f2"));
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 4, i + 1);
            formMain.TransactionOverviewTable.RowCount = i + 2;
        }

        /// <summary>
        /// Adds the default labels.
        /// </summary>
        private void AddDefaultLabels()
        {
            lDate = new Label();
            lDate.Text = "Datum";
            lDate.Font = new Font("Arial", 9, FontStyle.Bold);
            formMain.TransactionOverviewTable.Controls.Add(lDate, 0, 0);

            lFromAccount = new Label();
            lFromAccount.Text = "Van rekening";
            lFromAccount.Font = new Font("Arial", 9, FontStyle.Bold);
            formMain.TransactionOverviewTable.Controls.Add(lFromAccount, 1, 0);

            lRemark = new Label();
            lRemark.Text = "Omschrijving";
            lRemark.Font = new Font("Arial", 9, FontStyle.Bold);
            formMain.TransactionOverviewTable.Controls.Add(lRemark, 2, 0);

            lAddWithdraw = new Label();
            lAddWithdraw.Text = "Bij/af";
            lAddWithdraw.Font = new Font("Arial", 9, FontStyle.Bold);
            formMain.TransactionOverviewTable.Controls.Add(lAddWithdraw, 3, 0);

            lAmount = new Label();
            lAmount.Text = "Bedrag";
            lAmount.Font = new Font("Arial", 9, FontStyle.Bold);
            formMain.TransactionOverviewTable.Controls.Add(lAmount, 4, 0);
        }

        /// <summary>
        /// Fills the transaction overview table search results.
        /// </summary>
        private void FillTransactionOverviewTableSearchResults()
        {
            using (var con = new Q_BANKEntities())
            {
                formMain.TransactionOverviewTable.Controls.Clear();
                formMain.TransactionOverviewTable.RowStyles.Clear();
                formMain.TransactionOverviewTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                AddDefaultLabels();

                var transactionCol = from t in con.transactions
                                     orderby t.datetime descending
                                     where t.nameReceiver.Contains(formMain.TransactionOverviewSearchTextbox.Text)
                                     select t;
                int i = 0;
                foreach (transaction t in transactionCol)
                {
                    AddItemsInTable(t, i);
                    i++;
                }
                Label tempLabel = new Label();
                formMain.TransactionOverviewTable.Controls.Add(tempLabel, 0, formMain.TransactionOverviewTable.RowCount);
            }
        }

        /*
         * Events
         */
        /// <summary>
        /// Event when the combobox value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void TransactionOverviewAccountComboboxChanged(object sender, System.EventArgs e)
        {
            using (var con = new Q_BANKEntities())
            {
                formMain.TransactionOverviewTable.Controls.Clear();
                formMain.TransactionOverviewTable.RowStyles.Clear();
                formMain.TransactionOverviewTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                AddDefaultLabels();

                int i = 0;
                if (formMain.TransactionOverviewAccountsCombobox.SelectedIndex >= 0)
                {
                    ComboBoxItem combobox = (ComboBoxItem)formMain.TransactionOverviewAccountsCombobox.SelectedItem;

                    if (combobox.Value == 0)
                    {
                        int customerId = 1;
                        var accountCol = from a in con.accounts
                                         where a.customerId == customerId
                                         select a;
                        if (accountCol.Count() > 0)
                        {
                            double balance = 0;
                            foreach (account a in accountCol)
                            {
                                balance += a.balance;
                            }
                            formMain.TransactionOverviewBalanceLabel.Text = "Saldo: €" + String.Format("{0:0,00}", balance.ToString("f2"));
                        }

                        var transactionCol = from t in con.transactions
                                             orderby t.datetime descending
                                             select t;

                        foreach (transaction t in transactionCol)
                        {
                            AddItemsInTable(t, i);
                            i++;
                        }
                    }
                    else if (combobox.Value > 0)
                    {
                        var accountCol = from a in con.accounts
                                         where a.accountId == combobox.Value
                                         select a;
                        if (accountCol.Count() > 0)
                        {
                            account a = accountCol.First();
                            formMain.TransactionOverviewBalanceLabel.Text = "Saldo: €" + String.Format("{0:0,00}", a.balance.ToString("f2"));
                        }

                        var transactionCol = from t in con.transactions
                                             where t.accountId == combobox.Value
                                             orderby t.datetime descending
                                             select t;

                        foreach (transaction t in transactionCol)
                        {
                            AddItemsInTable(t, i);

                            i++;
                        }
                    }
                    Label tempLabel = new Label();
                    formMain.TransactionOverviewTable.Controls.Add(tempLabel, 0, formMain.TransactionOverviewTable.RowCount);
                }
            }

        }

        /// <summary>
        /// When the user clicks on the TransactionOverviewSearchTextbox.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TransactionOverviewSearchTextboxMouseDown(object sender, System.EventArgs e)
        {
            if (formMain.TransactionOverviewSearchTextbox.Text.Equals("Zoeken"))
            {
                formMain.TransactionOverviewSearchTextbox.Text = "";
            }
        }

        /// <summary>
        /// When the user presses on a key in the TransactionOverviewSearchTextbox.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void TransactionOverviewSearchTextboxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillTransactionOverviewTableSearchResults();
            }
        }
    }

    public class ComboBoxItem
    {
        public int Value;
        public string Text;
        public ComboBoxItem(int val, string text)
        {
            Value = val;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
