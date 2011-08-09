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
    public partial class GopY : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra đã đăng nhập nếu cần
            if (!IsPostBack)
            {
                txtNoiDungGopY.Text = "";
                txtMSSV.Text = "";
                txtEmail.Text = "";
            }
        }

        protected void btGopY_Click1(object sender, EventArgs e)
        {
            //Lấy user và email
     
         
            if (txtTieuDe.Text == "")
            {
                lblThongTin.Text = "Vui lòng tiêu đề của góp ý!";
                lblThongTin.Visible = true;
                return;
            }
            if (txtNoiDungGopY.Text == "")
            {
                lblThongTin.Text = "Vui lòng nhập nội dung góp ý của bạn!";
                lblThongTin.Visible = true;
                return;
            }
            if (txtMSSV.Text == "")
            {
                lblThongTin.Text = "Vui lòng nhập MSSV!";
                lblThongTin.Visible = true;
                return;
            }
            if (txtEmail.Text == "")
            {
                lblThongTin.Text = "Vui lòng nhập địa chỉ Email!";
                lblThongTin.Visible = true;
                return;
            }

            //BUSNguoiDung busnguoidung = new BUSNguoiDung();

            //NGUOIDUNG sv = busnguoidung.TimKiemTheoUsernameVaEmail(txtMSSV.Text, txtEmail.Text);

            //if (sv == null)
            //{
            //    lblThongTin.Text = "MSSV hoặc email không đúng, vui lòng nhập lại.";
            //}
            //else
            {
                BUSGopY busGopY = new BUSGopY();
                GOPY gopY = new GOPY();
                gopY.TieuDe = txtTieuDe.Text;
                gopY.NoiDungGopY = txtNoiDungGopY.Text;
                gopY.MSSV = txtMSSV.Text;
                gopY.Email = txtEmail.Text;
                int res = busGopY.Them(gopY);
                if (res == 1)
                {
                    lblEmail.Visible = false;
                    lblTieuDe.Visible = false;
                    lblMSSV.Visible = false;
                    lblNoiDung.Visible = false;
                    txtTieuDe.Visible = false;
                    lblThongBao.Visible = false;
                    txtMSSV.Visible = false;
                    txtEmail.Visible = false;
                    txtNoiDungGopY.Visible = false;
                    btGopY.Visible = false;
                    lblThongTin.Text = "Cảm ơn bạn đã đóng góp ý kiến nhằm giúp phát triển website!";
                }
                else lblThongTin.Text = "Chưa thực hiện được!";
            }
           
            
        }
    }
}