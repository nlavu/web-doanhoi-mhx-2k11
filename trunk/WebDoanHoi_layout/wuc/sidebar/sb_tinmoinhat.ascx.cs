using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Globalization;

namespace WebDoanHoi_layout.wuc
{
    public partial class sb_tinmoinhat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BUSBaiViet BaiVietBUS = new BUSBaiViet();
            List<BAIVIET> DSBaiVietMoiNhat = BaiVietBUS.LayDSBaiVietNoiBatMoiNhat(5);
            string str = "";
            if (DSBaiVietMoiNhat == null)
            {
                return;
            }
            for (int i = 0; i < DSBaiVietMoiNhat.Count(); i++)
            {
                /*str += "<ul>";
                str += "<li><a href='#'>";
                str += DSBaiVietMoiNhat[i].TieuDe;
                str += "</a></li>";
                str += "</ul>";*/
                str += "<p>";
                str += "<img src = 'images/bullet.GIF' height='6px' width='6px'/>";
                str += "<a href ='" + "BaiViet.aspx?id=" + DSBaiVietMoiNhat[i].MaBaiViet + "'>  " + CultureInfo.CurrentUICulture.TextInfo.ToTitleCase/*.CurrentCulture..TextInfo.ToTitleCase*/(DSBaiVietMoiNhat[i].TieuDe.ToLower()) + "</a>";
                str += "</p>";
            }
            lblBaiVietMoiNhat.Text = str;
        }
    }
}