using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.Controller;

namespace Q_Bank.View
{
    public class TabTransactionOverview
    {
        public FormMain formMain { get; set; }
        public TransactionOverviewController toc { get; set; }
        private Label lDate, lFromAccount, lRemark, lAddWithdraw, lAmount;
        public TabTransactionOverview(FormMain formMain)
        {
            this.formMain = formMain;
            formMain.TransactionOverviewAccountsCombobox.SelectedIndexChanged += TransactionOverviewAccountComboboxChanged;
            toc = new TransactionOverviewController(this);
        }
        public void TransactionOverviewAccountComboboxChanged(object sender, System.EventArgs e)
        {
            using (var con = new Q_BANKEntities())
            {
                formMain.TransactionOverviewTable.Controls.Clear();
                AddDefaultLabels();
                Label tempLabel;
                int i = 0;
                if (formMain.TransactionOverviewAccountsCombobox.SelectedIndex >= 0)
                {
                    ComboBoxItem combobox = (ComboBoxItem)formMain.TransactionOverviewAccountsCombobox.SelectedItem;

                    if (combobox.Value == 0) {
                        int userId = 1;
                        var accountCol = from a in con.accounts
                                         where a.userId == userId
                                         select a;
                        if (accountCol.Count() > 0)
                        {
                            double balance = 0;
                            foreach (account a in accountCol)
                            {
                                balance += a.balance;
                            }
                            formMain.TransactionOverviewBalanceLabel.Text = "Saldo: " + balance.ToString();
                        }

                        var transactionCol = from t in con.transactions
                                             orderby t.datetime descending
                                             select t;

                        foreach (transaction t in transactionCol)
                        {
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
                            tempLabel.Text = "€" + amount.ToString();
                            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 4, i + 1);

                            i++;
                        }
                    }
                    else
                    {
                        var accountCol = from a in con.accounts
                                         where a.accountId == combobox.Value
                                         select a;
                        if (accountCol.Count() > 0)
                        {
                            account a = accountCol.First();
                            formMain.TransactionOverviewBalanceLabel.Text = "Saldo: " + a.balance.ToString();
                        }

                        var transactionCol = from t in con.transactions
                                             where t.accountId == combobox.Value
                                             orderby t.datetime descending
                                             select t;

                        foreach (transaction t in transactionCol)
                        {
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

                            tempLabel = new Label();
                            tempLabel.Text = t.amount.ToString();
                            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                            formMain.TransactionOverviewTable.Controls.Add(tempLabel, 4, i + 1);

                            i++;
                        }
                    }
                }
            }

        }

        private void AddDefaultLabels()
        {
            lDate = new Label();
            lDate.Text = "Datum";
            lDate.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(lDate, 0, 0);

            lFromAccount = new Label();
            lFromAccount.Text = "Van rekening";
            lFromAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(lFromAccount, 1, 0);

            lRemark = new Label();
            lRemark.Text = "Omschrijving";
            lRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(lRemark, 2, 0);

            lAddWithdraw = new Label();
            lAddWithdraw.Text = "Bij/af";
            lAddWithdraw.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(lAddWithdraw, 3, 0);

            lAmount = new Label();
            lAmount.Text = "Bedrag";
            lAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionOverviewTable.Controls.Add(lAmount, 4, 0);
        }
    }
}
