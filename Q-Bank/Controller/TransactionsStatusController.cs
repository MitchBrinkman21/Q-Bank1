using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.View;
using Q_Bank.Model;

namespace Q_Bank.Controller
{
    public class TransactionsStatusController
    {
        private View.TabTransactionStatus tss;
        

        public TransactionsStatusController(View.TabTransactionStatus tss)
        {
            this.tss = tss;
            FillAccountsCombobox();
        }


        public void SelectAllHandler(object sender, System.EventArgs e)
        {
            if (!tss.allesGeselecteerd)
            {
                foreach (CheckBox item in tss.kies)
                {
                    item.Checked = true;
                }
                tss.allesGeselecteerd = true;
                tss.formMain.transactieStatusVerzenden.Enabled = true;
                tss.formMain.transactionStatusButtonAnnuleren.Enabled = true;
                
            }
            else
            {
                foreach (CheckBox item in tss.kies)
                {
                    item.Checked = false;
                }
                tss.allesGeselecteerd = false;
                tss.formMain.transactieStatusVerzenden.Enabled = false;
                tss.formMain.transactionStatusButtonAnnuleren.Enabled = false;
            }
        }

        public void Annuleren(object sender, EventArgs e)
        {
            List<transaction> able = new List<transaction>();
            List<transaction> unAble = new List<transaction>();
            var selectedId = from id in tss.kies
                             where id.Checked == true
                             select id.Tag;
            foreach (int id in selectedId)
            {
                using (var con = new Q_BANKEntities())
                {
                    var transact = from a in con.transactions
                                   where a.transactionId == id
                                   select a;
                    foreach (transaction item in transact)
                    {
                        if (item.transactionStatusId == 1 || item.transactionStatusId == 2)
                        {
                            able.Add(item);
                        }
                    }
                }
            }

            DialogResult result = MessageBox.Show("Wilt u de geselecteerde items annuleren?", "Weet u het zeker", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                SetID(6, able);
                MessageBox.Show("Alles is geannuuleerd", "annuleren");
                tss.TransactionStatusAccountComboboxChanged(sender, e);
            }
            else
            {
                MessageBox.Show("De annulerening is geannuleerd", "annuleren");
            }
        }

        private void FillAccountsCombobox()
        {
            AccComboBoxGen acbg = new AccComboBoxGen(tss.formMain, tss.formMain.TrasactionStatusDropBox);
        }

        public void clickLabelDate(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            View.TransactionDetails d = new View.TransactionDetails(Convert.ToInt32(clickedLabel.Tag), null);
            d.ShowDialog();
        }

        public void Verzenden(object sender, EventArgs e)
        {
            List<transaction> send = new List<transaction>();
            List<transaction> notSend = new List<transaction>();
            var selectedId = from id in tss.kies
                             where id.Checked == true
                             select id.Tag;
            foreach (int id in selectedId)
            {
                using (var con = new Q_BANKEntities())
                {
                    var transact = from a in con.transactions
                                       where a.transactionId == id
                                       select a;
                    foreach (transaction item in transact)
                    {
                        if (item.transactionStatusId == 1)
                        {
                            send.Add(item);
                        }
                        else
                        {
                            notSend.Add(item);
                        }
                    }
                }
            }

            DialogResult result = MessageBox.Show("Wilt u de geselecteerde items verzenden?", "Weet u het zeker", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                if(send.Count > 0)
                {
                    SetID(2, send);
                    if (notSend.Count > 0)
                    {
                        if (notSend.Count == 1 && send.Count == 1)
                        {
                            MessageBox.Show(notSend.Count + " Item is niet verzonden omdat deze reeds al verzonden is\n" + send.Count + " item is wel verzonden", "Verzenden");
                        }
                        else if(notSend.Count == 1 && send.Count > 1)
                        {
                            MessageBox.Show(notSend.Count + " Item is niet verzonden omdat deze reeds al verzonden is\n" + send.Count + " items zijn wel verzonden", "Verzenden");
                        }
                        else if (notSend.Count > 1 && send.Count == 1)
                        {
                            MessageBox.Show(notSend.Count + " Items zijn niet verzonden omdat deze reeds al verzonden zijn\n" + send.Count + " item is wel verzonden", "Verzenden");
                        }
                        else if (notSend.Count > 1 && send.Count > 1)
                        {
                            MessageBox.Show(notSend.Count + " Items zijn niet verzonden omdat deze reeds al verzonden zijn\n" + send.Count + " items zijn wel verzonden", "Verzenden");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Alle geselecteerde items zijn succesvol verzonden","verzenden");
                    }
                    tss.TransactionStatusAccountComboboxChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("er is geen geldige selectie gevonden om te verzenden/n je kunt alleen niet verzonden items verzenden", "verzenden");
                    foreach (CheckBox item in tss.kies)
                    {
                        item.Checked = false;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("De verzending is geannuleerd", "Verzenden");
            }
        }

        public void SetID(int setID, List<transaction> transactions)
        {

            using (var con = new Q_BANKEntities())
            {
                foreach (transaction item in transactions)
	            {
	    	 
	                var done = from a in con.transactions
                                     where a.transactionId == item.transactionId
                                     select a;

                    foreach (transaction item1 in done)
                    {
                         item1.transactionStatusId = setID;
                    }

                    try
                    {
                        con.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        // Provide for exceptions.
                        throw e;
                    }
                }
            }

        }
        public void Hide(object sender, EventArgs e)
        {
            if (!tss.hideVerzondenItems)
            {
                tss.hideVerzondenItems = true;
                tss.formMain.transactieStatusHideButton.Text = "alle items";
                tss.TransactionStatusAccountComboboxChanged(sender, e);
            }
            else
            {
                tss.hideVerzondenItems = false;
                tss.formMain.transactieStatusHideButton.Text = "niet verzonden items";
                tss.TransactionStatusAccountComboboxChanged(sender, e);
            }
        }

        public void Refresch(object sender, EventArgs e)
        {
            tss.TransactionStatusAccountComboboxChanged(sender, e);
        }

        public void CheckChanged(object sender, EventArgs e)
        {
            var selectedId = from id in tss.kies
                             where id.Checked == true
                             select id.Tag;

            if (selectedId.Count() > 0)
            {
                tss.formMain.transactieStatusVerzenden.Enabled = true;
                tss.formMain.transactionStatusButtonAnnuleren.Enabled = true;
            }
            else
            {
                tss.formMain.transactieStatusVerzenden.Enabled = false;
                tss.formMain.transactionStatusButtonAnnuleren.Enabled = false;
            }
        }
    }
}
