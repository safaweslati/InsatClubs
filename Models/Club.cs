using System;
using System.Collections.Generic;

namespace InsatClub.Models;

public partial class Club
{
    public long Id { get; set; }

    public string? Nom { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Administrateur> Administrateurs { get; } = new List<Administrateur>();

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual ICollection<Etudiant> IdEtudiants { get; } = new List<Etudiant>();
}
