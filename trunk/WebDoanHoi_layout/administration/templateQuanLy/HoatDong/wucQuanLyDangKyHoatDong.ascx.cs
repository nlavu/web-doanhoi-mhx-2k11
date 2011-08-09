using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;
using System.Windows.Forms;

namespace WebDoanHoi_layout.administration.templateQuanLy.HoatDong
{
    public partial class wucQuanLyDangKyHoatDong : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                ////lay ma
                //int mahoatdong = int.Parse(Request.QueryString["id"]);

                ////lay thong tin va load len cac textbox
                //BUSDangKyHoatDong BUSDangKyHoatDong = new BUSDangKyHoatDong();
                //DANGKYHOATDONG lpDTO = BUSDangKyHoatDong.TimKiem(mahoatdong);

                //BUSHoatDong bushoatdong = new BUSHoatDong();
                //BUSNguoiDung busnguoidung = new BUSNguoiDung();

                //txtmasinhvien.Text = busnguoidung.TimKiem(lpDTO.MaNguoiDung).Username;
                //txthoatdong.Text = bushoatdong.TimKiem(lpDTO.MaHoatDong).TenHoatDong;
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        //lay thong tin tu textbox
        //        DANGKYHOATDONG lpDTO = new DANGKYHOATDONG();
        //        lpDTO.MaNguoiDung  = int.Parse(txtmasinhvien.Text);
        //        lpDTO.MaHoatDong  = int.Parse(txtmahoatdong.Text);

        //        //Goi ham cap nhat
        //        BUSDangKyHoatDong BUSDangKyHoatDong = new BUSDangKyHoatDong();
        //        if (BUSDangKyHoatDong.CapNhat(lpDTO) == 0)
        //        {
        //            //Thong bao
        //            lbThongBao.Text = "Cập Nhật Thành Công";
        //            lbThongBao.Visible = true;
        //            //Response.Redirect("LoaiMatHang.aspx");
        //        }
        //        else
        //        {
        //            lbThongBao.Text = "Cập Nhật Không Thành Công";
        //            lbThongBao.Visible = true;
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        lbThongBao.Text = "Cập nhật Không Thành Công";
        //        lbThongBao.Visible = true;
        //    }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        //lay thong tin tu textbox
        //        DANGKYHOATDONG lpDTO = new DANGKYHOATDONG();
        //        lpDTO.MaNguoiDung = int.Parse(txtmasinhvien.Text);
        //        lpDTO.MaHoatDong = int.Parse(txtmahoatdong.Text);
        //        //Goi ham cap nhat
        //        BUSDangKyHoatDong BUSDangKyHoatDong = new BUSDangKyHoatDong();
        //        if (BUSDangKyHoatDong.Them(lpDTO) == 0)
        //        {
        //            //Thong bao
        //            lbThongBao.Text = "Thêm Thành Công";
        //            lbThongBao.Visible = true;

        //            Response.Redirect("~/administration/DangKyHoatDong.aspx");
        //        }
        //        else
        //        {
        //            lbThongBao.Text = "Thêm Không Thành Công";
        //            lbThongBao.Visible = true;
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        lbThongBao.Text = "Thêm Không Thành Công";
        //        lbThongBao.Visible = true;
        //    }
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        //lay thong tin tu textbox
        //        DANGKYHOATDONG hoatdong = new DANGKYHOATDONG();
        //        hoatdong.MaHoatDong = int.Parse(txtmahoatdong.Text);
        //        hoatdong.MaNguoiDung = int.Parse(txtmasinhvien.Text);
        //        //xac nhan truoc khi xoa
        //        DialogResult rs = MessageBox.Show("Bạn có chắc là muốn xoá Hoạt Động <" + hoatdong.MaHoatDong  + "> không?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (rs == DialogResult.Yes)
        //        {
        //            //Goi ham xoa
        //            BUSDangKyHoatDong BUSDangKyHoatDong = new BUSDangKyHoatDong();
        //            if (BUSDangKyHoatDong.Xoa(hoatdong) == 0)
        //            {
        //                //Thong bao
        //                lbThongBao.Text = "Xóa Thành Công";
        //                lbThongBao.Visible = true;
        //                Response.Redirect("HoatDong.aspx");
        //            }
        //            else
        //            {
        //                lbThongBao.Text = "Xóa Không Thành Công";
        //                lbThongBao.Visible = true;
        //            }
        //        }
        //        else
        //        {
        //            Response.Redirect("~/administration/DangKyHoatDong.aspx");
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        lbThongBao.Text = "Xoa Không Thành Công";
        //        lbThongBao.Visible = true;
        //    }
        }
        #endregion
    }
}