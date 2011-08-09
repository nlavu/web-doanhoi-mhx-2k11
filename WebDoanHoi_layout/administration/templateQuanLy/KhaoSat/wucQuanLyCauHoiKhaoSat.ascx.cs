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

namespace WebDoanHoi_layout.administration.templateQuanLy.KhaoSat
{
    public partial class wucQuanLyCauHoiKhaoSat : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
           

            if (Request.QueryString["id"] != null)
            {
                //lay ma
                int mahoatdong = int.Parse(Request.QueryString["id"]);

                //lay thong tin va load len cac textbox
                BUSCauHoiKhaoSat BUSCauHoiKhaoSat = new BUSCauHoiKhaoSat();
                CAUHOIKHAOSAT lpDTO = BUSCauHoiKhaoSat.TimKiem(mahoatdong);
                txtmacauhoikhaosat.Text = lpDTO.MaCauHoiKhaoSat .ToString();
                txttieude.Text = lpDTO.NoiDung ;
                txtlock.Text = lpDTO.BiKhoa.ToString()  ;
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                CAUHOIKHAOSAT lpDTO = new CAUHOIKHAOSAT();
                lpDTO.MaCauHoiKhaoSat  = int.Parse(txtmacauhoikhaosat.Text);
                lpDTO.NoiDung  = txttieude.Text;
                lpDTO.BiKhoa  = Convert.ToBoolean(txtlock.Text);
                //Goi ham cap nhat
                BUSCauHoiKhaoSat BUSCauHoiKhaoSat = new BUSCauHoiKhaoSat();
                if (BUSCauHoiKhaoSat.CapNhat(lpDTO) == 0)
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
                CAUHOIKHAOSAT lpDTO = new CAUHOIKHAOSAT();
                lpDTO.MaCauHoiKhaoSat = int.Parse(txtmacauhoikhaosat.Text);
                lpDTO.NoiDung = txttieude.Text;
                lpDTO.BiKhoa = Convert.ToBoolean(txtlock.Text);

                //Goi ham cap nhat
                BUSCauHoiKhaoSat BUSCauHoiKhaoSat = new BUSCauHoiKhaoSat();
                if (BUSCauHoiKhaoSat.Them(lpDTO) == 0)
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
                int mahoatdong = int.Parse(Request.QueryString["id"]);

             
                    //Goi ham xoa
                    BUSCauHoiKhaoSat BUSCauHoiKhaoSat = new BUSCauHoiKhaoSat();
                    if (BUSCauHoiKhaoSat.Xoa(mahoatdong) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("CauHoiKhaoSat.aspx");
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