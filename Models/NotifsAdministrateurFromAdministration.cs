using System;
using System.Collections.Generic;

namespace InsatClub.Models;

public partial class NotifsAdministrateurFromAdministration
{
    public long Id { get; set; }

    public long? AdministrateurId { get; set; }

    public string? Titre { get; set; }

    public string? Contenu { get; set; }

    public long? AdministrationId { get; set; }

    public virtual Administrateur? Administrateur { get; set; }

    public virtual Administration? Administration { get; set; }
}
