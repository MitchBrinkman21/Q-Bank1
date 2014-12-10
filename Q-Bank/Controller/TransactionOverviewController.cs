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
using Q_Bank.Model;

namespace Q_Bank.Controller
{
    public class TransactionOverviewController
    {
        public FormMain formMain { get; set; }
        public TransactionSearch ts { get; set; }
        public Boolean search { get; set; }
        private Label lDate, lFromAccount, lRemark, lAddWithdraw, lAmount;
        public TransactionOverviewController(FormMain formMain)
        {
            this.formMain = formMain;
            formMain.TransactionOverviewAccountsCombobox.SelectedIndexChanged += TransactionOverviewAccountComboboxChanged;
            formMain.TransactionOverviewSearchButton.MouseDown += TransactionOverviewSearchButtonMouseDown;
            AccComboBoxGen acbg = new AccComboBoxGen(formMain, formMain.TransactionOverviewAccountsCombobox);
        }

        /// <summary>
        /// Adds the items in table.
        /// </summary>
        /// <param name="t">The transaction.</param>
        /// <param name="i">The rownumber.</param>
        private void AddItemsInTable(transaction t, int i, ComboBoxItem combobox)
        {
            if (combobox.AccountId > 0)
            {
                if (combobox.Iban.Equals(t.ibanReceiver))
                {
                    if (t.transactionTypeId == 1)
                    {
                        t.transactiontype.transactionTypeName = "Bijschrijving";
                    }
                    else
                    {
                        t.transactiontype.transactionTypeName = "Afschrijving";
                    }
                    t.nameReceiver = t.account.customer.firstName + " " + t.account.customer.lastName;
                    t.ibanReceiver = t.account.iban;
                }
            }
            Label tempLabel;

            tempLabel = new Label();
            tempLabel.Text = t.commitDatetime.Value.Date.ToShortDateString();
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

            tempLabel = new Label();
            tempLabel.Text = t.transactiontype.transactionTypeName.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            tempLabel.Tag = t.transactionId;
            tempLabel.Click += TransactionOverviewLabelOnClick;
            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 3, i);

            tempLabel = new Label();
            tempLabel.Text = "€" + String.Format("{0:0,00}", t.amount.ToString("f2"));
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
        /// Fills the transaction overview table.
        /// </summary>
        private void FillTransactionOverviewTable()
        {
            using (var con = new Q_BANKEntities())
            {
                ComboBoxItem accountComboBox = null;

                formMain.TransactionOverviewTable.Controls.Clear();
                formMain.TransactionOverviewTable.RowStyles.Clear();
                formMain.TransactionOverviewTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                AddDefaultLabels();

                if (search)
                {
                    accountComboBox = (ComboBoxItem)ts.TransactionSearchAccountCombobox.SelectedItem;
                }
                else
                {
                    accountComboBox = (ComboBoxItem)formMain.TransactionOverviewAccountsCombobox.SelectedItem;
                }
                if (accountComboBox.AccountId > 0)
                {
                    formMain.TransactionOverviewBalanceLabel.Visible = true;
                    IQueryable<transaction> transactionCol = null;
                    int i = 1;
                    SetBalanceLabel();

                    transactionCol = from t in con.transactions
                                     select t;

                    if (search)
                    {
                        search = false;
                        formMain.TransactionOverviewSearchLabel.Visible = true;
                        if (ts.TransactionSearchCombobox.SelectedIndex == 0)
                        {
                            // Textboxes
                            if (String.IsNullOrEmpty(ts.textBoxFirstName.Text) && !String.IsNullOrEmpty(ts.textBoxLastName.Text))
                            {
                                transactionCol = transactionCol.Where(t => t.nameReceiver.Contains(ts.textBoxLastName.Text));
                            }
                            else if (String.IsNullOrEmpty(ts.textBoxLastName.Text) && !String.IsNullOrEmpty(ts.textBoxFirstName.Text))
                            {
                                transactionCol = transactionCol.Where(t => t.nameReceiver.Contains(ts.textBoxFirstName.Text));
                            }
                            else if (!String.IsNullOrEmpty(ts.textBoxFirstName.Text) && !String.IsNullOrEmpty(ts.textBoxLastName.Text))
                            {
                                transactionCol = transactionCol.Where(t => t.nameReceiver.Contains(ts.textBoxFirstName.Text) && t.nameReceiver.Contains(ts.textBoxLastName.Text));
                            }
                        }
                        else
                        {
                            transactionCol = transactionCol.Where(t => DbFunctions.TruncateTime(t.executeDate.Value) >= DbFunctions.TruncateTime(ts.beginDatePicker.Value));
                            transactionCol = transactionCol.Where(t => DbFunctions.TruncateTime(t.executeDate.Value) <= DbFunctions.TruncateTime(ts.endDatePicker.Value));
                        }

                        if (ts.TransactionSearchOrderByCombobobox.SelectedIndex == 0)
                        {
                            transactionCol = transactionCol.OrderBy(t => t.commitDatetime);
                        }
                        else
                        {
                            transactionCol = transactionCol.OrderByDescending(t => t.commitDatetime);
                        }
                    }
                    else
                    {
                        formMain.TransactionOverviewSearchLabel.Visible = false;

                        transactionCol = transactionCol.OrderByDescending(t => t.commitDatetime);
                    }

                    transactionCol = transactionCol.Where(t => t.commitDatetime != null && t.transactionStatusId == 4);
                    transactionCol = transactionCol.Where(t => t.account.iban == accountComboBox.Iban || t.ibanReceiver == accountComboBox.Iban);

                    if (transactionCol != null && accountComboBox != null)
                    {
                        foreach (transaction t in transactionCol)
                        {
                            AddItemsInTable(t, i, accountComboBox);
                            i++;
                        }
                    }
                }
                else
                {
                    formMain.TransactionOverviewBalanceLabel.Visible = false;
                }

                Label tempLabel = new Label();
                formMain.TransactionOverviewTable.Controls.Add(tempLabel, 0, formMain.TransactionOverviewTable.RowCount);
            }
        }

        /// <summary>
        /// Sets the balance label.
        /// </summary>
        private void SetBalanceLabel()
        {
            using (var con = new Q_BANKEntities())
            {
                IQueryable<account> accountCol = null;
                ComboBoxItem accountComboBox = (ComboBoxItem)formMain.TransactionOverviewAccountsCombobox.SelectedItem;

                if (accountComboBox.AccountId == 0)
                {
                    formMain.TransactionOverviewBalanceLabel.Visible = false;
                }
                else
                {
                    formMain.TransactionOverviewBalanceLabel.Visible = true;

                    accountCol = from a in con.accounts
                                 where a.accountId == accountComboBox.AccountId
                                 select a;

                    if (accountCol.Count() > 0)
                    {
                        account a = accountCol.First();
                        formMain.TransactionOverviewBalanceLabel.Text = "Saldo: €" + String.Format("{0:0,00}", a.balance.ToString("f2"));
                    }
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
            FillTransactionOverviewTable();
        }
        

        /// <summary>
        /// When the user clicks on the TransactionOverviewSearchButton.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TransactionOverviewSearchButtonMouseDown(object sender, System.EventArgs e)
        {
            using (ts = new TransactionSearch(formMain))
            {
                ts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
                ts.ShowDialog();
                if (ts.CloseForm == true)
                {
                    formMain.TransactionOverviewAccountsCombobox.SelectedIndex = ts.TransactionSearchAccountCombobox.SelectedIndex;
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
                    search = true;
                    FillTransactionOverviewTable();
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
                ComboBoxItem cbi = (ComboBoxItem)formMain.TransactionOverviewAccountsCombobox.SelectedItem;
                TransactionDetails td = new TransactionDetails(Convert.ToInt32(clickedLabel.Tag), cbi);
                td.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
                td.ShowDialog();
            }
        }
    }
}
