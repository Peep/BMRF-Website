using System.Collections.Generic;
using System.Linq;
using BMRF.Domain.DataModels;
using BMRF.Domain.Entities;

namespace BMRF.Domain.Frontpage
{
    public class QuickStatsBuilder
    {
        public IEnumerable<PlayerStat> GetPlayers()
        {
            var _playerStats = new List<PlayerStat>();

            using (var context = new StatsDataModel())
            {
                _playerStats = context.Stats.OrderByDescending(s => s.Score).Take(4).ToList();
            }

            return _playerStats;
        }
    }
}
