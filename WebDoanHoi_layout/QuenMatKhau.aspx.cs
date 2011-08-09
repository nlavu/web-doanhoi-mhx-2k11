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

namespace WebDoanHoi_layout
{
    public partial class QuenMatKhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btLayMatKhau_Click(object sender, EventArgs e)
        {

            if (txtMSSV.Text == "")
            {
                txtThongTin.Text = "Vui lòng nhập MSSV";
                txtThongTin.Visible = true;
                return;
            }

            if (txtEmail.Text == "")
            {
                txtThongTin.Text = "Vui lòng nhập địa chỉ Email";
                txtThongTin.Visible = true;
                return;
            }

            BUSNguoiDung busnguoidung = new BUSNguoiDung();

            NGUOIDUNG sv = busnguoidung.TimKiemTheoUsernameVaEmail(txtMSSV.Text, txtEmail.Text);

            if (sv == null)
            {
                txtThongTin.Text = "MSSV hoặc email không đúng, vui lòng nhập lại.";
            }
            else
            {
                sv.Password = txtMSSV.Text;

                busnguoidung.CapNhat(sv);

                txtThongTin.Text = "Mật khẩu mới của bạn là " + txtMSSV.Text;
            }

            txtThongTin.Visible = true;
        }
    }
}
