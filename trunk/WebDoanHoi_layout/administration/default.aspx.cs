using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BUSAuction;
using DTOAuction;
using System.Collections.Generic;


namespace WebDoanHoi_layout.administration
{
    public partial class index : System.Web.UI.Page
    {
        private string[] redirect = {/*0,1,2*/"~/administration/BaiViet.aspx", "~/administration/HoatDong.aspx", "~/administration/Album.aspx",
                                     /*3,4,5*/"~/administration/BaiHat.aspx", "~/administration/CauHoiKhaoSat.aspx", "~/administration/ChuyenMuc.aspx",
                                     /*6,7,8*/"~/administration/DangKyHoatDong.aspx", "~/administration/DangKyMuonPhong.aspx","~/administration/DapAnKhaoSat.aspx",
                                     /*9,10,11*/"~/administration/GioiThieu.aspx","~/administration/HeThongToChuc.aspx","~/administration/HinhAnh.aspx",
                                     /*12,13,14*/"~/administration/KhaoSat.aspx","~/administration/LichLamViec.aspx","~/administration/LoaiBaiViet.aspx",
                                     /*15,16,17*/"~/administration/LoaiHoatDong.aspx","~/administration/LoaiVaiTro.aspx","~/administration/NguoiDung.aspx",
                                     /*18,19,20*/"~/administration/TapTinBaiViet.aspx","~/administration/TapTinThongBao.aspx","~/administration/ThongBao.aspx"};
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Redirect("DangNhap.aspx");
                int id;
                if (Request.QueryString["id"] != null)
                {
                    id = int.Parse(Request.QueryString["id"]);
                }
                else
                {
                    id = 0;
                }
                if (HttpContext.Current.Session["QUANLY"] != null)
                {
                    Response.Redirect(redirect[id]);
                }
            }
        }
        //protected void btDangNhap_Click(object sender, EventArgs e)
        //{
        //    int id;
        //    if (Request.QueryString["id"] != null)
        //    {
        //        id = int.Parse(Request.QueryString["id"]);
        //    }
        //    else
        //    {
        //        id = 0;
        //    }
        //    BUSNguoiDung BUSNguoiDung = new BUSNguoiDung();
        //    NGUOIDUNG NGUOIDUNG = new NGUOIDUNG();

        //    NGUOIDUNG = BUSNguoiDung.TimKiem(txtusername.Text, txtpassword.Text);

        //    if (NGUOIDUNG != null)
        //    {
        //        if (NGUOIDUNG.MaVaiTro == 3)
        //        {
        //            Session["QUANLY"] = NGUOIDUNG;
        //            Response.Redirect(redirect[id]);
        //        }
        //        else
        //        {
        //            LabelError.Text = "Moi ban dang nhap lai!";
        //        }
        //    }
        //    else
        //    {
        //        LabelError.Text = "Moi ban dang nhap lai!";
        //    }

        //}

        protected void LoginAdmin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            int id;
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
            }
            else
            {
                id = 0;
            }
            BUSNguoiDung BUSNguoiDung = new BUSNguoiDung();
            NGUOIDUNG NGUOIDUNG = new NGUOIDUNG();

            NGUOIDUNG = BUSNguoiDung.TimKiem(LoginAdmin.UserName, LoginAdmin.Password);

            if (NGUOIDUNG != null)
            {
                if (NGUOIDUNG.MaVaiTro == 3)
                {
                    Application.Lock();
                    HttpContext.Current.Session["QUANLY"] = NGUOIDUNG.Username;
                    Application.UnLock();
                    Response.Redirect(redirect[id]);
                }                   
                else
                {
                    if (NGUOIDUNG.MaVaiTro == 4)
                    {
                        Application.Lock();
                        HttpContext.Current.Session["ADMIN"] = NGUOIDUNG.Username;
                        Application.UnLock();
                        Response.Redirect(redirect[id]);
                    }
                    else
                    {
                        LoginAdmin.InstructionText = "Bạn phải đăng nhập bằng tài khoảng Quản Lý!";
                    }
                    
                }
            }
            else
            {
                LoginAdmin.InstructionText = "Bạn phải đăng nhập bằng tài khoảng Quản Lý!";
            }

        }
    }
}
