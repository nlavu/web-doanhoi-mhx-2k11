using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;
using System.IO;
using System.Windows.Forms;

namespace WebDoanHoi_layout.administration.templateLoad.LichLamViec
{
    public partial class wucLichLamViec : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Lịch Làm Việc";

            if (!IsPostBack)
            {
                int soDong = LoadTAPTINBAIVIET();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewTAPTINBAIVIET.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewTAPTINBAIVIET.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadTAPTINBAIVIET()
        {
            List<TAPTINBAIVIET> lt = new List<TAPTINBAIVIET>();

            BUSTapTinBaiViet BUSTapTinBaiViet = new BUSTapTinBaiViet();

            lt = BUSTapTinBaiViet.getLichLamViec();
            
            if (lt.Count > 0)
            {
                this.GridViewTAPTINBAIVIET.DataSource = lt;
                GridViewTAPTINBAIVIET.DataBind();
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
            this.GridViewTAPTINBAIVIET.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadTAPTINBAIVIET();
            FilterSTT(SoDong, GridViewTAPTINBAIVIET.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewTAPTINBAIVIET_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTAPTINBAIVIET.PageIndex = e.NewPageIndex;
            int SoDong = LoadTAPTINBAIVIET();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }

        protected void XoaFile_Click(string tenTapTin)
        {
                DialogResult rs = MessageBox.Show("Bạn có chắc là muốn xoá lịch làm việc " + tenTapTin + " không?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    //Goi ham xoa
                    BUSTapTinBaiViet busTapTinBaiViet = new BUSTapTinBaiViet();
                    TAPTINBAIVIET ttbv = busTapTinBaiViet.TimKiemTenTapTin(tenTapTin);
                    XoaFile(ttbv.DuongDan);
                    busTapTinBaiViet.Xoa(ttbv.MaTapTin);
                    Response.Redirect("LichLamViec.aspx");
                }
                else
                {
                    Response.Redirect("LichLamViec.aspx");
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

        protected void GridViewTAPTINBAIVIET_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XoaFile")
            {

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);
                
                List<TAPTINBAIVIET> lt = new List<TAPTINBAIVIET>();

                BUSTapTinBaiViet BUSTapTinBaiViet = new BUSTapTinBaiViet();
                lt = BUSTapTinBaiViet.getLichLamViec();
                

                XoaFile_Click(lt[index].TenTapTin);
            }
        }
    }
}