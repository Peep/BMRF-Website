using System;
using System.Net;
using System.Web.Mvc;
using BMRF.Domain;
using BMRF.Domain.ProfileModels;

namespace BMRF.WebUI.Controllers
{
    public class APIController : Controller
    {
        [AllowCrossSiteJson]
        public ActionResult LaunchTimer()
        {
            DateTime countdownTime = new DateTime(2014, 09, 20, 12, 0, 0);
            TimeSpan span = (countdownTime - DateTime.Now);
            return Json(new { countdown = (int)span.TotalSeconds }, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, VaryByParam = "*"), AllowCrossSiteJson]
        public ActionResult Players(string searchString, string sortOrder = "score_desc", int page = 1, int pageSize = 15)
        {
            var query = PlayerIndex.GetPlayerIndex(searchString, sortOrder, page, pageSize);
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        #region Wordpress CMS functions

        public ActionResult Get_Post(string post_slug)
        {
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString("http://cms.bmrf.me/?json=get_post&post_slug=" + post_slug);
                json = json.Replace("http:", "https:");
                return Content(json, "application/json");
            }
        }

        public ActionResult Get_Recent_Posts(int count = 10)
        {
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString("http://cms.bmrf.me/?json=get_recent_posts&count=" + count);
                json = json.Replace("http:", "https:");
                return Content(json, "application/json");
            }
        }

        public ActionResult Get_Posts(int page = 1)
        {
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString("http://cms.bmrf.me/?json=get_posts&page=" + page);
                json = json.Replace("http:", "https:");
                return Content(json, "application/json");
            }
        }

        public ActionResult Get_Search_Results(string search)
        {
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString("http://cms.bmrf.me/?json=get_search_results&search=" + search);
                json = json.Replace("http:", "https:");
                return Content(json, "application/json");
            }
        }

        #endregion
    }
}