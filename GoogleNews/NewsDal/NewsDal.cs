using GoogleNews.NewsDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace GoogleNews.DALNewsGoogle
{
    public class NewsGoogle
    {


        private string url = "http://www.93fm.co.il/feed/?pz=1&cf=all&ned=en_il&hl=en&output=rss";
        private const string CacheKey = "GoogleNews";

        public List<NewsItem> GetFeedItems()
        {
            var items = HttpContext.Current.Cache[CacheKey] as List<NewsItem>;

            if (items == null)
            {
                items = FetchFeedFromUrl();
                HttpContext.Current.Cache.Insert(CacheKey, items, null, DateTime.Now.AddMinutes(20), TimeSpan.Zero);
            }

            return items;
        }

        private List<NewsItem> FetchFeedFromUrl()
        {
            var feedItems = new List<NewsItem>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            XmlNodeList nodes = xmlDoc.SelectNodes("rss/channel/item");

            foreach (XmlNode node in nodes)
            {
                string title = node.SelectSingleNode("title").InnerText;
                string link = node.SelectSingleNode("link").InnerText;
                string description = node.SelectSingleNode("description").InnerText;

                feedItems.Add(new NewsItem { Title = title, Link = link, Body = description });
            }

            return feedItems;
        }
    }
}
