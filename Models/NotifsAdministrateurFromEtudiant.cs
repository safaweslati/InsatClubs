using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsatClub.Models;

[Table("NotifsAdministrateur_from_Etudiant")]
public partial class NotifsAdministrateurFromEtudiant
{
    [Key]
    public long Id { get; set; }

    [Column("Administrateur_id")]
    public long? AdministrateurId { get; set; }

    public string? Titre { get; set; }

    public string? Contenu { get; set; }

    [Column("Etudiant_id")]
    public long? EtudiantId { get; set; }

    [ForeignKey("AdministrateurId")]
    [InverseProperty("NotifsAdministrateurFromEtudiants")]
    public virtual Administration? Administrateur { get; set; }

    [ForeignKey("EtudiantId")]
    [InverseProperty("NotifsAdministrateurFromEtudiants")]
    public virtual Etudiant? Etudiant { get; set; }
}
