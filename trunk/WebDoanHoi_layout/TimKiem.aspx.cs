using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDoanHoi_layout
{
    public partial class TimKiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.PlaceHolder1.Visible = true;
            this.PlaceHolder2.Visible = false;
            this.PlaceHolder3.Visible = false;
            Label1.Text = "Tìm Kiếm Sinh Viên";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            this.PlaceHolder1.Visible = false;
            this.PlaceHolder2.Visible = true;
            this.PlaceHolder3.Visible = false;
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownList1.SelectedValue)
            {
                case "Sinh viên":
                    this.PlaceHolder1.Visible = true;
                    this.PlaceHolder2.Visible = false;
                    this.PlaceHolder3.Visible = false;
                    Label1.Text = "Tìm Kiếm Sinh Viên";
                    break;
                case "Bài viết":
                    this.PlaceHolder1.Visible = false;
                    this.PlaceHolder2.Visible = true;
                    this.PlaceHolder3.Visible = false;
                    Label1.Text = "Tìm Kiếm Bài Viết";
                    break;
                case "Họat động":
                    this.PlaceHolder1.Visible = false;
                    this.PlaceHolder2.Visible = false;
                    this.PlaceHolder3.Visible = true;
                    Label1.Text = "Tìm Kiếm Họat Động";
                    break;
                default:
                    this.PlaceHolder1.Visible = false;
                    this.PlaceHolder2.Visible = false;
                    this.PlaceHolder3.Visible = false;
                    Label1.Text = "Tìm Kiếm";
                    break;
            }
        }
    }
}