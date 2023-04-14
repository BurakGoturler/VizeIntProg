using System;
using System.Collections.Generic;

namespace burakgoturler21660110043.Models;

public partial class FootballPlayer
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string BirthDate { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string UniformNumber { get; set; } = null!;

    public string RightOrHeftHanded { get; set; } = null!;

    public virtual ICollection<FootballPlayerHistory> FootballPlayerHistories { get; set; } = new List<FootballPlayerHistory>();
}
