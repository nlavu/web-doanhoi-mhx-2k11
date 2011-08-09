using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDoanHoi_layout.wuc.search
{
    public partial class wucHoatDongSearch : System.Web.UI.UserControl
    {        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LoadDB()
        {
            //if (TextBox1.Text.Equals(""))
            //    return;
            BUSAuction.BUSHoatDong hoatdong = new BUSAuction.BUSHoatDong();
            GridView1.DataSource = hoatdong.TimKiemTen(TextBox1.Text);          
           
        }
        public void Button1_Click(object sender, EventArgs e)
        {
            LoadDB();      
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadDB();
            DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);
            LoadDB();
            DataBind();
        }
       
    }
}