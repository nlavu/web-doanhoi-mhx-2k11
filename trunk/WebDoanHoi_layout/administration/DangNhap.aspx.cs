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
    public partial class DangNhap : System.Web.UI.Page
    {
        private string redirect = @"BaiViet.aspx";
        protected void LoginImageButton_Click(object sender, ImageClickEventArgs e)
        {
            
        }   

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["url"] != null && Request.QueryString["url"]!="")
                {
                    redirect = Request.QueryString["url"];
                }
                HttpCookie cookie = Request.Cookies.Get("myCookie");
                if (cookie != null)
                {
                    String username = cookie.Values["username"];
                    if (username != null && username != "")
                    {
                        Response.Redirect(redirect);
                    }
                }
                        
                
            }
        } 

        protected void LoginAdmin_Authenticate(object sender, AuthenticateEventArgs e)
        {
           
            BUSNguoiDung BUSNguoiDung = new BUSNguoiDung();
            NGUOIDUNG NGUOIDUNG = new NGUOIDUNG();

            NGUOIDUNG = BUSNguoiDung.TimKiem(LoginAdmin.UserName, LoginAdmin.Password);

            if (NGUOIDUNG != null)
            {
                if (NGUOIDUNG.LOAIVAITRO.TenLoaiVaiTro == "Quản Lý")
                {
                    HttpCookie myCookie = new HttpCookie("myCookie");
                    Response.Cookies.Remove("myCookie");
                    Response.Cookies.Add(myCookie);
                    myCookie.Values.Add("username", NGUOIDUNG.Username);
                    myCookie.Values.Add("role", "quanly");
                   
                    if (LoginAdmin.RememberMeSet == true)
                    {
                        DateTime dtExpiry = DateTime.Now.AddDays(3);
                        Response.Cookies["myCookie"].Expires = dtExpiry;
                    }
                    else
                    {
                        DateTime dtExpiry = DateTime.Now.AddMinutes(20);
                        Response.Cookies["myCookie"].Expires = dtExpiry;
                    }
                    Response.Redirect(redirect);
                }
                else
                {
                    if (NGUOIDUNG.LOAIVAITRO.TenLoaiVaiTro == "Admin" || NGUOIDUNG.LOAIVAITRO.TenLoaiVaiTro == "Quản lý")
                    {
                        HttpCookie myCookie = new HttpCookie("myCookie");
                        Response.Cookies.Remove("myCookie");
                        Response.Cookies.Add(myCookie);
                        myCookie.Values.Add("username", NGUOIDUNG.Username);
                        myCookie.Values.Add("role", "admin");
                        if (LoginAdmin.RememberMeSet == true)
                        {
                            DateTime dtExpiry = DateTime.Now.AddDays(3);
                            Response.Cookies["myCookie"].Expires = dtExpiry;
                        }
                        else
                        {
                            DateTime dtExpiry = DateTime.Now.AddMinutes(20);
                            Response.Cookies["myCookie"].Expires = dtExpiry;
                        }
                        Response.Redirect(redirect);
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