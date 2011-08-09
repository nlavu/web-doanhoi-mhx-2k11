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
using System.IO;
using System.Collections.Generic;

namespace WebDoanHoi_layout
{
    public partial class gioithieu : System.Web.UI.Page
    {
        int magioithieu = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                PanelNoiDungAll.Visible = false;
                PanelNoiDungChiTiet.Visible = true;
                magioithieu = int.Parse(Request.QueryString["id"]);
                loadGioiThieu(magioithieu);

            }
            else
            {
                PanelNoiDungAll.Visible = true;
                PanelNoiDungChiTiet.Visible = false;
                loadDSGioiThieu();

            }
        }
        private void loadDSGioiThieu()
        {
            BUSGioiThieu GioiThieuBus = new BUSGioiThieu();
            List<GIOITHIEU> DSGioiThieu = GioiThieuBus.SelectGIOITHIEUsAll();

            string noidung = "";
            lblTieuDe.Font.Bold = true;
            lblTieuDe.Font.Size = 18;
            for (int i = 0; i < DSGioiThieu.Count(); i++)
            {
                noidung += "<a href='" + "gioithieu.aspx?id=" + DSGioiThieu[i].MaBai + "'> " + DSGioiThieu[i].TieuDe + "</a>";
                noidung += "<br />";
                noidung += DSGioiThieu[i].NoiDung;
                noidung += "<br /><hr><br />";
            }
            ltrNoiDung.Text = noidung;
           
        }
        private void loadGioiThieu(int magioithieu)
        {
            BUSGioiThieu BUSGioiThieu = new BUSGioiThieu();
            int MaBaiViet = int.Parse(Request.QueryString["id"]);
            GIOITHIEU GIOITHIEU = BUSGioiThieu.TimKiem(MaBaiViet);
            this.lblNoiDungBaiViet.Text = GIOITHIEU.NoiDung;

            lblTieuDe.Text = GIOITHIEU.TieuDe;
            lblTieuDe.Font.Bold = true;
            lblTieuDe.Font.Size = 18;
        }
    }
}
