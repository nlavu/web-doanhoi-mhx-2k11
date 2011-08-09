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
    public partial class HeThongToChuc : System.Web.UI.Page
    {
        int maHETHONGTOCHUC = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                PanelNoiDungAll.Visible = false;
                PanelNoiDungChiTiet.Visible = true;
                maHETHONGTOCHUC = int.Parse(Request.QueryString["id"]);
                loadHETHONGTOCHUC(maHETHONGTOCHUC);

            }
            else
            {
                PanelNoiDungAll.Visible = true;
                PanelNoiDungChiTiet.Visible = false;
                loadDSHETHONGTOCHUC();

            }
        }
        private void loadDSHETHONGTOCHUC()
        {
            BUSHeThongToChuc HETHONGTOCHUCBus = new BUSHeThongToChuc();
            List<HETHONGTOCHUC> DSHETHONGTOCHUC = HETHONGTOCHUCBus.SelectHETHONGTOCHUCsAll();

            string noidung = "";
            lblTieuDe.Font.Bold = true;
            lblTieuDe.Font.Size = 18;
            for (int i = 0; i < DSHETHONGTOCHUC.Count(); i++)
            {
                noidung += "<a href='" + "HETHONGTOCHUC.aspx?id=" + DSHETHONGTOCHUC[i].MaBai + "'> " + DSHETHONGTOCHUC[i].TieuDe + "</a>";
                noidung += "<br />";
                noidung += DSHETHONGTOCHUC[i].NoiDung;
                noidung += "<br /><hr><br />";
            }
            ltrNoiDung.Text = noidung;

        }
        private void loadHETHONGTOCHUC(int maHETHONGTOCHUC)
        {
            BUSHeThongToChuc BUSHeThongToChuc = new BUSHeThongToChuc();
            int MaBaiViet = int.Parse(Request.QueryString["id"]);
            HETHONGTOCHUC HETHONGTOCHUC = BUSHeThongToChuc.TimKiem(MaBaiViet);
            this.lblNoiDungBaiViet.Text = HETHONGTOCHUC.NoiDung;

            lblTieuDe.Text = HETHONGTOCHUC.TieuDe;
            lblTieuDe.Font.Bold = true;
            lblTieuDe.Font.Size = 18;
        }
    }
}
