using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank.Controller
{
    public class TransactionsStatusController
    {
        private View.TabTransactionStatus tss;
        public bool AllesGeselecteerd { get; set; }
        private List<int> selectedId;
        public TransactionsStatusController(View.TabTransactionStatus tss)
        {
            this.tss = tss;
            AllesGeselecteerd = false;
            selectedId = new List<int>();
            FillAccountsCombobox();
        }


        public void SelectAllHandler(object sender, System.EventArgs e)
        {
            if (!AllesGeselecteerd)
            {
                foreach (CheckBox item in tss.kies)
                {
                    item.Checked = true;
                }
                AllesGeselecteerd = true;
            }
            else
            {
                foreach (CheckBox item in tss.kies)
                {
                    item.Checked = false;
                }
                AllesGeselecteerd = false;
            }
        }

        public void Annuleren(object sender, EventArgs e)
        {
            string a = "";
            selectedId.Clear();
            for (int i = 0; i < tss.kies.Count; i++)
            {
                if (tss.kies[i].Checked == true)
                {
                    selectedId.Add(i);
                    a += i;
                }
            }
            MessageBox.Show(a, "geselecteerde resultaaten");
        }

        public void Search(object sender, EventArgs e)
        {
            String a = tss.formMain.TransactionStatusSearchBar.Text;
            MessageBox.Show(tss.formMain.TransactionStatusSearchBar.Text, "ingetypte resultaat resultaaten");
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
    }
}
