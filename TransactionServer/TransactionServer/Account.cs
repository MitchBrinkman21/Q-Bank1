using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionServer
{
    class Account
    {
        private String iban;
        private double balance;

        public void SetIban(String iban)
        {
            this.iban = iban;
        }

        public String GetIban()
        {
            return this.iban;
        }

        public void SetBalance(double balance)
        {
            this.balance = balance;
        }

        public double GetBalance()
        {
            return this.balance;
        }
    }
}
