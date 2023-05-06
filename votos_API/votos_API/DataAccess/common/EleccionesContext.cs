using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using votos_API.DataAccess.models;

namespace votos_API.DataAccess.common;

public partial class EleccionesContext : DbContext
{
    public EleccionesContext()
    {
    }

    public EleccionesContext(DbContextOptions<EleccionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<ProcesoVotacione> ProcesoVotaciones { get; set; }

    public virtual DbSet<Voto> Votos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)

        {

            IConfigurationRoot configuration = new ConfigurationBuilder()

            .SetBasePath(Directory.GetCurrentDirectory())

                        .AddJsonFile("appsettings.json")

                        .Build();

            var connectionString = configuration.GetConnectionString("VotosDB");

            optionsBuilder.UseMySQL(connectionString);

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("candidato");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FormacionProfesional)
                .HasMaxLength(100)
                .HasColumnName("formacion_profesional");
            entity.Property(e => e.Informacion)
                .HasColumnType("text")
                .HasColumnName("informacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.PartidoPolitico)
                .HasMaxLength(50)
                .HasColumnName("partido_politico");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .HasColumnName("sexo");
        });

        modelBuilder.Entity<ProcesoVotacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proceso_votaciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
        });

        modelBuilder.Entity<Voto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("voto");

            entity.HasIndex(e => e.CandidatoId, "candidato_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CandidatoId).HasColumnName("candidato_id");
            entity.Property(e => e.Dpi)
                .HasMaxLength(13)
                .HasColumnName("dpi");
            entity.Property(e => e.EsFraudulento)
                .HasColumnType("tinyint(1)")
                .HasColumnName("es_fraudulento");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.IpOrigen)
                .HasMaxLength(45)
                .HasColumnName("ip_origen");
            entity.Property(e => e.Nulo)
                .HasColumnType("tinyint(1)")
                .HasColumnName("nulo");

            entity.HasOne(d => d.Candidato).WithMany(p => p.Votos)
                .HasForeignKey(d => d.CandidatoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("voto_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
