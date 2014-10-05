using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using BMRF.Domain.DataModels;
using Newtonsoft.Json.Linq;

namespace BMRF.Domain
{
    public class Util
    {
        public static int UnixTime()
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static FileStreamResult GetForumAvatar(int vuid)
        {
            using (var context = new VBulletinCustomAvatarDataModel())
            {
                var avatar = (from row in context.customavatars
                    where row.userid == vuid
                    select row.filedata).FirstOrDefault();

                if (avatar == null)
                {
                    var webClient = new WebClient();
                    byte[] imageBytes = webClient.DownloadData("http://puu.sh/b41O0/1dd9260d45.jpg");
                    var imgStream = new MemoryStream(imageBytes.ToArray());
                    return new FileStreamResult(imgStream, "image/jpeg");
                }

                var fileName = (from row in context.customavatars
                    where row.userid == vuid
                    select row.filename).FirstOrDefault();

                string extension = fileName.Substring(fileName.LastIndexOf('.') + 1);

                var stream = new MemoryStream(avatar.ToArray());
                return new FileStreamResult(stream, "image/" + extension);
            }
        }

        public static dynamic GetJson(string urlQuery)
        {
            var wc = new WebClient();
            var rawjson = wc.DownloadString(urlQuery);
            wc.Dispose();
            return JObject.Parse(rawjson);
        }

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength, bool addDots = false)
        {
            if (string.IsNullOrEmpty(value)) return value;
            if (addDots)
                return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "..";
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }

    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }
    }
}
