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
    public partial class wucLoaiHoatDong : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Danh Sách Loại Hoạt Động";

        if (!IsPostBack)
        {
            int soDong = LoadLoaiHoatDong();
            FilterSTT(soDong, 0, 10);
        }
        this.GridViewLoaiHoatDong.HeaderStyle.CssClass = "headerstyle";
    }
    //Do STT
    public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
    {
        int stt = 0;
        for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
        {
            GridViewLoaiHoatDong.Rows[stt].Cells[0].Text = (i + 1).ToString();
            stt += 1;
        }
    }
    //Load
    public int LoadLoaiHoatDong()
    {
        List<LOAIHOATDONG> lt = new List<LOAIHOATDONG>();

        BUSLoaiHoatDong BUSLoaiHoatDong = new BUSLoaiHoatDong();

        lt = BUSLoaiHoatDong.SelectLOAIHOATDONGsAll ();
        if (lt.Count > 0)
        {
            this.GridViewLoaiHoatDong.DataSource = lt;
            GridViewLoaiHoatDong.DataBind();
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
        this.GridViewLoaiHoatDong.PageSize = int.Parse(DropDownListPaging.SelectedValue);
        int SoDong = LoadLoaiHoatDong();
        FilterSTT(SoDong, GridViewLoaiHoatDong.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
    }
    //Chon trang NEXT
    protected void GridViewLoaiHoatDong_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewLoaiHoatDong.PageIndex = e.NewPageIndex;
        int SoDong = LoadLoaiHoatDong();
        FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
    }
    protected void GridViewLoaiHoatDong_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Xoa")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Xoa(id);
        }
    }
    protected void Xoa(int id)
    {
        try
        {
            //xac nhan truoc khi xoa
            BUSLoaiHoatDong bus = new BUSLoaiHoatDong();
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