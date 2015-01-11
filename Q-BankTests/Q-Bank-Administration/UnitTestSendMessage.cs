using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q_Bank_Administration.Controller;
using Q_Bank_Administration;

namespace Q_BankTests.Q_Bank_Administration
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTestSendMessage
    {
        [TestMethod]
        public void TestSendMessage()
        {
            FormMain formMain = new FormMain(1);
            MessageController mc = new MessageController(formMain);
            formMain.messageToUserTextbox.Text = "a";
            formMain.messageSubjectTextbox.Text = "a";
            formMain.messageMessageTextbox.Text = "a";
            bool actual = mc.CheckAllFields();
            bool expected = true;

            Assert.AreEqual<bool>(actual, expected, "Mail failed!");
        }
    }
}
