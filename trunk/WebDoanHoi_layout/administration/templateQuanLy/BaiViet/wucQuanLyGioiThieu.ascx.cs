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
    public partial class wucQuanLyGioiThieu : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
         
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    //lay ma              
                    int magioithieu = int.Parse(Request.QueryString["id"]);

                    //lay thong tin va load len cac textbox
                    BUSGioiThieu BUSGioiThieu = new BUSGioiThieu();
                    GIOITHIEU lpDTO = BUSGioiThieu.TimKiem(magioithieu);
                    this.txttengioithieu.Text = lpDTO.TieuDe;
                    this.txtnoidung.Content = lpDTO.NoiDung;
                }
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                GIOITHIEU lpDTO = new GIOITHIEU();
                lpDTO.MaBai = int.Parse(Request.QueryString["id"]);
                lpDTO.TieuDe  = this.txttengioithieu.Text;
                lpDTO.NoiDung  = this.txtnoidung.Content;
                //Goi ham cap nhat
                BUSGioiThieu BUSGioiThieu = new BUSGioiThieu();
                if (BUSGioiThieu.CapNhat(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("GioiThieu.aspx");
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
                GIOITHIEU lpDTO = new GIOITHIEU();                
                lpDTO.TieuDe  = this.txttengioithieu.Text;
                lpDTO.NoiDung  = this.txtnoidung.Content;
                //Goi ham cap nhat
                BUSGioiThieu BUSGioiThieu = new BUSGioiThieu();
                if (BUSGioiThieu.Them(lpDTO) == 1)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("GioiThieu.aspx");
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
                int magioithieu = int.Parse(Request.QueryString["id"]);
                //xac nhan truoc khi xoa
              
                    BUSGioiThieu BUSGioiThieu = new BUSGioiThieu();
                    if (BUSGioiThieu.Xoa(magioithieu) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("GioiThieu.aspx");
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