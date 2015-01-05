using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q_Bank_Administration.Controller;
using Q_Bank_Administration.View;

namespace Q_BankTests.Q_Bank_Administration
{
    [TestClass]
    public class UnitTestCreateAccount
    {
        [TestMethod]
        public void TestCreateIBAN()
        {
            CreateAccount ca = new CreateAccount(1);
            CreateAccountController cac = new CreateAccountController(ca, 1);
            string accountnumber = cac.createAccountNumber();
            string iban = cac.createIBAN(accountnumber);
            bool actual = cac.isIbanChecksumValid(iban);
            bool expected = true;

            Assert.AreEqual<bool>(actual, expected, "Right IBAN is not detected!");
        }

        [TestMethod]
        public void TestProcessCreateAccount()
        {
            CreateAccount ca = new CreateAccount(1);
            CreateAccountController cac = new CreateAccountController(ca, 1);
            ca.comboBoxAccountType.SelectedIndex = 1;
            cac.processCreateAccount(new object(), null);
        }
    }
}
