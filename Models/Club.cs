using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsatClub.Models;

[Table("Club")]
[Index("Id", IsUnique = true)]
public partial class Club
{
    [Key]
    public long Id { get; set; }

    public string? Nom { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    [Column("URL")]
    public string? Url { get; set; }

    [InverseProperty("Club")]
    public virtual ICollection<Event> Events { get; } = new List<Event>();

    [ForeignKey("IdClub")]
    [InverseProperty("IdClubs")]
    public virtual ICollection<Etudiant> IdEtudiants { get; } = new List<Etudiant>();
}
