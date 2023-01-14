using System;
using System.Collections.Generic;

namespace InsatClub.Models;

public partial class Administration
{
    public long Id { get; set; }

    public string? MotDePasse { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<NotifsAdministrateurFromAdministration> NotifsAdministrateurFromAdministrations { get; } = new List<NotifsAdministrateurFromAdministration>();

    public virtual ICollection<NotifsAdministrateurFromEtudiant> NotifsAdministrateurFromEtudiants { get; } = new List<NotifsAdministrateurFromEtudiant>();

    public virtual ICollection<NotifsAdministration> NotifsAdministrations { get; } = new List<NotifsAdministration>();
}
