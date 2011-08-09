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
using DTOAuction;
using BUSAuction;
using System.Collections.Generic;


namespace WebDoanHoi_layout
{
    public partial class AlbumAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                lbAlBum.Text = LayDanhSachHinhAnh();
            }
        }

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
            int count = 0;
            for (int i = 0; i < dsAlBum.Count; i++)
            {
                if (count == 1)
                {
                    str+="</tr><tr>";
                    count = 0;
                }
                str += "<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href ='" + "Album.aspx?id=" + dsAlBum[i].MaAlbum + "'>" + dsAlBum[i].TenAlbum + "</a>&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                count++;
            }
            str += "</tr></table>";
            return str;
        }
    }
}
