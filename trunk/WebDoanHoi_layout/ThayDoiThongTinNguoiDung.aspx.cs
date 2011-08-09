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
using BUSAuction;
using DTOAuction;

namespace WebDoanHoi_layout.Masterpages
{
    public partial class ThayDoiThongTinNguoiDung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string szTenDangNhap = (Session["LOGIN"] as string);

            txtUsername.Text = szTenDangNhap;
        }

        protected void btXacNhan_Click(object sender, EventArgs e)
        {
            string szTenDangNhap = (Session["LOGIN"] as string);

            if (szTenDangNhap != null)
            {
                BUSNguoiDung NguoiDungBUS = new BUSNguoiDung();

                NGUOIDUNG sv = NguoiDungBUS.TimKiem(int.Parse(szTenDangNhap));

                if (txtHoTen.Text != null)
                    sv.HoTen = txtHoTen.Text;

                if (txtEmail.Text != null)
                    sv.Email = txtEmail.Text;

                NguoiDungBUS.CapNhat(sv);

                lThongTin.Text = "Cập nhật thành công";
            }
            else
                lThongTin.Text = "Cập nhật thất bại";
        }   

    }
}
