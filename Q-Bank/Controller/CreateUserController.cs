using Q_Bank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank.Controller
{
    class CreateUserController
    {
        public CreateUser createUser { get; set; }
        public CreateUserController(CreateUser createUser)
        {
            this.createUser = createUser;
            using (var con = new Q_BANKEntities())
            {
                var phonetypes = from c in con.phonetypes
                                 select c.phoneTypeName;

                foreach (string pt in phonetypes)
                {
                    createUser.comboBoxTelType.Items.Add(pt);
                }
            }
            createUser.textBoxBSN.Select();
            createUser.buttonBevestigen.Click += processCreateUser;
        }

        public void processCreateUser(object sender, System.EventArgs e)
        {
            if (checkData())
            {
                DateTime registerDateTime = DateTime.Now;
                using (var con = new Q_BANKEntities())
                {
                    customer newCustomer = new customer()
                    {
                        bsn = createUser.textBoxBSN.Text,
                        active = 0,
                        firstName = createUser.textBoxVoornaam.Text,
                        lastName = createUser.textBoxAchternaam.Text,
                        gender = createUser.comboBoxGeslacht.Text,
                        birthDate = Convert.ToDateTime(createUser.dateTimePickerGeboortedatum.Value),
                        username = createUser.textBoxGebruikersnaam.Text,
                        password = createUser.textBoxWachtwoord.Text,
                        registerDatetime = registerDateTime
                    };
                    con.customers.Add(newCustomer);
                    con.SaveChanges();
                }

                using (var con = new Q_BANKEntities())
                {
                    var customers = from c in con.customers
                                    where c.username == createUser.textBoxGebruikersnaam.Text
                                    select c.customerId;

                    int customerID = 0;

                    foreach (int c in customers)
                    {
                        customerID = c;
                    }

                    customeraddress newCustomerAddress = new customeraddress()
                    {
                        customerId = customerID,
                        active = 1,
                        address = createUser.textBoxAdres.Text,
                        number = createUser.textBoxHuisnummer.Text,
                        zipcode = createUser.textBoxPostcode.Text,
                        city = createUser.textBoxStad.Text,
                        state = "empty",
                        country = createUser.textBoxLand.Text
                    };
                    con.customeraddresses.Add(newCustomerAddress);

                    customerphone newCustomerPhone = new customerphone()
                    {
                        customerId = customerID,
                        phoneTypeId = createUser.comboBoxTelType.SelectedIndex + 1,
                        phonenumber = createUser.textBoxTel.Text,
                        active = 1
                    };
                    con.customerphones.Add(newCustomerPhone);

                    customeremail newCustomerEmail = new customeremail()
                    {
                        customerId = customerID,
                        active = 1,
                        email = createUser.textBoxEmail.Text
                    };
                    con.customeremails.Add(newCustomerEmail);

                    con.SaveChanges();
                }
                resetFields();
                createUser.showMessage("Het account is met succes aangemaakt!");
                createUser.Close();
            }
        }

        public bool checkData()
        {
            if (!String.IsNullOrEmpty(createUser.textBoxBSN.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxVoornaam.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxAchternaam.Text) &&
               createUser.comboBoxGeslacht.SelectedIndex >= 0 &&
               !String.IsNullOrEmpty(createUser.textBoxAdres.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxHuisnummer.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxPostcode.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxStad.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxLand.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxTel.Text) &&
               createUser.comboBoxTelType.SelectedIndex >= 0 &&
               !String.IsNullOrEmpty(createUser.textBoxEmail.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxGebruikersnaam.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxWachtwoord.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxHerhaalWachtwoord.Text))
            {
                if (!checkUsername(createUser.textBoxGebruikersnaam.Text))
                {
                    createUser.showMessage("Gebruikersnaam is al in gebruik!");
                    return false;
                }
                else if(!checkPassword(createUser.textBoxWachtwoord.Text, createUser.textBoxHerhaalWachtwoord.Text)){
                    createUser.showMessage("Wachtwoorden komen niet overeen!");
                    return false;
                }
            }
            else
            {     
                createUser.showMessage("Niet alle velden zijn ingevuld!");
                return false;
            }

            return true;
        }

        private bool checkUsername(string username)
        {
            using (var con = new Q_BANKEntities())
            {
                var query = from c in con.customers
                            where c.username == createUser.textBoxGebruikersnaam.Text
                            select c;

                if (query.Count() != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool checkPassword(string password, string password2)
        {
            if (password != password2)
            {
                return false;
            }

            return true;
        }

        private void resetFields()
        {
            createUser.textBoxBSN.Clear();
            createUser.textBoxVoornaam.Clear();
            createUser.textBoxAchternaam.Clear();
            createUser.comboBoxGeslacht.Text = "Kies:";
            createUser.dateTimePickerGeboortedatum.Text = DateTime.Today.ToString();
            createUser.textBoxAdres.Clear();
            createUser.textBoxHuisnummer.Clear();
            createUser.textBoxPostcode.Clear();
            createUser.textBoxStad.Clear();
            createUser.textBoxLand.Clear();
            createUser.textBoxTel.Clear();
            createUser.comboBoxTelType.Text = "Kies: ";
            createUser.textBoxEmail.Clear();
            createUser.textBoxGebruikersnaam.Clear();
            createUser.textBoxWachtwoord.Clear();
            createUser.textBoxHerhaalWachtwoord.Clear();
        }

        /*public bool checkOnlyNumbers(string text)
        {
            foreach (char c in text)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
        public bool checkNoNumbers(string text)
        {
            foreach (char c in text)
            {
                if (Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }*/
    }
}
