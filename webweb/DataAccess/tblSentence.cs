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
    
    public partial class tblSentence
    {
        public tblSentence()
        {
            this.tblWords = new HashSet<tblWord>();
        }
    
        public int ID { get; set; }
        public Nullable<int> tblParagraph_ID { get; set; }
        public string Sentence { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
    
        public virtual tblParagraph tblParagraph { get; set; }
        public virtual ICollection<tblWord> tblWords { get; set; }
    }
}
