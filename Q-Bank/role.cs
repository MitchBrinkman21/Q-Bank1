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
    
    public partial class role
    {
        public role()
        {
            this.employees = new HashSet<employee>();
        }
    
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string remark { get; set; }
    
        public virtual ICollection<employee> employees { get; set; }
    }
}
