﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TropicalServerApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    [Table("tblOrder")]
    public partial class TropicalServerEntitiesCustomerOrder : DbContext
    {
        public TropicalServerEntitiesCustomerOrder()
            : base("name=TropicalServerEntitiesCustomerOrder")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
    }
}
