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
    public partial class wucQuanLyLoaiBaiViet : System.Web.UI.UserControl
    {
        #region Ham Chung

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    //lay ma
                    int maloaibaiviet = int.Parse(Request.QueryString["id"]);

                    //lay thong tin va load len cac textbox
                    BUSLoaiBaiViet BUSLoaiBaiViet = new BUSLoaiBaiViet();
                    LOAIBAIVIET lpDTO = BUSLoaiBaiViet.TimKiem(maloaibaiviet);
                    //       this.txtmaloaibaiviet.Text = Convert.ToString(lpDTO.MaLoaiBaiViet);
                    //this.txtmachuyenmuc.Text = Convert.ToString(lpDTO.MaChuyenMuc );
                    load_ddlChuyenMuc();
                    this.ddlChuyenMuc.SelectedValue = lpDTO.MaChuyenMuc.ToString();
                    this.txttenloaibaiviet.Text = lpDTO.TenLoaiBaiViet;
                }
                else
                {
                    load_ddlChuyenMuc();
                    ddlChuyenMuc.SelectedIndex = 0;
                }
            }

            
        }
        protected void load_ddlChuyenMuc()
        {
            // load ddlChuyenMuc
            ddlChuyenMuc.Items.Clear();
            BUSChuyenMuc BUSChuyenMuc = new BUSChuyenMuc();
            List<CHUYENMUC> lstCM = BUSChuyenMuc.SelectCHUYENMUCsAll();
            for (int i = 0; i < lstCM.Count; i++)
            {
                ListItem li = new ListItem(lstCM[i].TenChuyenMuc.ToString(), lstCM[i].MaChuyenMuc.ToString());
                this.ddlChuyenMuc.Items.Add(li);

            }

        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                LOAIBAIVIET lpDTO = new LOAIBAIVIET();
                lpDTO.MaLoaiBaiViet = int.Parse(Request.QueryString["id"]);
                lpDTO.TenLoaiBaiViet  = this.txttenloaibaiviet.Text;
                lpDTO.MaChuyenMuc  = int.Parse(this.ddlChuyenMuc.SelectedValue);

                //Goi ham cap nhat
                BUSLoaiBaiViet BUSLoaiBaiViet = new BUSLoaiBaiViet();
                if (BUSLoaiBaiViet.CapNhat(lpDTO) == 1)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("LoaiBaiViet.aspx");
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
                LOAIBAIVIET lpDTO = new LOAIBAIVIET();
                //lpDTO.MaLoaiBaiViet = int.Parse(this.txtmaloaibaiviet.Text);
                lpDTO.TenLoaiBaiViet = this.txttenloaibaiviet.Text;
                lpDTO.MaChuyenMuc = int.Parse(ddlChuyenMuc.SelectedValue);

                //Goi ham cap nhat
                BUSLoaiBaiViet BUSLoaiBaiViet = new BUSLoaiBaiViet();
                if (BUSLoaiBaiViet.Them(lpDTO) == 1)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("LoaiBaiViet.aspx");
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
                int maloaibaiviet = int.Parse(Request.QueryString["id"]);
                 BUSBaiViet busBaiViet = new BUSBaiViet();
                List<BAIVIET> lstBaiViet = busBaiViet.TimKiemTheoLoaiBaiViet(maloaibaiviet);
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
                BUSLoaiBaiViet bus = new BUSLoaiBaiViet();
                //xac nhan truoc khi xoa
                               
                    BUSLoaiBaiViet BUSLoaiBaiViet = new BUSLoaiBaiViet();
                    if (BUSLoaiBaiViet.Xoa(maloaibaiviet) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("LoaiBaiViet.aspx");
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