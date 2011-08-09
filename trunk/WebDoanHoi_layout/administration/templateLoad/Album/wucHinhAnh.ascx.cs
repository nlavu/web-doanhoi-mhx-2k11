using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;

namespace WebDoanHoi_layout.administration.templateLoad.Album
{
    public partial class wucHinhAnh : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách HinhAnh";

            if (!IsPostBack)
            {
                int soDong = LoadHinhAnh();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewHinhAnh.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewHinhAnh.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadHinhAnh()
        {
            List<HINHANH> lt = new List<HINHANH>();

            BUSHinhAnh BUSHinhAnh = new BUSHinhAnh();

            lt = BUSHinhAnh.SelectHINHANHsAll();
            if (lt.Count > 0)
            {
                this.GridViewHinhAnh.DataSource = lt;
                GridViewHinhAnh.DataBind();
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
            this.GridViewHinhAnh.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadHinhAnh();
            FilterSTT(SoDong, GridViewHinhAnh.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewHinhAnh_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewHinhAnh.PageIndex = e.NewPageIndex;
            int SoDong = LoadHinhAnh();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
    }
}