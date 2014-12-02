using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank.View;
using System.Windows.Forms;

namespace Q_Bank.Controller
{
    public class TransactionOverviewController
    {
        private TabTransactionOverview tto;
        public TransactionOverviewController(TabTransactionOverview tto)
        {
            this.tto = tto;
            FillAccountsCombobox();
        }

        private void FillAccountsCombobox()
        {
            using (var con = new Q_BANKEntities())
            {
                int userId = 1;
                tto.formMain.TransactionOverviewAccountsCombobox.Items.Clear();
                var accountsCol = from a in con.accounts
                                  where a.userId == userId
                                  select a;

                if (accountsCol.Count() > 0)
                {
                    tto.formMain.TransactionOverviewAccountsCombobox.Items.Add(new ComboBoxItem(0, "Alle rekeningen"));
                    tto.formMain.TransactionOverviewAccountsCombobox.SelectedIndex = 0;
                    foreach (account a in accountsCol)
                    {
                        tto.formMain.TransactionOverviewAccountsCombobox.Items.Add(new ComboBoxItem(a.accountId, a.iban.ToString()));
                    }
                }
                else
                {
                    tto.formMain.TransactionOverviewAccountsCombobox.Items.Add(new ComboBoxItem(-1, "Geen rekeningen gevonden"));
                    tto.formMain.TransactionOverviewAccountsCombobox.SelectedIndex = 0;
                }
            }
        }
            
    }

    public class ComboBoxItem
    {
        public int Value;
        public string Text;
        public ComboBoxItem(int val, string text)
        {
            Value = val;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
