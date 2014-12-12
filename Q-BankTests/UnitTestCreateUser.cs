using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q_Bank.Controller;
using Q_Bank.View;
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
        public void TestWrongZipcode()
        {
            CreateUser cu = new CreateUser();
            cu.textBoxZipcode.Text = "386PN";
            CreateUserController cuc = new CreateUserController(cu);
            bool actual = cuc.checkValidZipcode(cu.textBoxZipcode.Text);
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "Wrong Zipcode is not detected");
        }
    }
}
