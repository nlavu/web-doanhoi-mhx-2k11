using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDoanHoi_layout.wuc.search
{
    public partial class wucBaiVietSearch : System.Web.UI.UserControl
    {
        List<DTOAuction.BAIVIET> lstBaiViet;
        protected void Page_Load(object sender, EventArgs e)
        {           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadDB();
            GridView1.DataBind();                      
        }  
        protected void LoadDB()
        {           
            BUSAuction.BUSBaiViet bv = new BUSAuction.BUSBaiViet();
            lstBaiViet = bv.Search(TextBox1.Text, TextBox2.Text);
            GridView1.DataSource = lstBaiViet;
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