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
    public partial class wucThongBao : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Bài Gửi";

            if (!IsPostBack)
            {
                int soDong = LoadThongBao();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewThongBao.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewThongBao.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadThongBao()
        {
            List<THONGBAO_getall_newResult> lt = new List<THONGBAO_getall_newResult>();

            BUSThongBao BUSThongBao = new BUSThongBao();

            lt = BUSThongBao.SelectTHONGBAOsAll_New();
            if (lt.Count > 0)
            {
                this.GridViewThongBao.DataSource = lt;
                GridViewThongBao.DataBind();
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
            this.GridViewThongBao.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadThongBao();
            FilterSTT(SoDong, GridViewThongBao.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewThongBao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewThongBao.PageIndex = e.NewPageIndex;
            int SoDong = LoadThongBao();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
    }
}