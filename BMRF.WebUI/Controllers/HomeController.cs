using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using BMRF.Domain;
using BMRF.Domain.Frontpage;
using BMRF.Domain.HomepageModels;
using BMRF.Domain.Login;
using BMRF.Domain.ProfileModels;

namespace BMRF.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public static ForumUser ForumUser;

        public ActionResult Index()
        {
            var model = new HomepageModel();
            return View(model);
        }

        public ActionResult Article(string articleSlug)
        {
            if (articleSlug == null) throw new HttpException(404, "An article must be specified.");

            var builder = new ArticleBuilder();
            var article = builder.ValidateArticle(articleSlug);

            if (article == null) throw new HttpException(404, "The specified article was not found.");

            return View(article);
        }

        public ActionResult Articles()
        {
            return View();
        }

        public ActionResult Players(string searchQuery = null)
        {
            ViewBag.SearchQuery = searchQuery;
            return View();
        }

        public new ActionResult Profile(string playerName)
        {
            if (String.IsNullOrWhiteSpace(playerName)) throw new HttpException(404, "A profile must be specified.");

            var profile = PlayerProfile.GetProfile(playerName);

            if (profile == null)
                return RedirectToAction("Players");
            return View(profile);
        }

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult Servers()
        {
            List<QuickServerStat> servers = null;
            if (HttpRuntime.Cache["QuickStatsCollection"] != null)
            {
                servers = (List<QuickServerStat>) HttpRuntime.Cache["QuickStatsCollection"];
            }
            return View(servers);
        }

        public PartialViewResult NavBarPartial()
        {
            int userId = 0;
            string sessionHash = null;
            string password = null;

            if (Request.Cookies["bb_userid"] != null)
                if (!Int32.TryParse(Request.Cookies["bb_userid"].Value, out userId))
                    userId = 0;

            if (Request.Cookies["bb_sessionhash"] != null)
                sessionHash = Request.Cookies["bb_sessionhash"].Value;

            if (Request.Cookies["bb_password"] != null)
                password = Request.Cookies["bb_password"].Value;

            var forumRequest = new DefaultForumRequest()
            {
                IPAddress = Request.ServerVariables["REMOTE_ADDR"],
                SessionHash = sessionHash,
                UserID = userId,
                Password = password
            };

            var forumSession = new ForumUserSession(forumRequest);
            ForumUser = forumSession.BuildUser();

            return PartialView("_NavBarPartial", ForumUser);
        }

        public ActionResult Logout()
        {
            string[] cookies = { "bb_sessionhash", "bb_userid", 
                "bb_password", "bb_lastvisit", "bb_lastactivity" };

            foreach (var cookie in cookies)
            {
                if (Request.Cookies[cookie] != null)
                {
                    var c = new HttpCookie(cookie);
                    c.Expires = DateTime.Now.AddDays(-1);
                    c.Domain = ".bmrf.me";
                    Response.Cookies.Add(c);
                }
            }

            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.ToString());
            return RedirectToAction("Index");
        }

        [OutputCache(Duration = 3600, VaryByParam = "vuid")]
        public ActionResult RenderForumAvatar(int vuid)
        {
            return Util.GetForumAvatar(vuid);
        }
    }
}