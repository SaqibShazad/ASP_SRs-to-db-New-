//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webweb.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPOSS
    {
        public tblPOSS()
        {
            this.tblDD_POS = new HashSet<tblDD_POS>();
        }
    
        public int ID { get; set; }
        public string POSWords { get; set; }
        public Nullable<int> tblWords_ID { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
    
        public virtual tblWord tblWord { get; set; }
        public virtual ICollection<tblDD_POS> tblDD_POS { get; set; }
    }
}
