using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q_Bank.Controller;
using Q_Bank.View;
using Q_Bank.Pro6PPServiceReference;
using System.Data.SqlClient;

namespace Q_BankTests
{
    [TestClass]
    public class UnitTestCreateUser
    {
        [TestMethod]
        public void TestEmptyTextbox()
        {
            CreateUser cu = new CreateUser();
            CreateUserController cuc = new CreateUserController(cu);
            bool actual = cuc.checkEmptyFields();
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Empty fields are not detected");
        }

        [TestMethod]
        public void TestWrongBSN()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxBSN.Text = "abc";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(expected, actual, "Wrong BSN is not detected");
        }

        [TestMethod]
        public void TestWrongFirstname()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxFirstname.Text = "123";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(expected, actual, "Wrong Firstname is not detected");
        }

        [TestMethod]
        public void TestWrongLastname()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxLastname.Text = "123";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(expected, actual, "Wrong Lastname is not detected");
        }

        [TestMethod]
        public void TestWrongBirthday()
        {
            CreateUser cu = new CreateUser();
            cu.dateTimePickerBirthday.Value = Convert.ToDateTime("2015-01-30");
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(expected, actual, "Wrong Birthday is not detected");
        }

        [TestMethod]
        public void TestWrongZipcode()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxZipcode.Text = "386PN";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Wrong Zipcode is not detected");
        }

        [TestMethod]
        public void TestWrongNumber()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxNumber.Text = "A32";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Wrong Number is not detected");
        }

        [TestMethod]
        public void TestWrongAddress()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxAddress.Text = "123";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Wrong Address is not detected");
        }

        [TestMethod]
        public void TestWrongCity()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxCity.Text = "123";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Wrong City is not detected");
        }

        [TestMethod]
        public void TestWrongCountry()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxCountry.Text = "123";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Wrong Country is not detected");
        }

        [TestMethod]
        public void TestWrongPhonenumber()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxPhonenumber.Text = "abc";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Wrong Phonenumber is not detected");
        }

        [TestMethod]
        public void TestWrongEmail()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxEmail.Text = "123abc";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkValidText(new object(), null);
            bool actual = cuc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Wrong Email is not detected");
        }

        [TestMethod]
        public void TestExistingUsername()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxUsername.Text = "Piet";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkUsername(new object(), null);
            bool actual = cuc.validUsername;
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Existing Username is not detected");
        }

        [TestMethod]
        public void TestUnequalPassword()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxPassword.Text = "abc";
            cu.textBoxRepeatPassword.Text = "123";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.checkPassword(new object(), null);
            bool actual = cuc.validPassword;
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Unequal password is not detected");
        }

        [TestMethod]
        public void TestFillAddress()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxZipcode.Text = "3864PN";
            cu.textBoxNumber.Text = "25b";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.fillAddress(new object(), null);
            string actualAddress = cu.textBoxAddress.Text;
            string actualCity = cu.textBoxCity.Text;
            string expectedAddress = "Domstraat";
            string expectedCity = "Nijkerkerveen";

            Assert.AreEqual<string>(actualAddress, expectedAddress, "Wrong address");
            Assert.AreEqual<string>(actualCity, expectedCity, "Wrong city");
        }

        
        [TestMethod]
        public void TestCheckData()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxBSN.Text = "123456789";
            cu.textBoxFirstname.Text = "Jan";
            cu.textBoxLastname.Text = "van Vliet";
            cu.comboBoxGender.SelectedIndex = 1;
            cu.dateTimePickerBirthday.Value = Convert.ToDateTime("1990-02-12");
            cu.textBoxZipcode.Text = "3864PN";
            cu.textBoxNumber.Text = "25b";
            cu.textBoxAddress.Text = "Domstraat";
            cu.textBoxCity.Text = "Nijkerkerveen";
            cu.textBoxCountry.Text = "Nederland";
            cu.textBoxPhonenumber.Text = "033-4560058";
            cu.comboBoxPhoneType.SelectedIndex = 1;
            cu.textBoxEmail.Text = "janvanvliet@gmail.com";
            cu.textBoxUsername.Text = "jvliet";
            cu.textBoxPassword.Text = "vliet123";
            cu.textBoxRepeatPassword.Text = "vliet123";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.validText = true;
            cuc.validUsername = true;
            cuc.validPassword = true;
            bool actual = cuc.checkData();
            bool expected = true;

            Assert.AreEqual<bool>(actual, expected, "Valid data is not detected");
        }

        [TestMethod]
        public void TestProcessCreateUser()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxBSN.Text = "123456789";
            cu.textBoxFirstname.Text = "Jan";
            cu.textBoxLastname.Text = "van Vliet";
            cu.comboBoxGender.SelectedIndex = 1;
            cu.dateTimePickerBirthday.Value = Convert.ToDateTime("1990-02-12");
            cu.textBoxZipcode.Text = "3864PN";
            cu.textBoxNumber.Text = "25b";
            cu.textBoxAddress.Text = "Domstraat";
            cu.textBoxCity.Text = "Nijkerkerveen";
            cu.textBoxCountry.Text = "Nederland";
            cu.textBoxPhonenumber.Text = "033-4560058";
            cu.comboBoxPhoneType.SelectedIndex = 1;
            cu.textBoxEmail.Text = "janvanvliet@gmail.com";
            cu.textBoxUsername.Text = "jvliet";
            cu.textBoxPassword.Text = "vliet123";
            cu.textBoxRepeatPassword.Text = "vliet123";
            CreateUserController cuc = new CreateUserController(cu);
            cuc.validText = true;
            cuc.validUsername = true;
            cuc.validPassword = true;
            cuc.processCreateUser(new object(), null);
        }
    }
}
