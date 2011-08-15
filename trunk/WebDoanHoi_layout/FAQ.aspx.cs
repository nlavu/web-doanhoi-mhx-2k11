using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using BUSAuction;
using DTOAuction;
using System.IO;
using System.Collections.Generic;

namespace WebDoanHoi_layout
{
    public partial class FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                PanelNoiDungAll.Visible = false;
                PanelNoiDungChiTiet.Visible = true;
                int maCauHoi = int.Parse(Request.QueryString["id"]);
                timKiemCauTraLoi(maCauHoi);

            }
            else
            {
                PanelNoiDungAll.Visible = true;
                PanelNoiDungChiTiet.Visible = false;
                loadDanhSachTatCaCauHoi();
            }
        }

        private List<CAUHOITHUONGGAP> layDanhSachTatCaCauHoi()
        {
            BUSFAQ bus_FAQ = new BUSFAQ();
            List<CAUHOITHUONGGAP> lstCauHoi_All = bus_FAQ.LayDanhSachTatCaCauHoi();
            return lstCauHoi_All;
        }

        //int MaCauHoi = 0;

        private void loadDanhSachTatCaCauHoi()
        {
            List<CAUHOITHUONGGAP> lstCauHoi_All = layDanhSachTatCaCauHoi();

            string noiDungCauHoi_All = "";
            for (int i = 0; i < lstCauHoi_All.Count; i++)
            {
                int MaCauHoi = lstCauHoi_All[i].MaCauHoi;
                noiDungCauHoi_All += "<b><a href='" + "FAQ.aspx?id=" + MaCauHoi + "'> " + lstCauHoi_All[i].NoiDungCauHoi + "</a></b>";
                noiDungCauHoi_All += "<br />";
            }
            ltrNoiDung.Text = noiDungCauHoi_All;
        }

        private void timKiemCauTraLoi(int maCauHoi)
        {
            BUSFAQ bus_FAQ = new BUSFAQ();

            int MaBaiViet = int.Parse(Request.QueryString["id"]);
            CAUHOITHUONGGAP faq = bus_FAQ.TimKiem(MaBaiViet);
            string noiDungHienThi = "";
            noiDungHienThi += "<b><p>" + faq.NoiDungCauHoi + "</p></b>";
            noiDungHienThi += "<p>" + faq.CauTraLoi + "</p>";

            this.lblNoiDungBaiViet.Text = noiDungHienThi;
        }


    }
}