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
    public partial class wucQuanLyNguoiDung : System.Web.UI.UserControl
    {
        #region Ham Chung
        int MaNguoiDung;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    //lay ma
                    MaNguoiDung = int.Parse(Request.QueryString["id"]);

                    //lay thong tin va load len cac textbox
                    BUSNguoiDung BUSNguoiDung = new BUSNguoiDung();
                    NGUOIDUNG lpDTO = BUSNguoiDung.TimKiem(MaNguoiDung);
                    txtmasinhvien.Text = lpDTO.Username;
                    txtpass.Text = lpDTO.Password;
                    txthoten.Text = lpDTO.HoTen;
                    txtemail.Text = lpDTO.Email;
                    txtvaitro.Text = lpDTO.MaVaiTro.ToString();
                }
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                NGUOIDUNG lpDTO = new NGUOIDUNG();
                lpDTO.MaNguoiDung  = MaNguoiDung;
                lpDTO.Username = txtmasinhvien.Text;
                lpDTO.Password  = txtpass.Text;
                lpDTO.HoTen  = txthoten.Text;
                lpDTO.Email  = txtemail.Text;
                lpDTO.MaVaiTro = int.Parse(txtvaitro.Text);

                //Goi ham cap nhat
                BUSNguoiDung BUSNguoiDung = new BUSNguoiDung();
                if (txtpass.ReadOnly)
                {
                    if (BUSNguoiDung.CapNhatWhitOutPass(lpDTO) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Cập Nhật Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("NguoiDung.aspx?id=" + MaNguoiDung.ToString());
                    }
                    else
                    {
                        lbThongBao.Text = "Cập Nhật Không Thành Công";
                        lbThongBao.Visible = true;
                    }
                }
                else
                {
                    if (BUSNguoiDung.CapNhat(lpDTO) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Cập Nhật Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("NguoiDung.aspx?id=" + MaNguoiDung.ToString());
                    }
                    else
                    {
                        lbThongBao.Text = "Cập Nhật Không Thành Công";
                        lbThongBao.Visible = true;
                    }
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
                NGUOIDUNG lpDTO = new NGUOIDUNG();
             //   lpDTO.MaNguoiDung = 0;
                lpDTO.Username = txtmasinhvien.Text;
                lpDTO.Password = txtpass.Text;
                lpDTO.HoTen = txthoten.Text;
                lpDTO.Email = txtemail.Text;
                lpDTO.MaVaiTro = int.Parse(txtvaitro.Text);

                //Goi ham cap nhat
                BUSNguoiDung BUSNguoiDung = new BUSNguoiDung();
                if (BUSNguoiDung.Them(lpDTO) == 1)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("NguoiDung.aspx");
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
                BUSNguoiDung BUSNguoiDung = new BUSNguoiDung();
                NGUOIDUNG lpDTO = BUSNguoiDung.TimKiem(MaNguoiDung);

                    //Goi ham xoa
                    if (BUSNguoiDung.Xoa(MaNguoiDung) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("NguoiDung.aspx");
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (txtpass.ReadOnly)
            {
                txtpass.ReadOnly = false;
                txtpass.Enabled = true;
            }
        }

        protected void ThemPass_Click(object sender, EventArgs e)
        {
            txtpass.Enabled = true;
            txtpass.ReadOnly = false;
            lkUpdatePass.Visible = false;
            lkThemPass.Visible = false;
            btnCapNhat.Visible = false;
        }
    }
}