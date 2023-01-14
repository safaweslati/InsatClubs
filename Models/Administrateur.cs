using System;
using System.Collections.Generic;

namespace InsatClub.Models;

public partial class Administrateur
{
    public long Id { get; set; }

    public long? ClubId { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Email { get; set; }

    public string? MotDePasse { get; set; }

    public virtual Club? Club { get; set; }

    public virtual ICollection<NotifsAdministrateurFromAdministration> NotifsAdministrateurFromAdministrations { get; } = new List<NotifsAdministrateurFromAdministration>();

    public virtual ICollection<NotifsAdministration> NotifsAdministrations { get; } = new List<NotifsAdministration>();

    public virtual ICollection<NotifsEtudiant> NotifsEtudiants { get; } = new List<NotifsEtudiant>();
}
