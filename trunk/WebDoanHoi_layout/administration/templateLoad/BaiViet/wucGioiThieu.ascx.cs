using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;
using System.Windows.Forms;

namespace WebDoanHoi_layout.administration.templateLoad.BaiViet
{
    public partial class wucGioiThieu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Bài Gửi";

            if (!IsPostBack)
            {
                int soDong = LoadGioiThieu();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewGioiThieu.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewGioiThieu.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadGioiThieu()
        {
            List<GIOITHIEU> lt = new List<GIOITHIEU>();

            BUSGioiThieu BUSGioiThieu = new BUSGioiThieu();

            lt = BUSGioiThieu.SelectGIOITHIEUsAll();
            if (lt.Count > 0)
            {
                this.GridViewGioiThieu.DataSource = lt;
                GridViewGioiThieu.DataBind();
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
            this.GridViewGioiThieu.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadGioiThieu();
            FilterSTT(SoDong, GridViewGioiThieu.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewGioiThieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewGioiThieu.PageIndex = e.NewPageIndex;
            int SoDong = LoadGioiThieu();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        #region tin-xoa
        protected void GridViewGioiThieu_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "XoaGioiThieu")
            {
                int id = Convert.ToInt32(e.CommandArgument); ;
                XoaGioiThieu(id);
            }
        }
        protected void XoaGioiThieu(int maBai)
        {
            try
            {

                //xac nhan truoc khi xoa               
                    BUSGioiThieu busGioiThieu = new BUSGioiThieu();
                    if (busGioiThieu.Xoa(maBai) == 0)
                    {
                        //Thong bao
                       Response.Redirect("GioiThieu.aspx");
                    }    
            }
            catch 
            {
            }
        }
        #endregion
    }
}