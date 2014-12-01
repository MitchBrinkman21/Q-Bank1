using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.Controller;

namespace Q_Bank.View
{
    public class TabTransaction
    {
        public FormMain formMain { get; set; }
        public TabTransaction(FormMain formMain)
        {
            this.formMain = formMain;
            formMain.transactionButton1.Click += random;
        }

        public void random(object sender, System.EventArgs e) {

            using (var con = new Q_BANKEntities())
            {
        
                transaction newTransaction = new transaction() { accountId = 2, transactionTypeId = 1, transactionStatusId = 1,
                                                                 amount = Convert.ToDouble(formMain.transactionNumericUpDown1.Text),
                                                                 datetime = DateTime.Today,
                                                                 commit = 0,
                                                                 executeDatetime = Convert.ToDateTime(formMain.transactionDateTimePicker1.Value),
                                                                 nameReceiver = formMain.transactionTextBox2.Text,
                                                                 ibanReceiver = "lalalalala" ,
                                                                 remark = formMain.transactionTextBox3.Text
                };
               

                con.transactions.Add(newTransaction);
                con.SaveChanges();
            }

            formMain.transactionTextBox1.Text = String.Empty;
            formMain.transactionTextBox2.Text = String.Empty;
            formMain.transactionTextBox3.Text = String.Empty;
            formMain.transactionDateTimePicker1.Text = DateTime.Today.ToString();
            formMain.transactionNumericUpDown1.Text = "0.00";
        }
    }
}
