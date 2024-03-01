using System;
using System.Collections.Generic;

namespace FootballDataEngine.Api.Data;

public partial class Match
{
    public int MatchId { get; set; }

    public DateTime EventDate { get; set; }

    public string Country { get; set; } = null!;

    public string League { get; set; } = null!;

    public string HomeTeam { get; set; } = null!;

    public string AwayTeam { get; set; } = null!;

    public decimal AverageGoals { get; set; }

    public DateTime DateTimeCreated { get; set; }
}
