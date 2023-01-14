using System;
using System.Collections.Generic;

namespace InsatClub.Models;

public partial class Etudiant
{
    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Email { get; set; }

    public long Id { get; set; }

    public long? NumTel { get; set; }

    public string? MotDePasse { get; set; }

    public virtual ICollection<NotifsAdministrateurFromEtudiant> NotifsAdministrateurFromEtudiants { get; } = new List<NotifsAdministrateurFromEtudiant>();

    public virtual ICollection<NotifsEtudiant> NotifsEtudiants { get; } = new List<NotifsEtudiant>();

    public virtual ICollection<Club> IdClubs { get; } = new List<Club>();
}
