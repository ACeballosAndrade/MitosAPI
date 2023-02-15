using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MitosAPI.Models;

public partial class MITOSContext : DbContext
{
    public MITOSContext()
    {
    }

    public MITOSContext(DbContextOptions<MITOSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dios> Dios { get; set; }

    public virtual DbSet<Mitologia> Mitologia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dios>(entity =>
        {
            entity.HasKey(e => e.IdDios).HasName("PK__Dios__DCA84FD15FC3F8DE");

            entity.Property(e => e.IdDios).HasColumnName("idDios");
            entity.Property(e => e.Afiliacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("afiliacion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Hogar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hogar");
            entity.Property(e => e.IdMitologia).HasColumnName("idMitologia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreImagen");
            entity.Property(e => e.Poder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("poder");
            entity.Property(e => e.Posesiones)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("posesiones");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlImagen");

            entity.HasOne(d => d.oMitologia).WithMany(p => p.Dios)
                .HasForeignKey(d => d.IdMitologia)
                .HasConstraintName("FK__Dios__idMitologi__75A278F5");
        });

        modelBuilder.Entity<Mitologia>(entity =>
        {
            entity.HasKey(e => e.IdMitologia).HasName("PK__Mitologi__34DEBACC3EC31B71");

            entity.Property(e => e.IdMitologia).HasColumnName("idMitologia");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
