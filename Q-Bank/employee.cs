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
    
    public partial class employee
    {
        public employee()
        {
            this.employeeaddresses = new HashSet<employeeaddress>();
            this.employeeemails = new HashSet<employeeemail>();
            this.employeeloginlogs = new HashSet<employeeloginlog>();
            this.employeemessages = new HashSet<employeemessage>();
            this.employeephones = new HashSet<employeephone>();
        }
    
        public int employeeId { get; set; }
        public int roleId { get; set; }
        public string bsn { get; set; }
        public short active { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public System.DateTime birthDate { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string key { get; set; }
        public System.DateTime registerDatetime { get; set; }
    
        public virtual role role { get; set; }
        public virtual ICollection<employeeaddress> employeeaddresses { get; set; }
        public virtual ICollection<employeeemail> employeeemails { get; set; }
        public virtual ICollection<employeeloginlog> employeeloginlogs { get; set; }
        public virtual ICollection<employeemessage> employeemessages { get; set; }
        public virtual ICollection<employeephone> employeephones { get; set; }
    }
}
