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

namespace WebDoanHoi_layout.administration.templateLoad.CauHoiThuongGap
{
    public partial class wucFAQ : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Quản Lý Câu Hỏi Thường Gặp";

            if (!IsPostBack)
            {
                int soDong = LoadFAQ();
            }
            this.GridViewFAQ.HeaderStyle.CssClass = "headerstyle";

            int maFAQ;
            if (int.TryParse(Request.QueryString["id"], out maFAQ))
            {
                BUSFAQ busFAQ = new BUSFAQ();
                CAUHOITHUONGGAP faq = new CAUHOITHUONGGAP();
                faq = busFAQ.TimKiem(maFAQ);

                txtCauHoi.Text = faq.NoiDungCauHoi;
                txtCauTraLoi.Text = faq.CauTraLoi;
            }
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewFAQ.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }

        public int LoadFAQ()
        {
            BUSFAQ faq = new BUSFAQ();
            List<CAUHOITHUONGGAP> dsFAQ = new List<CAUHOITHUONGGAP>();
            dsFAQ = faq.LayDanhSachTatCaCauHoiThuongGap();

            if (dsFAQ.Count > 0)
            {
                //lt.Sort(SortByDate);
                this.GridViewFAQ.DataSource = dsFAQ;
                GridViewFAQ.DataBind();
                PanelDanhSach.Visible = true;
                PanelMessage.Visible = false;


                //                 for (int i = 0; i < lt.Count; i++)
                //                 {
                //                     GridViewBaiViet.Rows[i].Cells[4].Text = BUSLoaiBaiViet.TimKiem((int)lt[i].MaLoaiBaiViet).TenLoaiBaiViet;
                //                 }
                return dsFAQ.Count;
            }
            else
            {
                PanelDanhSach.Visible = false;
                PanelMessage.Visible = true;
                return 0;
            }
        }

        ////Chon Phan Trang Theo y nguoi dung: 5, 10, 15, 20,..

        protected void DropDownListPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewFAQ.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadFAQ();
            //    //             FilterSTT(SoDong, GridViewBaiViet.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
            //    //           this.GridViewBaiViet.DataBind();
        }
        ////Chon trang NEXT
        protected void GridViewFAQ_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFAQ.PageIndex = e.NewPageIndex;
            //             int SoDong = LoadBaiViet();
            //             FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
            LoadFAQ();
        }

        // Thêm FAQ:
        protected void ThemCauHoiThuongGap(object sender, EventArgs e)
        {
            //Lấy câu hỏi và câu trả lời
            if (txtCauHoi.Text == "")
            {
                lblThongTin.Text = "Vui lòng nhập câu hỏi!";
                lblThongTin.Visible = true;
                return;
            }
            if (txtCauTraLoi.Text == "")
            {
                lblThongTin.Text = "Vui lòng nhập câu trả lời cho câu hỏi của bạn!";
                lblThongTin.Visible = true;
                return;
            }
            string cauhoi = txtCauHoi.Text;
            string cautraloi = txtCauTraLoi.Text;
            BUSFAQ busfaq = new BUSFAQ();
            int kq;
            kq = busfaq.FAQ_Them(cauhoi, cautraloi);
            if (kq == 1)
            {
                txtCauHoi.Text = "";
                txtCauTraLoi.Text = "";
                lblThongTin.Text = "";
                LoadFAQ();
            }
            else
            {
                lblThongTin.Text = "Thêm thất bại";
            }            
        }

        protected void XoaCauHoiThuongGap(object sender, EventArgs e)
        {
            int maFAQ;
            if (int.TryParse(Request.QueryString["id"], out maFAQ))
            {
                BUSFAQ busFAQ = new BUSFAQ();
                int kq;
                kq = busFAQ.FAQ_Xoa(maFAQ);

                if (kq == 1)
                {
                    txtCauHoi.Text = "";
                    txtCauTraLoi.Text = "";
                    LoadFAQ();
                }
                else
                {
                    lblThongTin.Text = "Xóa thất bại!";
                }                
            }
        }

        protected void SuaCauHoiThuongGap(object sender, EventArgs e)
        {
            try
            {
                int maFAQ;
                if (int.TryParse(Request.QueryString["id"], out maFAQ))
                {
                    lblCauhoimoi.Visible = true;
                    txtCauHoiMoi.Visible = true;

                    lblCautraloimoi.Visible = true;
                    txtCauTraLoiMoi.Visible = true;
                    //Lấy Cauhoimoi và cautraloimoi

                    string cauhoimoi = txtCauHoiMoi.Text;
                    string cautraloimoi = txtCauTraLoiMoi.Text;
                    if (cauhoimoi == "")
                    {
                        lblThongTin.Text = "Vui lòng nhập câu hỏi mới!";
                        lblThongTin.Visible = true;
                        return;
                    }
                    if (cautraloimoi == "")
                    {
                        lblThongTin.Text = "Vui lòng nhập câu trả lời mới cho câu hỏi của bạn!";
                        lblThongTin.Visible = true;
                        return;
                    }

                    BUSFAQ busfaq = new BUSFAQ();
                    int kq;
                    kq = busfaq.FAQ_Sua(maFAQ, cauhoimoi, cautraloimoi);

                    if (kq == 1)
                    {
                        lblCauhoimoi.Visible = false;
                        txtCauHoiMoi.Visible = false;
                        lblCautraloimoi.Visible = false;
                        txtCauTraLoiMoi.Visible = false;

                        txtCauHoi.Text = "";
                        txtCauTraLoi.Text = "";
                        LoadFAQ();
                        lblThongTin.Text = "Cập Nhật Thành Công";
                        lblThongTin.Visible = true;
                    }
                    else
                    {
                        lblThongTin.Text = "Cập Nhật thất bại";
                        lblThongTin.Visible = true;
                    }
                }
            }
            catch
            {
                lblThongTin.Text = "Cập nhật Không Thành Công";
                lblThongTin.Visible = true;
            }
            
        }
    }
}