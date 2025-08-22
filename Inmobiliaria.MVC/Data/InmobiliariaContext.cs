using System;
using System.Collections.Generic;
using Inmobiliaria.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.MVC.Data;

public partial class InmobiliariaContext : DbContext
{
    public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inquilino> Inquilinos { get; set; }

    public virtual DbSet<Propietario> Propietarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Inquilino>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inquilinos");

            entity.HasIndex(e => e.Dni, "Dni").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Dni).HasMaxLength(20);
            entity.Property(e => e.Domicilio).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<Propietario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("propietarios");

            entity.HasIndex(e => e.Dni, "Dni").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Dni).HasMaxLength(20);
            entity.Property(e => e.Domicilio).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
