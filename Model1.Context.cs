﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Table_Management_System
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class table_management_systemEntities : DbContext
    {
        public table_management_systemEntities()
            : base("name=table_management_systemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<reservation> reservations { get; set; }
        public virtual DbSet<table> tables { get; set; }
        public virtual DbSet<time_slots> time_slots { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
