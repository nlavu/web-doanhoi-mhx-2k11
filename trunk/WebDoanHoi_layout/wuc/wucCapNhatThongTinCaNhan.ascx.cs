using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;

namespace WebDoanHoi_layout.wuc
{
    public partial class wucCapNhatThongTinCaNhan : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((NGUOIDUNG)Session["LOGIN"]) == null)
                {
                   // Page.Title = "Mời bạn đăng nhập để có thể cập nhật thông tin cá nhân";
                    Response.Redirect("~/default.aspx");
                   // return;
                }
                Page.Title = "Cập nhật thông tin cá nhân";
                LoadMaNguoiDung();
                lThongTin.Text = "";
            }

        }

        protected void BtnThoat_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ThongTinCaNhan.aspx?id=" + ((NGUOIDUNG)Session["LOGIN"]).MaNguoiDung.ToString());
        }

        protected void BtnHuy_Click(object sender, EventArgs e)
        {
            TxbHoTen.Text = "";
            TxbEmail.Text = "";

            lThongTin.Text = "";
            //Response.Redirect("~/CapNhatThongTinCaNhan.aspx?id=" + MaNguoiDung.ToString());
        }

        protected void BtnSua_Click(object sender, EventArgs e)
        {
            BUSNguoiDung NguoiDungBUS = new BUSNguoiDung();
            NGUOIDUNG a = ((NGUOIDUNG)Session["LOGIN"]);
            if (TxbHoTen.Text == "" || TxbEmail.Text == "")
            {
                lThongTin.Text = "Cập nhật không thành công do bạn chưa nhập Họ tên hoặc Email";
            }
            else
            {
                a.HoTen = TxbHoTen.Text.Trim();
                a.Email = TxbEmail.Text.Trim();

                NguoiDungBUS.CapNhat(a);

                lThongTin.Text = "Cập nhật thành công";
            }

//             a.HoTen = TxbHoTen.Text;
//             a.Email = TxbEmail.Text;

        /*    NguoiDungBUS.CapNhat(a);*/

  /*          lThongTin.Text = "Cập nhật thành công";             */       
        }

        private void LoadMaNguoiDung()
        {
            //string tempMa = Request.QueryString["id"];
            int MaND = ((NGUOIDUNG)Session["LOGIN"]).MaNguoiDung;
            BUSNguoiDung NguoiDungBUS = new BUSNguoiDung();
            NGUOIDUNG NguoiDung = NguoiDungBUS.TimKiem(MaND);
            if (NguoiDung != null)
            {
                TxbHoTen.Text = NguoiDung.HoTen;
                TxbEmail.Text = NguoiDung.Email;
            }
        }
    }
}