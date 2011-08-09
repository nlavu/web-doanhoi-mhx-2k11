using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace WebDoanHoi_layout.administration.templateQuanLy.BaiViet
{
    public partial class wucQuanLyBaiViet : System.Web.UI.UserControl
    {
        static BAIVIET BaiVietTemp = new BAIVIET();
        #region Ham Chung
        #region Đức 17/8
        protected void Page_Load(object sender, EventArgs e)
        {          
            load();
        }
        public int LoadTapTin()
        {
            List<TAPTINBAIVIET> lt = new List<TAPTINBAIVIET>();
            BUSTapTinBaiViet BUSTapTinBaiViet = new BUSTapTinBaiViet();
            int sodong;
            BaiVietTemp = (BAIVIET)Session["BaiVietTemp"];
            lt = BUSTapTinBaiViet.TimKiemMaBaiViet(BaiVietTemp.MaBaiViet);
            if (lt != null)
            {
                this.GridViewTapTin.DataSource = lt;
                GridViewTapTin.DataBind();
                PanelMessage.Visible = false;
                PanelDanhSach.Visible = true;
                sodong = lt.Count;
            }
            else
            {
                //lt = new List<TAPTINBAIVIET>();
               // this.GridViewTapTin.DataSource = lt;
               // GridViewTapTin.DataBind();
                PanelMessage.Visible = true;
                PanelDanhSach.Visible = true;
                sodong = 0;
            }
            Session.Add("GridViewTapTinDataSource", lt);
            List<TAPTINBAIVIET> lFileTemp = new List<TAPTINBAIVIET>();
            Session.Add("FileUploadTemp", lFileTemp);
            List<HttpPostedFile> lFileClientPath = new List<HttpPostedFile>();
            Session.Add("FileClientTemp", lFileClientPath);
            return sodong;
        }

        protected void load()
        {
            //Thong tin nguoi dung
            
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    //lay ma
                    int mabaiviet = int.Parse(Request.QueryString["id"]);
                    BUSBaiViet BUSBaiViet = new BUSBaiViet();
                    BAIVIET lpDTO = BUSBaiViet.TimKiem(mabaiviet);
                    BaiVietTemp = lpDTO;
                    Session.Add("BaiVietTemp", BaiVietTemp);
                    BUSChuyenMuc BUSChuyenMuc = new BUSChuyenMuc();
                    CHUYENMUC cmDTO = BUSChuyenMuc.LayChuyenMucTheoBaiViet((int)lpDTO.MaLoaiBaiViet);
                    //this.txtngaydang.Text = dt.ToString("dd/MM/yyyy");
                    this.txtnoidung.Value = lpDTO.NoiDung;
                    this.txtTomTat.Text = lpDTO.TomTat;
                    this.txttieude.Text = lpDTO.TieuDe;
                    this.lblNgayDang.Text = lpDTO.NgayDang.ToString();
                    this.lblNgayCapNhat.Text = lpDTO.CapNhat.ToString();
                    if (lpDTO.HinhAnh != "")
                    {
                        this.imgAnhDaiDien.ImageUrl = @"~\Uploads/" + lpDTO.HinhAnh;
                    }
                    // load ddl
                    load_ddlChuyenMuc();
                    ddlChuyenMuc.SelectedValue = cmDTO.MaChuyenMuc.ToString();
                    load_ddlLBV(cmDTO.MaChuyenMuc);
                    ddlLoaiBaiViet.SelectedValue = lpDTO.MaLoaiBaiViet.ToString();
                    int soDong = LoadTapTin();
                    FilterSTT(soDong, 0, 30);
                    PanelBtnUpload.Visible = true;
                }
                else
                {
                    load_ddlChuyenMuc();
                    ddlChuyenMuc.SelectedValue = "1";
                    load_ddlLBV(1);
                    PanelBtnUpload.Visible = false;
                }
            }

        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewTapTin.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        #endregion
        protected void load_ddlChuyenMuc()
        {
            // load ddlChuyenMuc
            ddlChuyenMuc.Items.Clear();
            BUSChuyenMuc BUSChuyenMuc = new BUSChuyenMuc();
            List<CHUYENMUC> lstCM = BUSChuyenMuc.SelectCHUYENMUCsAll();
            for (int i = 0; i < lstCM.Count; i++)
            {
                ListItem li = new ListItem(lstCM[i].TenChuyenMuc.ToString(), lstCM[i].MaChuyenMuc.ToString());
                this.ddlChuyenMuc.Items.Add(li);
            }

        }
        protected void load_ddlLBV(int machuyenmuc)
        {
            ddlLoaiBaiViet.Items.Clear();
            // load ddlLoaiBaiViet
            BUSLoaiBaiViet BUSLoaiBaiViet = new BUSLoaiBaiViet();
            List<LOAIBAIVIET> lstLBV = BUSLoaiBaiViet.TimKiemLoaiBaiVietTheoChuyenMuc(machuyenmuc);
            for (int i = 0; i < lstLBV.Count; i++)
            {
                ListItem li = new ListItem(lstLBV[i].TenLoaiBaiViet.ToString(), lstLBV[i].MaLoaiBaiViet.ToString());
                this.ddlLoaiBaiViet.Items.Add(li);
            }
        }
        protected void ddlChuyenMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_ddlLBV(int.Parse(ddlChuyenMuc.SelectedValue));
        }
        #region Đức sửa 17/8
        #region chỉnh sửa ảnh đại diện
        public bool ThumbnailCallback()
        {
            return false;
        }
        protected System.Drawing.Image getThumbnailImage(string imgFileName)
        {
            System.Drawing.Image.GetThumbnailImageAbort myCallback =
        new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            Bitmap myBitmap = new Bitmap(imgFileName);
            System.Drawing.Image myThumbnail = myBitmap.GetThumbnailImage(
            400, 400, myCallback, IntPtr.Zero);
            myBitmap.Dispose();
            return myThumbnail;
        }
        protected Bitmap resizeImage(string imgFileName)
        {
          System.Drawing.Image img = System.Drawing.Image.FromFile(imgFileName);
        
            int maxHeight = 400;
            int maxWidth = 400;
             int newHeight;
            int newWidth;
            float percent;
            if (img.Width > img.Height)
            {

                if (img.Width > maxWidth)
                {
                    percent = (float)maxWidth/img.Width;
                }
                else
                {
                    percent = 1;
                }
            }
            else
            {
               
                if (img.Height > maxHeight)
                {
                    percent = (float)maxHeight/img.Height;
                }
                else
                {
                    percent = 1;
                }
            }
            newHeight = (int)(img.Height * percent);
            newWidth = (int)(img.Width * percent);
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);
            Graphics graphic = Graphics.FromImage((System.Drawing.Image)resizedImage);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //draw the newly resized image
            graphic.DrawImage(img, 0, 0, newWidth, newHeight);
            //dispose and free up the resources
            graphic.Dispose();
            img.Dispose();
            return resizedImage;
        }
        protected void SaveImageThumbnail(string imgSourceFile, string desPath, bool deleteSource)
        {
           Bitmap img = resizeImage(imgSourceFile);
            
            img.Save(desPath, System.Drawing.Imaging.ImageFormat.Png);
            img.Dispose();
            if (deleteSource == true)
                System.IO.File.Delete(imgSourceFile);
        }
        #endregion


        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                BAIVIET lpDTO = new BAIVIET();
                lpDTO.MaBaiViet = int.Parse(Request.QueryString["id"]);
                lpDTO.MaLoaiBaiViet = int.Parse(ddlLoaiBaiViet.SelectedValue);
                lpDTO.NgayDang = Convert.ToDateTime(lblNgayDang.Text);
                lpDTO.CapNhat = Convert.ToDateTime(System.DateTime.Now);
                lpDTO.NoiDung = this.txtnoidung.Value;
                lpDTO.TieuDe = this.txttieude.Text;
                lpDTO.TomTat = this.txtTomTat.Text;
                BaiVietTemp = (BAIVIET)Session["BaiVietTemp"];
                BUSBaiViet BUSBaiViet = new BUSBaiViet();
                if (this.fulImage.HasFile)
                {
                   // if (BaiVietTemp.HinhAnh != null && BaiVietTemp.HinhAnh != "")
                   //     System.IO.File.Delete(Server.MapPath("~/Uploads/") + BaiVietTemp.HinhAnh);
                    String currentPath = Server.MapPath("~/Uploads/");
                    String tempPath = Server.MapPath("~/Temp/");
                    String fileName = "anh_dai_dien" + lpDTO.NgayDang.Value.Day.ToString()
                        + lpDTO.NgayDang.Value.Month.ToString() + lpDTO.NgayDang.Value.Year.ToString()
                        + lpDTO.NgayDang.Value.Hour.ToString() + lpDTO.NgayDang.Value.Minute.ToString() + lpDTO.NgayDang.Value.Second.ToString() + ".jpg";
                    lpDTO.HinhAnh = fileName;
                   this.fulImage.SaveAs(tempPath + fileName);
                   SaveImageThumbnail(tempPath + fileName, currentPath + fileName, true);             
                }
                else
                {
                    lpDTO.HinhAnh = BaiVietTemp.HinhAnh;
                }
                //Goi ham cap nhat

                if (BUSBaiViet.CapNhat(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
//                     //Upload tập tin
//                     List<TAPTINBAIVIET> lTapTinDTO = new List<TAPTINBAIVIET>();
//                     string savePath = Server.MapPath("~/Uploads\\");
// 
//                     //string fileName;
//                     lTapTinDTO = (List<TAPTINBAIVIET>)Session["FileUploadTemp"];
//                     List<HttpPostedFile> lFile = (List<HttpPostedFile>)Session["FileClientTemp"];
//                     BUSTapTinBaiViet BUSTapTinBaiViet = new BUSTapTinBaiViet();
//                     for (int i = 0; i < lTapTinDTO.Count && i < lFile.Count; i++)
//                     {
//                         lFile[i].SaveAs(savePath + lTapTinDTO[i].TenTapTin);
//                         if (BUSTapTinBaiViet.Them(lTapTinDTO[i]) == 0)
//                         {
//                             MessageBox.Show("Upload tập tin " + lTapTinDTO[i].TenTapTin + " thất bại.");
// 
//                         }
           //         }
                    lbThongBao.Visible = true;
                    Response.Redirect("~/administration/BaiViet.aspx?id=" + lpDTO.MaBaiViet.ToString());
                }
                else
                {
                    lbThongBao.Text = "Cập Nhật Không Thành Công";
                    lbThongBao.Visible = true;
                }
            }

            catch 
            {
                lbThongBao.Text = "Cập nhật Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        #endregion
        #region Đức sửa hàm Thêm 17/8
        protected void btnThem_Click(object sender, EventArgs e)
        {
            //txtngaydang.Text = DateTime.Now.ToShortDateString();
            try
            {
                //lay thong tin tu textbox
                BAIVIET lpDTO = new BAIVIET();

                lpDTO.MaLoaiBaiViet = int.Parse(ddlLoaiBaiViet.SelectedValue);
                lpDTO.NgayDang = Convert.ToDateTime(System.DateTime.Now);
                lpDTO.NoiDung = this.txtnoidung.Value;
                lpDTO.TieuDe = this.txttieude.Text;
                //Nhi sửa: thêm phần tóm tắt bài viết 11/8/2010
                lpDTO.TomTat = this.txtTomTat.Text;
                if (this.fulImage.HasFile)
                {
                    String currentPath = Server.MapPath("~/Uploads/");
                    String tempPath = Server.MapPath("~/Temp/");
                    String fileName = "anh_dai_dien" + lpDTO.NgayDang.Value.Day.ToString()
                        + lpDTO.NgayDang.Value.Month.ToString() + lpDTO.NgayDang.Value.Year.ToString()
                        + lpDTO.NgayDang.Value.Hour.ToString() + lpDTO.NgayDang.Value.Minute.ToString() + lpDTO.NgayDang.Value.Second.ToString() + ".jpg";
                    lpDTO.HinhAnh = fileName;
                    this.fulImage.SaveAs(tempPath + fileName);
                    SaveImageThumbnail(tempPath + fileName, currentPath + fileName, true);
                    
                }

                //Goi ham cap nhat
                BUSBaiViet BUSBaiViet = new BUSBaiViet();
                if (BUSBaiViet.Them(lpDTO) == 1)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    Response.Redirect("BaiViet.aspx");
                }
                else
                {
                    lbThongBao.Text = "Thêm Không Thành Công";
                    lbThongBao.Visible = true;
                }
            }

            catch 
            {
                lbThongBao.Text = "Thêm Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        #endregion Đức  5/8
        #region Đức sửa hàm Xóa 4/8
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                int mabaiviet = int.Parse(Request.QueryString["id"]);

                //xac nhan truoc khi xoa
              
                    BUSBaiViet BUSBaiViet = new BUSBaiViet();
                    if (BUSBaiViet.Xoa(mabaiviet) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        Response.Redirect("BaiViet.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Xóa Không Thành Công";
                        lbThongBao.Visible = true;
                    }
               
            }

            catch 
            {
                lbThongBao.Text = "Xoa Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        #endregion

        #endregion

        #region Upload file
        protected void btnUploadFiles_Click(object sender, EventArgs e)
        {
            PanelUploadTapTinBaiViet.Visible = true;
            PanelBtnUpload.Visible = false;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (FileUploadTapTin.HasFile)
            {
                SaveFile(FileUploadTapTin.PostedFile);
            }
            else
            {
                LabelUploadStatus.Text = "Bạn vẫn chưa chọn file để upload.";
            }
        }
        void SaveFile(HttpPostedFile file)
        {
            //Duong dan den thu muc Uploads tren server
            string savePath = Server.MapPath("~/Uploads\\TapTin");

            // Ten file upload
            string fileName = FileUploadTapTin.FileName;

            // Tao duong dan de kiem tra xem file da ton tai chua
            string pathToCheck = savePath + Path.DirectorySeparatorChar+ fileName;
            string tempfileName = fileName;
            //bool overwrite = false;

            // Kiem tra xem da ton tai file co ten giong voi file nguoi dung muon up chua
            if (System.IO.File.Exists(pathToCheck))
            {
   
                LabelUploadStatus.Text = "Tập tin trùng với tập tin đã có trên csdl";
            }
            else
            {
                file.SaveAs(savePath+ Path.DirectorySeparatorChar +fileName);
                // Thong bao la da upload thanh cong               
                TAPTINBAIVIET ttbvDTO = new TAPTINBAIVIET();
                ttbvDTO.TenTapTin = fileName;
                string linkDir = "~/Uploads/TapTin/" + fileName;
                ttbvDTO.DuongDan = linkDir;
                ttbvDTO.MaBaiViet = int.Parse(Request.QueryString["id"]);
                BUSTapTinBaiViet bus = new BUSTapTinBaiViet();
                bus.Them(ttbvDTO);
                List<TAPTINBAIVIET> gvTapTinDS = bus.TimKiemMaBaiViet(int.Parse(Request.QueryString["id"]));
           //     gvTapTinDS.Add(ttbvDTO);
                this.GridViewTapTin.DataSource = gvTapTinDS;
                this.GridViewTapTin.DataBind();
                FilterSTT(gvTapTinDS.Count, 0, 30);
                ((List<TAPTINBAIVIET>)Session["FileUploadTemp"]).Add(ttbvDTO);
                ((List<HttpPostedFile>)Session["FileClientTemp"]).Add(file);
            }

        }

        #endregion

        protected void imgBtnXoa_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void GridViewTapTin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XoaTapTin")
            {
                int idBV = Convert.ToInt32(e.CommandArgument);


                //List<BAIVIET> lt = new List<BAIVIET>();

                //BUSBaiViet busBaiViet = new BUSBaiViet();
                //lt = busBaiViet.SelectBAIVIETsAll();

                BUSTapTinBaiViet bus = new BUSTapTinBaiViet();
                bus.Xoa(idBV);
                List<TAPTINBAIVIET> gvTapTinDS = bus.TimKiemMaBaiViet(int.Parse(Request.QueryString["id"]));
                //     gvTapTinDS.Add(ttbvDTO);
                this.GridViewTapTin.DataSource = gvTapTinDS;
                this.GridViewTapTin.DataBind();
                FilterSTT(gvTapTinDS.Count, 0, 30);
            }
        }


    }
}