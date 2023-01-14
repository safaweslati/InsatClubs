using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsatClub.Models;

[Table("Administrateur")]
public partial class Administrateur
{
    [Key]
    public long Id { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Email { get; set; }

    [Column("Mot_de_Passe")]
    public string? MotDePasse { get; set; }

    [InverseProperty("Administrateur")]
    public virtual ICollection<NotifsAdministrateurFromAdministration> NotifsAdministrateurFromAdministrations { get; } = new List<NotifsAdministrateurFromAdministration>();

    [InverseProperty("Administrateur")]
    public virtual ICollection<NotifsAdministration> NotifsAdministrations { get; } = new List<NotifsAdministration>();

    [InverseProperty("Administrateur")]
    public virtual ICollection<NotifsEtudiant> NotifsEtudiants { get; } = new List<NotifsEtudiant>();
}
