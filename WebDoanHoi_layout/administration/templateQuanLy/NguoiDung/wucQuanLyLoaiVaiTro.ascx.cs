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

namespace WebDoanHoi_layout.administration.templateQuanLy.NguoiDung
{
    public partial class wucQuanLyLoaiVaiTro : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
    if (!IsPostBack)
    {
        if (Request.QueryString["id"] != null)
        {
            //lay ma
            int mahoatdong = int.Parse(Request.QueryString["id"]);

            //lay thong tin va load len cac textbox
            BUSLoaiVaiTro BUSLoaiVaiTro = new BUSLoaiVaiTro();
            LOAIVAITRO lpDTO = BUSLoaiVaiTro.TimKiem(mahoatdong);
            txtmaloaivaitro.Text = lpDTO.MaLoaiVaiTro.ToString();
            txttenloaivaitro.Text = lpDTO.TenLoaiVaiTro;
        }
    }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                LOAIVAITRO lpDTO = new LOAIVAITRO();
                lpDTO.MaLoaiVaiTro  = int.Parse(txtmaloaivaitro.Text);
                lpDTO.TenLoaiVaiTro  = txttenloaivaitro.Text;

                //Goi ham cap nhat
                BUSLoaiVaiTro BUSLoaiVaiTro = new BUSLoaiVaiTro();
                if (BUSLoaiVaiTro.CapNhat(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("LoaiVaiTro.aspx?id=" + txtmaloaivaitro.Text);
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
                LOAIVAITRO lpDTO = new LOAIVAITRO();
                lpDTO.MaLoaiVaiTro = 0;
                lpDTO.TenLoaiVaiTro = txttenloaivaitro.Text;

                //Goi ham cap nhat
                BUSLoaiVaiTro BUSLoaiVaiTro = new BUSLoaiVaiTro();
                if (BUSLoaiVaiTro.Them(lpDTO) == 1)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("LoaiVaiTro.aspx");
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
                DialogResult rs = MessageBox.Show("Bạn có chắc là muốn xoá Hoạt Động <" + mahoatdong + "> không?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    //Goi ham xoa
                    BUSLoaiVaiTro BUSLoaiVaiTro = new BUSLoaiVaiTro();
                    if (BUSLoaiVaiTro.Xoa(mahoatdong) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("LoaiVaiTro.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Xóa Không Thành Công";
                        lbThongBao.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("LoaiVaiTro.aspx");
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