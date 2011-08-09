using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Profile;
using System.Web.Configuration;
/// <summary>
/// Summary description for BasePage
/// </summary>

namespace AuctionOnline
{
    public class BasePage : Page
    {

        private bool _moveHiddenFields;
        public ProfileBase PageProfile;
        //public static readonly AuctionSection Settings =
       //     ((AuctionSection)WebConfigurationManager.GetSection("Auction"));

        public BasePage()
        {

            CleanWhiteSpace = true;
            _moveHiddenFields = true;
            //PageProfile = Helpers.GetUserProfile();

        }

        /// <summary>
        /// </summary>
        /// <param name="cssFile"></param>
        /// <remarks></remarks>
        public void AddStyleSheet(string cssFile)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("href", "~/" + cssFile);
            base.Header.Controls.Add(link);
        }

        //public string ConvertToHtml(string vString)
        //{
        //    return Helpers.ConvertToHtml(vString);
        //}

        /// <summary>
        /// </summary>
        /// <param name="sTagName"></param>
        /// <param name="TagValue"></param>
        /// <remarks></remarks>
        public void CreateMetaControl(string sTagName, string TagValue)
        {
            HtmlMeta meta = new HtmlMeta();
            meta.Name = sTagName;
            meta.Content = TagValue;
            if ((null != Master) && ((null != Master.Page) ? 1 : 0) != 0)
            {
                Master.Page.Header.Controls.Add(meta);
            }
            else
            {
                Page.Header.Controls.Add(meta);
            }
        }


        protected void GetDateTextBoxValue(TextBox vTextBox, ref DateTime? vDate)
        {
            if (string.IsNullOrEmpty(vTextBox.Text))
            {
                vDate = DateTime.MinValue;
            }
            else
            {
                vDate = DateTime.Parse(vTextBox.Text);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sTagName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string GetMetaValue(string sTagName)
        {
            HtmlMeta meta;
            if (null != Master)
            {
                meta = (HtmlMeta)Master.Page.Header.FindControl(sTagName);
            }
            else
            {
                meta = (HtmlMeta)Page.Header.FindControl(sTagName);
            }
            if (null != meta)
            {
                return meta.Content;
            }
            return string.Empty;
        }



        //private void Page_PreInit(object sender, EventArgs e)
        //{
        //    string id = Helpers.ThemesSelectorID;
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        if ((((Request.Form["__EVENTTARGET"] == id) && !string.IsNullOrEmpty(Request.Form[id])) ? 1 : 0) != 0)
        //        {
        //            Theme = Request.Form[id];
        //            Helpers.SetProfileTheme(PageProfile, Theme);
        //        }
        //        else if (!string.IsNullOrEmpty(Helpers.GetProfileTheme(PageProfile)))
        //        {
        //            Theme = Helpers.GetProfileTheme(PageProfile);
        //        }
        //    }
        //}

        //protected string RemoveWhiteSpace(string strText)
        //{
        //    return Helpers.RemoveWhiteSpace(strText);
        //}



        public void RequestLogin()
        {
            Response.Redirect(FormsAuthentication.LoginUrl + "?ReturnUrl=" + Request.Url.PathAndQuery);
        }


        protected void SetDateTextBoxValue(TextBox vTextBox, DateTime vDate)
        {
            if (DateTime.Compare(vDate, DateTime.MinValue) == 0)
            {
                vTextBox.Text = string.Empty;
            }
            else
            {
                vTextBox.Text = vDate.ToShortDateString();
            }
        }

        public void SetupListViewPager(int vCount, DataPager vPager)
        {
            if (null != vPager)
            {
                vPager.Visible = vCount <= vPager.PageSize ? false : true;
            }
        }

        public string BaseUrl
        {
            get
            {
                string url = Request.ApplicationPath;
                if (url.EndsWith("/"))
                {
                    return url;
                }
                return (url + "/");
            }
        }

        public bool CleanWhiteSpace { get; set; }

        public string FullBaseUrl
        {
            get
            {
                return (Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "") + BaseUrl);
            }
        }

        public bool IsAdmin
        {
            get
            {
                return (User.Identity.IsAuthenticated & User.IsInRole("Administrators"));
            }
        }

        /// <summary>
        /// Property that can be set by the child page to indicate if 
        /// hidden fields are going to be moved to the bottom of the page.
        /// Sometimes I have found that moving the fields to the bottom can cause 
        /// some runtime issues.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>The main reason you want to do this is to move the 
        /// ViewState to the bottom of the page. This will make the 
        /// content of the page render slightly faster, but it
        /// also helps with Search Engine optimization.
        /// </remarks>
        public bool MoveHiddenFields
        {
            get
            {
                return _moveHiddenFields;
            }
            set
            {
                _moveHiddenFields = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        protected string PageDescription
        {
            get
            {
                return GetMetaValue("DESCRIPTION");
            }
            set
            {
                CreateMetaControl("DESCRIPTION", value);
            }
        }

        /// <summary>
        /// </summary>
        /// <value></value>
        protected string PageKeyWords
        {
            get
            {
                return GetMetaValue("KEYWORDS");
            }
            set
            {
                CreateMetaControl("KEYWORDS", value);
            }
        }

        /// <summary>
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        protected string PageTitle
        {
            get
            {
                if (null != Master)
                {
                    if (Master.Page.Title == string.Empty)
                    {
                        return string.Empty;
                    }
                    return Master.Page.Title;
                }
                if (Page.Title == string.Empty)
                {
                    return string.Empty;
                }
                return Page.Title;
            }
            set
            {
                if (null != Master)
                {
                    Master.Page.Title = value;
                }
                else
                {
                    Page.Title = value;
                }
            }
        }

        public int PrimaryKeyId(string vPrimaryKey)
        {

            {
                if ((ViewState[vPrimaryKey] != null) && int.Parse(ViewState[vPrimaryKey].ToString()) != 0)
                {
                    return int.Parse(ViewState[vPrimaryKey].ToString());
                }
                else if (Request.QueryString[vPrimaryKey] != null &&
                    int.Parse(Request.QueryString[vPrimaryKey]) != 0)
                {
                    ViewState[vPrimaryKey] = int.Parse(Request.QueryString[vPrimaryKey]);
                    return int.Parse(Request.QueryString[vPrimaryKey].ToString());
                }
                return 0;
            }

        }

        public string PrimaryKeyIdAsString(string vPrimaryKey)
        {
            if (null != ViewState[vPrimaryKey])
            {
                return ViewState[vPrimaryKey].ToString();
            }
            if (null != Request.QueryString[vPrimaryKey])
            {
                ViewState[vPrimaryKey] = Request.QueryString[vPrimaryKey];
                return Request.QueryString[vPrimaryKey];
            }
            return string.Empty;
        }

        public string UserName
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }

        //protected void CommitSiteMap(string vTitle, string vURL, string vRealURL, string vDescription, string vKeywords, string vURLType)
        //{
        //    using (SiteMapRepository siteMapRpt = new SiteMapRepository())
        //    {
        //        //Need a way to delete title changes and 301 them to the new URL.
        //        SiteMapInfo lSiteMap = default(SiteMapInfo);
        //        lSiteMap = siteMapRpt.GetSiteMapInfoByRealURL(vRealURL);

        //        if ((lSiteMap == null))
        //        {
        //            lSiteMap = new SiteMapInfo();
        //        }
        //        lSiteMap.Description = vDescription;
        //        lSiteMap.Keywords = vKeywords;
        //        lSiteMap.RealURL = vRealURL;
        //        lSiteMap.Title = vTitle;
        //        lSiteMap.URLType = vURLType;
        //        lSiteMap.URL = vURL;
        //        lSiteMap.NodeType = 1;

        //        if (lSiteMap.SiteMapId == 0)
        //        {
        //            lSiteMap.DateAdded = DateTime.Now;
        //            lSiteMap.AddedBy = Helpers.CurrentUserName;
        //        }

        //        lSiteMap.DateUpdated = DateTime.Now;
        //        lSiteMap.UpdatedBy = Helpers.CurrentUserName;


        //        siteMapRpt.AddSiteMap(lSiteMap);

        //    }
        //}


    }
}