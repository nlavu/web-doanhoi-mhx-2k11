using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;
using System.Windows.Forms;
//using Google.Picasa;

namespace WebDoanHoi_layout.administration.templateLoad.BaiViet
{
    public partial class wucChuyenMuc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<script>alert('load');</script>");
            Page.Title = "Danh Sách Bài Gửi";

            if (!IsPostBack)
            {
                int soDong = LoadChuyenMuc();
               FilterSTT(soDong, 0, 10);
            }
            this.GridViewChuyenMuc.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewChuyenMuc.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadChuyenMuc()
        {
            List<CHUYENMUC> lt = new List<CHUYENMUC>();

            BUSChuyenMuc BUSChuyenMuc = new BUSChuyenMuc();

            lt = BUSChuyenMuc.SelectCHUYENMUCsAll();
            Response.Write("<script>alert('hello');</script>");
            if (lt != null || lt.Count > 0)
            {
                this.GridViewChuyenMuc.DataSource = lt;
                GridViewChuyenMuc.DataBind();
                UpdatePanel1.Visible = true;
                PanelMessage.Visible = false;
                return lt.Count;
            }
            else
            {
                UpdatePanel1.Visible = false;
                PanelMessage.Visible = true;
                return 0;
            }
            //return 0;
        }

        //Chon Phan Trang Theo y nguoi dung: 5, 10, 15, 20,..
        protected void DropDownListPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewChuyenMuc.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadChuyenMuc();
            FilterSTT(SoDong, GridViewChuyenMuc.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewChuyenMuc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewChuyenMuc.PageIndex = e.NewPageIndex;
            int SoDong = LoadChuyenMuc();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        #region tin-xoa
        protected void GridViewChuyenMuc_RowCommand(object sender, GridViewCommandEventArgs e)
        {          

            if (e.CommandName == "XoaChuyenMuc")
            {
              int id = Convert.ToInt32(e.CommandArgument); 
                
                XoaChuyenMuc(id);
            }
        }
        protected void XoaChuyenMuc(int maChuyenMuc)
        {
            try
            {

                //xac nhan truoc khi xoa

                BUSBaiViet busBaiViet = new BUSBaiViet();
                List<BAIVIET> lstBaiViet = busBaiViet.LayDSBaiVietTheoChuyenMuc(maChuyenMuc);
                if (lstBaiViet != null)
                {
                    foreach (BAIVIET bv in lstBaiViet)
                    {
                        BUSTapTinBaiViet busTapTin = new BUSTapTinBaiViet();
                        List<TAPTINBAIVIET> lstTapTin = busTapTin.TimKiemMaBaiViet(bv.MaBaiViet);
                        if (lstTapTin != null)
                        {
                            foreach (TAPTINBAIVIET taptin in lstTapTin)
                            {
                                busTapTin.Xoa(taptin.MaTapTin);
                            }
                        }

                        busBaiViet.Xoa(bv.MaBaiViet);
                    }
                }
              
                    BUSChuyenMuc busChuyenMuc = new BUSChuyenMuc();
                    if (busChuyenMuc.Xoa(maChuyenMuc) == 0)
                    {
                        //Thong bao
                        
                        Response.Redirect("ChuyenMuc.aspx");
                    }
                   
            }

            catch 
            {
            }
        }
        #endregion

    }
}