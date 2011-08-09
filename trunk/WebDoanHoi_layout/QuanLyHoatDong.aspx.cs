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

namespace WebDoanHoi_layout
{
    public partial class QuanLyHoatDong : System.Web.UI.Page
    {
        private bool KiemTra()
        {
            DateTime ngaydienra = new DateTime(int.Parse(txtNgayDienRa.Text.Substring(6, 4)), int.Parse(txtNgayDienRa.Text.Substring(3, 2)), int.Parse(txtNgayDienRa.Text.Substring(0, 2)));
            DateTime thoigianbatdaudk = new DateTime(int.Parse(txtThoiGianBatDauDK.Text.Substring(6, 4)), int.Parse(txtThoiGianBatDauDK.Text.Substring(3, 2)), int.Parse(txtThoiGianBatDauDK.Text.Substring(0, 2)));
            DateTime thoigianketthucdk = new DateTime(int.Parse(txtThoiGianKetThucDK.Text.Substring(6, 4)), int.Parse(txtThoiGianKetThucDK.Text.Substring(3, 2)), int.Parse(txtThoiGianKetThucDK.Text.Substring(0, 2)));
       
            if (thoigianbatdaudk <= thoigianketthucdk && thoigianketthucdk < ngaydienra)
            {
                return true;
            }

            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlMaHoatDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUSHoatDong bushoatdong = new BUSHoatDong();
            HOATDONG hoatdong = bushoatdong.TimKiem(int.Parse(ddlMaHoatDong.SelectedValue));
            txtTenHoatDong.Text = hoatdong.TenHoatDong;
            ddlLoaiHoatDong.Text = hoatdong.MaLoaiHoatDong.ToString();

            txtNgayDienRa.Text = hoatdong.NgayDienRa.Value.Day + "/" + hoatdong.NgayDienRa.Value.Month + "/" + hoatdong.NgayDienRa.Value.Year;
            txtThoiGianBatDauDK.Text = hoatdong.ThoiGianBatDauDangKy.Value.Day + "/" + hoatdong.ThoiGianBatDauDangKy.Value.Month + "/" + hoatdong.ThoiGianBatDauDangKy.Value.Year;
            txtThoiGianKetThucDK.Text = hoatdong.ThoiGianKetThucDangKy.Value.Day + "/" + hoatdong.ThoiGianKetThucDangKy.Value.Month + "/" + hoatdong.ThoiGianKetThucDangKy.Value.Year;
        }

        protected void btThem_Click(object sender, EventArgs e)
        {
            if (KiemTra() == false)
            {
                txtThongTin.Text = "Thời gian không hợp lệ";
                return;
            }

            HOATDONG hoatdong = new HOATDONG();
            hoatdong.TenHoatDong = txtTenHoatDong.Text;
            hoatdong.MaLoaiHoatDong = int.Parse(ddlMaHoatDong.SelectedValue);

            hoatdong.NgayDienRa = new DateTime(int.Parse(txtNgayDienRa.Text.Substring(6, 4)), int.Parse(txtNgayDienRa.Text.Substring(3, 2)), int.Parse(txtNgayDienRa.Text.Substring(0, 2)));
            hoatdong.ThoiGianBatDauDangKy = new DateTime(int.Parse(txtThoiGianBatDauDK.Text.Substring(6, 4)), int.Parse(txtThoiGianBatDauDK.Text.Substring(3, 2)), int.Parse(txtThoiGianBatDauDK.Text.Substring(0, 2)));
            hoatdong.ThoiGianKetThucDangKy = new DateTime(int.Parse(txtThoiGianKetThucDK.Text.Substring(6, 4)), int.Parse(txtThoiGianKetThucDK.Text.Substring(3, 2)), int.Parse(txtThoiGianKetThucDK.Text.Substring(0, 2)));

            BUSHoatDong bushoatdong = new BUSHoatDong();
            bushoatdong.Them(hoatdong);

            Response.Redirect("QuanLyHoatDong.aspx");
        }

        protected void btCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra() == false)
            {
                txtThongTin.Text = "Thời gian không hợp lệ";
                return;
            }

            HOATDONG hoatdong = new HOATDONG();
            hoatdong.MaHoatDong = int.Parse(ddlMaHoatDong.SelectedValue);
            hoatdong.TenHoatDong = txtTenHoatDong.Text;
            hoatdong.MaLoaiHoatDong = int.Parse(ddlMaHoatDong.SelectedValue);

            hoatdong.NgayDienRa = new DateTime(int.Parse(txtNgayDienRa.Text.Substring(6, 4)), int.Parse(txtNgayDienRa.Text.Substring(3, 2)), int.Parse(txtNgayDienRa.Text.Substring(0, 2)));
            hoatdong.ThoiGianBatDauDangKy = new DateTime(int.Parse(txtThoiGianBatDauDK.Text.Substring(6, 4)), int.Parse(txtThoiGianBatDauDK.Text.Substring(3, 2)), int.Parse(txtThoiGianBatDauDK.Text.Substring(0, 2)));
            hoatdong.ThoiGianKetThucDangKy = new DateTime(int.Parse(txtThoiGianKetThucDK.Text.Substring(6, 4)), int.Parse(txtThoiGianKetThucDK.Text.Substring(3, 2)), int.Parse(txtThoiGianKetThucDK.Text.Substring(0, 2)));

            BUSHoatDong bushoatdong = new BUSHoatDong();
            bushoatdong.CapNhat(hoatdong);
        }

        protected void btXoa_Click(object sender, EventArgs e)
        {
            BUSHoatDong bushoatdong = new BUSHoatDong();
            bushoatdong.Xoa(int.Parse(ddlMaHoatDong.SelectedValue));
            Response.Redirect("QuanLyHoatDong.aspx");
        }
    }
}
