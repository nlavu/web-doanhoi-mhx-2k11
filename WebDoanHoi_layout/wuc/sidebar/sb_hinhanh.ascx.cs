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
    public partial class sb_hinhanh : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
                lbAlBum.Text = LayDanhSachHinhAnh();
            }*/
        }
        /*
        protected string LayDanhSachHinhAnh()
        {

            BUSAlbum busalbum = new BUSAlbum();

            List<ALBUM> dsAlBum = busalbum.SelectALBUMsAll();
            string str = "";

            if (dsAlBum.Count() == 0)
            {
                str = "Không có album";
                return str;
            }
            str += "<table><tr>";

            int max = dsAlBum.Count;
            if (dsAlBum.Count > 4)
            {
                max = 4;
            }

            for (int i = 0; i < max; i++)//lay 4 album dau tien
            {

                str += "<td>&nbsp;&nbsp;<a href ='" + "Album.aspx?id=" + dsAlBum[i].MaAlbum + "'>" + dsAlBum[i].TenAlbum + "</a>&nbsp;&nbsp;</td>";
               
            }
            str += "</tr></table>";
            return str;
        }*/
    }
}