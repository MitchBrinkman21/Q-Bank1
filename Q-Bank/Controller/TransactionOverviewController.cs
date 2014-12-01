using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank.View;

namespace Q_Bank.Controller
{
    public class TransactionOverviewController
    {
        private TabTransactionOverview tto;
        public TransactionOverviewController(TabTransactionOverview tto)
        {
            this.tto = tto;
            FillAccountsCombobox();
            FillTransactionsTable();
        }

        private void FillAccountsCombobox()
        {
            using (var con = new Q_BANKEntities())
            {
                tto.formMain.TransactionOverviewAccountsCombobox.Items.Clear();
                var accountsCol = from a in con.accounts
                                  select a;

                foreach (account a in accountsCol)
                {
                    tto.formMain.TransactionOverviewAccountsCombobox.Items.Add(a);
                }

            }
        }

        private void FillTransactionsTable()
        {
            using (var con = new Q_BANKEntities())
            {

                var transactionCol = from t in con.transactions
                                     select t;

                foreach (transaction t in transactionCol)
                {
                    
                }

            }
        }
    }
}
