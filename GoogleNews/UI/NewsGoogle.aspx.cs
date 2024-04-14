using GoogleNews.NewsDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoogleNews.DALNewsGoogle;

namespace GoogleNews.UI
{
    public partial class newsGoogle : System.Web.UI.Page
    {
        NewsGoogle rss = new NewsGoogle();
        List<string> listTitle = new List<string>();
        List<string> listLink = new List<string>();
        List<string> listDescription = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFeedItems();
            }
        }

        protected void LoadFeedItems()
        {
            List<NewsItem> items = rss.GetFeedItems();
            foreach (NewsItem item in items)
            {
                listTitle.Add(item.Title);
                listDescription.Add(item.Body);
                listLink.Add(item.Link);
            }

            RepeaterNews.DataSource = items;
            RepeaterNews.DataBind();
        }
    }
}
