using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ProjectAPI.Helpers
{
    public struct Score{
        int Goals { get; set; }
        int Points { get; set; }
    }

    [Table("fixtures")]
    public class Fixture
    {
        [Key]
        int FixtureID { get; set; }
        DateTime? Date { get; set; }
        string HomeTeam { get; set; }
        string AwayTeam { get; set; }
        Score HomeScore { get; set; }
        Score AwayScore { get; set; }
        string League { get; set; }
        string Referee { get; set; }

        public Fixture(DateTime? dateIn, string homeIn, string awayIn, Score homescoreIn, Score awayscoreIn, string leagueIn, string refIn)
        {
            Date = dateIn;
            HomeTeam = homeIn;
            AwayTeam = awayIn;
            HomeScore = homescoreIn;
            AwayScore = awayscoreIn;
            League = leagueIn;
            Referee = refIn;
        }
    }
}