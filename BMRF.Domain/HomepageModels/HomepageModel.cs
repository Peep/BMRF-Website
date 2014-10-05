using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BMRF.Domain.DataModels;
using BMRF.Domain.DataStructures;
using BMRF.Domain.Entities;
using BMRF.Domain.Frontpage;

namespace BMRF.Domain.HomepageModels
{
    public class HomepageModel
    {
        public IEnumerable<FeaturedStream> FeaturedStreams { get; private set; }
        public IEnumerable<QuickServerStat> QuickServerStats { get; private set; }
        public IEnumerable<PlayerStat> QuickPlayerStats { get; private set; }
        public IEnumerable<HomepageArticle> Articles { get; private set; }
        public FrontPageStats TotalStats { get; private set; }

        public HomepageModel()
        {
            FeaturedStreams = new List<FeaturedStream>();
            QuickServerStats = new List<QuickServerStat>();
            QuickPlayerStats = new List<PlayerStat>();

            GetStreams();
            GetPlayerStats();
            GetServerStats();
            GetArticles();
            GetFrontPageStats();
        }
 
        internal void GetStreams()
        {
            if (HttpRuntime.Cache["StreamsCollection"] != null)
                FeaturedStreams = (IEnumerable<FeaturedStream>)HttpRuntime.Cache["StreamsCollection"];
        }

        internal void GetPlayerStats()
        {
            if (HttpRuntime.Cache["StreamsCollection"] != null)
                QuickPlayerStats = (IEnumerable<PlayerStat>)HttpRuntime.Cache["PlayerStatsCollection"];
        }

        internal void GetServerStats()
        {
            if (HttpRuntime.Cache["QuickStatsCollection"] != null)
                QuickServerStats = (List<QuickServerStat>) HttpRuntime.Cache["QuickStatsCollection"];
        }

        internal void GetArticles()
        {
            var articleBuilder = new ArticleBuilder();
            Articles = articleBuilder.GetLatestArticles(5).Take(5);
        }

        [OutputCache(Duration = 3600)]
        internal void GetFrontPageStats()
        {
            using (var context = new PlayerDataModel())
            {
                if (!context.Players.Any()) return;
                TotalStats = new FrontPageStats()
                {
                    HoursPlayed = context.Players.Sum(p => p.Duration) / 60,
                    AvgSurvivalTime = (int)context.Players.Average(p => p.Duration)
                };
            }
        }
    }

    public class FrontPageStats
    {
        public int HoursPlayed { get; set; }
        public int AvgSurvivalTime { get; set; }
    }
}
