using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsatClub.Models;

[Table("Administration")]
public partial class Administration
{
    [Key]
    public long Id { get; set; }

    [Column("Mot_de_Passe")]
    public string? MotDePasse { get; set; }

    public string? Email { get; set; }

    [InverseProperty("Administration")]
    public virtual ICollection<NotifsAdministrateurFromAdministration> NotifsAdministrateurFromAdministrations { get; } = new List<NotifsAdministrateurFromAdministration>();

    [InverseProperty("Administrateur")]
    public virtual ICollection<NotifsAdministrateurFromEtudiant> NotifsAdministrateurFromEtudiants { get; } = new List<NotifsAdministrateurFromEtudiant>();

    [InverseProperty("Administration")]
    public virtual ICollection<NotifsAdministration> NotifsAdministrations { get; } = new List<NotifsAdministration>();
}
