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
    
    public partial class phonetype
    {
        public phonetype()
        {
            this.phones = new HashSet<phone>();
        }
    
        public int phoneTypeId { get; set; }
        public string phoneTypeName { get; set; }
    
        public virtual ICollection<phone> phones { get; set; }
    }
}
