using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BMRF.Domain.DataStructures;
using BMRF.Domain.Frontpage;
using BMRF.Domain.HomepageModels;

namespace BMRF.WebUI
{
    public class MvcApplication : HttpApplication
    {
        List<ServerOptions> ServerOptions { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //ModelBinders.Binders.Add(typeof (User), new UserModelBinder());

            var configThread = new Thread(GetServersFromConfig);
            configThread.Start();

            var queryThread = new Thread(QuerySteamServers);
            queryThread.Start();

            var streamQueryThread = new Thread(QueryStreams);
            streamQueryThread.Start();

            var statsQueryThread = new Thread(QueryStats);
            statsQueryThread.Start();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //You don't want to redirect on posts, or images/css/js
            bool isGet = HttpContext.Current.Request.RequestType.ToLowerInvariant().Contains("get");
            if (isGet && HttpContext.Current.Request.Url.AbsolutePath.Contains('.') == false)
            {
                string lowercaseURL = (Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                                       HttpContext.Current.Request.Url.AbsolutePath);
                if (Regex.IsMatch(lowercaseURL, @"[A-Z]"))
                {
                    //You don't want to change casing on query strings
                    lowercaseURL = lowercaseURL.ToLower() + HttpContext.Current.Request.Url.Query;

                    Response.Clear();
                    Response.Status = "301 Moved Permanently";
                    Response.AddHeader("Location", lowercaseURL);
                    Response.End();
                }
            }
        }

        private void GetServersFromConfig()
        {
            while (true)
            {
                var settings = System.Web.Configuration.WebConfigurationManager.AppSettings;
                var query = from string q in settings.Keys
                    where q.StartsWith("registerServer")
                    select settings[q];

                var optionsList = new List<ServerOptions>();
                foreach (var entry in query)
                {
                    var inputOptions = entry.Split(new[] {','});
                    var serverOptions = new ServerOptions
                    {
                        FriendlyName = inputOptions[0],
                        Hostname = inputOptions[1],
                        Port = Convert.ToInt32(inputOptions[2])
                    };
                    optionsList.Add(serverOptions);
                }
                ServerOptions = optionsList;
                Thread.Sleep(300*1000);
            }
        }

        private void QuerySteamServers()
        {
            while (true)
            {
                if (ServerOptions != null)
                {
                    var statList = new List<QuickServerStat>();
                    foreach (var s in ServerOptions)
                    {
                        var server = new QuickServerStat();
                        server.GetServer(s.Hostname, s.Port, s.FriendlyName);
                        statList.Add(server);
                    }
                    HttpRuntime.Cache["QuickStatsCollection"] = statList;
                }
                Thread.Sleep(1000);
            }
        }

        private static void QueryStreams()
        {
            while (true)
            {
                var sb = new StreamBuilder();
                HttpRuntime.Cache["StreamsCollection"] = sb.GetStreams();
                Thread.Sleep(1000 * 15);
            }
        }

        private static void QueryStats()
        {
            while (true)
            {
                var builder = new QuickStatsBuilder();
                HttpRuntime.Cache["PlayerStatsCollection"] = builder.GetPlayers();
                Thread.Sleep(1000 * 15);
            }
        }
    }
}
