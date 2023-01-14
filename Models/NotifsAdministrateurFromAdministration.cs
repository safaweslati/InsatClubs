﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsatClub.Models;

[Table("NotifsAdministrateur_from_Administration")]
public partial class NotifsAdministrateurFromAdministration
{
    [Key]
    public long Id { get; set; }

    [Column("Administrateur_id")]
    public long? AdministrateurId { get; set; }

    public string? Titre { get; set; }

    public string? Contenu { get; set; }

    [Column("Administration_id")]
    public long? AdministrationId { get; set; }

    [ForeignKey("AdministrateurId")]
    [InverseProperty("NotifsAdministrateurFromAdministrations")]
    public virtual Administrateur? Administrateur { get; set; }

    [ForeignKey("AdministrationId")]
    [InverseProperty("NotifsAdministrateurFromAdministrations")]
    public virtual Administration? Administration { get; set; }
}
