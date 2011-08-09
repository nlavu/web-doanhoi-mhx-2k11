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
    public partial class wucDangNhap : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //HttpCookie cookie = Request.Cookies.Get("mainCookie");
                //if (cookie != null)
                //{
                //    String username = cookie.Values["username"];
                //    if (username != null && username != "")
                //    {
                //        PanelDangNhap.Visible = true;
                //        PanelDangXuat.Visible = false;
                //        PanelDangNhapSai.Visible = false;
                //    }
                //    else
                //    {
                //        PanelDangNhap.Visible = false;
                //        PanelDangXuat.Visible = true;
                //        PanelDangNhapSai.Visible = false;
                //        LoadSinhVien(username);
                //    }
                //}
                //else
                {
                    if (((NGUOIDUNG)Session["LOGIN"]) == null)
                    {
                        PanelDangNhap.Visible = true;
                        PanelDangXuat.Visible = false;
                        PanelDangNhapSai.Visible = false;
                    }
                    else
                    {
                        PanelDangNhap.Visible = false;
                        PanelDangXuat.Visible = true;
                        PanelDangNhapSai.Visible = false;
                        LoadSinhVien((NGUOIDUNG)Session["LOGIN"]);
                    }
                }
                
            }
        }
        protected void LoadSinhVien(NGUOIDUNG user)
        {
            hlhoten.Text = user.HoTen;
            hlhoten.NavigateUrl = "~/ThongTinCaNhan.aspx?id=" + user.MaNguoiDung.ToString();
            hlhoten.Visible = true;

            if (((NGUOIDUNG)Session["LOGIN"]).MaVaiTro == 1)
            {
                hlVaiTro.InnerText = "Hoạt Động";
                hlVaiTro.HRef = "~/HoatDong.aspx";
            }
            else if (((NGUOIDUNG)Session["LOGIN"]).MaVaiTro == 2)
            {
                hlVaiTro.InnerText = "Mượn Phòng";
                hlVaiTro.HRef = "~/MuonPhong.aspx";
            }
            else
            {
                hlVaiTro.InnerText = "Quản Lý";
                hlVaiTro.HRef = "~/administration/BaiViet.aspx";
            }
        }
        protected void btDangNhap_Click(object sender, EventArgs e)
        {
            BUSNguoiDung BUSNguoiDung = new BUSNguoiDung();
            NGUOIDUNG NGUOIDUNG = new NGUOIDUNG();
            NGUOIDUNG = BUSNguoiDung.TimKiem(txtusername.Text, txtpassword.Text);

            if (NGUOIDUNG != null)
            {
                //HttpCookie myCookie = new HttpCookie("mainCookie");
                //Response.Cookies.Remove("mainCookie");
                //Response.Cookies.Add(myCookie);
                //myCookie.Values.Add("username", NGUOIDUNG.Username);
                //myCookie.Values.Add("role", "");

                PanelDangNhap.Visible = false;
                PanelDangNhapSai.Visible = false;
                PanelDangXuat.Visible = true;

                Session["LOGIN"] = NGUOIDUNG;
                LoadSinhVien(NGUOIDUNG);
            }
            else
            {
                PanelDangNhap.Visible = false;
                PanelDangNhapSai.Visible = true;
                PanelDangXuat.Visible = false;
            }
        }
        protected void btDangXuat_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            PanelDangNhap.Visible = true;
            PanelDangXuat.Visible = false;
        }

        protected void btDangNhapLai_Click(object sender, EventArgs e)
        {
            PanelDangNhapSai.Visible = false;
            PanelDangNhap.Visible = true;
        }
    }
}