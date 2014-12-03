using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.Controller;
using System.Data;
using System.Text.RegularExpressions;

namespace Q_Bank.View
{
    public class TabTransaction
    {
        public FormMain formMain { get; set; }
        public TabTransaction(FormMain formMain)
        {
            this.formMain = formMain;
            formMain.transactionButton1.Click += random;
            fillComboBox();
        }

        public void fillComboBox()
        {
            var con = FormMain.connection;
            formMain.transactionComboBox1.Items.Clear();

            var query = from c in con.accounts
                        where c.userId == 2
                        select c;

            if (query.Count() > 0)
            {
                formMain.transactionComboBox1.Items.Add(new ComboBoxItem(0, "Alle rekeningen"));
                formMain.transactionComboBox1.SelectedIndex = 0;
                foreach (account a in query)
                {
                    formMain.transactionComboBox1.Items.Add(new ComboBoxItem(a.accountId, a.accountNumber.ToString()));
                }
            }
            else
            {
                formMain.transactionComboBox1.Items.Add(new ComboBoxItem(-1, "Geen rekeningen gevonden"));
                formMain.transactionComboBox1.SelectedIndex = 0;
            }
        }

        public void random(object sender, System.EventArgs e)
        {

            var con = FormMain.connection;

            if (formMain.transactionComboBox1.SelectedIndex != 0)
            {
                //Check of alle tekstboxen zijn gevuld
                if (!String.IsNullOrEmpty(formMain.transactionTextBox1.Text) &&
                    !String.IsNullOrEmpty(formMain.transactionTextBox2.Text) &&
                    !String.IsNullOrEmpty(formMain.transactionTextBox3.Text) &&
                    Convert.ToDouble(formMain.transactionNumericUpDown1.Text) != 0.00)
                {
                    //Check IBANformaat
                    Regex rgx = new Regex(@"^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$");
                    if (rgx.IsMatch(formMain.transactionTextBox2.Text))
                    {

                        
                        transaction newTransaction = new transaction()
                        {
                            accountId = 2,
                            transactionTypeId = 1,
                            transactionStatusId = 1,
                            amount = Convert.ToDouble(formMain.transactionNumericUpDown1.Text),
                            datetime = DateTime.Today,
                            commit = 0,
                            executeDatetime = Convert.ToDateTime(formMain.transactionDateTimePicker1.Value),
                            nameReceiver = formMain.transactionTextBox1.Text,
                            ibanReceiver = formMain.transactionTextBox2.Text,
                            remark = formMain.transactionTextBox3.Text
                        };
                        con.transactions.Add(newTransaction);
                        con.SaveChanges();

                        //Reset calendar and textboxes
                        formMain.transactionTextBox1.Text = String.Empty;
                        formMain.transactionTextBox2.Text = String.Empty;
                        formMain.transactionTextBox3.Text = String.Empty;
                        formMain.transactionDateTimePicker1.Text = DateTime.Today.ToString();
                        formMain.transactionNumericUpDown1.Text = "0.00";
                        formMain.transactionLabel9.Text = String.Empty;
                    }
                    else
                    {
                        formMain.transactionLabel9.ForeColor = System.Drawing.Color.Red;
                        formMain.transactionLabel9.Text = "Dit is geen legitiem IBANformaat";
                    }
                }
                else
                {
                    formMain.transactionLabel9.ForeColor = System.Drawing.Color.Red;
                    formMain.transactionLabel9.Text = "Niet alle tekstvelden zijn ingevuld";
                }
            }
            else
            {
                formMain.transactionLabel9.ForeColor = System.Drawing.Color.Red;
                formMain.transactionLabel9.Text = "Je hebt geen rekening gekozen";
            }
        }
    }

    public class TempAccount
    {
        public string accountnumber;
        public int accountid;
        public TempAccount(int accountid, string accountnumber)
        {
            this.accountid = accountid;
            this.accountnumber = accountnumber;
        }

        public override string ToString()
        {
            return accountnumber;
        }
    }
}
