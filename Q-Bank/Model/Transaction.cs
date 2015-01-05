using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank.Model
{
    public class Transaction
    {
        public int accountId;
        public int transactionTypeId;
        public double amount;
        public DateTime datetime;
        public DateTime executeDate;
        public String nameReceiver;
        public String ibanReceiver;
        public String remark;
        public int sepa;
        public String bic;

        public Transaction(int accountId, double amount, DateTime datetime, DateTime executeDate,
            String nameReceiver, String ibanReceiver, String remark, int sepa, String bic)
        {
            this.accountId = accountId;
            this.amount = amount;
            this.datetime = datetime;
            this.executeDate = executeDate;
            this.nameReceiver = nameReceiver;
            this.ibanReceiver = ibanReceiver;
            this.remark = remark;
            this.sepa = sepa;
            this.bic = bic;

        }
    }
}
