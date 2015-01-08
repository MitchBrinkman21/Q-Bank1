using Q_Bank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank.Controller
{
    public class CreateUserController
    {
        public CreateUser createUser { get; set; }
        public bool validUsername { get; set; }
        public bool validPassword { get; set; }
        public bool validText { get; set; }
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
            createUser.textBoxBSN.Leave += checkValidText;
            createUser.textBoxFirstname.Leave += checkValidText;
            createUser.textBoxLastname.Leave += checkValidText;
            createUser.dateTimePickerBirthday.ValueChanged += checkValidText;
            createUser.textBoxZipcode.Leave += checkValidText;
            createUser.textBoxNumber.Leave += checkValidText;
            createUser.textBoxAddress.Leave += checkValidText;
            createUser.textBoxCity.Leave += checkValidText;
            createUser.textBoxCountry.Leave += checkValidText;
            createUser.textBoxPhonenumber.Leave += checkValidText;
            createUser.textBoxEmail.Leave += checkValidText;
            createUser.AcceptButton = createUser.buttonBevestigen;
        }

        public void processCreateUser(object sender, System.EventArgs e)
        {
            // Check if entered data is valid
            if (checkData())
            {
                PasswordEncryption pe = new PasswordEncryption();
                pe.createEncryptedPassword(createUser.textBoxPassword.Text);

                // Import data into database

                using (var con = new Q_BANKEntities())
                {
                    customer newCustomer = new customer()
                    {
                        bsn = createUser.textBoxBSN.Text,
                        active = false,
                        firstName = createUser.textBoxFirstname.Text,
                        lastName = createUser.textBoxLastname.Text,
                        gender = createUser.comboBoxGender.Text,
                        birthDate = Convert.ToDateTime(createUser.dateTimePickerBirthday.Value),
                        username = createUser.textBoxUsername.Text,
                        password = pe.encodedSalt,
                        key = pe.encodedKey,
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
                        active = true,
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
                        active = true
                    };
                    con.customerphones.Add(newCustomerPhone);

                    customeremail newCustomerEmail = new customeremail()
                    {
                        customerId = customerID,
                        active = true,
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
            if (checkEmptyFields())
            {
                if (validUsername && validPassword && validText)
                {
                    return true;
                }
                else
                {
                    createUser.showMessage("Niet alle velden zijn correct ingevuld!");
                    return false;
                }
            }
            else
            {     
                createUser.showMessage("Niet alle velden zijn ingevuld!");
                return false;
            }
        }

        public bool checkEmptyFields()
        {
            // Check if entered data is not empty
            if(!String.IsNullOrEmpty(createUser.textBoxBSN.Text) &&
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
                return true;
            }
            else
            {
                return false;
            }
        }

        public void checkUsername(object sender, System.EventArgs e)
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
                    validUsername = false;
                }
                else
                {
                    createUser.labelCheckUsername.Visible = false;
                    validUsername = true;
                }
            }
        }

        public void checkPassword(object sender, System.EventArgs e)
        {
            // Check if password is equal to repeated password
            if (!String.IsNullOrEmpty(createUser.textBoxPassword.Text) &&
                !String.IsNullOrEmpty(createUser.textBoxRepeatPassword.Text))
            {
                if (createUser.textBoxPassword.Text != createUser.textBoxRepeatPassword.Text)
                {
                    createUser.labelCheckPassword.Text = "Wachtwoorden komen niet overeen!";
                    createUser.labelCheckPassword.Visible = true;
                    validPassword = false;
                }
                else if (createUser.textBoxPassword.Text.Length < 5)
                {
                    createUser.labelCheckPassword.Text = "Wachtwoord voldoet niet aan de eisen!";
                    createUser.labelCheckPassword.Visible = true;
                    validPassword = false;
                }
                else
                {
                    createUser.labelCheckPassword.Visible = false;
                    validPassword = true;
                }
            }
        }

        public void fillAddress(object sender, System.EventArgs e)
        {
            // Search and fill address and city when zipcode and number are entered in the textboxes
            if (!String.IsNullOrEmpty(createUser.textBoxZipcode.Text) &&
                !String.IsNullOrEmpty(createUser.textBoxNumber.Text))
            {
                try
                {
                    AddressGenerator ag = new AddressGenerator(createUser.textBoxZipcode.Text, createUser.textBoxNumber.Text);
                    ag.generateAddressDetails();
                    createUser.textBoxAddress.Text = ag.street;
                    createUser.textBoxCity.Text = ag.city;
                }
                catch
                {
                    createUser.textBoxAddress.Clear();
                    createUser.textBoxCity.Clear();
                }
            }
        }

        public void checkValidText(object sender, System.EventArgs e)
        {
            validText = true;

            // Check if entered data is correct

            if(!String.IsNullOrEmpty(createUser.textBoxBSN.Text) && 
                (!Regex.IsMatch(createUser.textBoxBSN.Text, @"^[0-9]+$") ||
                createUser.textBoxBSN.Text.Length != 9))
            {
                createUser.labelCheckBSN.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckBSN.Visible = false;
            }

            if(!String.IsNullOrEmpty(createUser.textBoxFirstname.Text) && 
                !Regex.IsMatch(createUser.textBoxFirstname.Text, @"^[-\ a-zA-Z]+$"))
            {
                createUser.labelCheckFirstname.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckFirstname.Visible = false;
            }

            if(!String.IsNullOrEmpty(createUser.textBoxLastname.Text) && 
                !Regex.IsMatch(createUser.textBoxLastname.Text, @"^[-\ a-zA-Z]+$"))
            {
                createUser.labelCheckLastname.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckLastname.Visible = false;
            }

            if (createUser.dateTimePickerBirthday.Value > DateTime.Now)
            {
                createUser.labelCheckBirthday.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckBirthday.Visible = false;
            }

            if (!String.IsNullOrEmpty(createUser.textBoxZipcode.Text) &&
                !checkValidZipcode(createUser.textBoxZipcode.Text))
            {
                createUser.labelCheckZipcode.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckZipcode.Visible = false;
            }

            if (!String.IsNullOrEmpty(createUser.textBoxNumber.Text) &&
                !checkValidHouseNumber(createUser.textBoxNumber.Text))
            {
                createUser.labelCheckNumber.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckNumber.Visible = false;
            }

            if (!String.IsNullOrEmpty(createUser.textBoxAddress.Text) &&
                !Regex.IsMatch(createUser.textBoxAddress.Text, @"^[-\ a-zA-Z]+$"))
            {
                createUser.labelCheckAddress.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckAddress.Visible = false;
            }


            if(!String.IsNullOrEmpty(createUser.textBoxCity.Text) && 
                !Regex.IsMatch(createUser.textBoxCity.Text, @"^[-\ a-zA-Z]+$"))
            {
                createUser.labelCheckCity.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckCity.Visible = false;
            }

            if(!String.IsNullOrEmpty(createUser.textBoxCountry.Text) && 
                !Regex.IsMatch(createUser.textBoxCountry.Text, @"^[-\ a-zA-Z]+$"))
            {
                createUser.labelCheckCountry.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckCountry.Visible = false;
            }

            if(!String.IsNullOrEmpty(createUser.textBoxPhonenumber.Text) && 
               !Regex.IsMatch(createUser.textBoxPhonenumber.Text, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$"))
            {
                createUser.labelCheckPhonenumber.Visible = true;
                validText = false;
            }
            else
            {
                createUser.labelCheckPhonenumber.Visible = false;
            }

            if (!String.IsNullOrEmpty(createUser.textBoxEmail.Text))
            {
                ValidateEmail ve = new ValidateEmail();
                if (!ve.IsValidEmail(createUser.textBoxEmail.Text))
                {
                    createUser.labelCheckEmail.Visible = true;
                    validText = false;
                }
                else
                {
                    createUser.labelCheckEmail.Visible = false;
                }
            }
            else
            {
                createUser.labelCheckEmail.Visible = false;
            }
        }

        public bool checkValidZipcode(string zipcode)
        {
            // Check if entered zipcode is valid
            if (zipcode.Length < 6 || zipcode.Length > 6)
            {
                return false;
            }
            else
            {
                for (int index = 0; index < 6; index++)
                {
                    if (index < 4)
                    {
                        if (!(zipcode[index] >= '0' && zipcode[index] <= '9'))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!((zipcode[index] >= 'A' || zipcode[index] >= 'a') && (zipcode[index] <= 'Z' || zipcode[index] <= 'z')))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool checkValidHouseNumber(string number)
        {
            bool switchSort = false;

            for (int index = 0; index < number.Length; index++)
            {
                if (index > 0)
                {
                    if (number[index] >= '0' && number[index] <= '9')
                    {
                        if (!(number[index - 1] >= '0' && number[index - 1] <= '9'))
                        {
                            return false;
                        }
                    }
                    else if ((number[index] >= 'A' || number[index] >= 'a') && (number[index] <= 'Z' || number[index] <= 'z'))
                    {
                        if (!((number[index - 1] >= 'A' || number[index - 1] >= 'a') && (number[index - 1] <= 'Z' || number[index - 1] <= 'z')) && switchSort == true)
                        {
                            return false;
                        }
                        else
                        {
                            switchSort = true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (!(number[index] >= '0' && number[index] <= '9'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void resetFields()
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
    }
}
