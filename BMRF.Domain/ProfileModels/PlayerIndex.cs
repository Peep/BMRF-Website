using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using BMRF.Domain.DataModels;
using BMRF.Domain.Entities;
using PagedList;

namespace BMRF.Domain.ProfileModels
{
    public class PlayerIndex
    {
        public static PlayerIndexViewModel GetPlayerIndex(string searchString, string sortOrder, int page, int pageSize)
        {
            var timer = new Stopwatch();
            timer.Start();

            var players = new List<PlayerStat>();

            using (var repository = new StatsDataModel())
            {
                if (!String.IsNullOrEmpty(searchString))
                    players = repository.Stats.Where(p => p.ForumUsername.ToUpper().Contains(searchString.ToUpper())
                                                          || p.Name.ToUpper().Contains(searchString.ToUpper())
                                                          || p.PUID.ToString(CultureInfo.InvariantCulture) == searchString
                                                          || p.GUID.ToString(CultureInfo.InvariantCulture) == searchString).ToList();
                else
                    players = repository.Stats.ToList();
            }

            #region sort cases
            switch (sortOrder.ToLower())
            {
                case "humankills":
                    players = players.OrderBy(s => s.KillsH).ToList();
                    break;
                case "humankills_desc":
                    players = players.OrderByDescending(s => s.KillsH).ToList();
                    break;
                case "banditkills":
                    players = players.OrderBy(s => s.KillsB).ToList();
                    break;
                case "banditkills_desc":
                    players = players.OrderByDescending(s => s.KillsB).ToList();
                    break;
                case "zombiekills":
                    players = players.OrderBy(s => s.KillsZ).ToList();
                    break;
                case "zombiekills_desc":
                    players = players.OrderByDescending(s => s.KillsZ).ToList();
                    break;
                case "deaths":
                    players = players.OrderBy(s => s.Deaths).ToList();
                    break;
                case "deaths_desc":
                    players = players.OrderByDescending(s => s.Deaths).ToList();
                    break;
                case "distance":
                    players = players.OrderBy(s => s.DistanceMeter).ToList();
                    break;
                case "distance_desc":
                    players = players.OrderByDescending(s => s.DistanceMeter).ToList();
                    break;
                case "score":
                    players = players.OrderBy(s => s.Score).ToList();
                    break;
                case "tplayed":
                    players = players.OrderBy(s => s.Playtime).ToList();
                    break;
                case "tplayed_desc":
                    players = players.OrderByDescending(s => s.Playtime).ToList();
                    break;
                default:
                    players = players.OrderByDescending(s => s.Score).ToList();
                    break;

            }
            #endregion

            // we should always round pageCount up to the nearest int
            int pageCount = (players.Count + pageSize - 1) / pageSize;

            int totalPlayers = players.Count;

            var pagedList = players.ToPagedList(page, pageSize);

            timer.Stop();
            var ts = timer.Elapsed;

            return new PlayerIndexViewModel() { CurrentPage = page, PageCount = pageCount, PlayerIndex = pagedList, 
                                                TotalPlayers = totalPlayers, GeneratedIn = ts.TotalSeconds};
        }
    }

    public class PlayerIndexViewModel
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int TotalPlayers { get; set; }
        public double GeneratedIn { get; set; }
        public IPagedList<PlayerStat> PlayerIndex { get; set; } 
    }
}
