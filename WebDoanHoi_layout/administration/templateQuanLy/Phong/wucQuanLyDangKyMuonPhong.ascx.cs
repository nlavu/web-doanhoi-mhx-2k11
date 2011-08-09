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

namespace WebDoanHoi_layout.administration.templateQuanLy.Phong
{
    public partial class wucQuanLyDangKyMuonPhong : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMuonPhong();              
            }

        }
        protected void LoadMuonPhong()
        {
            //Xu ly session
            NGUOIDUNG a = (NGUOIDUNG)Session["LOGIN"];

            if (Request.QueryString["id"] != null)
            {
                //lay ma
                int madangky = int.Parse(Request.QueryString["id"]);


                //lay thong tin va load len cac textbox
                BUSDangKyMuonPhong BUSDangKyMuonPhong = new BUSDangKyMuonPhong();
                DANGKYMUONPHONG lpDTO = BUSDangKyMuonPhong.TimKiem(madangky);
                txtngay.Text = lpDTO.NgaySuDung.ToString();
                txtsoluong.Text = lpDTO.SoLuong.ToString();
                txtmucdich.Text = lpDTO.MucDich;
                txtdonvimuon.Text = lpDTO.DonViMuon;
                txtPhong.Text = lpDTO.KQPhong;
                TGTu.Text = lpDTO.TGBatDau;
                TGDen.Text = lpDTO.TGKetThuc;
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                DANGKYMUONPHONG lpDTO = new DANGKYMUONPHONG();
                lpDTO.MaDangKy = int.Parse(Request.QueryString["id"]);
                lpDTO.MaNguoiDung = int.Parse(Request.QueryString["manguoidung"]);
                lpDTO.NgaySuDung = DateTime.Parse(txtngay.Text);
                lpDTO.SoLuong = int.Parse(txtsoluong.Text);
                lpDTO.MucDich = txtmucdich.Text;
                lpDTO.DonViMuon = txtdonvimuon.Text;
                lpDTO.KQPhong = txtPhong.Text;
                lpDTO.TGBatDau = TGTu.Text;
                lpDTO.TGKetThuc = TGDen.Text;

                BUSDangKyMuonPhong BUSDangKyMuonPhong = new BUSDangKyMuonPhong();
                if (BUSDangKyMuonPhong.CapNhat(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
                    lbThongBao.Visible = true;
                    //LoadMuonPhong();
                    
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
                DANGKYMUONPHONG lpDTO = new DANGKYMUONPHONG();
                //Hiện tại chỉ cho phép thêm đk phòng dưới tên của admin
                lpDTO.MaNguoiDung = ((NGUOIDUNG)Session["QUANLY"]).MaNguoiDung;
                lpDTO.NgaySuDung = DateTime.Parse(txtngay.Text);
                lpDTO.SoLuong = int.Parse(txtsoluong.Text);
                lpDTO.MucDich = txtmucdich.Text;
                lpDTO.DonViMuon = txtdonvimuon.Text;
                lpDTO.KQPhong = txtPhong.Text;
                lpDTO.TGBatDau = TGTu.Text;
                lpDTO.TGKetThuc = TGDen.Text;
                lpDTO.NgayDangKy = DateTime.Now;
                //Goi ham cap nhat
                BUSDangKyMuonPhong BUSDangKyMuonPhong = new BUSDangKyMuonPhong();
                if (BUSDangKyMuonPhong.Them(lpDTO) == 1)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    //LoadMuonPhong();
               
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
                int madangky = int.Parse(Request.QueryString["id"]);

                //xac nhan truoc khi xoa
               
                    //Goi ham xoa
                    BUSDangKyMuonPhong BUSDangKyMuonPhong = new BUSDangKyMuonPhong();
                    if (BUSDangKyMuonPhong.Xoa(madangky) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                   
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

        protected void btnXoaNhieu_Click(object sender, EventArgs e)
        {
            try
            {
                List<DANGKYMUONPHONG> lt = new List<DANGKYMUONPHONG>();

                BUSDangKyMuonPhong BUSDangKyMuonPhong = new BUSDangKyMuonPhong();

                lt = BUSDangKyMuonPhong.SelectDANGKYMUONPHONGBYDATE(DateTime.Parse(txtXoaNhieu.Text));
                //lay thong tin tu textbox

                //xac nhan truoc khi xoa
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa các đăng ký trước ngày: <" + DateTime.Parse(txtXoaNhieu.Text) + "> không?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    for (int i = 0; i < lt.Count; i++)
                    {
                        int madangky = lt[i].MaDangKy;
                        //Goi ham xoa
                        BUSDangKyMuonPhong BUSDangKyMuonPhong2 = new BUSDangKyMuonPhong();
                        if (BUSDangKyMuonPhong2.Xoa(madangky) == 0)
                        {
                            //Thong bao
                        }
                        else
                        {
                            lbThongBao.Text = "Xóa Không Thành Công";
                            lbThongBao.Visible = true;
                            break;
                        }
                    }
                    lbThongBao.Text = "Xóa Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("DangKyMuonPhong.aspx");
                }
                else
                {
                    Response.Redirect("DangKyMuonPhong.aspx");
                }
            }

            catch 
            {
                lbThongBao.Text = "Xóa Không Thành Công";
                lbThongBao.Visible = true;
            }
        }

      
       
        //Load
        
    }
}