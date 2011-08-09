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
using System.Windows.Forms;

namespace WebDoanHoi_layout
{
    public partial class BaiViet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
                LoadBaiViet();
        }
        protected void LoadBaiViet()
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                BUSBaiViet BaiVietBUS = new BUSBaiViet();
                int MaBaiViet = int.Parse(Request.QueryString["id"]);
                BAIVIET BaiViet = BaiVietBUS.TimKiem(MaBaiViet);
                lblNoiDungBaiViet.Text = BaiViet.NoiDung;
                lblTieuDe.Text = BaiViet.TieuDe;
                lblTieuDe.Font.Bold = true;
                lblTieuDe.Font.Size = 18;

                if (BaiViet.NgayDang != null)
                {
                    lblNgayDang.Text = "Ngày đăng: " + BaiViet.NgayDang.Value.Day + "/" + BaiViet.NgayDang.Value.Month + "/" + BaiViet.NgayDang.Value.Year;
                    lblNgayDang.Font.Italic = true;
                }
                else
                    lblNgayDang.Visible = false;

                BUSTapTinBaiViet busTapTinBaiViet = new BUSTapTinBaiViet();
                List<TAPTINBAIVIET> DStapTinBaiViet = busTapTinBaiViet.TimKiemMaBaiViet(MaBaiViet);
                if (DStapTinBaiViet != null)
                {
                    foreach(TAPTINBAIVIET ttbv in DStapTinBaiViet)
                    {
                        System.Web.UI.WebControls.MenuItem item = new System.Web.UI.WebControls.MenuItem("-" + ttbv.TenTapTin);
                        item.NavigateUrl = ttbv.DuongDan;
                        hplDownloadLink.Items.Add(item);
                    }
                }
            }
        }

       /* protected void btnUploadFilesClick(object sender, EventArgs e)
        {
            PanelUploadTapTinBaiViet.Visible = true;
            PanelBtnUpload.Visible = false;
        }

        protected void btnUploadClick(object sender, EventArgs e)
        {
            if (FileUploadTapTin.HasFile)
                SaveFile(FileUploadTapTin.PostedFile);
            else
                LabelUploadStatus.Text = "Bạn vẫn chưa chọn file để upload.";
        }

        void SaveFile(HttpPostedFile file)
        {
            //Duong dan den thu muc Uploads tren server
            string savePath = Server.MapPath("Uploads\\");

            // Ten file upload
            string fileName = FileUploadTapTin.FileName;

            // Tao duong dan de kiem tra xem file da ton tai chua
            string pathToCheck = savePath + fileName;
            string tempfileName = fileName;
            bool overwrite = false;

            // Kiem tra xem da ton tai file co ten giong voi file nguoi dung muon up chua
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    DialogResult result;
                    string message = "Tên file " + tempfileName + " đã tồn tại. Bạn có muốn ghi đè lên không?";
                    result = MessageBox.Show(message, "Caution", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        // them (so) vao sau ten file
                        int point = fileName.LastIndexOf('.');
                        string nameNumber = "(" + counter.ToString() + ")";
                        tempfileName = fileName.Insert(point, nameNumber);
                        pathToCheck = savePath + tempfileName;
                        counter++;
                    }
                    else
                    {
                        overwrite = true;
                        LabelUploadStatus.Text = "File của bạn đã được ghi đè thành công.";
                        break;
                    }
                }

                fileName = tempfileName;
                if (counter > 2)
                    LabelUploadStatus.Text = "File của bạn đã được ghi dưới tên: " + fileName;
            }
            else
            {
                // Thong bao la da upload thanh cong
                LabelUploadStatus.Text = "File của bạn đã được ghi thành công.";
            }

            savePath += fileName;

            //Luu file
            FileUploadTapTin.SaveAs(savePath);

            //Duong dan de tai file
            string linkDir = "~/Uploads/" + fileName;

            //Them vao bang TapTin
            //id la tham so truyen vao url, la id cua bai viet lien quan den tap tin

            if (Request.QueryString["id"] != null)
            {
                if (overwrite == false)
                {
                    int maBaiViet = int.Parse(Request.QueryString["id"]);

                    BUSTapTinBaiViet busTapTin = new BUSTapTinBaiViet();
                    int numberTapTin = busTapTin.TimSoLuongTapTin();
                    TAPTINBAIVIET lpDTO = new TAPTINBAIVIET();
                    lpDTO.TenTapTin = fileName;
                    lpDTO.DuongDan = linkDir;
                    lpDTO.MaBaiViet = maBaiViet;
                    lpDTO.MaTapTin = numberTapTin + 1;
                    busTapTin.Them(lpDTO);
                }
                else
                {
                    int maBaiViet = int.Parse(Request.QueryString["id"]);

                    BUSTapTinBaiViet busTapTin = new BUSTapTinBaiViet();
                    TAPTINBAIVIET lpDTO = busTapTin.TimKiemTenTapTin(fileName);

                    lpDTO.MaBaiViet = maBaiViet;
                    busTapTin.CapNhat(lpDTO);
                }
            }
        }*/
    }
}
