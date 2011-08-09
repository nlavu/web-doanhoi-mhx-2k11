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
    public partial class wucQuanLyLoaiHoatDong : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    //lay ma
                    int mahoatdong = int.Parse(Request.QueryString["id"]);

                    //lay thong tin va load len cac textbox
                    BUSLoaiHoatDong BUSLoaiHoatDong = new BUSLoaiHoatDong();
                    LOAIHOATDONG lpDTO = BUSLoaiHoatDong.TimKiem(mahoatdong);
                    txtmaloaihoatdong.Text = lpDTO.MaLoaiHoatDong.ToString();
                    txttenloaihoatdong.Text = lpDTO.TenLoaiHoatDong;
                }
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                LOAIHOATDONG lpDTO = new LOAIHOATDONG();
                lpDTO.MaLoaiHoatDong  = int.Parse(txtmaloaihoatdong.Text);
                lpDTO.TenLoaiHoatDong  = txttenloaihoatdong.Text;

                //Goi ham cap nhat
                BUSLoaiHoatDong BUSLoaiHoatDong = new BUSLoaiHoatDong();
                if (BUSLoaiHoatDong.CapNhat(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
                    lbThongBao.Visible = true;

                    Response.Redirect("~/administration/LoaiHoatDong.aspx?id="  + txtmaloaihoatdong.Text);
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
                LOAIHOATDONG lpDTO = new LOAIHOATDONG();
                lpDTO.MaLoaiHoatDong = 1;
                lpDTO.TenLoaiHoatDong = txttenloaihoatdong.Text;

                //Goi ham cap nhat
                BUSLoaiHoatDong BUSLoaiHoatDong = new BUSLoaiHoatDong();
                if (BUSLoaiHoatDong.Them(lpDTO) == 1)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("~/administration/LoaiHoatDong.aspx");
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
                int mahoatdong = int.Parse(Request.QueryString["id"]);

                //xac nhan truoc khi xoa
               
                    BUSLoaiHoatDong BUSLoaiHoatDong = new BUSLoaiHoatDong();
                    if (BUSLoaiHoatDong.Xoa(mahoatdong) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("~/administration/LoaiHoatDong.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Xóa Không Thành Công";
                        lbThongBao.Visible = true;
                    }
               
            }

            catch 
            {
                lbThongBao.Text = "Xóa Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        #endregion
    }
}