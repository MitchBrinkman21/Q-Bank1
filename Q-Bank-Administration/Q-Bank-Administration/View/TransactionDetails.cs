using Q_Bank;
using Q_Bank.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank_Administration.View
{
    public partial class TransactionDetails : Form
    {
        public TransactionDetails(int tID, ComboBoxItem cbi)
        {
            InitializeComponent();
            using (var con = new Q_BANKEntities())
            {
                var details = from t in con.transactions
                              where t.transactionId == tID
                              select t;

                String transactionType = "";
                transaction tr = details.First();
                if (cbi != null)
                {
                    if (cbi.AccountId > 0)
                    {
                        if (cbi.Iban.Equals(tr.ibanReceiver))
                        {
                            transactionType = "Bijschrijving";

                            tr.nameReceiver = tr.account.customer.firstName + " " + tr.account.customer.lastName;
                            tr.ibanReceiver = tr.account.iban;
                        }
                        else
                        {
                            transactionType = "Afschrijving";
                        }
                    }
                }
                accountLabel.Text = tr.account.iban.ToString() + "-" + tr.account.accounttype.accountTypeName.ToString();
                datetimeLabel.Text = tr.datetime.ToShortDateString();
                executeDateLabel.Text = tr.executeDate.ToShortDateString();
                fromAccountLabel.Text = tr.nameReceiver.ToString() + "\n" + tr.ibanReceiver.ToString();
                transactionTypeLabel.Text = transactionType.ToString();
                double amount = tr.amount;
                if (tr.amount < 0)
                {
                    amount *= -1;
                }
                amountLabel.Text = "€" + String.Format("{0:0,00}", amount.ToString("f2"));
                remarkLabel.Text = tr.remark.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
