//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Q_Bank
{
    using System;
    using System.Collections.Generic;
    
    public partial class transactionqueue
    {
        public int transactionId { get; set; }
        public int transactionStatusId { get; set; }
        public int accountId { get; set; }
        public double amount { get; set; }
        public System.DateTime datetime { get; set; }
        public Nullable<System.DateTime> executeDate { get; set; }
        public string ibanReceiver { get; set; }
        public string nameReceiver { get; set; }
        public bool sepa { get; set; }
        public string bic { get; set; }
        public string remark { get; set; }
    
        public virtual transactionstatu transactionstatu { get; set; }
    }
}
