using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTOAuction;
using BUSAuction;

namespace WebDoanHoi_layout.wuc
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongDateString();
            //
            if (!IsPostBack)
            {
                string strMenu = "";
                strMenu = "<ul class='menu'>";
                strMenu += strMenuTrangChu();
                strMenu += strMenuGioiThieu();
                strMenu += strMenuHeThongToChuc();
                strMenu += strMenuHoatDong();
                strMenu += strMenuChuyenMuc();
                strMenu += strMenuHoTroSinhVien();
                strMenu += strMenuTienIch();
                strMenu += "</ul>";
                lblMenu.Text = strMenu;
            }
           
        }
        public string strMenuTrangChu()
        {
            string strMenu = "";
            strMenu += "<li>";
            strMenu += "<a class='parent' href='default.aspx'><span>Trang Chủ</span></a>";
            strMenu += "</li>";
            return strMenu;
        }
        public string strMenuGioiThieu()
        {
            BUSGioiThieu GioiThieuBUS = new BUSGioiThieu();
            int i;
            List<GIOITHIEU> DSGioiThieu = GioiThieuBUS.SelectGIOITHIEUsAll();
            string str = "";
            str += "<li>";
            str += "<a class='parent' href='GioiThieu.aspx'><span>Giới Thiệu</span></a>";
            str += "<div><ul>";
            for (i = 0; i < DSGioiThieu.Count(); i++)
            {
                
                str += "<li><a href='GioiThieu.aspx?id="+DSGioiThieu[i].MaBai.ToString()+"'><span>"+DSGioiThieu[i].TieuDe+"</span></a>";
               // MenuItem mn = new MenuItem(DSGioiThieu[i].TieuDe, "", "", "~/GioiThieu.aspx?id=" + DSGioiThieu[i].MaBai);
               // mnGioiThieu.ChildItems.Add(mn);
                str += "</li>";
                
            }
            str += "</ul></div";
            str += "</li>";
            return str;
        }
        public string strMenuHeThongToChuc()
        {
            string str = "";
            str += "<li>";
            str += "<a href='HeThongToChuc.aspx' class='parent'><span>Hệ Thống Tổ Chức</span></a>";
            str += "<div><ul>";
            BUSHeThongToChuc HttcBUS = new BUSHeThongToChuc();
            List<HETHONGTOCHUC> DSHttc = HttcBUS.SelectHETHONGTOCHUCsAll();
            int i;
            for (i = 0; i < DSHttc.Count(); i++)
            {
                str += "<li><a href='HeThongToChuc.aspx?id=" + DSHttc[i].MaBai.ToString() + "'><span>" + DSHttc[i].TieuDe + "</span></a>";
                //MenuItem mn = new MenuItem(DSHttc[i].TieuDe, "", "", "~/HeThongToChuc.aspx?id=" + DSHttc[i].MaBai);
                //mnHeThongToChuc.ChildItems.Add(mn);
            }
            str += "</ul></div>";
            str += "</li>";
            return str;
        }

        public string strMenuHoatDong()
        {
            string strMenu = "";
            strMenu += "<li>";
            strMenu += "<a class='parent' href='ChuyenMuc.aspx?id=8'><span>Thông tin Hoạt Động</span></a>";           
            BUSLoaiBaiViet LoaiBaiVietBUS = new BUSLoaiBaiViet();

            int i;
            strMenu += "<div><ul>";
            List<LOAIBAIVIET> DSLoaiBaiViet = LoaiBaiVietBUS.TimKiemLoaiBaiVietTheoChuyenMuc(8);
                  for (i = 0; i < DSLoaiBaiViet.Count(); i++)
                    {
                        strMenu += "<li><a href='LoaiBaiViet.aspx?id=" + DSLoaiBaiViet[i].MaLoaiBaiViet.ToString() + "'><span>" + DSLoaiBaiViet[i].TenLoaiBaiViet + "</span></a></li>";
                        // MenuItem mn = new MenuItem(DSLoaiBaiViet[j].TenLoaiBaiViet, "", "", "~/LoaiBaiViet.aspx?id=" + DSLoaiBaiViet[j].MaLoaiBaiViet);
                        // mnChuyenMuc.ChildItems[i + 3].ChildItems.Add(mn);
                        // mnItemChildItems.Add(mn);
                    }
              
            strMenu += "</ul></div>";
            strMenu += "</li>";
            return strMenu;
        }

        public string strMenuChuyenMuc()
        {
            string lblMenu = "";
            lblMenu += "<li>";
            lblMenu += "<a class='parent' href='#'><span>Chuyên Mục</span></a>";
            BUSChuyenMuc ChuyenMucBUS = new BUSChuyenMuc();
            List<CHUYENMUC> DSChuyenMuc = ChuyenMucBUS.SelectCHUYENMUCsAll_exception();
            BUSLoaiBaiViet LoaiBaiVietBUS = new BUSLoaiBaiViet();

            int i, j;
            lblMenu += "<div><ul>";
            for (i = 1; i < DSChuyenMuc.Count(); i++)
            {
                //MenuItem mnItem = new MenuItem(DSChuyenMuc[i].TenChuyenMuc, "", "");
                
                lblMenu += "<li><a href='ChuyenMuc.aspx?id="+ DSChuyenMuc[i].MaChuyenMuc.ToString()+"'><span>"+DSChuyenMuc[i].TenChuyenMuc+"</span></a>";
                List<LOAIBAIVIET> DSLoaiBaiViet = LoaiBaiVietBUS.TimKiemLoaiBaiVietTheoChuyenMuc(DSChuyenMuc[i].MaChuyenMuc);
                if (DSLoaiBaiViet.Count() != 0)
                {
                    lblMenu += "<div><ul>";
                    
                    for (j = 0; j < DSLoaiBaiViet.Count(); j++)
                    {
                        lblMenu += "<li><a href='LoaiBaiViet.aspx?id=" + DSLoaiBaiViet[j].MaLoaiBaiViet.ToString()+ "'><span>" + DSLoaiBaiViet[j].TenLoaiBaiViet + "</span></a></li>";
                       // MenuItem mn = new MenuItem(DSLoaiBaiViet[j].TenLoaiBaiViet, "", "", "~/LoaiBaiViet.aspx?id=" + DSLoaiBaiViet[j].MaLoaiBaiViet);
                        // mnChuyenMuc.ChildItems[i + 3].ChildItems.Add(mn);
                       // mnItem.ChildItems.Add(mn);
                    }
                    lblMenu += "</ul></div>";
                }
               // mnChuyenMuc.ChildItems.Add(mnItem);
                
            }
            lblMenu += "</ul></div>";
            lblMenu += "</li>";
            return lblMenu;
        }

        public string strMenuHoTroSinhVien()
        {
            BUSLoaiBaiViet LoaiBaiVietBUS = new BUSLoaiBaiViet();
            BUSChuyenMuc ChuyenMucBUS = new BUSChuyenMuc();
            List<CHUYENMUC> DSChuyenMuc = ChuyenMucBUS.SelectCHUYENMUCsAll();
            string strMenu = "";
            strMenu += "<li>";
            strMenu += "<a class='parent' href='ChuyenMuc.aspx?id=1'><span>Hỗ Trợ Sinh Viên</span></a>";
            
            int j;
           // MenuItem mnHoTroSinhVien = new MenuItem("Hỗ Trợ Sinh Viên", "", "", "~/default.aspx");
            List<LOAIBAIVIET> DSLoaiBaiVietHoTroSV = LoaiBaiVietBUS.TimKiemLoaiBaiVietTheoChuyenMuc(DSChuyenMuc[0].MaChuyenMuc);
            if (DSLoaiBaiVietHoTroSV.Count() != 0)
            {
                strMenu += "<div><ul>";
                for (j = 0; j < DSLoaiBaiVietHoTroSV.Count(); j++)
                {
                    //MenuItem mn = new MenuItem(DSLoaiBaiVietHoTroSV[j].TenLoaiBaiViet, "", "", "~/LoaiBaiViet.aspx?id=" + DSLoaiBaiVietHoTroSV[j].MaLoaiBaiViet);
                    //mnHoTroSinhVien.ChildItems.Add(mn);
                    strMenu += "<li><a href='LoaiBaiViet.aspx?id="+DSLoaiBaiVietHoTroSV[j].MaLoaiBaiViet.ToString()+"'><span>"+DSLoaiBaiVietHoTroSV[j].TenLoaiBaiViet+"</span></a></li>";
                }
                strMenu += "</ul></div>";
            }
           
            
            strMenu += "</li>";
            return strMenu;
        }
       
        public string strMenuTienIch()
        {
            string strMenu = "";
            strMenu += "<li>";
            strMenu += "<a class='parent' href='#'><span>Tiện Ích</span></a>";
            strMenu += "<div><ul>";
            strMenu += "<li><a href='LichLamViec2.aspx'><span>Lịch Làm Việc</span></a></li>";
//            strMenu += "<li><a href='MuonPhong.aspx'><span>Mượn phòng</span></a></li>";
             strMenu += "<li><a href='http://spreadsheets.google.com/viewform?formkey=dE5UVTZ1YlloZFJaQnZiZnlpdEJ3aEE6MA..'><span>Mượn Phòng</span></a></li>";
  //           strMenu += "<li><a href='http://doantn.hcmus.edu.vn/ket-qua-dang-ky-phong' ><span>Kết quả mượn Phòng</span></a></li>";
             strMenu += "<li><a href='https://sites.google.com/site/doantnkhtn/ket-qua-dang-ky-phong'><span>Kết quả mượn Phòng</span></a></li>";
            strMenu += "<li><a href='http://picasaweb.google.com/115481308871412250631?feat=flashalbum' ><span>Hình Ảnh Hoạt Động</span></a></li>";
            strMenu += "<li class='last'><a href='BaiHat.aspx'><span>Bài Hát</span></a></li>";
            strMenu += "</ul></div>";
            strMenu += "</li>";
            return strMenu;
        }
        //Le Van Long
        protected void ddlLienKet_SelectedIndexChanged(object sender, EventArgs e)
        {
            string link = ddlLienKet.SelectedValue;
            HyperLink hp = new HyperLink();
            hp.NavigateUrl = link;
            hp.Target = "_blank";
            Response.Redirect(link);
        }
    }   
}