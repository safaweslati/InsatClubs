using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using InsatClub.Models;

namespace InsatClub.Data;

public partial class ClubsInsatContext : DbContext
{
    public ClubsInsatContext()
    {
    }

    public ClubsInsatContext(DbContextOptions<ClubsInsatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrateur> Administrateurs { get; set; }

    public virtual DbSet<Administration> Administrations { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Etudiant> Etudiants { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<NotifsAdministrateurFromAdministration> NotifsAdministrateurFromAdministrations { get; set; }

    public virtual DbSet<NotifsAdministrateurFromEtudiant> NotifsAdministrateurFromEtudiants { get; set; }

    public virtual DbSet<NotifsAdministration> NotifsAdministrations { get; set; }

    public virtual DbSet<NotifsEtudiant> NotifsEtudiants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\safaw\\source\\repos\\InsatClub\\ClubsInsat.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrateur>(entity =>
        {
            entity.ToTable("Administrateur");

            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.MotDePasse).HasColumnName("Mot_de_Passe");

            entity.HasOne(d => d.Club).WithMany(p => p.Administrateurs).HasForeignKey(d => d.ClubId);
        });

        modelBuilder.Entity<Administration>(entity =>
        {
            entity.ToTable("Administration");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MotDePasse).HasColumnName("Mot_de_Passe");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.ToTable("Club");

            entity.HasIndex(e => e.Id, "IX_Club_Id").IsUnique();

            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasMany(d => d.IdEtudiants).WithMany(p => p.IdClubs)
                .UsingEntity<Dictionary<string, object>>(
                    "ClubMember",
                    r => r.HasOne<Etudiant>().WithMany()
                        .HasForeignKey("IdEtudiant")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Club>().WithMany()
                        .HasForeignKey("IdClub")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("IdClub", "IdEtudiant");
                        j.ToTable("Club_Members");
                    });
        });

        modelBuilder.Entity<Etudiant>(entity =>
        {
            entity.ToTable("Etudiant");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MotDePasse).HasColumnName("Mot_de_Passe");
            entity.Property(e => e.NumTel).HasColumnName("Num_tel");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("Event");

            entity.HasIndex(e => e.Id, "IX_Event_Id").IsUnique();

            entity.Property(e => e.Img).HasColumnName("img");

            entity.HasOne(d => d.Club).WithMany(p => p.Events).HasForeignKey(d => d.ClubId);
        });

        modelBuilder.Entity<NotifsAdministrateurFromAdministration>(entity =>
        {
            entity.ToTable("NotifsAdministrateur_from_Administration");

            entity.Property(e => e.AdministrateurId).HasColumnName("Administrateur_id");
            entity.Property(e => e.AdministrationId).HasColumnName("Administration_id");

            entity.HasOne(d => d.Administrateur).WithMany(p => p.NotifsAdministrateurFromAdministrations).HasForeignKey(d => d.AdministrateurId);

            entity.HasOne(d => d.Administration).WithMany(p => p.NotifsAdministrateurFromAdministrations).HasForeignKey(d => d.AdministrationId);
        });

        modelBuilder.Entity<NotifsAdministrateurFromEtudiant>(entity =>
        {
            entity.ToTable("NotifsAdministrateur_from_Etudiant");

            entity.Property(e => e.AdministrateurId).HasColumnName("Administrateur_id");
            entity.Property(e => e.EtudiantId).HasColumnName("Etudiant_id");

            entity.HasOne(d => d.Administrateur).WithMany(p => p.NotifsAdministrateurFromEtudiants).HasForeignKey(d => d.AdministrateurId);

            entity.HasOne(d => d.Etudiant).WithMany(p => p.NotifsAdministrateurFromEtudiants).HasForeignKey(d => d.EtudiantId);
        });

        modelBuilder.Entity<NotifsAdministration>(entity =>
        {
            entity.ToTable("NotifsAdministration");

            entity.Property(e => e.AdministrateurId).HasColumnName("Administrateur_id");
            entity.Property(e => e.AdministrationId).HasColumnName("Administration_id");

            entity.HasOne(d => d.Administrateur).WithMany(p => p.NotifsAdministrations).HasForeignKey(d => d.AdministrateurId);

            entity.HasOne(d => d.Administration).WithMany(p => p.NotifsAdministrations).HasForeignKey(d => d.AdministrationId);
        });

        modelBuilder.Entity<NotifsEtudiant>(entity =>
        {
            entity.ToTable("NotifsEtudiant");

            entity.Property(e => e.AdministrateurId).HasColumnName("Administrateur_id");
            entity.Property(e => e.EtudiantId).HasColumnName("Etudiant_id");

            entity.HasOne(d => d.Administrateur).WithMany(p => p.NotifsEtudiants).HasForeignKey(d => d.AdministrateurId);

            entity.HasOne(d => d.Etudiant).WithMany(p => p.NotifsEtudiants).HasForeignKey(d => d.EtudiantId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
