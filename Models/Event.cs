using System;
using System.Collections.Generic;

namespace InsatClub.Models;

public partial class Event
{
    public long Id { get; set; }

    public string? Nom { get; set; }

    public string? Img { get; set; }

    public long? ClubId { get; set; }

    public string? Description { get; set; }

    public string? Date { get; set; }

    public virtual Club? Club { get; set; }
}
