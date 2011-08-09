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
using System.Web.UI.MobileControls;

namespace WebDoanHoi_layout.wuc
{
    public partial class wucHoatDong : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Hoạt Động";

            if (!IsPostBack)
            {
                DropDownListPaging.SelectedIndex = 1;   // Set số dòng mặc định là 10
                int soDong = LoadHoatDong();
                FilterSTT(soDong, 0, int.Parse(DropDownListPaging.SelectedValue));

                LoadLoaiHoatDong();
                ddlLoaiHoatDong.SelectedIndex = 0;
                ddlLoaiHoatDong_SelectedIndexChanged(sender,  e);
            }
            this.GridViewHoatDong.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewHoatDong.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadHoatDong()
        {
            List<HOATDONG> lt = new List<HOATDONG>();

            BUSHoatDong BUSHoatDong = new BUSHoatDong();

            lt = BUSHoatDong.SelectHOATDONGsAll();
            if (lt.Count > 0)
            {
                this.GridViewHoatDong.DataSource = lt;
                GridViewHoatDong.DataBind();
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

        public void LoadLoaiHoatDong()
        {
            BUSLoaiHoatDong BUSLoaiHoatDong = new BUSLoaiHoatDong();
            List<LOAIHOATDONG> LOAIHOATDONG = BUSLoaiHoatDong.SelectLOAIHOATDONGsAll();
            ddlLoaiHoatDong.DataSource = LOAIHOATDONG;
            ddlLoaiHoatDong.DataTextField = "TenLoaiHoatDong";
            ddlLoaiHoatDong.DataValueField = "MaLoaiHoatDong";
            ddlLoaiHoatDong.DataBind();
        }

        //Chon Phan Trang Theo y nguoi dung: 5, 10, 15, 20,..
        protected void DropDownListPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewHoatDong.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadHoatDong();
            FilterSTT(SoDong, GridViewHoatDong.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewHoatDong_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewHoatDong.PageIndex = e.NewPageIndex;
            int SoDong = LoadHoatDong();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        protected void ddlLoaiHoatDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLoaiHoatDong.SelectedIndex != -1)
            {
                int iMaLoai = int.Parse(ddlLoaiHoatDong.SelectedValue);
                BUSLoaiHoatDong busLoaiHD = new BUSLoaiHoatDong();
                LOAIHOATDONG LoaiTatCa = busLoaiHD.TimKiem("Tất Cả");
                if (LoaiTatCa != null && iMaLoai == LoaiTatCa.MaLoaiHoatDong)
                {
                    int soDong = LoadHoatDong();
                    FilterSTT(soDong, 0, int.Parse(DropDownListPaging.SelectedValue));
                }
                else
                {
                    //Lấy hoạt động theo mã loại
                    BUSHoatDong busHoatDong = new BUSHoatDong();
                    List<HOATDONG> dsHoatDong = busHoatDong.LayHoatDongTheoLoai(iMaLoai);
                    GridViewHoatDong.DataSource = dsHoatDong;
                    GridViewHoatDong.AutoGenerateColumns = false;
                    GridViewHoatDong.DataBind();
                    this.FilterSTT(dsHoatDong.Count, GridViewHoatDong.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
                }
            }
        }
        protected void GridViewHoatDong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
}
}