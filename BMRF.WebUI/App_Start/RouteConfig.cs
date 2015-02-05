using System.Web.Mvc;
using System.Web.Routing;

namespace BMRF.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("vbforums/{*pathInfo}");
            routes.IgnoreRoute("images/{*pathInfo}");
            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Article",
                url: "article/{articleSlug}",
                defaults: new { controller = "Home", action = "Article", articleSlug = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Articles",
                url: "articles",
                defaults: new { controller = "Home", action = "Articles" }
                );

            routes.MapRoute(
                name: "Players",
                url: "players",
                defaults: new { controller = "Home", action = "Players" }
                );

            routes.MapRoute(
                name: "SearchPlayers",
                url: "players/search/{searchQuery}",
                defaults: new { controller = "Home", action = "Players", searchQuery = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Profile",
                url: "profile/{playerName}",
                defaults: new { controller = "Home", action = "Profile", playerName = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Rules",
                url: "rules",
                defaults: new { controller = "Home", action = "Rules" }
                );

            routes.MapRoute(
                name: "Servers",
                url: "servers",
                defaults: new { controller = "Home", action = "Servers" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
