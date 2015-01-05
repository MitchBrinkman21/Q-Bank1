using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank_Administration.View;
using Q_Bank;
using System.Windows.Forms;
using System.Numerics;

namespace Q_Bank_Administration.Controller
{
    class CreateAccountController
    {
        public CreateAccount createAccount { get; set; }
        public int customerId;
        public CreateAccountController(CreateAccount ca, int customerId)
        {
            this.createAccount = ca;
            this.customerId = customerId;

            using (var con = new Q_BANKEntities())
            {
                var accounttypes = from c in con.accounttypes
                                 select c.accountTypeName;
                // Fill combobox with account types
                foreach (string accountTypeName in accounttypes)
                {
                    createAccount.comboBoxAccountType.Items.Add(accountTypeName);
                }

                var customer = from c in con.customers
                               where c.customerId == customerId
                               select c;

                foreach (var name in customer)
                {
                    createAccount.labelNameText.Text = name.firstName + " " + name.lastName;
                }
            }

            createAccount.buttonSubmit.Click += processCreateAccount;
        }

        private void processCreateAccount(object sender, EventArgs e)
        {
            string accountNumber = createAccountNumber();
            string iban = createIBAN(accountNumber);

            if (isIbanChecksumValid(iban))
            {
                if (createAccount.comboBoxAccountType.SelectedIndex >= 0)
                {
                    using (var con = new Q_BANKEntities())
                    {
                        account newAccount = new account()
                        {
                            customerId = customerId,
                            accountTypeId = createAccount.comboBoxAccountType.SelectedIndex + 1,
                            balance = 0,
                            accountNumber = accountNumber,
                            iban = iban,
                            bic = "QBANK",
                            active = true
                        };
                        con.accounts.Add(newAccount);
                        con.SaveChanges();
                    }
                    MessageBox.Show("De rekening is met succes aangemaakt!");
                    createAccount.Close();
                }
                else
                {
                    MessageBox.Show("Geen type rekening geselecteerd!");
                }
            }
            else
            {
                MessageBox.Show("Er is een fout opgetreden tijdens het aanmaken van de rekening, probeer het opnieuw.");
            }
        }

        public string createAccountNumber()
        {
            Random random = new Random();
            string accountNumber = "";

            for (int sum = 0; sum < 10; sum++)
            {
                accountNumber += random.Next(0, 9).ToString();
            }

            return accountNumber;
        }

        public string createIBAN(string accountNumber)
        {
            BigInteger bla = BigInteger.Parse("26111023" + accountNumber + "232100");

            for (int sum = 0; sum < 100; sum++)
            {
                if ((bla % 97) == 1)
                {
                    if (sum < 10)
                    {
                        return "NL" + "0" + sum.ToString() + "QBAN" + accountNumber;
                    }
                    else
                    {
                        return "NL" + sum.ToString() + "QBAN" + accountNumber;
                    }
                }

                bla += BigInteger.Parse("1");
            }
            return "niks";
        }

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
