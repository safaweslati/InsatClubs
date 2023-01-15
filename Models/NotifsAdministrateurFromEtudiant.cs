using System;
using System.Collections.Generic;

namespace InsatClub.Models;

public partial class NotifsAdministrateurFromEtudiant
{
    
    public long Id { get; set; }

    public long? AdministrateurId { get; set; }

    public string? Titre { get; set; }

    public string? Contenu { get; set; }

    public long? EtudiantId { get; set; }

    public virtual Administration? Administrateur { get; set; }

    public virtual Etudiant? Etudiant { get; set; }
}
