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
    
    public partial class transaction
    {
        public int transactionId { get; set; }
        public int accountId { get; set; }
        public int transactionTypeId { get; set; }
        public int transactionStatusId { get; set; }
        public double amount { get; set; }
        public System.DateTime datetime { get; set; }
        public short commit { get; set; }
        public System.DateTime executeDatetime { get; set; }
        public string nameReceiver { get; set; }
        public string ibanReceiver { get; set; }
        public string remark { get; set; }
    
        public virtual account account { get; set; }
        public virtual transactionstatu transactionstatu { get; set; }
        public virtual transactiontype transactiontype { get; set; }
    }
}
