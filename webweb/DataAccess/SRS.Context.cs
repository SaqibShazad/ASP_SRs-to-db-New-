﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SRSDBEntities : DbContext
    {
        public SRSDBEntities()
            : base("name=SRSDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblParagraph> tblParagraphs { get; set; }
        public virtual DbSet<tblSentence> tblSentences { get; set; }
        public virtual DbSet<tblWord> tblWords { get; set; }
        public virtual DbSet<tblPOSS> tblPOSSes { get; set; }
        public virtual DbSet<tblDD_POS> tblDD_POS { get; set; }
        public virtual DbSet<tblDD> tblDDs { get; set; }
    }
}
