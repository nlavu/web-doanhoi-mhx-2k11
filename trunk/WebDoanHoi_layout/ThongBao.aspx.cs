using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using DTOAuction;
using BUSAuction;
using System.Collections.Generic;

namespace WebDoanHoi_layout
{
    public partial class ThongBao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadThongBao();
        }

        protected void LoadThongBao()
        {
  
        }
    }

}
