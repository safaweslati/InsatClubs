using System;
using System.Collections.Generic;
using InsatClub.Models;
using Microsoft.EntityFrameworkCore;

namespace InsatClub.Data;

public partial class ClubsInsatContext : DbContext
{
    public ClubsInsatContext()
    {
    }

    public ClubsInsatContext(DbContextOptions<DbContext> options)
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
        modelBuilder.Entity<Administration>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Club>(entity =>
        {
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
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
