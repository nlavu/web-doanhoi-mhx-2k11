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

namespace WebDoanHoi_layout.administration.templateQuanLy.Album
{
    public partial class wucQuanLyHinhAnh : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
            NGUOIDUNG a = new NGUOIDUNG();
            a.MaNguoiDung  = 1;
            Session["NguoiDung"] = a;

            if (Request.QueryString["id"] != null)
            {
                //lay ma
                int mahinhanh = int.Parse(Request.QueryString["id"]);

                //lay thong tin va load len cac textbox
                BUSHinhAnh BUSHinhAnh = new BUSHinhAnh();
                HINHANH lpDTO = BUSHinhAnh.TimKiem(mahinhanh);
                txtmahinhanh.Text = Convert.ToString(lpDTO.MaHinhAnh  );
                txthinhanh.Text = lpDTO.DuongDan ;
                txtmaalbum.Text = lpDTO.MaAlbum.ToString() ;
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                HINHANH lpDTO = new HINHANH();
                lpDTO.MaHinhAnh  = int.Parse(txtmahinhanh.Text);
                lpDTO.DuongDan  = txthinhanh.Text;
                lpDTO.MaAlbum  = int.Parse(txtmaalbum.Text);

                //Goi ham cap nhat
                BUSHinhAnh BUSHinhAnh = new BUSHinhAnh();
                if (BUSHinhAnh.CapNhat(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
                    lbThongBao.Visible = true;
                    //Response.Redirect("LoaiMatHang.aspx");
                }
                else
                {
                    lbThongBao.Text = "Cập Nhật Không Thành Công";
                    lbThongBao.Visible = true;
                }
            }

            catch 
            {
                lbThongBao.Text = "Cập nhật Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                HINHANH lpDTO = new HINHANH();
                lpDTO.MaHinhAnh = int.Parse(txtmahinhanh.Text);
                lpDTO.DuongDan = txthinhanh.Text;
                lpDTO.MaAlbum = int.Parse(txtmaalbum.Text);


                //Goi ham cap nhat
                BUSHinhAnh BUSHinhAnh = new BUSHinhAnh();
                if (BUSHinhAnh.Them(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    //Response.Redirect("LoaiMatHang.aspx");
                }
                else
                {
                    lbThongBao.Text = "Thêm Không Thành Công";
                    lbThongBao.Visible = true;
                }
            }

            catch 
            {
                lbThongBao.Text = "Thêm Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                int mahinhanh = int.Parse(Request.QueryString["id"]);

                //xac nhan truoc khi xoa
                DialogResult rs = MessageBox.Show("Bạn có chắc là muốn xoá Hoạt Động <" + mahinhanh + "> không?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    //Goi ham xoa
                    BUSHinhAnh BUSHinhAnh = new BUSHinhAnh();
                    if (BUSHinhAnh.Xoa(mahinhanh) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("HoatDong.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Xóa Không Thành Công";
                        lbThongBao.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("HoatDong.aspx");
                }
            }

            catch 
            {
                lbThongBao.Text = "Xoa Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        #endregion
    }
}