using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTOAuction;
using BUSAuction;

namespace WebDoanHoi_layout.wuc.sidebar
{
    public partial class sb_hd_noibat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadImage()
        {
            BUSLoaiHoatDong busLoaiHD = new BUSLoaiHoatDong();
            LOAIHOATDONG aLoaiHD = busLoaiHD.TimKiem("Hoạt động nổi bật");
            if (aLoaiHD != null)
            {
                BUSHoatDong busHD = new BUSHoatDong();
                List<HOATDONG> dsHDNoiBat = busHD.LayHoatDongTheoLoai(aLoaiHD.MaLoaiHoatDong);
                if (dsHDNoiBat.Count > 0)
                {
                    imgMain.ImageUrl = "~/Uploads/HinhAnhHoatDong/" + dsHDNoiBat[0].HinhAnh;
                    imgMain.AlternateText = "Không tìm thấy hình ảnh";
                    imgMain.PostBackUrl = "~/ChiTietHoatDong.aspx?id=" + dsHDNoiBat[0].MaHoatDong;
                }
            }
        }
    }
}