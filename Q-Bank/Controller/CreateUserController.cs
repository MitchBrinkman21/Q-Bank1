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
                // Fill combobox with phonetypes
                foreach (string pt in phonetypes)
                {
                    createUser.comboBoxPhoneType.Items.Add(pt);
                }
            }
            createUser.textBoxBSN.Select();
            createUser.buttonBevestigen.Click += processCreateUser;
            createUser.textBoxUsername.TextChanged += checkUsername;
            createUser.textBoxPassword.Leave += checkPassword;
            createUser.textBoxRepeatPassword.Leave += checkPassword;
            createUser.textBoxZipcode.Leave += fillAddress;
            createUser.textBoxNumber.Leave += fillAddress;
        }

        public void processCreateUser(object sender, System.EventArgs e)
        {
            // Check if entered data is valid
            if (checkData())
            {
                // Import data into database

                using (var con = new Q_BANKEntities())
                {
                    customer newCustomer = new customer()
                    {
                        bsn = createUser.textBoxBSN.Text,
                        active = 0,
                        firstName = createUser.textBoxFirstname.Text,
                        lastName = createUser.textBoxLastname.Text,
                        gender = createUser.comboBoxGender.Text,
                        birthDate = Convert.ToDateTime(createUser.dateTimePickerBirthday.Value),
                        username = createUser.textBoxUsername.Text,
                        password = createUser.textBoxPassword.Text,
                        registerDatetime = DateTime.Now
                    };
                    con.customers.Add(newCustomer);
                    con.SaveChanges();
                }

                using (var con = new Q_BANKEntities())
                {
                    var customers = from c in con.customers
                                    where c.username == createUser.textBoxUsername.Text
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
                        address = createUser.textBoxAddress.Text,
                        number = createUser.textBoxNumber.Text,
                        zipcode = createUser.textBoxZipcode.Text,
                        city = createUser.textBoxCity.Text,
                        state = "empty",
                        country = createUser.textBoxCountry.Text
                    };
                    con.customeraddresses.Add(newCustomerAddress);

                    customerphone newCustomerPhone = new customerphone()
                    {
                        customerId = customerID,
                        phoneTypeId = createUser.comboBoxPhoneType.SelectedIndex + 1,
                        phonenumber = createUser.textBoxPhonenumber.Text,
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
                createUser.showMessage("Uw account is met succes aangemaakt!");
                resetFields();
                createUser.Close();
            }
        }

        public bool checkData()
        {
            // Check if all entered data is not empty
            if (!String.IsNullOrEmpty(createUser.textBoxBSN.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxFirstname.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxLastname.Text) &&
               createUser.comboBoxGender.SelectedIndex >= 0 &&
               !String.IsNullOrEmpty(createUser.textBoxAddress.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxNumber.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxZipcode.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxCity.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxCountry.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxPhonenumber.Text) &&
               createUser.comboBoxPhoneType.SelectedIndex >= 0 &&
               !String.IsNullOrEmpty(createUser.textBoxEmail.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxUsername.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxPassword.Text) &&
               !String.IsNullOrEmpty(createUser.textBoxRepeatPassword.Text))
            {
                // Check if username doesn't exist and password is correct
                if(createUser.labelCheckUsername.Visible == true || createUser.labelCheckPassword.Visible == true)
                {
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

        private void checkUsername(object sender, System.EventArgs e)
        {
            using (var con = new Q_BANKEntities())
            {
                var query = from c in con.customers
                            where c.username == createUser.textBoxUsername.Text
                            select c;
                // Check if username doesn't exist
                if (query.Count() != 0)
                {
                    createUser.labelCheckUsername.Visible = true;
                }
                else
                {
                    createUser.labelCheckUsername.Visible = false;
                }
            }
        }

        private void checkPassword(object sender, System.EventArgs e)
        {
            // Check if password is equal to repeated password
            if (!String.IsNullOrEmpty(createUser.textBoxPassword.Text) &&
                !String.IsNullOrEmpty(createUser.textBoxRepeatPassword.Text))
            {
                if (createUser.textBoxPassword.Text != createUser.textBoxRepeatPassword.Text)
                {
                    createUser.labelCheckPassword.Visible = true;
                }
                else
                {
                    createUser.labelCheckPassword.Visible = false;
                }
            }
        }

        private void fillAddress(object sender, System.EventArgs e)
        {
            if (!String.IsNullOrEmpty(createUser.textBoxZipcode.Text) &&
                !String.IsNullOrEmpty(createUser.textBoxNumber.Text))
            {
                /*AddressGenerator ag = new AddressGenerator(createUser.textBoxZipcode.Text, createUser.textBoxNumber.Text);
                ag.generateAddressDetails();
                createUser.textBoxAddress.Text = ag.street;
                createUser.textBoxCity.Text = ag.city;*/
            }
        }

        private void resetFields()
        {
            createUser.textBoxBSN.Clear();
            createUser.textBoxFirstname.Clear();
            createUser.textBoxLastname.Clear();
            createUser.comboBoxGender.Text = "Kies:";
            createUser.dateTimePickerBirthday.Text = DateTime.Today.ToString();
            createUser.textBoxAddress.Clear();
            createUser.textBoxNumber.Clear();
            createUser.textBoxZipcode.Clear();
            createUser.textBoxCity.Clear();
            createUser.textBoxCountry.Clear();
            createUser.textBoxPhonenumber.Clear();
            createUser.comboBoxPhoneType.Text = "Kies: ";
            createUser.textBoxEmail.Clear();
            createUser.textBoxUsername.Clear();
            createUser.textBoxPassword.Clear();
            createUser.textBoxRepeatPassword.Clear();
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
