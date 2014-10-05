using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BMRF.Domain.DataModels;
using BMRF.Domain.DataStructures;
using Newtonsoft.Json.Linq;

namespace BMRF.Domain.Frontpage
{
    public class StreamBuilder
    {
        private readonly List<FeaturedStream> _streams;

        public StreamBuilder()
        {
            _streams = new List<FeaturedStream>();
        }

        public IEnumerable<FeaturedStream> GetStreams()
        {
            GetFeatured();
            if (_streams.Count < 9)
                GetFiller();
            MakePretty();
            
            return _streams.OrderBy(p => p.Priority).ThenByDescending(v => v.Viewers).Take(9);
        }

        private void GetFeatured()
        {
            List<string> streamsToQuery;

            using (var streamDb = new StreamsDataModel())
                streamsToQuery = (from s in streamDb.Streams
                    select s.url).ToList();

            var wc = new WebClient();
            var rawjson = wc.DownloadString("https://api.twitch.tv/kraken/streams?channel=" +
                                                String.Join(",", streamsToQuery.ToArray()));
            ParseAndAdd(rawjson, 1);
        }

        private void GetFiller()
        {
            var wc = new WebClient();
            var csgo = wc.DownloadString("https://api.twitch.tv/kraken/streams?game=Counter-Strike:+Global+Offensive");
            var dayz = wc.DownloadString("https://api.twitch.tv/kraken/streams?game=DayZ");
            var a2 = wc.DownloadString("https://api.twitch.tv/kraken/streams?game=Arma+2:+Operation+Arrowhead");
            var a3 = wc.DownloadString("https://api.twitch.tv/kraken/streams?game=Arma+III");

            ParseAndAdd(a2, 2);
            ParseAndAdd(dayz, 2);
            ParseAndAdd(a3, 2);
            ParseAndAdd(csgo, 2);
        }

        private void ParseAndAdd(string rawjson, int priority)
        {
            dynamic json = JObject.Parse(rawjson);

            foreach (var k in json.streams)
            {
                string previewImage = k.preview.large;
                string channelUrl = k.channel.url;
                previewImage = previewImage.Replace("http://", "https://");
                //channelUrl = channelUrl.Replace("http://", "https://");

                _streams.Add(new FeaturedStream()
                {
                    StreamTitle = k.channel.status,
                    PreviewImage = previewImage,
                    Game = k.channel.game,
                    StreamerName = k.channel.display_name,
                    StreamUrl = channelUrl,
                    Viewers = k.viewers,
                    Priority = priority
                });
            }
        }

        private void MakePretty()
        {
            foreach (var s in _streams.Where(i => i.Game == "Counter-Strike: Global Offensive"))
                s.Game = "CS:GO";
            foreach (var s in _streams.Where(i => i.Game == "Arma 2: Operation Arrowhead"))
                s.Game = "Arma 2: OA";
        }
    }
}
