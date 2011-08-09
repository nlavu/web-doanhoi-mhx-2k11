using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDoanHoi_layout.wuc.sidebar;
using System.Xml;

namespace WebDoanHoi_layout.wuc
{
    public partial class sb_quangcao : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadImage();
        }

        public void LoadImage()
        {
            //// Hình quảng cáo 1
            //Image1.ImageUrl = "~/Uploads/HinhAnhQuangCao/qc1.jpg";
            //Image1.AlternateText = "Dành cho quảng cáo";
            //Image1.PostBackUrl = "~/GioiThieu.aspx"; //Test
            ////Image1.DescriptionUrl = "BaiViet.aspx";

            //// Hình quảng cáo 2
            //Image2.ImageUrl = "~/Uploads/HinhAnhQuangCao/qc2.jpg";
            //Image2.AlternateText = "Dành cho quảng cáo";
            //Image2.PostBackUrl = "http://www.fit.hcmus.edu.vn/PFInfo/index.html";

            //// Hình quảng cáo 3
            //Image3.ImageUrl = "~/Uploads/HinhAnhQuangCao/qc3.jpg";
            //Image3.AlternateText = "Dành cho quảng cáo";
            //Image3.PostBackUrl = "http://www.jvn.edu.vn";

            
        }
    }
}