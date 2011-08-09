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
using System.Windows;
using DTOAuction;
using BUSAuction;
using System.Collections.Generic;

namespace WebDoanHoi_layout
{
    public partial class ChiTietHoatDong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadHoatDong();
            }
            
        }

        protected void LoadHoatDong()
        {
            string mahoatdong = Request.QueryString["id"];

            if (mahoatdong == null)
            {
                Response.Redirect("HoatDong.aspx");
            }
            lblDanhSachThongBao.Text = LayDanhSachThongBao(int.Parse(mahoatdong));

            BUSHoatDong bushoatdong = new BUSHoatDong();

            HOATDONG hoatdong = bushoatdong.TimKiem(int.Parse(mahoatdong));

            if (hoatdong == null)
            {
                Response.Redirect("HoatDong.aspx");
            }

            lbHoatDong.Text = hoatdong.TenHoatDong;
            lbNgayDienRa.Text = hoatdong.NgayDienRa.Value.Day + "/" + hoatdong.NgayDienRa.Value.Month + "/" + hoatdong.NgayDienRa.Value.Year;
            lbBatDauDK.Text = hoatdong.ThoiGianBatDauDangKy.Value.Day + "/" + hoatdong.ThoiGianBatDauDangKy.Value.Month + "/" + hoatdong.ThoiGianBatDauDangKy.Value.Year;
            lbKetThucDK.Text = hoatdong.ThoiGianKetThucDangKy.Value.Day + "/" + hoatdong.ThoiGianKetThucDangKy.Value.Month + "/" + hoatdong.ThoiGianKetThucDangKy.Value.Year;
            //chua toi han dang ky
            if (System.DateTime.Today < hoatdong.ThoiGianBatDauDangKy)
            {
                txtTrangThai.Text = "Chưa tới thời gian được phép đăng ký hoạt động này";
                txtTrangThai.Visible = true;
                PanelDangKy.Visible = false;
                PanelHuyDangKy.Visible = false;
                return;
            }
            //het han dang ky
            if (System.DateTime.Today > hoatdong.ThoiGianKetThucDangKy)
            {
                txtTrangThai.Text = "Đã quá hạn đăng ký hoạt động này";
                txtTrangThai.Visible = true;
                PanelDangKy.Visible = false;
                PanelHuyDangKy.Visible = false;
                return;
            }
            //con han dang ky

            NGUOIDUNG sv = (NGUOIDUNG)Session["LOGIN"];

            if (sv == null)
            {
                txtTrangThai.Text = "Bạn không được phép đăng ký hoạt động này, vui lòng đăng nhập";
                txtTrangThai.Visible = true;
                PanelDangKy.Visible = false;
                PanelHuyDangKy.Visible = false;
                return;
            }

            BUSDangKyHoatDong busdangkyhoatdong = new BUSDangKyHoatDong();

            DANGKYHOATDONG dangkyhoatdong = busdangkyhoatdong.TimKiem(sv.MaNguoiDung, int.Parse(mahoatdong));

            if (dangkyhoatdong == null)
            {
                txtTrangThai.Text = "Hãy nhấn đăng ký để tham gia hoạt động này!!!";
                txtTrangThai.Visible = true;
                PanelDangKy.Visible = true;
                PanelHuyDangKy.Visible = false;
                return;
            }
            else
            {
                txtTrangThai.Text = "Bạn đã đăng ký thành công";
                txtTrangThai.Visible = true;
                PanelDangKy.Visible = false;
                PanelHuyDangKy.Visible = true;
                return;
            }
        }
        protected string LayDanhSachThongBao(int MaHoatDong)
        {
            BUSThongBao ThongBaoBUS = new BUSThongBao();
            List<THONGBAO> DSThongBao = ThongBaoBUS.LayThongBaoTheoMaHoatDong(MaHoatDong);
            string str = "";

            if (DSThongBao.Count() == 0)
            {
                str = "Không có thông báo";
                return str;
            }

            str = "";
            for(int i=0; i<DSThongBao.Count(); i++)
            {
               
                //str += DSThongBao[i].TieuDe + "</div>";
                str += "<a href ='" + "ThongBao.aspx?id=" + DSThongBao[i].MaThongBao + "'>" + DSThongBao[i].TieuDe + "</a><br/>";
               
            }
            return str;
        }
        protected void btDangKy_Click(object sender, EventArgs e)
        {
            NGUOIDUNG sv = (NGUOIDUNG)Session["LOGIN"];

            DANGKYHOATDONG dangkyhoatdong = new DANGKYHOATDONG();
            dangkyhoatdong.MaNguoiDung = sv.MaNguoiDung;
            dangkyhoatdong.MaHoatDong = int.Parse(Request.QueryString["id"]);

            BUSDangKyHoatDong busdangkyhoatdong = new BUSDangKyHoatDong();
            busdangkyhoatdong.Them(dangkyhoatdong);

            PanelDangKy.Visible = false;
            PanelHuyDangKy.Visible = true;
            txtTrangThai.Text = "Hoạt động này đã được đăng ký";

            Response.Redirect("ChiTietHoatDong.aspx?id=" + Request.QueryString["id"]);
        }

        protected void btHuy_Click(object sender, EventArgs e)
        {
            string szTenDangNhap = ((NGUOIDUNG)Session["LOGIN"]).Username;

            BUSNguoiDung busnguoidung = new BUSNguoiDung();
            NGUOIDUNG sv = busnguoidung.TimKiem(szTenDangNhap);

            DANGKYHOATDONG dangkyhoatdong = new DANGKYHOATDONG();
            dangkyhoatdong.MaNguoiDung = sv.MaNguoiDung;
            dangkyhoatdong.MaHoatDong = int.Parse(Request.QueryString["id"]);

            BUSDangKyHoatDong busdangkyhoatdong = new BUSDangKyHoatDong();
            busdangkyhoatdong.Xoa(dangkyhoatdong);

            PanelDangKy.Visible = true;
            PanelHuyDangKy.Visible = false;
            txtTrangThai.Text = "Hoạt động này chưa được đăng ký";

            Response.Redirect("ChiTietHoatDong.aspx?id=" + Request.QueryString["id"]);
        }
    }
}
