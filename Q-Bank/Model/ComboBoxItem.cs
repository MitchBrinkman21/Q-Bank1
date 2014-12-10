using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank.Model
{
    public class ComboBoxItem
    {
        public int AccountId;
        public string Iban;
        public string AccountType;
        public double Balance;

        public ComboBoxItem(int AccountId, string Iban, string AccountType, double Balance)
        {
            this.AccountId = AccountId;
            this.Iban = Iban;
            this.AccountType = AccountType;
            this.Balance = Balance;
        }

        public override string ToString()
        {
            if (AccountId > 0)
            {
                return Iban + " - " + AccountType + " - EUR " + String.Format("{0:0,00}", Balance.ToString("f2"));
            }
            else
            {
                return Iban;
            }
        }
    }
}
