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
    public partial class wucQuanLyDapAnKhaoSat : System.Web.UI.UserControl
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
                BUSDapAnKhaoSat BUSDapAnKhaoSat = new BUSDapAnKhaoSat();
                DAPANKHAOSAT lpDTO = BUSDapAnKhaoSat.TimKiem(mahoatdong);
                txtmadapankhaosat.Text = lpDTO.MaDapAn.ToString();
                txtmakhaosat.Text = lpDTO.MaCauHoi.ToString();
                txttieude.Text = lpDTO.NoiDung ;
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                DAPANKHAOSAT lpDTO = new DAPANKHAOSAT();
                lpDTO.MaDapAn  = int.Parse(txtmadapankhaosat.Text);
                lpDTO.MaCauHoi  = int.Parse(txtmakhaosat.Text);
                lpDTO.NoiDung  = txttieude.Text;

                //Goi ham cap nhat
                BUSDapAnKhaoSat BUSDapAnKhaoSat = new BUSDapAnKhaoSat();
                if (BUSDapAnKhaoSat.CapNhat(lpDTO) == 0)
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
                DAPANKHAOSAT lpDTO = new DAPANKHAOSAT();
                lpDTO.MaDapAn = int.Parse(txtmadapankhaosat.Text);
                lpDTO.MaCauHoi = int.Parse(txtmakhaosat.Text);
                lpDTO.NoiDung = txttieude.Text;

                //Goi ham cap nhat
                BUSDapAnKhaoSat BUSDapAnKhaoSat = new BUSDapAnKhaoSat();
                if (BUSDapAnKhaoSat.Them(lpDTO) == 0)
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

                //xac nhan truoc khi xoa
               
                    BUSDapAnKhaoSat BUSDapAnKhaoSat = new BUSDapAnKhaoSat();
                    if (BUSDapAnKhaoSat.Xoa(mahoatdong) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("DapAnKhaoSat.aspx");
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