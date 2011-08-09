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

namespace WebDoanHoi_layout.administration.templateLoad.KhaoSat
{
    public partial class wucCauHoiKhaoSat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Bài Gửi";

            if (!IsPostBack)
            {
                int soDong = LoadCauHoiKhaoSat();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewCauHoiKhaoSat.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewCauHoiKhaoSat.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadCauHoiKhaoSat()
        {
            List<CAUHOIKHAOSAT> lt = new List<CAUHOIKHAOSAT>();

            BUSCauHoiKhaoSat BUSCauHoiKhaoSat = new BUSCauHoiKhaoSat();

            lt = BUSCauHoiKhaoSat.SelectCAUHOIKHAOSATsAll();
            if (lt.Count > 0)
            {
                this.GridViewCauHoiKhaoSat.DataSource = lt;
                GridViewCauHoiKhaoSat.DataBind();
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
            this.GridViewCauHoiKhaoSat.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadCauHoiKhaoSat();
            FilterSTT(SoDong, GridViewCauHoiKhaoSat.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewCauHoiKhaoSat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCauHoiKhaoSat.PageIndex = e.NewPageIndex;
            int SoDong = LoadCauHoiKhaoSat();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        #region tin-xoa
        protected void GridViewCauHoiKhaoSat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XoaCauHoiKhaoSat")
            {
                int id = Convert.ToInt32(e.CommandArgument);

            
                XoaCauHoiKhaoSat(id);
            }
        }
        protected void XoaCauHoiKhaoSat(int maCauHoi)
        {
            try
            {

                //xac nhan truoc khi xoa
             
        
                    //Goi ham xoa
                    BUSCauHoiKhaoSat BUSCauHoiKhaoSat = new BUSCauHoiKhaoSat();
                    if (BUSCauHoiKhaoSat.Xoa(maCauHoi) == 0)
                    {
                        //Thong bao                        
                        Response.Redirect("CauHoiKhaoSat.aspx");
                    }
                 
            }

            catch
            {
            }
        }
        #endregion
    }
}