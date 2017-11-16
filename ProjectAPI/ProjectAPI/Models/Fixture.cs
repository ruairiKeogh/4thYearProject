using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using HtmlAgilityPack;
using System.Threading.Tasks;

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
        string Venue { get; set; }

        public Fixture(DateTime? dateIn, string homeIn, string awayIn, Score homescoreIn, Score awayscoreIn, string leagueIn, string refIn, string venueIn)
        {
            Date = dateIn;
            HomeTeam = homeIn;
            AwayTeam = awayIn;
            HomeScore = homescoreIn;
            AwayScore = awayscoreIn;
            League = leagueIn;
            Referee = refIn;
            Venue = venueIn;
        }

        public static async void ScrapeData()
        {
            HtmlWeb web = new HtmlWeb();
            var doc = await Task.Factory.StartNew(() => web.Load("https://www.dublingaa.ie/fixtures"));
            var leagueNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a");//*[@id="listing_wrapper"]/div[2]
            
            //for (int i =0; i<leagueNodes.Count();i++)
            //{
            //    if (i % 2 != 0) {
            //       var leagueTexts += leagueNodes.Select(i);
            //    }
            //}
            var leagueTexts = leagueNodes.Select(node => node.InnerText);

            var dateNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[1]");
            var dateTexts = dateNodes.Select(node => node.InnerText);
            var timeNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[2]");
            var timeTexts = timeNodes.Select(node => node.InnerText);

            var venueNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[3]");
            var venueTexts = venueNodes.Select(node => node.InnerText);

            var homeTeamNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[4]");
            var homeTeamTexts = homeTeamNodes.Select(node => node.InnerText);

            var awayTeamNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[6]");
            var awayTeamTexts = awayTeamNodes.Select(node => node.InnerText);

            var refNodes = doc.DocumentNode.SelectNodes("//*[@id=\"listing_wrapper\"]/div//a/div[7]");
            var refTexts = refNodes.Select(node => node.InnerText);
        }
    }
}