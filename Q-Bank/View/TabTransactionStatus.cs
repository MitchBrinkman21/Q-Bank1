using Q_Bank.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.Model;

namespace Q_Bank.View
{
    public class TabTransactionStatus
    {
        public FormMain formMain { get; set; }
        public Controller.TransactionsStatusController tsc;
        public List<Label> uitvoerDatum, tegenRekening, omschrijving, bedrag, status;
        public List<CheckBox> kies;
        public List<transaction> ListTransactions;
        private Label lKies, lUitvoerDatum, lTegenRekening, lOmschrijving, lBedrag, lStatus;
        private List<String> statussen = new List<string>();
        public bool hideVerzondenItems = false;
        public bool allesGeselecteerd = false;
        public TabTransactionStatus(FormMain formMain)
        {
            
            using (var con = new Q_BANKEntities())
            {
                var statusList = from a in con.transactionstatus
                                 select a;

                foreach (transactionstatu item in statusList)
                {
                    statussen.Add(item.transactionStatusName);
                }
            }

            uitvoerDatum = new List<Label>();
            tegenRekening = new List<Label>();
            omschrijving = new List<Label>();
            bedrag = new List<Label>();
            status = new List<Label>();
            kies = new List<CheckBox>();
            ListTransactions = new List<transaction>();
            this.formMain = formMain;
            tsc = new Controller.TransactionsStatusController(this);
            formMain.transactionStatusSelectEverything.Click += tsc.SelectAllHandler;
            formMain.transactionStatusButtonAnnuleren.Click += tsc.Annuleren;
            formMain.TrasactionStatusDropBox.SelectedIndexChanged += TransactionStatusAccountComboboxChanged;
            formMain.transactieStatusVerzenden.Click += tsc.Verzenden;
            formMain.transactieStatusHideButton.Click += tsc.Hide;
            formMain.transactionStatusRefreshButton.Click += tsc.Refresch;
            tsc = new Controller.TransactionsStatusController(this);
            formMain.transactieStatusVerzenden.Enabled = false;
            formMain.transactionStatusButtonAnnuleren.Enabled = false;
            //AddTransactions();
            //verwijderd de verticale scrollbar
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            formMain.TransactionStatusTableLayout.Padding = new Padding(0, 0, vertScrollWidth, 0);
        }

        public void TransactionStatusAccountComboboxChanged(object sender, System.EventArgs e)
        {
            allesGeselecteerd = false;
            using (var con = new Q_BANKEntities())
            {
                
                formMain.TransactionStatusTableLayout.Controls.Clear();
                formMain.TransactionStatusTableLayout.RowStyles.Clear();
                formMain.TransactionStatusTableLayout.RowCount = 1;
                AddDefaultLabels();
                ClearArray();

                int i = 0;
                if (formMain.TrasactionStatusDropBox.SelectedIndex >= 0)
                {
                    ComboBoxItem combobox = (ComboBoxItem)formMain.TrasactionStatusDropBox.SelectedItem;

                    if (combobox.AccountId == 0)
                    {
                        formMain.transactionStatusSaldo.Visible = false;
                    }
                    else
                    {
                        var accountCol = from a in con.accounts
                                         where a.accountId == combobox.AccountId
                                         select a;
                        if (accountCol.Count() > 0)
                        {
                            account a = accountCol.First();
                            formMain.transactionStatusSaldo.Text = "Saldo: €" + String.Format("{0:0,00}",a.balance.ToString("f2"));
                            formMain.transactionStatusSaldo.Visible = true;
                        }

                        var transactionCol = from t in con.transactions
                                             where t.accountId == combobox.AccountId
                                             orderby t.datetime descending
                                             select t;

                        foreach (transaction t in transactionCol)
                        {
                            CheckItems(t, i);
                            i++;
                        }
                    }
                    Label tempLabel = new Label();
                    formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 0, formMain.TransactionStatusTableLayout.RowCount);
                }
            }

        }

        private void CheckItems(transaction t, int i)
        {
            if (hideVerzondenItems)
            {
                if (t.transactionStatusId == 1)
                {
                    AddItemsInTable(t, i);
                }
            }
            else
            {
                if (t.transactionStatusId == 1 || t.transactionStatusId == 2 || t.transactionStatusId == 3)
                {
                    AddItemsInTable(t, i);
                }
            }
        }

        private void AddItemsInTable(transaction t, int i)
        {
                ListTransactions.Add(t);
                Label tempLabel;
                CheckBox tempCBox;
                int tID = t.transactionId;

                if (t.transactionStatusId < 3)
                {                    
                    tempCBox = new CheckBox();
                    tempCBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                    tempCBox.Tag = tID;
                    formMain.TransactionStatusTableLayout.Controls.Add(tempCBox, 0, i + 1);
                    tempCBox.CheckedChanged += tsc.CheckChanged;
                    kies.Add(tempCBox);
                }

                tempLabel = new Label();
                tempLabel.Text = t.datetime.ToString();
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = tID;
                tempLabel.Click += tsc.clickLabelDate;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 1, i + 1);
                uitvoerDatum.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = t.nameReceiver.ToString() + " " + t.ibanReceiver.ToString();
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = tID;
                tempLabel.Click += tsc.clickLabelDate;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 2, i + 1);
                tegenRekening.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = t.remark.ToString();
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = tID;
                tempLabel.Click += tsc.clickLabelDate;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 3, i + 1);
                omschrijving.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = "€" + String.Format("{0:0,00}", t.amount.ToString("f2"));
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = tID;
                tempLabel.Click += tsc.clickLabelDate;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 4, i + 1);
                bedrag.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = statussen[t.transactionStatusId - 1];
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = tID;
                tempLabel.Click += tsc.clickLabelDate;
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
