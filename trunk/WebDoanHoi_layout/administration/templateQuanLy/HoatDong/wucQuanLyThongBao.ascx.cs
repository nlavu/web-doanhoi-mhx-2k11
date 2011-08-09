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
    public partial class wucQuanLyThongBao : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
         
            BUSHoatDong HoatDongBUS = new BUSHoatDong();
            List<HOATDONG> DSHoatDong = HoatDongBUS.SelectHOATDONGsAll();
            drlHoatDong.DataSource = DSHoatDong;
            drlHoatDong.DataTextField = "TenHoatDong";
            drlHoatDong.DataValueField = "MaHoatDong";
            drlHoatDong.DataBind();
         

            if (Request.QueryString["id"] != null)
            {
                //lay ma
                int mahoatdong = int.Parse(Request.QueryString["id"]);

                //lay thong tin va load len cac textbox
                BUSThongBao BUSThongBao = new BUSThongBao();
                THONGBAO lpDTO = BUSThongBao.TimKiem(mahoatdong);
                txttieude.Text = lpDTO.TieuDe ;
                txtnoidung.Content = lpDTO.NoiDung ;
                drlHoatDong.SelectedValue = mahoatdong.ToString();
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                THONGBAO lpDTO = new THONGBAO();
                lpDTO.TieuDe  = txttieude.Text;
                lpDTO.NoiDung  = txtnoidung.Content;
                lpDTO.MaHoatDong  = int.Parse(drlHoatDong.SelectedValue);
                lpDTO.NgayDang  = DateTime.Now;

                //Goi ham cap nhat
                BUSThongBao BUSThongBao = new BUSThongBao();
                if (BUSThongBao.CapNhat(lpDTO) == 0)
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
                THONGBAO lpDTO = new THONGBAO();
                lpDTO.TieuDe = txttieude.Text;
                lpDTO.NoiDung = txtnoidung.Content;
                lpDTO.MaHoatDong = int.Parse(drlHoatDong.SelectedValue);
                lpDTO.NgayDang = DateTime.Now;

                //Goi ham cap nhat
                BUSThongBao BUSThongBao = new BUSThongBao();
                if (BUSThongBao.Them(lpDTO) == 0)
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
              
                    //Goi ham xoa
                    BUSThongBao BUSThongBao = new BUSThongBao();
                    if (BUSThongBao.Xoa(mahoatdong) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("ThongBao.aspx");
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