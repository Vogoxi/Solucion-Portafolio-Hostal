﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hostal.DALC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<DETALLE_FACTURA> DETALLE_FACTURA { get; set; }
        public DbSet<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }
        public DbSet<EMPLEADO> EMPLEADO { get; set; }
        public DbSet<EMPRESA> EMPRESA { get; set; }
        public DbSet<FACTURA> FACTURA { get; set; }
        public DbSet<HABITACION> HABITACION { get; set; }
        public DbSet<HUESPED> HUESPED { get; set; }
        public DbSet<PEDIDO> PEDIDO { get; set; }
        public DbSet<PLATO> PLATO { get; set; }
        public DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public DbSet<SERVICIO> SERVICIO { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }
    }
}
