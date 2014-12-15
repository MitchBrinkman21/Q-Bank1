using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionServer
{
    public class Transaction
    {
        private int transactionId;
        private int transactionStatusId;
        private int sepa; 
        private String ibanReceiver;
        private String nameReceiver;
        private int accountId;
        private double amount;
        private String bic;
        private String executeDate;
        private String remark;
        private String iban;
        private double balance;

        public void SetTransactionId(int transactionId)
        {
            this.transactionId = transactionId;
        }

        public int GetTransactionId()
        {
            return this.transactionId;
        }

        public void SetTransactionStatusId(int transactionStatusId)
        {
            this.transactionStatusId = transactionStatusId;
        }

        public int GetTransactionStatusId()
        {
            return this.transactionStatusId;
        }

        public void SetSepa(int sepa)
        {
            this.sepa = sepa;
        }

        public int GetSepa()
        {
            return this.sepa;
        }

        public void SetIbanReceiver(String ibanReceiver)
        {
            this.ibanReceiver = ibanReceiver;
        }

        public String GetIbanReceiver()
        {
            return this.ibanReceiver;
        }

        public void SetNameReceiver(String nameReceiver)
        {
            this.nameReceiver = nameReceiver;
        }

        public String GetNameReceiver()
        {
            return this.nameReceiver;
        }

        public void SetAccountId(int accountId)
        {
            this.accountId = accountId;
        }

        public int GetAccountId()
        {
            return this.accountId;
        }

        public void SetAmount(double amount)
        {
            this.amount = amount;
        }

        public double GetAmount()
        {
            return this.amount;
        }

        public void SetBic(String bic)
        {
            this.bic = bic;
        }

        public String GetBic()
        {
            return this.bic;
        }

        public void SetRemark(String remark)
        {
            this.remark = remark;
        }

        public String GetRemark()
        {
            return this.remark;
        }

        public void SetExecuteDate(String executeDate)
        {
            this.executeDate = executeDate;
        }

        public String GetExecuteDate()
        {
            return this.executeDate;
        }

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
