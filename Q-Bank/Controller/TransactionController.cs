using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank.Controller
{
    public class TransactionController
    {
        public FormMain formMain { get; set; }
        public TransactionController(FormMain formMain)
        {
            this.formMain = formMain;
            formMain.transactionButton1.Click += sendTransactionNew;
            formMain.transactionButton2.Click += sendTransactionOverview;
            fillComboBox();
        }

        public void fillComboBox()
        {
            
            formMain.transactionComboBox1.Items.Clear();
            using (var con = new Q_BANKEntities())
            {
                var query = from c in con.accounts
                            where c.userId == 2
                            select c;

                if (query.Count() > 0)
                {


                    formMain.transactionComboBox1.Items.Add(new TempAccount(0, "Selecteer rekening", "", 0));
                    formMain.transactionComboBox1.SelectedIndex = 0;
                    foreach (account a in query)
                    {
                        var query2 = from at in con.accounttypes
                                     where at.accountTypeId == a.accountTypeId
                                     select at;
                        formMain.transactionComboBox1.Items.Add(new TempAccount(a.accountId, a.accountNumber.ToString(), query2.First().accountTypeName, a.balance));
                    }
                }
                else
                {
                    formMain.transactionComboBox1.Items.Add(new TempAccount(-1, "Geen rekeningen gevonden", "", 0));
                    formMain.transactionComboBox1.SelectedIndex = 0;
                }
            }
        }

        public void sendTransactionOverview(object sender, System.EventArgs e)
        {

            if (formMain.transactionComboBox1.SelectedIndex != 0)
            {
                //Check of alle tekstboxen zijn gevuld
                if (!String.IsNullOrEmpty(formMain.transactionTextBox1.Text) &&
                    !String.IsNullOrEmpty(formMain.transactionTextBox2.Text) &&
                    !String.IsNullOrEmpty(formMain.transactionTextBox3.Text) &&
                    Convert.ToDouble(formMain.transactionNumericUpDown1.Text) != 0.00)
                {
                    //Check IBANformaat
                    if (isIbanChecksumValid(formMain.transactionTextBox2.Text))
                    {
                        using (var con = new Q_BANKEntities())
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
                    }
                    else
                    {
                        formMain.transactionLabel9.ForeColor = System.Drawing.Color.Red;
                        formMain.transactionLabel9.Text = "Dit is geen legitieme IBAN";
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
                formMain.transactionLabel9.Text = "Er is geen rekening geselecteerd";
            }
        }

        public void sendTransactionNew(object sender, System.EventArgs e)
        {

            if (formMain.transactionComboBox1.SelectedIndex != 0)
            {
                //Check of alle tekstboxen zijn gevuld
                if (!String.IsNullOrEmpty(formMain.transactionTextBox1.Text) &&
                    !String.IsNullOrEmpty(formMain.transactionTextBox2.Text) &&
                    !String.IsNullOrEmpty(formMain.transactionTextBox3.Text) &&
                    Convert.ToDouble(formMain.transactionNumericUpDown1.Text) != 0.00)
                {
                    //Check IBANformaat
                    if (isIbanChecksumValid(formMain.transactionTextBox2.Text))
                    {
                        var con = FormMain.connection;
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
                        formMain.transactionLabel9.Text = "Dit is geen legitieme IBAN";
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
                formMain.transactionLabel9.Text = "Er is geen rekening geselecteerd";
            }
        }

        //Check if the IBAN format is valid
        public static bool isIbanChecksumValid(string iban)
        {
            if (iban.Length < 4 || iban[0] == ' ' || iban[1] == ' ' || iban[2] == ' ' || iban[3] == ' ') throw new InvalidOperationException();

            var checksum = 0;
            var ibanLength = iban.Length;
            for (int charIndex = 0; charIndex < ibanLength; charIndex++)
            {
                if (iban[charIndex] == ' ') continue;

                int value;
                var c = iban[(charIndex + 4) % ibanLength];
                if ((c >= '0') && (c <= '9'))
                {
                    value = c - '0';
                }
                else if ((c >= 'A') && (c <= 'Z'))
                {
                    value = c - 'A';
                    checksum = (checksum * 10 + (value / 10 + 1)) % 97;
                    value %= 10;
                }
                else if ((c >= 'a') && (c <= 'z'))
                {
                    value = c - 'a';
                    checksum = (checksum * 10 + (value / 10 + 1)) % 97;
                    value %= 10;
                }
                else throw new InvalidOperationException();

                checksum = (checksum * 10 + value) % 97;
            }
            return checksum == 1;
        }
    }


    //Temporary class to fill the combobox with
    public class TempAccount
    {
        public string accountnumber;
        public string accounttype;
        public int accountid;
        public double balance;

        public TempAccount(int accountid, string accountnumber, string accounttype, double balance)
        {
            this.accountid = accountid;
            this.accountnumber = accountnumber;
            this.accounttype = accounttype;
            this.balance = balance;
        }

        public override string ToString()
        {
            if (accountid > 0)
            {
                return accountnumber + " - " + accounttype + " - EUR " + balance;
            }
            else
            {
                return accountnumber;
            }
        }
    }
}
