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
    
    public partial class employeeloginlog
    {
        public int customeLoginId { get; set; }
        public int employeeId { get; set; }
        public string ip { get; set; }
        public System.DateTime datetimeLogin { get; set; }
    
        public virtual employee employee { get; set; }
    }
}