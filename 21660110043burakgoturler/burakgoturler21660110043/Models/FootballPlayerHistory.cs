using System;
using System.Collections.Generic;

namespace burakgoturler21660110043.Models;

public partial class FootballPlayerHistory
{
    public long Id { get; set; }

    public long PlayerId { get; set; }

    public long TeamId { get; set; }

    public virtual FootballPlayer Player { get; set; } = null!;

    public virtual FootballTeam Team { get; set; } = null!;
}
