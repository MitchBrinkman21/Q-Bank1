using Q_Bank.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank.View
{
    public class TabTransactionStatus
    {
        public FormMain formMain { get; set; }
        public Controller.TransactionsStatusController tsc;
        public List<Label> uitvoerDatum, tegenRekening, omschrijving, bedrag, status;
        public List<CheckBox> kies;
        private Label lKies, lUitvoerDatum, lTegenRekening, lOmschrijving, lBedrag, lStatus;

        public TabTransactionStatus(FormMain formMain)
        {
            uitvoerDatum = new List<Label>();
            tegenRekening = new List<Label>();
            omschrijving = new List<Label>();
            bedrag = new List<Label>();
            status = new List<Label>();
            kies = new List<CheckBox>();
            this.formMain = formMain;
            tsc = new Controller.TransactionsStatusController(this);
            formMain.transactionStatusSelectEverything.Click += tsc.SelectAllHandler;
            formMain.transactionStatusButtonAnnuleren.Click += tsc.Annuleren;
            formMain.TransactionStatusSearchBar.KeyPress += tsc.Search;  
            formMain.TrasactionStatusDropBox.SelectedIndexChanged += TransactionStatusAccountComboboxChanged;
            tsc = new Controller.TransactionsStatusController(this);
            //AddTransactions();
            //verwijderd de verticale scrollbar
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            formMain.TransactionStatusTableLayout.Padding = new Padding(0, 0, vertScrollWidth, 0);
        }

        public void TransactionStatusAccountComboboxChanged(object sender, System.EventArgs e)
        {
            using (var con = new Q_BANKEntities())
            {
                formMain.TransactionStatusTableLayout.Controls.Clear();
                AddDefaultLabels();
                ClearArray();

                int i = 0;
                if (formMain.TrasactionStatusDropBox.SelectedIndex >= 0)
                {
                    ComboBoxItem combobox = (ComboBoxItem)formMain.TrasactionStatusDropBox.SelectedItem;

                    if (combobox.Value == 0)
                    {
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
                            formMain.transactionStatusSaldo.Text = "Saldo: " + balance.ToString();
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
                    else
                    {
                        var accountCol = from a in con.accounts
                                         where a.accountId == combobox.Value
                                         select a;
                        if (accountCol.Count() > 0)
                        {
                            account a = accountCol.First();
                            formMain.transactionStatusSaldo.Text = "Saldo: " + a.balance.ToString();
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
                    formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 0, formMain.TransactionStatusTableLayout.RowCount);
                }
            }

        }

        private void AddItemsInTable(transaction t, int i)
        {
            Label tempLabel;
            CheckBox tempCBox;

            tempCBox = new CheckBox();
            tempCBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(tempCBox, 0, i + 1);
            kies.Add(tempCBox);

            tempLabel = new Label();
            tempLabel.Text = t.datetime.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 1, i + 1);
            uitvoerDatum.Add(tempLabel);

            tempLabel = new Label();
            tempLabel.Text = t.nameReceiver.ToString() + " " + t.ibanReceiver.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 2, i + 1);
            tegenRekening.Add(tempLabel);

            tempLabel = new Label();
            tempLabel.Text = t.remark.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 3, i + 1);
            omschrijving.Add(tempLabel);

            tempLabel = new Label();
            tempLabel.Text = "€" + t.amount.ToString();
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 4, i + 1);
            bedrag.Add(tempLabel);

            tempLabel = new Label();
            tempLabel.Text = "Bezig met verwerken";
            tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 5, i + 1);
            status.Add(tempLabel);

            formMain.TransactionStatusTableLayout.RowCount = i + 2;

        }


        private void AddDefaultLabels()
        {
            lKies = new Label();
            lKies.Text = "Kies";
            lKies.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lKies, 0, 0);

            lUitvoerDatum = new Label();
            lUitvoerDatum.Text = "Uitvoerdatum";
            lUitvoerDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lUitvoerDatum, 1, 0);

            lTegenRekening = new Label();
            lTegenRekening.Text = "Tegenrekening";
            lTegenRekening.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lTegenRekening, 2, 0);

            lOmschrijving = new Label();
            lOmschrijving.Text = "Omschrijving";
            lOmschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lOmschrijving, 3, 0);

            lBedrag = new Label();
            lBedrag.Text = "Bedrag";
            lBedrag.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lBedrag, 4, 0);

            lStatus = new Label();
            lStatus.Text = "Status";
            lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lStatus, 5, 0);

        }

        public void ClearArray()
        {
            uitvoerDatum.Clear();
            tegenRekening.Clear();
            omschrijving.Clear();
            bedrag.Clear();
            status.Clear();
            kies.Clear();
        }
    }
}
