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

public partial class administration_LoaiBaiViet : System.Web.UI.Page
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
