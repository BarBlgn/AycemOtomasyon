﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AycemOtomasyon
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AycemEntities : DbContext
    {
        public AycemEntities()
            : base("name=AycemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Colour> Colour { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Porduct> Porduct { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Error> Error { get; set; }
        public virtual DbSet<Machines> Machines { get; set; }
    }
}
