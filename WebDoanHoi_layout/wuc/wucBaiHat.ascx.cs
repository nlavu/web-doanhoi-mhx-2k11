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

namespace WebDoanHoi_layout.wuc
{
    public partial class wucBaiHat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //Do STT
        //public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        //{
        //    int stt = 0;
        //    for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
        //    {
        //        GridViewBaiHat.Rows[stt].Cells[0].Text = (i + 1).ToString();
        //        stt += 1;
        //    }
        //}
        ////Load
        //public int LoadBAIHAT()
        //{
        //    List<BAIHAT> lt = new List<BAIHAT>();

        //    BUSBaiHat BUSBaiHat = new BUSBaiHat();

        //    lt = BUSBaiHat.SelectBAIHATsAll();
        //    if (lt.Count > 0)
        //    {
        //        this.GridViewBaiHat.DataSource = lt;
        //        GridViewBaiHat.DataBind();
        //        PanelDanhSach.Visible = true;
        //    }
        //    return lt.Count;
        //}

        ////Chon Phan Trang Theo y nguoi dung: 5, 10, 15, 20,..
        //protected void DropDownListPaging_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.GridViewBaiHat.PageSize = int.Parse(DropDownListPaging.SelectedValue);
        //    int SoDong = LoadBAIHAT();
        //    FilterSTT(SoDong, GridViewBaiHat.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        //}
        ////Chon trang NEXT
        //protected void GridViewBaiHat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridViewBaiHat.PageIndex = e.NewPageIndex;
        //    int SoDong = LoadBAIHAT();
        //    FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        //}
    }
}