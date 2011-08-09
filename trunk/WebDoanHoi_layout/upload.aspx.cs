using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BUSAuction;
using DTOAuction;

namespace WebDoanHoi_layout
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUploadClick(object sender, EventArgs e)
        {
            if (FileUploadHinhAnh.HasFile)
                SaveFile(FileUploadHinhAnh.PostedFile);
            else
                LabelUploadStatus.Text = "Bạn vẫn chưa chọn file để upload.";
        }
        void SaveFile(HttpPostedFile file)
        {
            //Duong dan den thu muc Uploads tren server
            string savePath = Server.MapPath("Uploads\\");

            // Ten file upload
            string fileName = FileUploadHinhAnh.FileName;

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
            FileUploadHinhAnh.SaveAs(savePath);

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
        }
    }
}
