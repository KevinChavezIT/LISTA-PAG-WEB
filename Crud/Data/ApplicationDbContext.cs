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
        public virtual DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
                modelBuilder.Entity<Genero>(entity =>
                {
                    entity.HasKey(e => e.Codigo);

                    entity.ToTable("Genero");

                    entity.Property(e => e.Descripcion)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);
                });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Persona__06370DAD4E9B6980");

                entity.ToTable("Persona");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoGeneroNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.CodigoGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Genero");
            });
        }
    }
}
