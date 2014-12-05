using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank.View;
using System.Windows.Forms;
using System.Drawing;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

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
            formMain.TransactionOverviewSearchButton.MouseDown += TransactionOverviewSearchButtonMouseDown;
            FillAccountCombobox();
        }

        /// <summary>
        /// Fills the account combobox.
        /// </summary>
        private void FillAccountCombobox()
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
            tempLabel.Text = t.executeDate.Value.Date.ToShortDateString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempLabel.Tag = t.transactionId;
            tempLabel.Click += TransactionOverviewLabelOnClick;
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 0, i);

            tempLabel = new Label();
            tempLabel.Text = t.nameReceiver.ToString() + " " + t.ibanReceiver.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempLabel.Tag = t.transactionId;
            tempLabel.Click += TransactionOverviewLabelOnClick;
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 1, i);

            tempLabel = new Label();
            tempLabel.Text = t.remark.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempLabel.Tag = t.transactionId;
            tempLabel.Click += TransactionOverviewLabelOnClick;
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 2, i);

            String addWithdraw = "Bij";
            if (t.amount < 0)
            {
                addWithdraw = "Af";
            }
            tempLabel = new Label();
            tempLabel.Text = addWithdraw;
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempLabel.Tag = t.transactionId;
            tempLabel.Click += TransactionOverviewLabelOnClick;
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 3, i);

            double amount = t.amount;
            if (t.amount < 0)
            {
                amount *= -1;
            }

            tempLabel = new Label();
            tempLabel.Text = "€" + String.Format("{0:0,00}", amount.ToString("f2"));
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempLabel.Tag = t.transactionId;
            tempLabel.Click += TransactionOverviewLabelOnClick;
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 4, i);
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
        private void FillTransactionOverviewTableSearchResults(TransactionSearch ts)
        {
            using (var con = new Q_BANKEntities())
            {
                formMain.TransactionOverviewTable.Controls.Clear();
                formMain.TransactionOverviewTable.RowStyles.Clear();
                formMain.TransactionOverviewTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                AddDefaultLabels();

                ComboBoxItem accountComboBox = (ComboBoxItem)ts.TransactionSearchAccountCombobox.SelectedItem;

                IQueryable<transaction> transactionCol = null;
                transactionCol = from t in con.transactions
                                 select t;
                if (ts.TransactionSearchCombobox.SelectedIndex == 0) {
                    // Textboxes
                    if (String.IsNullOrEmpty(ts.textBoxFirstName.Text))
                    {
                        transactionCol = transactionCol.Where(t => t.nameReceiver.Contains(ts.textBoxLastName.Text));
                    }
                    else if (String.IsNullOrEmpty(ts.textBoxLastName.Text))
                    {
                        transactionCol = transactionCol.Where(t => t.nameReceiver.Contains(ts.textBoxFirstName.Text));
                    }
                    else
                    {
                        transactionCol = transactionCol.Where(t => t.nameReceiver.Contains(ts.textBoxFirstName.Text) && t.nameReceiver.Contains(ts.textBoxLastName.Text));
                    }
                    // ComboBox for accounts
                    if (accountComboBox.Value != 0)
                    {
                        transactionCol = transactionCol.Where(t => t.accountId == accountComboBox.Value);
                    }
                }
                else
                {
                    transactionCol = transactionCol.Where(t => DbFunctions.TruncateTime(t.executeDate.Value) >= DbFunctions.TruncateTime(ts.beginDatePicker.Value));
                    transactionCol = transactionCol.Where(t => DbFunctions.TruncateTime(t.executeDate.Value) <= DbFunctions.TruncateTime(ts.endDatePicker.Value));

                    if (accountComboBox.Value != 0)
                    {
                        transactionCol = transactionCol.Where(t => t.accountId == accountComboBox.Value);
                    }
                }
                if (ts.TransactionSearchOrderByCombobobox.SelectedIndex == 0)
                {
                    transactionCol = transactionCol.OrderBy(t => t.executeDate);
                }
                else
                {
                    transactionCol = transactionCol.OrderByDescending(t => t.executeDate);
                }
                if (transactionCol != null)
                {
                    int i = 1;
                    foreach (transaction t in transactionCol)
                    {
                        AddItemsInTable(t, i);
                        i++;
                    }
                    Label tempLabel = new Label();
                    formMain.TransactionOverviewTable.Controls.Add(tempLabel, 0, formMain.TransactionOverviewTable.RowCount);
                }
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
                formMain.TransactionOverviewSearchLabel.Visible = false;
                formMain.TransactionOverviewTable.Controls.Clear();
                formMain.TransactionOverviewTable.RowStyles.Clear();
                formMain.TransactionOverviewTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                AddDefaultLabels();

                IQueryable<account> accountCol = null;
                IQueryable<transaction> transactionCol = null;
                int i = 1;
                if (formMain.TransactionOverviewAccountsCombobox.SelectedIndex >= 0)
                {
                    ComboBoxItem combobox = (ComboBoxItem)formMain.TransactionOverviewAccountsCombobox.SelectedItem;

                    if (combobox.Value == 0)
                    {
                        int customerId = 1;
                        accountCol = from a in con.accounts
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

                        transactionCol = from t in con.transactions
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
                        accountCol = from a in con.accounts
                                     where a.accountId == combobox.Value
                                     select a;

                        if (accountCol.Count() > 0)
                        {
                            account a = accountCol.First();
                            formMain.TransactionOverviewBalanceLabel.Text = "Saldo: €" + String.Format("{0:0,00}", a.balance.ToString("f2"));
                        }

                        transactionCol = from t in con.transactions
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
        private void TransactionOverviewSearchButtonMouseDown(object sender, System.EventArgs e)
        {
            using (TransactionSearch ts = new TransactionSearch())
            {
                ts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
                ts.ShowDialog();
                if (ts.CloseForm == true)
                {
                    formMain.TransactionOverviewSearchLabel.Visible = true;
                    if (ts.TransactionSearchCombobox.SelectedIndex == 0) 
                    { 
                        formMain.TransactionOverviewSearchLabel.Text = "U hebt gezocht naar transacties van: " + ts.textBoxFirstName.Text + " " + ts.textBoxLastName.Text;
                    }
                    else
                    {
                        formMain.TransactionOverviewSearchLabel.Text = "U hebt gezocht naar transacties in de periode " + ts.beginDatePicker.Value.ToShortDateString() + " - " + ts.endDatePicker.Value.ToShortDateString();
                    }
                    formMain.TransactionOverviewSearchLabel.Text += " (" + ts.TransactionSearchOrderByCombobobox.Text + ")";
                    FillTransactionOverviewTableSearchResults(ts);
                }
            }
        }

        /// <summary>
        /// When the user clicks on a transaction a window with more details will show.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TransactionOverviewLabelOnClick(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null) { 
                TransactionDetails td = new TransactionDetails(Convert.ToInt32(clickedLabel.Tag));
                td.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
                td.ShowDialog();
            }
        }
    }
}
