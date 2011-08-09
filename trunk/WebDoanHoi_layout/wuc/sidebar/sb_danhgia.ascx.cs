using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTOAuction;
using BUSAuction;

namespace WebDoanHoi_layout.wuc.sidebar
{
    public partial class sb_danhgia : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDanhGia();
            }
        }

        protected void LoadDanhGia()
        {
            int MaCauHoiDanhGia = 1;
            BUSCauHoiKhaoSat BUSCauHoiKhaoSat = new BUSCauHoiKhaoSat();
            CAUHOIKHAOSAT CAUHOIKHAOSAT = new CAUHOIKHAOSAT();
            CAUHOIKHAOSAT = BUSCauHoiKhaoSat.TimKiem(MaCauHoiDanhGia);

            if (CAUHOIKHAOSAT != null)
            {
                lbCauHoi.Text = CAUHOIKHAOSAT.NoiDung;

                BUSDapAnKhaoSat BUSDapAnKhaoSat = new BUSDapAnKhaoSat();
                List<DAPANKHAOSAT> listDA = new List<DAPANKHAOSAT>();
                listDA = BUSDapAnKhaoSat.layDapAnTheoMaCauHoi(CAUHOIKHAOSAT.MaCauHoiKhaoSat);

                
                rblDanhSachDapAn.DataSource = listDA;
                rblDanhSachDapAn.DataTextField = "NoiDung";
                rblDanhSachDapAn.DataValueField = "MaDapAn";

                rblDanhSachDapAn.DataBind();
            }
            else
            {
                rblDanhSachDapAn.Visible = true;
                btSubmit.Visible = true;
            }

           // rblistDanhSachDapAn.Items[0].Selected = true;
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            int i = -1;
            if (((NGUOIDUNG)Session["LOGIN"]) == null)
            {
                lbCauHoi.Text = "Mời bạn đăng nhập để tham gia khảo sát!!!";
                return;
            }

            i = rblDanhSachDapAn.SelectedIndex;
            if (i == -1)
            {
                lThongTin.Text = "Bạn chưa chọn đáp án";
            }
            else
            {
                lThongTin.Text = rblDanhSachDapAn.Items[i].Text;
                KHAOSAT KhaoSat = new KHAOSAT();
                KhaoSat.MaDapAn = int.Parse(rblDanhSachDapAn.SelectedValue);
                BUSKhaoSat KhaoSatBUS = new BUSKhaoSat();  
                KhaoSatBUS.Them(KhaoSat);
            }    
        }
    }
}