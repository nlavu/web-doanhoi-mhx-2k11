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

namespace WebDoanHoi_layout.administration.templateLoad.GopY
{
    public partial class wucGopY : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Góp Ý";

            if (!IsPostBack)
            {
                int soDong = LoadGopY();
               
                //                 if (Request.QueryString["id"] != null)
                //                 {
                //                     for (int i = 0; i < ((List<BAIVIET_getall_newResult>)this.GridViewBaiViet.DataSource).Count; i++)
                //                     {
                //                         if (((List<BAIVIET_getall_newResult>)this.GridViewBaiViet.DataSource)[i].MaBaiViet.ToString() == Request.QueryString["id"].ToString())
                //                         {
                //                            // this.GridViewBaiViet.PageIndex = i / this.GridViewBaiViet.PageSize;
                //                             this.GridViewBaiViet.DataBind();
                //                            // this.GridViewBaiViet.Rows[i].CssClass = "selectedrow";
                //                             break;
                //                         }
                //                     }
                //                 }

                // FilterSTT(soDong, this.GridViewBaiViet.PageIndex, 10);

            }
            this.GridViewGopY.HeaderStyle.CssClass = "headerstyle";
            int maGopY;
            if (int.TryParse(Request.QueryString["id"], out maGopY))
            {
                BUSGopY busGopY = new BUSGopY();
                GOPY gopy = new GOPY();
                gopy = busGopY.LayGopYTheoMa(maGopY);
                
                txtTieuDe.Text = gopy.TieuDe;
              
                txtNoiDung.Text = gopy.NoiDungGopY;
            }
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewGopY.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        ////Load
        //private static int SortByDate(BAIVIET_getall_newResult rs1, BAIVIET_getall_newResult rs2)
        //{
        //    if (rs1.NgayDang > rs2.NgayDang)
        //    {
        //        return -1;
        //    }
        //    if (rs1.NgayDang == rs2.NgayDang)
        //        return 0;
        //    return 1;
        //}
        public int LoadGopY()
        {
            BUSGopY gopY = new BUSGopY();
            List<GOPY> dsGopY = new List<GOPY>();
            dsGopY = gopY.LayDSGopY();

            if (dsGopY.Count > 0)
            {
                //lt.Sort(SortByDate);
                this.GridViewGopY.DataSource = dsGopY;
                GridViewGopY.DataBind();
                PanelDanhSach.Visible = true;
                PanelMessage.Visible = false;


                //                 for (int i = 0; i < lt.Count; i++)
                //                 {
                //                     GridViewBaiViet.Rows[i].Cells[4].Text = BUSLoaiBaiViet.TimKiem((int)lt[i].MaLoaiBaiViet).TenLoaiBaiViet;
                //                 }
                return dsGopY.Count;
            }
            else
            {
                PanelDanhSach.Visible = false;
                PanelMessage.Visible = true;
                return 0;
            }
        }

        ////Chon Phan Trang Theo y nguoi dung: 5, 10, 15, 20,..
        protected void DropDownListPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewGopY.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadGopY();
        //    //             FilterSTT(SoDong, GridViewBaiViet.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        //    //           this.GridViewBaiViet.DataBind();
        }
        ////Chon trang NEXT
        protected void GridViewGopY_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewGopY.PageIndex = e.NewPageIndex;
            //             int SoDong = LoadBaiViet();
            //             FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
            LoadGopY();
        }
    }
}