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
using System.IO;

namespace WebDoanHoi_layout.administration.templateLoad.BaiViet
{
    public partial class wucTapTinBaiViet : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Bài Gửi";

            if (!IsPostBack)
            {
                int soDong = LoadTapTin();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewTapTin.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewTapTin.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadTapTin()
        {
            List<TAPTINBAIVIET> lt = new List<TAPTINBAIVIET>();

            BUSTapTinBaiViet BUSTapTinBaiViet = new BUSTapTinBaiViet();

            lt = BUSTapTinBaiViet.SelectTAPTINBAIVIETsAll();
            if (lt.Count > 0)
            {
                this.GridViewTapTin.DataSource = lt;
                GridViewTapTin.DataBind();
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
            this.GridViewTapTin.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadTapTin();
            FilterSTT(SoDong, GridViewTapTin.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewTapTin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTapTin.PageIndex = e.NewPageIndex;
            int SoDong = LoadTapTin();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        #region tin-xoa
        protected void GridViewTapTin_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "XoaTapTin")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                XoaTapTin(id);
            }
        }
        protected void XoaTapTin(int maTapTin)
        {
            try
            {

                //xac nhan truoc khi xoa
               
                    BUSTapTinBaiViet bus = new BUSTapTinBaiViet();
                    TAPTINBAIVIET ttbv = bus.TimKiemMaTapTin(maTapTin);
                    XoaFile(ttbv.DuongDan);
                    if (bus.Xoa(maTapTin) == 0)
                    {
                        //Thong bao
                        
                        Response.Redirect("TapTinBaiViet.aspx");
                    }
                   
              
            }

            catch
            {
            }
        }
        void XoaFile(string duongDan)
        {
            FileInfo f = new FileInfo(MapPath(duongDan));
            if (f.Exists)
            {
                f.Delete();
            }
            else
            {

            }

        }
        #endregion

    }
}