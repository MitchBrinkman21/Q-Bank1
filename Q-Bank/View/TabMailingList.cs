using Q_Bank.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.Model;
using System.Drawing;

namespace Q_Bank.View
{
    public class TabMailingList
    {
        public FormMain formMain { get; set; }
        public Controller.MailingListController tsc;
        public List<Label> uitvoerDatum, tegenRekening, omschrijving, bedrag, status;
        public List<CheckBox> kies;
        public List<Transaction> ListTransactions;
        private Label lKies, lUitvoerDatum, lTegenRekening, lOmschrijving, lBedrag, lStatus;
        public bool hideVerzondenItems = false;
        public bool allesGeselecteerd = false;
        public TabMailingList(FormMain formMain)
        {
            uitvoerDatum = new List<Label>();
            tegenRekening = new List<Label>();
            omschrijving = new List<Label>();
            bedrag = new List<Label>();
            status = new List<Label>();
            kies = new List<CheckBox>();
            ListTransactions = new List<Transaction>();
            this.formMain = formMain;
            tsc = new Controller.MailingListController(this);
            formMain.transactionStatusSelectEverything.MouseClick += tsc.SelectAllHandler;
            formMain.transactionStatusButtonAnnuleren.MouseClick += tsc.Annuleren;
            formMain.transactieStatusVerzenden.MouseClick += tsc.Verzenden;
            formMain.transactionStatusRefreshButton.MouseClick += tsc.Refresch;
            tsc = new Controller.MailingListController(this);
            formMain.transactieStatusVerzenden.Enabled = false;
            formMain.transactionStatusButtonAnnuleren.Enabled = false;
            FillList();
            //verwijderd de verticale scrollbar
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            formMain.TransactionStatusTableLayout.Padding = new Padding(0, 0, vertScrollWidth, 0);
        }

        public void FillList()
        {
            allesGeselecteerd = false;
               
            formMain.TransactionStatusTableLayout.Controls.Clear();
            formMain.TransactionStatusTableLayout.RowStyles.Clear();
            formMain.TransactionStatusTableLayout.RowCount = 1;
            AddDefaultLabels();
            ClearArray();

            int i = 0;
            if (TransactionController.transactions.Count() == 0)
            {
                Label tempLabel0 = new Label();
                tempLabel0.Text = "Er zijn geen rekeningen te verzenden";
                tempLabel0.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel0.Tag = i;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel0, 2, i + 1);
                tegenRekening.Add(tempLabel0);
            }
            else
            {
                foreach (Model.Transaction t in TransactionController.transactions)
                {
                    AddItemsInTable(t, i);
                    i++;
                }
            }
            formMain.TransactionStatusTableLayout.RowCount = i + 2;
            Label tempLabel = new Label();
            formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 0, formMain.TransactionStatusTableLayout.RowCount);
        }


        private void AddItemsInTable(Transaction t, int i)
        {
                ListTransactions.Add(t);
                Label tempLabel;
                CheckBox tempCBox;

                tempCBox = new CheckBox();
                tempCBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempCBox.Tag = i;
                formMain.TransactionStatusTableLayout.Controls.Add(tempCBox, 0, i + 1);
                tempCBox.CheckedChanged += tsc.CheckChanged;
                kies.Add(tempCBox);


                tempLabel = new Label();
                tempLabel.Text = t.datetime.ToString();
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = i;
                //tempLabel.Click += tsc.clickLabelDate;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 1, i + 1);
                uitvoerDatum.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = t.nameReceiver.ToString() + " " + t.ibanReceiver.ToString();
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = i;
                //tempLabel.Click += tsc.clickLabelDate;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 2, i + 1);
                tegenRekening.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = t.remark.ToString();
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = i;
                //tempLabel.Click += tsc.clickLabelDate;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 3, i + 1);
                omschrijving.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = "€" + String.Format("{0:0,00}", t.amount.ToString("f2"));
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = i;
                //tempLabel.Click += tsc.clickLabelDate;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 4, i + 1);
                bedrag.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = "nog te verzenden";
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                tempLabel.Tag = i;
                //tempLabel.Click += tsc.clickLabelDate;
                formMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 5, i + 1);
                status.Add(tempLabel);                
        }


        private void AddDefaultLabels()
        {
            lKies = new Label();
            lKies.Text = "Kies";
            lKies.Font = new Font("Arial", 9, FontStyle.Bold);
            lKies.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lKies, 0, 0);

            lUitvoerDatum = new Label();
            lUitvoerDatum.Text = "Uitvoerdatum";
            lUitvoerDatum.Font = new Font("Arial", 9, FontStyle.Bold);
            lUitvoerDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lUitvoerDatum, 1, 0);

            lTegenRekening = new Label();
            lTegenRekening.Text = "Tegenrekening";
            lTegenRekening.Font = new Font("Arial", 9, FontStyle.Bold);
            lTegenRekening.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lTegenRekening, 2, 0);

            lOmschrijving = new Label();
            lOmschrijving.Text = "Omschrijving";
            lOmschrijving.Font = new Font("Arial", 9, FontStyle.Bold);
            lOmschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lOmschrijving, 3, 0);

            lBedrag = new Label();
            lBedrag.Text = "Bedrag";
            lBedrag.Font = new Font("Arial", 9, FontStyle.Bold);
            lBedrag.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            formMain.TransactionStatusTableLayout.Controls.Add(lBedrag, 4, 0);

            lStatus = new Label();
            lStatus.Text = "Status";
            lStatus.Font = new Font("Arial", 9, FontStyle.Bold);
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
