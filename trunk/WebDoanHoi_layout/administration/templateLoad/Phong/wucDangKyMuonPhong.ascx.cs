using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;

namespace WebDoanHoi_layout.administration.templateLoad.Phong
{
    public partial class wucDangKyMuonPhong : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Bài Gửi";

            if (!IsPostBack)
            {
                int soDong = LoadDangKyMuonPhong();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewDangKyMuonPhong.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewDangKyMuonPhong.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadDangKyMuonPhong()
        {
            List<DANGKYMUONPHONG> lt = new List<DANGKYMUONPHONG>();

            BUSDangKyMuonPhong BUSDangKyMuonPhong = new BUSDangKyMuonPhong();

            lt = BUSDangKyMuonPhong.SelectDANGKYMUONPHONGsAll();
            if (lt.Count > 0)
            {
                this.GridViewDangKyMuonPhong.DataSource = lt;
                GridViewDangKyMuonPhong.DataBind();
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
            this.GridViewDangKyMuonPhong.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadDangKyMuonPhong();
            FilterSTT(SoDong, GridViewDangKyMuonPhong.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewDangKyMuonPhong_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewDangKyMuonPhong.PageIndex = e.NewPageIndex;
            int SoDong = LoadDangKyMuonPhong();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
    }
}