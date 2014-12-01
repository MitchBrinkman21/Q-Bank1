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
        public FormMain FormMain { get; set; }
        public Controller.TransactionsStatusController tsc;
        public List<Label> uitvoerDatum, tegenRekening, omschrijving, bedrag, status;
        public List<CheckBox> kies;
        private Label lKies, lUitvoerDatum, lTegenRekening, lOmschrijving, lBedrag, lStatus;

        public TabTransactionStatus(FormMain FormMain)
        {
            this.FormMain = FormMain;
            tsc = new Controller.TransactionsStatusController(this);

            uitvoerDatum = new List<Label>();
            tegenRekening = new List<Label>();
            omschrijving = new List<Label>();
            bedrag = new List<Label>();
            status = new List<Label>();
            kies = new List<CheckBox>();
            AddTransactions();

            //verwijderd de verticale scrollbar
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            //FormMain.TransactionStatusTableLayout.Padding = new Padding(0, 0, vertScrollWidth, 0);
        }

        private void AddTransactions()
        {
            //FormMain.TransactionStatusTableLayout.Controls.Clear();
            AddDefaultLabels();
            for (int i = 0; i < 25; i++)
            {
                CheckBox tempCBox = new CheckBox();
                tempCBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                //FormMain.TransactionStatusTableLayout.Controls.Add(tempCBox, 0, i + 2);
                kies.Add(tempCBox);

                Label tempLabel = new Label();
                tempLabel.Text = "02-12-2014";
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                //FormMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 1, i + 2);
                uitvoerDatum.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = "Belastingdienst NL86 INGB 0002 4455 88";
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                //FormMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 2, i + 2);
                tegenRekening.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = "Geld dat overgemaakt is door de belasing dienst. Maar dat ook weer terug betaald moet worden :P";
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                //FormMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 3, i + 2);
                omschrijving.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = "€7500,00";
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                //FormMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 4, i + 2);
                bedrag.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = "Bezig met verwerken";
                tempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                //FormMain.TransactionStatusTableLayout.Controls.Add(tempLabel, 5, i + 2);
                status.Add(tempLabel);

                
            }
        }

        private void AddDefaultLabels()
        {
            lKies = new Label();
            lKies.Text = "Kies";
            lKies.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            //FormMain.TransactionStatusTableLayout.Controls.Add(lKies, 0, 0);

            lUitvoerDatum = new Label();
            lUitvoerDatum.Text = "Uitvoerdatum";
            lUitvoerDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            //FormMain.TransactionStatusTableLayout.Controls.Add(lUitvoerDatum, 1, 0);

            lTegenRekening = new Label();
            lTegenRekening.Text = "Tegenrekening";
            lTegenRekening.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
           // FormMain.TransactionStatusTableLayout.Controls.Add(lTegenRekening, 2, 0);

            lOmschrijving = new Label();
            lOmschrijving.Text = "Omschrijving";
            lOmschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            //FormMain.TransactionStatusTableLayout.Controls.Add(lOmschrijving, 3, 0);

            lBedrag = new Label();
            lBedrag.Text = "Bedrag";
            lBedrag.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            //FormMain.TransactionStatusTableLayout.Controls.Add(lBedrag, 4, 0);

            lStatus = new Label();
            lStatus.Text = "Status";
            lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            //FormMain.TransactionStatusTableLayout.Controls.Add(lStatus, 5, 0);

        }
    }
}
