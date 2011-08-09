using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Windows.Forms;
using System.IO;

namespace WebDoanHoi_layout.administration.templateQuanLy.KhaoSat
{
    public partial class wucLichLamViec : System.Web.UI.UserControl
    {
        #region Ham Chung
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thong tin nguoi dung
         
            
            if (Request.QueryString["id"] != null)
            {
                int maTapTin = int.Parse(Request.QueryString["id"]);

                //lay thong tin va load len cac textbox
                BUSTapTinBaiViet busTapTinBaiViet = new BUSTapTinBaiViet();
                TAPTINBAIVIET tt = busTapTinBaiViet.TimKiemMaTapTin(maTapTin);

                string name = tt.TenTapTin.ToString();
                int subIndex = name.IndexOf('-');
                string dateStart = name.Substring(0, subIndex);
                string dateEnd = name.Substring(subIndex+1, name.Length - subIndex - 1);
                txtNgayBatDau.Text = dateStart;
                txtNgayKetThuc.Text = dateEnd;
            }
                
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (FileUploadLichLamViec.HasFile)
            {
                SaveFile(FileUploadLichLamViec.PostedFile,-1);
                Response.Redirect("LichLamViec.aspx");
            }
            else
                LabelUploadStatus.Text = "Bạn vẫn chưa chọn file để upload.";
        }
        void SaveFile(HttpPostedFile file,int id)
        {
            //Duong dan den thu muc Uploads tren server
            string savePath = Server.MapPath("~/Uploads\\");

            // Ten file upload
            string originalFileName = FileUploadLichLamViec.FileName;
            int pointIndex = originalFileName.LastIndexOf('.');
            string extension =  originalFileName.Substring(pointIndex,originalFileName.Length - pointIndex);

            string dateStart = txtNgayBatDau.Text;
            string dateEnd = txtNgayKetThuc.Text;
            string textFileName = dateStart + "-" + dateEnd;

            while (dateStart.IndexOf('/') > -1)
            {
                dateStart = dateStart.Remove(dateStart.IndexOf('/'), 1);
            }
            while (dateEnd.IndexOf('/') > -1)
            {
                dateEnd = dateEnd.Remove(dateEnd.IndexOf('/'), 1);
            }

            string fileName = dateStart + "-" + dateEnd + extension;
            
            
            // Tao duong dan de kiem tra xem file da ton tai chua
            string pathToCheck = savePath + fileName;
            string tempfileName = fileName;
            string tempTenTapTin = textFileName;
            bool overwrite = false;

            // Kiem tra xem da ton tai file co ten giong voi file nguoi dung muon up chua
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    DialogResult result;
                    string message = "Lịch Làm Việc " + textFileName + " đã tồn tại. Bạn có muốn cập nhật không?";
                    result = MessageBox.Show(message, "Caution", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                         //them (so) vao sau ten file
                        int point = fileName.LastIndexOf('.');
                        string nameNumber = "(" + counter.ToString() + ")";
                        tempfileName = fileName.Insert(point, nameNumber);
                        pathToCheck = savePath + tempfileName;
                        tempTenTapTin = textFileName + nameNumber;
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
                textFileName = tempTenTapTin;
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
            FileUploadLichLamViec.SaveAs(savePath);

            //Duong dan de tai file
            string linkDir = "~/Uploads/" + fileName;

            //Them vao bang TapTinBaiViet
            BUSTapTinBaiViet busTapTinBV = new BUSTapTinBaiViet();
            int maBaiViet = busTapTinBV.getMaBaiVietLichLamViec();
            if (maBaiViet == -1)
            {
                BUSChuyenMuc busChuyenMuc = new BUSChuyenMuc();
                CHUYENMUC cm = new CHUYENMUC();
                cm.TenChuyenMuc = "LLV";
                busChuyenMuc.Them(cm);
                cm = busChuyenMuc.TimKiemTen("LLV");

                BUSLoaiBaiViet busLoaiBV = new BUSLoaiBaiViet();
                LOAIBAIVIET lbv = new LOAIBAIVIET();
                lbv.MaChuyenMuc= cm.MaChuyenMuc;
                lbv.TenLoaiBaiViet = "LLV";
                busLoaiBV.Them(lbv);
                lbv = busLoaiBV.TimKiemTen("LLV");

                BUSBaiViet busBV = new BUSBaiViet();
                BAIVIET bv = new BAIVIET();
                bv.MaLoaiBaiViet = lbv.MaLoaiBaiViet;
                bv.TieuDe = "LLV";
                busBV.Them(bv);
                bv = busBV.TimKiemTieuDe("LLV");

                maBaiViet = bv.MaBaiViet;
            }
            if(id == -1)
            {
                if (overwrite == false)
                {
                    BUSTapTinBaiViet busTapTin = new BUSTapTinBaiViet();
                    int numberTapTin = busTapTin.TimSoLuongTapTin();
                    TAPTINBAIVIET lpDTO = new TAPTINBAIVIET();
                    lpDTO.TenTapTin = textFileName;
                    lpDTO.DuongDan = linkDir;
                    lpDTO.MaBaiViet = maBaiViet;
                    busTapTin.Them(lpDTO);
                }
                else
                {

                }
            }
            else
            {
                    BUSTapTinBaiViet busTapTin = new BUSTapTinBaiViet();
                    TAPTINBAIVIET lpDTO = busTapTin.TimKiemMaTapTin(id);
                    XoaFile(lpDTO.DuongDan);
                    lpDTO.TenTapTin = textFileName;
                    lpDTO.MaBaiViet = maBaiViet;
                    lpDTO.DuongDan = linkDir;
                    busTapTin.CapNhat(lpDTO);
            }
        }
        void XoaFile(string duongDan)
        {
            FileInfo f = new FileInfo(MapPath(duongDan));
            if (f.Exists)
            {
                f.Delete();
            }
            else
            {

            }
            
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int maTapTin = int.Parse(Request.QueryString["id"]);
                SaveFile(FileUploadLichLamViec.PostedFile, maTapTin);
            }
            else
            {
                LabelUploadStatus.Text = "Chưa chọn lịch làm việc để cập nhật";
            }

        }
        #endregion
    }
}