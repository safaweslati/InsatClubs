using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsatClub.Models;

[Table("Event")]
[Index("Id", IsUnique = true)]
public partial class Event
{
    [Key]
    public long Id { get; set; }

    public string? Nom { get; set; }

    [Column("img")]
    public string? Img { get; set; }

    public long? ClubId { get; set; }

    public string? Description { get; set; }

    public string? Date { get; set; }

    [ForeignKey("ClubId")]
    [InverseProperty("Events")]
    public virtual Club? Club { get; set; }
}
