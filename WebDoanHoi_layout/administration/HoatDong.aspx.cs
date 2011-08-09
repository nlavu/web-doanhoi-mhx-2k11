using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTOAuction;

namespace WebDoanHoi_layout.administration
{
    public partial class HoatDong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("myCookie");
            String username = cookie.Values["username"];

            if (username == null || username == "")
            {
                Response.Redirect("~/administration/DangNhap.aspx?url=" + Request.Url.AbsoluteUri);
            }        
        }
    }
}
