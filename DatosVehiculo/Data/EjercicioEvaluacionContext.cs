﻿using System;
using DatosVehiculo.Data;
using DatosVehiculo.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatosVehiculo.ModelosNuevos
{
    public partial class EjercicioEvaluacionContext : IdentityDbContext<AplicationUser, UserRole, string>
    {     

        public EjercicioEvaluacionContext(DbContextOptions<EjercicioEvaluacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__TipoVehi__06370DAD9070CCA4");

                entity.ToTable("TipoVehiculo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoVehiculoNavigation)
                    .WithMany(p => p.TipoVehiculos)
                    .HasForeignKey(d => d.CodigoVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vehicuo");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Vehiculo__06370DADAB72DB16");

                entity.ToTable("Vehiculo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }    
    }
}
