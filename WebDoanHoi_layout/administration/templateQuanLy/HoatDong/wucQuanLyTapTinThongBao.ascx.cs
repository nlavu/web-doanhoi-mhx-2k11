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

namespace WebDoanHoi_layout.administration.templateQuanLy.HoatDong
{
    public partial class wucQuanLyTapTinThongBao : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
          

            if (Request.QueryString["id"] != null)
            {
                //lay ma
                int mataptin = int.Parse(Request.QueryString["id"]);

                //lay thong tin va load len cac textbox
                BUSTapTinThongBao BUSTapTinThongBao = new BUSTapTinThongBao();
                TAPTINTHONGBAO lpDTO = BUSTapTinThongBao.TimKiem(mataptin);
                this.txtmataptin.Text = Convert.ToString(lpDTO.MaTapTin);
                this.txttentaptin.Text = lpDTO.TenTapTin ;
                this.txtmabaiviet.Text = Convert.ToString(lpDTO.MaThongBao );
                this.txtduongdan.Text = lpDTO.DuongDan ;
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                TAPTINTHONGBAO lpDTO = new TAPTINTHONGBAO();
                lpDTO.MaTapTin  = int.Parse(this.txtmataptin.Text);
                lpDTO.TenTapTin  = this.txttentaptin.Text;
                lpDTO.MaThongBao  = int.Parse(this.txtmabaiviet.Text);
                lpDTO.DuongDan  = this.txtduongdan.Text;

                //Goi ham cap nhat
                BUSTapTinThongBao BUSTapTinThongBao = new BUSTapTinThongBao();
                if (BUSTapTinThongBao.CapNhat(lpDTO) == 0)
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
                TAPTINTHONGBAO lpDTO = new TAPTINTHONGBAO();
                lpDTO.MaTapTin = int.Parse(this.txtmataptin.Text);
                lpDTO.TenTapTin = this.txttentaptin.Text;
                lpDTO.MaThongBao = int.Parse(this.txtmabaiviet.Text);
                lpDTO.DuongDan = this.txtduongdan.Text;
                //Goi ham cap nhat
                BUSTapTinThongBao BUSTapTinThongBao = new BUSTapTinThongBao();
                if (BUSTapTinThongBao.Them(lpDTO) == 0)
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
                int mataptin = int.Parse(Request.QueryString["id"]);

                //xac nhan truoc khi xoa
              
              
                    BUSTapTinThongBao BUSTapTinThongBao = new BUSTapTinThongBao();
                    if (BUSTapTinThongBao.Xoa(mataptin) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("TapTinThongBao.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Xóa Không Thành Công";
                        lbThongBao.Visible = true;
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