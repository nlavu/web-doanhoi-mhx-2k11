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

namespace WebDoanHoi_layout.administration.templateQuanLy.BaiHat
{
    public partial class wucQuanLyBaiHat : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
            NGUOIDUNG a = new NGUOIDUNG();
            a.MaNguoiDung = 1;
            Session["NGUOIDUNG"] = a;

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    //lay ma
                    int mabaihat = int.Parse(Request.QueryString["id"]);

                    //lay thong tin va load len cac textbox
                    BUSBaiHat BUSBaiHat = new BUSBaiHat();
                    BAIHAT lpDTO = BUSBaiHat.TimKiem(mabaihat);
                    this.txtmabaihat.Text = Convert.ToString(lpDTO.MaBaiHat);
                    this.txttenbaihat.Text = lpDTO.TenBaiHat;
                    this.txtlinkbaihat.Text = lpDTO.LinkBaiHat;
                }
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                BAIHAT lpDTO = new BAIHAT();
                lpDTO.MaBaiHat  = Convert.ToInt32(this.txtmabaihat.Text);
                lpDTO.TenBaiHat  = this.txttenbaihat.Text;
                lpDTO.LinkBaiHat  = this.txtlinkbaihat.Text;
                //Goi ham cap nhat
                BUSBaiHat BUSBaiHat = new BUSBaiHat();
                if (BUSBaiHat.CapNhat(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("BaiHat.aspx");
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
                BAIHAT lpDTO = new BAIHAT();
                //lpDTO.MaBaiHat = Convert.ToInt32(this.txtmabaihat.Text);
                lpDTO.TenBaiHat = this.txttenbaihat.Text;
                lpDTO.LinkBaiHat = this.txtlinkbaihat.Text;

                //Goi ham cap nhat
                BUSBaiHat BUSBaiHat = new BUSBaiHat();
                if (BUSBaiHat.Them(lpDTO) != 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    //Response.Redirect("BaiHat.aspx");
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
                int mabaihat = int.Parse(Request.QueryString["id"]);

                //xac nhan truoc khi xoa
                DialogResult rs = MessageBox.Show("Bạn có chắc là muốn xoá Hoạt Động <" + mabaihat + "> không?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    //Goi ham xoa
                    BUSBaiHat BUSBaiHat = new BUSBaiHat();
                    if (BUSBaiHat.Xoa(mabaihat) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("BaiHat.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Xóa Không Thành Công";
                        lbThongBao.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("BaiHat.aspx");
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