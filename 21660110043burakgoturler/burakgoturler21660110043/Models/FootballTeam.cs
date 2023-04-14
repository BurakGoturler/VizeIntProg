using System;
using System.Collections.Generic;

namespace burakgoturler21660110043.Models;

public partial class FootballTeam
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string EstablishDate { get; set; } = null!;

    public string DirectorName { get; set; } = null!;

    public string UniformTeamColor { get; set; } = null!;

    public string DirectoHelperName { get; set; } = null!;

    public virtual ICollection<FootballPlayerHistory> FootballPlayerHistories { get; set; } = new List<FootballPlayerHistory>();
}
