using System;
using System.Collections.Generic;
using System.Net;
using BMRF.Domain.DataStructures;
using BMRF.Domain.HomepageModels;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

namespace BMRF.Domain.Frontpage
{
    public class ArticleBuilder
    {
        private readonly List<HomepageArticle> _articles;

        public ArticleBuilder()
        {
            _articles = new List<HomepageArticle>();
        }

        public Article ValidateArticle(string slug)
        {
            var json = GetJson("http://cms.bmrf.me/?json=get_post&post_slug=" + slug);
            try
            {
                if (json.status == "ok")
                    return new Article() {Slug = slug, Title = json.post.title_plain, Author = json.post.author.name};
            }
            catch (RuntimeBinderException)
            {
                return null;
            }
            return null;
        }

        public IEnumerable<HomepageArticle> GetLatestArticles(int numOfArticles)
        {
            if (_articles.Count != 0)
                _articles.Clear();

            var wc = new WebClient();
            var rawjson = wc.DownloadString(
                "http://cms.bmrf.me/?json=get_recent_posts?count=" + numOfArticles);
            dynamic json = JObject.Parse(rawjson);

            foreach (var article in json.posts)
            {
                string title = article.title_plain;
                string slug = article.slug;
                string image;

                try // if the image doesn't exist, this property won't either
                {
                    image = article.thumbnail_images.full.url;
                }
                catch (RuntimeBinderException)
                {
                    image = "https://cdn.bmrf.me/defaultimage.jpg";
                }

                if (image != null)
                    image = image.Replace("http://", "https://");

                string category;
                try
                {
                    category = article.categories[0].title;
                }
                catch (RuntimeBinderException)
                {
                    category = "none";
                }
                catch (ArgumentOutOfRangeException)
                {
                    category = "none";
                }

                var newArticle = new HomepageArticle() {ImageUrl = image, Slug = slug, Title = title, Category = category};

                _articles.Add(newArticle);
            }

            for (var i = 0; i < _articles.Count; i++)
            {
                string cssClass;

                switch (i)
                {
                    case 0:
                        cssClass = "all-66 medium-100 small-100 headline-1 clearfix";
                        break;
                    case 1:
                        cssClass = "all-33 medium-100 small-100 headline-1 clearfix";
                        break;
                    case 2:
                        cssClass = "all-33 medium-100 small-100 headline-2 clearfix";
                        break;
                    default:
                        cssClass = "all-33 medium-50 small-100 headline-2 clearfix";
                        break;
                }

                _articles[i].Class = cssClass;
            }

            return _articles;
        }

        private dynamic GetJson(string urlQuery)
        {
            var wc = new WebClient();
            var rawjson = wc.DownloadString(urlQuery);
            wc.Dispose();
            return JObject.Parse(rawjson);
        }
    }
}
