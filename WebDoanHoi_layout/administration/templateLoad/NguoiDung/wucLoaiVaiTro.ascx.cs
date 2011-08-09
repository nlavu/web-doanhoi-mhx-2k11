using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;

namespace WebDoanHoi_layout.administration.templateLoad.NguoiDung
{
    public partial class wucLoaiVaiTro : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Loại Vai Trò Người Dùng";

            if (!IsPostBack)
            {
                int soDong = LoadLoaiVaiTro();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewLoaiVaiTro.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewLoaiVaiTro.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadLoaiVaiTro()
        {
            List<LOAIVAITRO> lt = new List<LOAIVAITRO>();

            BUSLoaiVaiTro BUSLoaiVaiTro = new BUSLoaiVaiTro();

            lt = BUSLoaiVaiTro.SelectLOAIVAITROsAll();
            if (lt.Count > 0)
            {
                this.GridViewLoaiVaiTro.DataSource = lt;
                GridViewLoaiVaiTro.DataBind();
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
            this.GridViewLoaiVaiTro.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadLoaiVaiTro();
            FilterSTT(SoDong, GridViewLoaiVaiTro.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewLoaiVaiTro_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewLoaiVaiTro.PageIndex = e.NewPageIndex;
            int SoDong = LoadLoaiVaiTro();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
    }
}