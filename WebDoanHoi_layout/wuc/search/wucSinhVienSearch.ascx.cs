using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAOAuction;
using DTOAuction;

namespace WebDoanHoi_layout.wuc.search
{
    public partial class wucSinhVienSearch : System.Web.UI.UserControl
    {
        public List<DTOAuction.NGUOIDUNG> lstNguoiDung;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                LoadDB();
                GridView1.DataBind();
            }
            
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            LoadDB();
            GridView1.DataBind();
            GridView1.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);            
        }
        private void LoadDB()
        {
            BUSAuction.BUSNguoiDung nguoidung = new BUSAuction.BUSNguoiDung();
            if (TextBox1.Text.Length > 0 && TextBox2.Text.Length > 0)
            {
                lstNguoiDung = nguoidung.TimKiem(TextBox1.Text, TextBox2.Text, 1);
            }
            else
            {
                if (TextBox1.Text.Length > 0)
                {
                    lstNguoiDung = nguoidung.TimKiem(TextBox1.Text, 1);
                }
                if (TextBox2.Text.Length > 0)
                {
                    lstNguoiDung = nguoidung.TimKiemHT(TextBox2.Text, 1);
                }
            }
            if (lstNguoiDung != null)
            {
                GridView1.DataSource = lstNguoiDung;
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDB();
                GridView1.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);
                GridView1.DataBind();
            }
            catch
            {
            }
        }  
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {                        
            GridView1.PageIndex = e.NewPageIndex;
            LoadDB();
            GridView1.DataBind();
        }       
    }
}