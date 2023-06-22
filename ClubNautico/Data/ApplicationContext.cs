using System;
using System.Collections.Generic;
using ClubNautico.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.Data;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Embarcacione> Embarcaciones { get; set; }

    public virtual DbSet<Socio> Socios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Embarcacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("embarcaciones_pkey");

            entity.ToTable("embarcaciones");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Cuota).HasColumnName("cuota");
            entity.Property(e => e.IdSocio).HasColumnName("id_socio");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
            entity.Property(e => e.NumAmarre)
                .HasColumnType("character varying")
                .HasColumnName("num_amarre");
            entity.Property(e => e.NumMatricula).HasColumnName("num_matricula");

            entity.HasOne(d => d.IdSocioNavigation).WithMany(p => p.Embarcaciones)
                .HasForeignKey(d => d.IdSocio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_socio_barco");
        });

        modelBuilder.Entity<Socio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("socios_pkey");

            entity.ToTable("socios");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
