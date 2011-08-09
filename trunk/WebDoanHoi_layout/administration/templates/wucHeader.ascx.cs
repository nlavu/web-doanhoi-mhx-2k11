using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BUSAuction;
using DTOAuction;

namespace WebDoanHoi_layout.administration.templates
{
    public partial class wucHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("myCookie");
            if (cookie == null)
                Response.Redirect("~/administration/DangNhap.aspx?url=" + Request.Url.AbsoluteUri);
            String username = cookie.Values["username"];

            if (username == null || username == "")
            {
                Response.Redirect("~/administration/DangNhap.aspx?url=" + Request.Url.AbsoluteUri);
            }
            else
            {
                lblUserName.Text = username;
            }
        }

        protected void linkButtonLogout_Click(object sender, EventArgs e)
        {
             Response.Write("Logout");
             HttpCookie myCookie = new HttpCookie("myCookie");
             myCookie.Expires = DateTime.Now.AddDays(-1d);
             Response.Cookies.Add(myCookie);
            Response.Redirect("default.aspx");
        }
    }
}