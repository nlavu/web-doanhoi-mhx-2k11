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
    public partial class wucQuanLyKhaoSat : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
         

            if (Request.QueryString["id"] != null)
            {
                //lay ma
                int makhaosat = int.Parse(Request.QueryString["id"]);

                //lay thong tin va load len cac textbox
                BUSKhaoSat BUSKhaoSat = new BUSKhaoSat();
                KHAOSAT lpDTO = BUSKhaoSat.TimKiem(makhaosat);
                txtmadapan.Text = lpDTO.MaDapAn.ToString();             
                txtykienkhac.Text = lpDTO.YKienKhac;
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                KHAOSAT lpDTO = new KHAOSAT();
                lpDTO.YKienKhac  = txtykienkhac.Text;            
                lpDTO.MaDapAn  =  int.Parse(txtmadapan.Text);
                lpDTO.MaYKKS = int.Parse(txtMaYKKS.Text);
                //Goi ham cap nhat
                BUSKhaoSat BUSKhaoSat = new BUSKhaoSat();
                if (BUSKhaoSat.CapNhat(lpDTO) == 0)
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
                KHAOSAT lpDTO = new KHAOSAT();
                lpDTO.YKienKhac = txtykienkhac.Text;            
                lpDTO.MaDapAn = int.Parse(txtmadapan.Text);

                //Goi ham cap nhat
                BUSKhaoSat BUSKhaoSat = new BUSKhaoSat();
                if (BUSKhaoSat.Them(lpDTO) == 0)
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
                int makhaosat = int.Parse(Request.QueryString["id"]);
                KHAOSAT khaosat = new KHAOSAT();
                khaosat.MaYKKS = int.Parse(txtMaYKKS.Text);           
                khaosat.YKienKhac = txtykienkhac.Text;
                //xac nhan truoc khi xoa
                DialogResult rs = MessageBox.Show("Bạn có chắc là muốn xoá Hoạt Động <" + khaosat.MaDapAn  + "> không?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    //Goi ham xoa
                    BUSKhaoSat BUSKhaoSat = new BUSKhaoSat();
                    if (BUSKhaoSat.Xoa(khaosat) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("HoatDong.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Xóa Không Thành Công";
                        lbThongBao.Visible = true;
                    }
                }
                else
                {
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