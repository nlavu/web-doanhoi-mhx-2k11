using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDoanHoi_layout.administration
{
    public partial class HDNoiBat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                     
                HttpCookie cookie = Request.Cookies.Get("myCookie");
                String username = cookie.Values["username"];

                if (username == null || username == "")
                {
                    Response.Redirect("~/administration/DangNhap.aspx?url=" + Request.Url.AbsoluteUri);
                }        
            if (!IsPostBack)
                LoadData();
           
        }
        private void LoadData()
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            try
            {
                string strRoot = Server.MapPath("/");
                xmlDoc.Load(strRoot + "XML\\QuanLyHDNoiBat.xml");
                txtEditor.Text = xmlDoc.OuterXml;
            }
            catch (Exception exp) { txtEditor.Text = "Lỗi load XML:" + exp.Message; };
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                string strRoot = Server.MapPath("/");
                xmlDoc.LoadXml(txtEditor.Text);
                xmlDoc.Save(strRoot + "XML\\QuanLyHDNoiBat.xml");
                lbStatus.ForeColor = System.Drawing.Color.Blue;
                lbStatus.Text = "Update thành công!";
            }
            catch (Exception exp)
            {
                lbStatus.ForeColor = System.Drawing.Color.Red;
                lbStatus.Text = "Lỗi! Không thể update:";
            }
        }
    }
}