using System.Linq;
using System.Web.Mvc;
using BMRF.Domain.DataModels;
using BMRF.Domain.Entities;

namespace BMRF.Domain.ProfileModels
{
    public class PlayerProfile
    {
        [OutputCache(Duration = 30, VaryByParam = "forumUsername")]
        public static ProfileViewModel GetProfile(string forumUsername)
        {
            PlayerStat stats;

            using (var context = new StatsDataModel())
            {
                stats = context.Stats.FirstOrDefault(p => p.ForumUsername.ToLower() == forumUsername.ToLower());
            }

            if (stats == null) return null;

            string lastInventory;
            bool lastAlive;
            string lastServer;

            using (var context = new PlayerDataModel())
            {
                var characters = context.Players.Where(p => p.PlayerUID == stats.PUID).OrderByDescending(d => d.Datestamp).Select(p => p).ToList();

                lastInventory = characters.Select(i => i.Inventory).FirstOrDefault();
                lastAlive = characters.Select(p => p.Alive == 1).FirstOrDefault();
                lastServer = characters.Select(p => p.OriginDB).FirstOrDefault();
            }

            var inventory = new Inventory(lastInventory);

            return new ProfileViewModel()
            {
                Player = stats,
                LastCharacter = new LastPlayedCharacter() { Inventory = inventory, Alive = lastAlive, Server = lastServer }
            };
        }
    }

    public class LastPlayedCharacter
    {
        public Inventory Inventory { get; set; }
        public bool Alive { get; set; }
        public string Server { get; set; }
    }

    public class ProfileViewModel
    {
        public PlayerStat Player { get; set; }
        public LastPlayedCharacter LastCharacter { get; set; }
    }
}
