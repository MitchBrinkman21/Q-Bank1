using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank.View
{
    public partial class TransactionDetails : Form
    {
        public TransactionDetails(int tID)
        {
            InitializeComponent();
            using (var con = new Q_BANKEntities())
            {
                var details = from t in con.transactions 
                              where t.transactionId == tID
                              select t;

                transaction tr = details.First();
                accountLabel.Text = tr.account.iban.ToString() + "-" + tr.account.accounttype.accountTypeName.ToString();
                datetimeLabel.Text = tr.datetime.ToShortDateString();
                executeDateLabel.Text = tr.executeDate.Value.ToShortDateString();
                fromAccountLabel.Text = tr.nameReceiver.ToString() + "\n" + tr.ibanReceiver.ToString();
                transactionTypeLabel.Text = tr.transactiontype.transactionTypeName.ToString();
                double amount = tr.amount;
                if (tr.amount < 0)
                {
                    amount *= -1;
                }
                amountLabel.Text = "€" + String.Format("{0:0,00}", amount.ToString("f2"));
                transactionStateLabel.Text = tr.transactionstatu.transactionStatusName.ToString();
                remarkLabel.Text = tr.remark.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
