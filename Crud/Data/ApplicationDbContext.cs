using Crud.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Data
{
    public class ApplicationDbContext : IdentityDbContext<Applicationempleado, empleadoRole,string >
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Persona>Persona{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Persona>(en => {

                en.HasKey(p => p.Codigo);

                en.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                en.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                en.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                en.Property(p => p.Estado)
                .IsRequired()
               .IsUnicode(false);

            });
        }
    }
}
