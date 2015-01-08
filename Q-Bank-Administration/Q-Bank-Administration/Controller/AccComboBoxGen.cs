using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank;
using System.Windows.Forms;
using Q_Bank.Model;
using Q_Bank_Administration.View;

namespace Q_Bank_Administration.Controller
{
    class AccComboBoxGen
    {
        public AccComboBoxGen(AccountOverview accountOverview, ComboBox comboBox)
        {
            using (var con = new Q_BANKEntities())
            {
                comboBox.Items.Clear();
                var accountsCol = from a in con.accounts
                                  where a.customerId == accountOverview.customerId
                                  select a;

                if (accountsCol.Count() > 0)
                {
                    comboBox.Items.Add(new ComboBoxItem(0, "Selecteer een rekening", "", 0));
                    foreach (account a in accountsCol)
                    {
                        comboBox.Items.Add(new ComboBoxItem(a.accountId, a.iban.ToString(), a.accounttype.accountTypeName, a.balance));
                    }
                }
                else
                {
                    comboBox.Items.Add(new ComboBoxItem(0, "Geen rekeningen gevonden", "", 0));
                }
                comboBox.SelectedIndex = 0;
            }
        }
    }
}
