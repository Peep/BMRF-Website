using System;
using System.Diagnostics;
using System.Net;
using SSQLib;

namespace BMRF.Domain.HomepageModels
{
    public class QuickServerStat
    {
        public string FriendlyName { get; private set; }
        public string ServerName { get; private set; }

        public string IP { get; private set; }
        public int Port { get; private set; }

        public string Map { get; private set; }
        public string Game { get; private set; }

        public int PlayerCount { get; private set; }
        public int MaxPlayers { get; private set; }

        public bool Offline { get; private set; }

        public void GetServer(string ip, int port, string friendlyName)
        {
            FriendlyName = friendlyName;
            var ssql = new SSQL(new IPEndPoint(IPAddress.Parse(ip), port));
            try
            {
                var info = ssql.Server();
                PlayerCount = Convert.ToInt32(info.PlayerCount);
                MaxPlayers = Convert.ToInt32(info.MaxPlayers);
                ServerName = info.Name;
                Map = info.Map;
                Game = info.Game;

                IP = ip;
                Port = port;

                Offline = false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Offline = true;
            }
        }
    }
}
