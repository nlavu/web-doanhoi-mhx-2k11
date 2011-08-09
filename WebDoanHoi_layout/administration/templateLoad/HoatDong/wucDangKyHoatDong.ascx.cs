using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;

namespace WebDoanHoi_layout.administration.templateLoad.HoatDong
{
    public partial class wucDangKyHoatDong : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Đăng Ký Hoạt Động";

            if (!IsPostBack)
            {
                int soDong = LoadDangKyHoatDong();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewDangKyHoatDong.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewDangKyHoatDong.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadDangKyHoatDong()
        {
            List<DANGKYHOATDONG_getallResult> lt = new List<DANGKYHOATDONG_getallResult>();

            BUSDangKyHoatDong BUSDangKyHoatDong = new BUSDangKyHoatDong();

            lt = BUSDangKyHoatDong.SelectDANGKYHOATDONGsAll();
            if (lt.Count > 0)
            {
                this.GridViewDangKyHoatDong.DataSource = lt;
                GridViewDangKyHoatDong.DataBind();
                PanelDanhSach.Visible = true;
                PanelMessage.Visible = false;
                return lt.Count;
            }
            else
            {
                PanelDanhSach.Visible = false;
                PanelMessage.Visible = true;
                return 0;
            }
        }

        //Chon Phan Trang Theo y nguoi dung: 5, 10, 15, 20,..
        protected void DropDownListPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewDangKyHoatDong.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadDangKyHoatDong();
            FilterSTT(SoDong, GridViewDangKyHoatDong.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewDangKyHoatDong_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewDangKyHoatDong.PageIndex = e.NewPageIndex;
            int SoDong = LoadDangKyHoatDong();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
    }
}