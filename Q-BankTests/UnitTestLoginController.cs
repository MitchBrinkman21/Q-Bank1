using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q_Bank.View;
using Q_Bank.Controller;

namespace Q_BankTests
{
    [TestClass]
    public class UnitTestLoginController
    {
        [TestMethod]
        public void TestTrueLoginCheck()
        {
            FormLogin fl = new FormLogin();
            fl.textBox1.Text = "henk";
            fl.textBox2.Text = "test";
            LoginController lc = new LoginController(fl);
            bool actual = lc.checkLogin();
            bool expected = true;

            Assert.AreEqual<bool>(actual, expected, "Correct login is not detected");
        }

        [TestMethod]
        public void TestFalseLoginCheck()
        {
            FormLogin fl = new FormLogin();
            fl.textBox1.Text = "henkk";
            fl.textBox2.Text = "testt";
            LoginController lc = new LoginController(fl);
            bool actual = lc.checkLogin();
            bool expected = false;

            Assert.AreEqual<bool>(actual, expected, "False login is not detected");
        }

        [TestMethod]
        public void TestProcess()
        {
            FormLogin fl = new FormLogin();
            fl.textBox1.Text = "henk";
            fl.textBox2.Text = "test";
            LoginController lc = new LoginController(fl);
            bool actual = lc.checkLogin();
            bool expected = true;

            Assert.AreEqual<bool>(actual, expected, "Correct login is not detected");
        }
    }
}
