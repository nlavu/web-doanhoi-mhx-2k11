using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Windows.Forms;

namespace WebDoanHoi_layout.wuc.sidebar
{
    public partial class sb_khaosat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadKhaosat();
            }
            
        }
        static int MaCauHoi;
        protected void LoadKhaosat()
        {
            BUSCauHoiKhaoSat BUSCauHoiKhaoSat = new BUSCauHoiKhaoSat();
            CAUHOIKHAOSAT CAUHOIKHAOSAT = new CAUHOIKHAOSAT();
            CAUHOIKHAOSAT = BUSCauHoiKhaoSat.layCauHoiKhongKhoa();
            MaCauHoi = CAUHOIKHAOSAT.MaCauHoiKhaoSat;
            if (CAUHOIKHAOSAT != null)
            {
                lbCauHoi.Text = CAUHOIKHAOSAT.NoiDung;

                BUSDapAnKhaoSat BUSDapAnKhaoSat = new BUSDapAnKhaoSat();
                List<DAPANKHAOSAT> listDA = new List<DAPANKHAOSAT>();
                listDA = BUSDapAnKhaoSat.layDapAnTheoMaCauHoi(CAUHOIKHAOSAT.MaCauHoiKhaoSat);

                
                rblistDanhSachDapAn.DataSource = listDA;
                rblistDanhSachDapAn.DataTextField = "NoiDung";
                rblistDanhSachDapAn.DataValueField = "MaDapAn";

                rblistDanhSachDapAn.DataBind();
            }
            else
            {
                rblistDanhSachDapAn.Visible = true;
                btSubmit.Visible = true;
            }

           // rblistDanhSachDapAn.Items[0].Selected = true;
        }
        protected void btSubmit_Click(object sender, EventArgs e)
        {
            int i = -1;         
         
            i = rblistDanhSachDapAn.SelectedIndex;
            if (i == -1)
            {
                lThongTin.Text = "Bạn chưa chọn đáp án";
            }
            else
            {
                KHAOSAT KhaoSat = new KHAOSAT();
                BUSKhaoSat KhaoSatBUS = new BUSKhaoSat();
                
                lThongTin.Text = rblistDanhSachDapAn.Items[i].Text;

                    KhaoSat.MaDapAn = int.Parse(rblistDanhSachDapAn.SelectedValue);
                               
                    KhaoSatBUS.Them(KhaoSat);
               
         
            }              
        }

        protected void rblistDanhSachDapAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*int index = rblistDanhSachDapAn.SelectedIndex;
            rblistDanhSachDapAn.Items[index].Selected = true;*/
        }
    }
}