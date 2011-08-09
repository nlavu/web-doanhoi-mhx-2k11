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


namespace WebDoanHoi_layout.administration.templateLoad.HoatDong
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
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
            }
            this.GridViewHoatDong.HeaderStyle.CssClass = "headerstyle";

        }

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

        protected void GridViewHoatDong_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewHoatDong.PageIndex = e.NewPageIndex;
            int SoDong = LoadHoatDong();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }

        protected void DropDownListPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewHoatDong.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadHoatDong();
            FilterSTT(SoDong, GridViewHoatDong.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        protected void GridViewTapTin_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "XoaHoatDong")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                XoaHoatDong(id);
            }
        }
        protected void XoaHoatDong(int id)
        {
            try
            {
                //xac nhan truoc khi xoa
                BUSHoatDong bus = new BUSHoatDong();               
                if (bus.Xoa(id) == 0)
                {
                    //Thong bao
                    Response.Redirect("HoatDong.aspx");
                }

            }

            catch
            {
            }
        }
    }
}