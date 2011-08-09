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
    public partial class wucBaiViet : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Bài Gửi";

            if (!IsPostBack)
            {
                int soDong = LoadBaiViet();
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
            this.GridViewBaiViet.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewBaiViet.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        private static int SortByDate(BAIVIET_getall_newResult rs1, BAIVIET_getall_newResult rs2)
        {
            if (rs1.NgayDang > rs2.NgayDang)
            {
                return -1;
            }
            if (rs1.NgayDang == rs2.NgayDang)
                return 0;            
                return 1;
        }
        public int LoadBaiViet()
        {
            List<BAIVIET_getall_newResult> lt = new List<BAIVIET_getall_newResult>();
            BUSBaiViet BUSBaiViet = new BUSBaiViet();
            lt = BUSBaiViet.SelectBAIVIETsAll_new();
            
            LOAIBAIVIET ltLoaiBaiViet = new LOAIBAIVIET();
            BUSLoaiBaiViet BUSLoaiBaiViet = new BUSLoaiBaiViet();
            if (lt.Count > 0)
            {
                lt.Sort(SortByDate);
                this.GridViewBaiViet.DataSource = lt;                
                GridViewBaiViet.DataBind();             
                PanelDanhSach.Visible = true;
                PanelMessage.Visible = false;


                //                 for (int i = 0; i < lt.Count; i++)
                //                 {
                //                     GridViewBaiViet.Rows[i].Cells[4].Text = BUSLoaiBaiViet.TimKiem((int)lt[i].MaLoaiBaiViet).TenLoaiBaiViet;
                //                 }
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
            this.GridViewBaiViet.PageSize = int.Parse(DropDownListPaging.SelectedValue);
             int SoDong = LoadBaiViet();
//             FilterSTT(SoDong, GridViewBaiViet.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
 //           this.GridViewBaiViet.DataBind();
        }
        //Chon trang NEXT
        protected void GridViewBaiViet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewBaiViet.PageIndex = e.NewPageIndex;
//             int SoDong = LoadBaiViet();
//             FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
            LoadBaiViet();
        }
        #region tin-xoa
        protected void GridViewBaiViet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XoaBaiViet")
            {
                List<BAIVIET> lt = new List<BAIVIET>();

                BUSBaiViet busBaiViet = new BUSBaiViet();
                lt = busBaiViet.SelectBAIVIETsAll();

                //Anh Vu
                //kiem tra xem co phai admin hoac tac gia bai viet thi cho xoa
                //
                if (((NGUOIDUNG)Session["LOGIN"]) != null)
                {
                    if (((NGUOIDUNG)Session["LOGIN"]).MaVaiTro == 4)
                    {
                        int idBV = Convert.ToInt32(e.CommandArgument);
                        XoaBaiViet(idBV);
                    }
                    else
                    {
                        BAIVIET baiviet = new BAIVIET();
                        BUSBaiViet bviet = new BUSBaiViet();
                        int idBV = Convert.ToInt32(e.CommandArgument);
                        baiviet = bviet.TimKiemTheoMa(idBV);
                        if (((NGUOIDUNG)Session["LOGIN"]).MaNguoiDung == baiviet.MaNguoiDang)
                        {
                            XoaBaiViet(idBV);
                        }
                        else
                        {
                            ThongBao.Text = "<h1>Không xoá được vì bạn không phải admin hoặc tác giả bài viết !!!</h1>";
                        }
                    }
                }
            }
            
        }

        protected void XoaBaiViet(int mabaiviet)
        {
            try
            {

                //xac nhan truoc khi xoa

                //Goi ham xoa
                BUSBaiViet BUSBaiViet = new BUSBaiViet();
                if (BUSBaiViet.Xoa(mabaiviet) == 0)
                {
                    //Thong bao

                    Response.Redirect("BaiViet.aspx");
                }

            }

            catch
            {
            }
        }
        #endregion
        protected void onchecked_changed(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox chkStatus = (System.Web.UI.WebControls.CheckBox)sender;
            GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
            int id = Int32.Parse(row.Cells[1].Text) ;
            bool status = chkStatus.Checked;
            BUSBaiViet bus = new BUSBaiViet();
            BAIVIET bv = bus.TimKiem(id);
            bv.TinNoiBat = status;
            bus.CapNhat(bv);
        }

    }
}