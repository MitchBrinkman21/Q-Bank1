﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank.Model;

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
                            where c.customerId == formMain.id
                            select c;

                if (query.Count() > 0)
                {


                    formMain.transactionComboBox1.Items.Add(new ComboBoxItem(0, "Selecteer rekening", "", 0));
                    formMain.transactionComboBox1.SelectedIndex = 0;
                    foreach (account a in query)
                    {
                        formMain.transactionComboBox1.Items.Add(new ComboBoxItem(a.accountId, a.iban, a.accounttype.accountTypeName, a.balance));
                    }
                }
                else
                {
                    formMain.transactionComboBox1.Items.Add(new ComboBoxItem(-1, "Geen rekeningen gevonden", "", 0));
                    formMain.transactionComboBox1.SelectedIndex = 0;
                }
            }
        }

        public void sendTransactionNew(object sender, System.EventArgs e)
        {
            if (IsCorrectlyFilledIn())
            {
                ComboBoxItem tp = (ComboBoxItem)formMain.transactionComboBox1.SelectedItem;
                if (!tp.Iban.Equals(formMain.transactionTextBox2.Text))
                {
                    createTransaction();
                    resetFields();
                }
                else
                {
                    formMain.transactionLabel9.Text = "U heeft uw eigen IBAN ingevuld als doelrekening";
                }
            }
        }

        public void sendTransactionOverview(object sender, System.EventArgs e)
        {
            if (IsCorrectlyFilledIn())
            {
                ComboBoxItem tp = (ComboBoxItem)formMain.transactionComboBox1.SelectedItem;
                if (!tp.Iban.Equals(formMain.transactionTextBox2.Text))
                {
                    createTransaction();
                    resetFields();
                    formMain.tabControl1.SelectedIndex = 3;
                }
                else
                {
                    formMain.transactionLabel9.Text = "U heeft uw geselecteerde IBAN ingevuld als doelrekening";
                }
            }

        }

        private void createTransaction()
        {
            using (var con = new Q_BANKEntities())
            {
                ComboBoxItem tp = (ComboBoxItem)formMain.transactionComboBox1.SelectedItem;
                transaction newTransaction = new transaction()
                {
                    accountId = tp.AccountId,
                    transactionTypeId = 1,
                    transactionStatusId = 1,
                    amount = Convert.ToDouble(formMain.transactionNumericUpDown1.Text),
                    datetime = DateTime.Now,
                    executeDate = Convert.ToDateTime(formMain.transactionDateTimePicker1.Value),
                    commitDatetime = null,
                    commit = 0,
                    nameReceiver = formMain.transactionTextBox1.Text,
                    ibanReceiver = formMain.transactionTextBox2.Text,
                    remark = formMain.transactionTextBox3.Text,
                    sepa = 0,
                    bic = "QBank"
                };
                con.transactions.Add(newTransaction);
                con.SaveChanges();


            }
        }

        private Boolean IsCorrectlyFilledIn()
        {
            Boolean filled = false;
            if (formMain.transactionComboBox1.SelectedIndex != 0)
            {

                if (!String.IsNullOrEmpty(formMain.transactionTextBox1.Text) &&
                        !String.IsNullOrEmpty(formMain.transactionTextBox2.Text) &&
                        !String.IsNullOrEmpty(formMain.transactionTextBox3.Text) &&
                        Convert.ToDouble(formMain.transactionNumericUpDown1.Text) != 0.00)
                {
                    //Check IBANformaat
                    if (isIbanChecksumValid(formMain.transactionTextBox2.Text))
                    {
                        filled = true;
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
            return filled;
        }

        private void resetFields()
        {
            formMain.transactionTextBox1.Text = String.Empty;
            formMain.transactionTextBox2.Text = String.Empty;
            formMain.transactionTextBox3.Text = String.Empty;
            formMain.transactionDateTimePicker1.Text = DateTime.Today.ToString();
            formMain.transactionNumericUpDown1.Text = "0.00";
            formMain.transactionLabel9.Text = String.Empty;
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
}
