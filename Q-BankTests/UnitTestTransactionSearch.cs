using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q_Bank.Controller;
using Q_Bank.View;
using Q_Bank.Model;
using Q_Bank;

namespace Q_BankTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTestTransactionSearch
    {
        [TestMethod]
        public void TestWrongBeginEndDate()
        {
            FormMain formMain = new FormMain(1);
            TransactionSearch ts = new TransactionSearch(formMain);
            ts.beginDatePicker.Value = Convert.ToDateTime("2015-01-30");
            ts.endDatePicker.Value = Convert.ToDateTime("2015-06-30");
            TransactionSearchController tc = new TransactionSearchController(ts);

            tc.checkValidText();
            bool actual = tc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(expected, actual, "Wrong Begin and End date is not detected");
        }


        [TestMethod]
        public void TestWrongAccountComboBoxSelected()
        {
            FormMain formMain = new FormMain(1);
            TransactionSearch ts = new TransactionSearch(formMain);
            ts.TransactionSearchAccountCombobox.SelectedIndex = 0;
            TransactionSearchController tc = new TransactionSearchController(ts);

            tc.checkValidText();
            bool actual = tc.validText;
            bool expected = false;

            Assert.AreEqual<bool>(expected, actual, "Wrong AccountComboBox selected index is not detected");
        }
    }
}
