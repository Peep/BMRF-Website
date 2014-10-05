using System;
using System.Collections.Generic;

namespace BMRF.Domain.ViewModels
{
    public class AdminPlayerViewModel
    {
        public string ForumName { get; set; }

        public string EmailAddr { get; set; }

        /// <summary>
        /// Forum UserID.
        /// </summary>
        public int Vuid { get; set; }

        public string PrimaryForumUsergroup { get; set; }
        /// <summary>
        /// Last time this player loaded a page on the forums or main site.
        /// </summary>
        public DateTime LastSiteActivity { get; set; }

        public long PostCount { get; set; }

        /// <summary>
        /// A list of GUIDs associated with this player.
        /// </summary>
        public List<string> GuidList { get; set; }

        /// <summary>
        /// Current in-game name.
        /// </summary>
        public string InGameName { get; set; }

        /// <summary>
        /// Player ID.
        /// </summary>
        public string Puid { get; set; }

        /// <summary>
        /// Last time this player was online on a tracked server.
        /// </summary>
        public DateTime LastPlayed { get; set; }

        /// <summary>
        /// Total playtime in minutes across all tracked servers.
        /// </summary>
        public int Playtime { get; set; }

        /// <summary>
        /// A dictionary of CharacterIDs with their associated server.
        /// </summary>
        public Dictionary<int, string> CharacterIDs { get; set; }
    }
}
