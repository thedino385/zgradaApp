﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZgradaApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZgradaDbEntities : DbContext
    {
        public ZgradaDbEntities()
            : base("name=ZgradaDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Zgrade> Zgrade { get; set; }
        public virtual DbSet<Pripadci> Pripadci { get; set; }
        public virtual DbSet<Kompanije> Kompanije { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Stanovi> Stanovi { get; set; }
        public virtual DbSet<Stanovi_PosebniDijelovi> Stanovi_PosebniDijelovi { get; set; }
        public virtual DbSet<Stanovi_Pripadci> Stanovi_Pripadci { get; set; }
        public virtual DbSet<Stanovi_Stanari> Stanovi_Stanari { get; set; }
    }
}
