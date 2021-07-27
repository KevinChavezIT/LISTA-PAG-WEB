using CrudExamen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudExamen.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Socio>Socio { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Socio>(so => {

                so.HasKey(s => s.Cedula);
              

                so.Property(s => s.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                so.Property(s => s.Apellido)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                so.Property(s => s.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                so.Property(s => s.Estado);
                //.IsRequired();               
                
            });
            builder.Entity<Cuenta>(so => {

                so.HasKey(s => s.Numero);


                so.Property(s => s.SaldoTotal)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                so.Property(s => s.CodigoSocio)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                so.Property(s => s.Estado)
                .IsRequired();               
            });
        }

        public DbSet<CrudExamen.Models.Cuenta> Cuenta { get; set; }
    }
}
