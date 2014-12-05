using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.View;

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
            }
            else
            {
                foreach (CheckBox item in tss.kies)
                {
                    item.Checked = false;
                }
                tss.allesGeselecteerd = false;
            }
        }

        public void Annuleren(object sender, EventArgs e)
        {
            List<transaction> d = new List<transaction>();
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
                            d.Add(item);
                        }
                    }
                }
            }

            DialogResult result = MessageBox.Show("Wilt u de geselecteerde items annuleren?", "Weet u het zeker", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                SetID(6, d);
                MessageBox.Show("Alles is geannuuleerd behalve die al worden verwerkt", "annuleren");
                tss.TransactionStatusAccountComboboxChanged(sender, e);
            }
            else
            {
                MessageBox.Show("De annulerening is geannuleerd", "annuleren");
            }
        }

        private void FillAccountsCombobox()
        {
            using (var con = new Q_BANKEntities())
            { 
                int userId = 1;
                tss.formMain.TrasactionStatusDropBox.Items.Clear();
                var accountsCol = from a in con.accounts
                                  where a.customerId == userId
                                  select a;

                if (accountsCol.Count() > 0)
                {
                    tss.formMain.TrasactionStatusDropBox.Items.Add(new ComboBoxItem(0, "Alle rekeningen"));
                    tss.formMain.TrasactionStatusDropBox.SelectedIndex = 0;
                    foreach (account a in accountsCol)
                    {
                        tss.formMain.TrasactionStatusDropBox.Items.Add(new ComboBoxItem(a.accountId, a.iban.ToString()));
                    }
                }
                else
                {
                    tss.formMain.TrasactionStatusDropBox.Items.Add(new ComboBoxItem(-1, "Geen rekeningen gevonden"));
                    tss.formMain.TrasactionStatusDropBox.SelectedIndex = 0;
                }
            }
        }

        public void clickLabelDate(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            View.TransactionDetails d = new View.TransactionDetails(Convert.ToInt32(clickedLabel.Tag), null);
            d.ShowDialog();
        }

        public void Verzenden(object sender, EventArgs e)
        {
            List<transaction> d = new List<transaction>();
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
                            d.Add(item);
                        }
                    }
                }
            }

            DialogResult result = MessageBox.Show("Wilt u de geselecteerde items verzenden?", "Weet u het zeker", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                SetID(2, d);
                MessageBox.Show("Alle niet verzonden items zijn verzonden", "Verzenden");
                tss.TransactionStatusAccountComboboxChanged(sender, e);
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
    }
}
