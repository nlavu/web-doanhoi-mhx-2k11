using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BUSAuction;
using DTOAuction;
using System.Collections.Generic;
//using System.Web.UI.MobileControls;
using System.Windows.Forms;

namespace WebDoanHoi_layout
{
    public partial class MuonPhong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((NGUOIDUNG)Session["LOGIN"] != null)
                {
                    txtMaNguoiDung.Text = ((NGUOIDUNG)(Session["LOGIN"])).MaNguoiDung.ToString();
                    int iMaNguoiDung = int.Parse(txtMaNguoiDung.Text);
                    LoadDanhSachPhong(iMaNguoiDung);
                    lbDangKy.Visible = true;
                }
                else
                {
                    Response.Redirect("default.aspx");
                    //btnDangKy.Visible = false;
                    //lbDangKy.Visible = true;
                }
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (((NGUOIDUNG)(Session["LOGIN"])).MaNguoiDung == int.Parse(txtMaNguoiDung.Text))
            {
                try
                {
                    //lay thong tin tu textbox
                    DANGKYMUONPHONG lpDTO = new DANGKYMUONPHONG();
                    //lpDTO.MaDangKy = int.Parse(txtMaDangKy.Text);
                    lpDTO.MaNguoiDung = int.Parse(txtMaNguoiDung.Text);
                    lpDTO.NgaySuDung = DateTime.ParseExact(txtNgayMuon.Text, "dd/mm/yyyy", null);
                    lpDTO.NgayDangKy = DateTime.Now;
                    lpDTO.SoLuong = int.Parse(txtSoLuong.Text);
                    lpDTO.MucDich = txtMucDich.Text;
                    lpDTO.DonViMuon = txtDonViMuon.Text;
                    lpDTO.TGBatDau = txtTGTu.Text;
                    lpDTO.TGKetThuc = txtTGDen.Text;
                    lpDTO.KetQua = false;
                    //lpDTO.BiKhoa  = txtlock.Text;
                    //Goi ham cap nhat
                    BUSDangKyMuonPhong BUSDangKyMuonPhong = new BUSDangKyMuonPhong();
                    if (BUSDangKyMuonPhong.Them(lpDTO) == 1)
                    {
                        //Thong bao
                        lbThongBao.Text = "Đăng Kí Thành Công";
                        lbThongBao.Visible = true;
                        int iMaNguoiDung = int.Parse(txtMaNguoiDung.Text);
                        LoadDanhSachPhong(iMaNguoiDung);
                        //LoadDanhSachPhong()
                        //Response.Redirect("LoaiMatHang.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Đăng Kí Không Thành Công";
                        lbThongBao.Visible = true;
                    }
                }

                catch
                {
                    lbThongBao.Text = "Đăng Kí Không Thành Công";
                    lbThongBao.Visible = true;
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }

        public int LoadDanhSachPhong(int manguoidung)
        {
            List<DANGKYMUONPHONG> lt = new List<DANGKYMUONPHONG>();

            BUSDangKyMuonPhong BUSDangKyMuonPhong = new BUSDangKyMuonPhong();
            lt = BUSDangKyMuonPhong.TimKiemDANGKYMUONPHONGtheoSV(manguoidung);
            if (lt.Count > 0)
            {
                this.GridViewDanhSachPhongMuon.DataSource = lt;
                GridViewDanhSachPhongMuon.DataBind();
                PanelDanhSach.Visible = true;
                PanelMessage.Visible = false;
                return lt.Count;
            }
            else
            {
                PanelDanhSach.Visible = false;
                PanelMessage.Visible = true;
                return 0;
            }
        }

        protected void GridViewDanhSachPhongMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int madangky = int.Parse(GridViewDanhSachPhongMuon.SelectedRow.Cells[0].Text);
            BUSDangKyMuonPhong bus = new BUSDangKyMuonPhong();
            DANGKYMUONPHONG rs = bus.TimKiem(madangky);
            dvMuonPhong.DataSource = rs;
            dvMuonPhong.DataBind();
        }

        protected void GridViewDanhSachPhongMuon_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Xem")
            {
                int madangky = Convert.ToInt32(e.CommandArgument);
                BUSDangKyMuonPhong bus = new BUSDangKyMuonPhong();
                DANGKYMUONPHONG rs = bus.TimKiem(madangky);
                List<DANGKYMUONPHONG> lst = new List<DANGKYMUONPHONG>();
                lst.Add(rs);
                dvMuonPhong.DataSource = lst;
                dvMuonPhong.DataBind();
            }
            
        }
    }
}