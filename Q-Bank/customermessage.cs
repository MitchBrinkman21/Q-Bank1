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
    
    public partial class customermessage
    {
        public int customerMessageId { get; set; }
        public int customerId { get; set; }
        public string messageText { get; set; }
        public Nullable<short> read { get; set; }
        public Nullable<short> deleted { get; set; }
        public string title { get; set; }
        public Nullable<int> employeeId { get; set; }
    
        public virtual customer customer { get; set; }
    }
}
