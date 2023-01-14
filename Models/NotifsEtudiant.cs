using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsatClub.Models;

[Table("NotifsEtudiant")]
public partial class NotifsEtudiant
{
    [Key]
    public long Id { get; set; }

    [Column("Etudiant_id")]
    public long? EtudiantId { get; set; }

    public string? Titre { get; set; }

    public string? Contenu { get; set; }

    [Column("Administrateur_id")]
    public long? AdministrateurId { get; set; }

    [ForeignKey("AdministrateurId")]
    [InverseProperty("NotifsEtudiants")]
    public virtual Administrateur? Administrateur { get; set; }

    [ForeignKey("EtudiantId")]
    [InverseProperty("NotifsEtudiants")]
    public virtual Etudiant? Etudiant { get; set; }
}
