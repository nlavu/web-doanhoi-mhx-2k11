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

namespace WebDoanHoi_layout.administration.templateQuanLy.BaiViet
{
    public partial class wucQuanLyChuyenMuc : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Bài Gửi";

            if (!IsPostBack)
            {
                int soDong = LoadChuyenMuc();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewChuyenMuc.HeaderStyle.CssClass = "headerstyle";
            //Thong tin nguoi dung
        
            if (Request.QueryString["id"] != null)
            {
                //lay ma
                int machuyenmuc = int.Parse(Request.QueryString["id"]);

                //lay thong tin va load len cac textbox
                BUSChuyenMuc BUSChuyenMuc = new BUSChuyenMuc();
                CHUYENMUC lpDTO = BUSChuyenMuc.TimKiem(machuyenmuc);
                this.txtmachuyenmuc.Text = Convert.ToString(lpDTO.MaChuyenMuc );
                this.txttenchuyenmuc.Text = lpDTO.TenChuyenMuc ;
            }
        }
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
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                CHUYENMUC lpDTO = new CHUYENMUC();
                lpDTO.MaChuyenMuc  = int.Parse(this.txtmachuyenmuc.Text);
                lpDTO.TenChuyenMuc  = this.txttenchuyenmuc.Text;


                //Goi ham cap nhat
                BUSChuyenMuc BUSChuyenMuc = new BUSChuyenMuc();
                if (BUSChuyenMuc.CapNhat(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
                    lbThongBao.Visible = true;
                    //Response.Redirect("LoaiMatHang.aspx");
                }
                else
                {
                    lbThongBao.Text = "Cập Nhật Không Thành Công";
                    lbThongBao.Visible = true;
                }
            }

            catch 
            {
                lbThongBao.Text = "Cập nhật Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                CHUYENMUC lpDTO = new CHUYENMUC();               
                lpDTO.TenChuyenMuc = this.txttenchuyenmuc.Text;
                //Goi ham cap nhat
                BUSChuyenMuc BUSChuyenMuc = new BUSChuyenMuc();
                if (BUSChuyenMuc.Them(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    //Response.Redirect("LoaiMatHang.aspx");
                }
                else
                {
                    lbThongBao.Text = "Thêm Không Thành Công";
                    lbThongBao.Visible = true;
                }
            }

            catch
            {
                lbThongBao.Text = "Thêm Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                int machuyenmuc = int.Parse(Request.QueryString["id"]);
                BUSBaiViet busBaiViet = new BUSBaiViet();
                List<BAIVIET> lstBaiViet = busBaiViet.LayDSBaiVietTheoChuyenMuc(machuyenmuc);
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
             
                //xac nhan truoc khi xoa
              
             
                    //Goi ham xoa
                    BUSChuyenMuc BUSChuyenMuc = new BUSChuyenMuc();
                    if (BUSChuyenMuc.Xoa(machuyenmuc) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("HoatDong.aspx");
                    }                  
             
            }

            catch 
            {
                lbThongBao.Text = "Xoa Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        #endregion
    }
}