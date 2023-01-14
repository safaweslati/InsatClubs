using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsatClub.Models;

[Table("Etudiant")]
public partial class Etudiant
{
    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Email { get; set; }

    [Key]
    public long Id { get; set; }

    [Column("Num_tel")]
    public long? NumTel { get; set; }

    [Column("Mot_de_Passe")]
    public string? MotDePasse { get; set; }

    [InverseProperty("Etudiant")]
    public virtual ICollection<NotifsAdministrateurFromEtudiant> NotifsAdministrateurFromEtudiants { get; } = new List<NotifsAdministrateurFromEtudiant>();

    [InverseProperty("Etudiant")]
    public virtual ICollection<NotifsEtudiant> NotifsEtudiants { get; } = new List<NotifsEtudiant>();

    [ForeignKey("IdEtudiant")]
    [InverseProperty("IdEtudiants")]
    public virtual ICollection<Club> IdClubs { get; } = new List<Club>();
}
