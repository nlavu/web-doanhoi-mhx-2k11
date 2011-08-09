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
using System.Globalization;
using System.IO;

namespace WebDoanHoi_layout.administration.templateQuanLy.HoatDong
{
    public partial class wucQuanLyHoatDong : System.Web.UI.UserControl
    {
        #region Ham Chung

        static string link;
        static string linkTemp;
        static string defaultLink = "~/Uploads/HinhAnhHoatDong/";

        protected bool KiemTra()
        {
            IFormatProvider culture = new CultureInfo("vi-VN", true);

            DateTime NgayDienRa = DateTime.Parse(txtngaydienra.Text, culture);
            DateTime ThoiGianBatDauDangKy = DateTime.Parse(txtthoigianbatdaudangky.Text, culture);
            DateTime ThoiGianKetThucDangKy = DateTime.Parse(txtthoigianketthucdangky.Text, culture);

            if (ThoiGianKetThucDangKy < ThoiGianBatDauDangKy)
            {
                lbThongBao.Text = "Ngày Kết Thúc Đăng Ký Phải Sau Ngày Bắt Đầu Đăng Ký";
                lbThongBao.Visible = true;
                return false;
            }
            else
                if (NgayDienRa < ThoiGianKetThucDangKy)
                {
                    lbThongBao.Text = "Ngày Diễn Ra Hoạt Động Phải Sau Ngày Kết Thúc Đăng Ký";
                    lbThongBao.Visible = true;
                    return false;
                }

            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Do loai hoat dong
                BUSLoaiHoatDong BUSLoaiHoatDong = new BUSLoaiHoatDong();
                ddlLoaiHoatDong.DataSource = BUSLoaiHoatDong.SelectLOAIHOATDONGsAll();
                ddlLoaiHoatDong.DataTextField = "TenLoaiHoatDong";
                ddlLoaiHoatDong.DataValueField = "MaLoaiHoatDong";
                ddlLoaiHoatDong.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    LoadHoatDong();
                }
            }
        }

        protected void LoadHoatDong()
        {
            //lay ma
            int mahoatdong = int.Parse(Request.QueryString["id"]);

            //lay thong tin va load len cac textbox
            BUSHoatDong BUSHoatDong = new BUSHoatDong();
            HOATDONG lpDTO = BUSHoatDong.TimKiem(mahoatdong);
            txttenhoatdong.Text = lpDTO.TenHoatDong;
            ddlLoaiHoatDong.SelectedValue = lpDTO.MaLoaiHoatDong.ToString();
            txtngaydienra.Text = ((DateTime)lpDTO.NgayDienRa).ToString("dd/MM/yyyy");
            txtthoigianbatdaudangky.Text = ((DateTime)lpDTO.ThoiGianBatDauDangKy).ToString("dd/MM/yyyy");
            txtthoigianketthucdangky.Text = ((DateTime)lpDTO.ThoiGianKetThucDangKy).ToString("dd/MM/yyyy");

            if (lpDTO.HinhAnh == "")
            {
                link = "";
                image.Visible = false;
            }
            else
            {
                if (lpDTO.HinhAnh != "")
                {
                    link = defaultLink + lpDTO.HinhAnh;
                    image.ImageUrl = link;
                    image.Visible = true;
                }
            }
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra() == false)
            {
                return;
            }

            try
            {
                //lay thong tin tu textbox
                HOATDONG lpDTO = new HOATDONG();
                lpDTO.MaHoatDong = int.Parse(Request.QueryString["id"]);
                lpDTO.TenHoatDong = txttenhoatdong.Text;
                lpDTO.MaLoaiHoatDong = int.Parse(ddlLoaiHoatDong.SelectedValue);
                //
                IFormatProvider culture = new CultureInfo("vi-VN", true);

                lpDTO.NgayDienRa = DateTime.Parse(txtngaydienra.Text, culture);
                lpDTO.ThoiGianBatDauDangKy = DateTime.Parse(txtthoigianbatdaudangky.Text, culture);
                lpDTO.ThoiGianKetThucDangKy = DateTime.Parse(txtthoigianketthucdangky.Text, culture);

                if (image.ImageUrl == link)
                {
                    lpDTO.HinhAnh = link.Substring(defaultLink.Length);
                }
                else
                {
                    if (image.ImageUrl != "")
                    {
                        lpDTO.HinhAnh = RenameHinhAnh(image.ImageUrl, lpDTO.TenHoatDong).Substring(defaultLink.Length);
                    }
                }

                //Goi ham cap nhat
                BUSHoatDong BUSHoatDong = new BUSHoatDong();
                if (BUSHoatDong.CapNhat(lpDTO) == 0)
                {
                    //Thong bao
                    lbThongBao.Text = "Cập Nhật Thành Công";
                    lbThongBao.Visible = true;
                    link = "";
                    linkTemp = "";
                    Response.Redirect("~/administration/HoatDong.aspx?id=" + Request.QueryString["id"]);
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

            DeleteHinhAnh(linkTemp);
            link = "";
            linkTemp = "";
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra() == false)
            {
                return;
            }

            try
            {
                //lay thong tin tu textbox
                HOATDONG lpDTO = new HOATDONG();                
                lpDTO.TenHoatDong = txttenhoatdong.Text;
                lpDTO.MaLoaiHoatDong = int.Parse(ddlLoaiHoatDong.SelectedValue);

                IFormatProvider culture = new CultureInfo("vi-VN", true);

                lpDTO.NgayDienRa = DateTime.Parse(txtngaydienra.Text, culture);
                lpDTO.ThoiGianBatDauDangKy = DateTime.Parse(txtthoigianbatdaudangky.Text, culture);
                lpDTO.ThoiGianKetThucDangKy = DateTime.Parse(txtthoigianketthucdangky.Text, culture);

                if (image.ImageUrl == link)
                {
                    lpDTO.HinhAnh = link.Substring(defaultLink.Length);
                }
                else
                {
                    if (image.ImageUrl != "")
                    {
                       lpDTO.HinhAnh = RenameHinhAnh (image.ImageUrl, lpDTO.TenHoatDong).Substring(defaultLink.Length);
                    }
                }

                //Goi ham cap nhat
                BUSHoatDong BUSHoatDong = new BUSHoatDong();
                if (BUSHoatDong.Them(lpDTO) == 1)
                {
                    //Thong bao
                    lbThongBao.Text = "Thêm Thành Công";
                    lbThongBao.Visible = true;
                    linkTemp = "";
                    link = "";
                    Response.Redirect("~/administration/HoatDong.aspx");
                }
                else
                {
                    lbThongBao.Text = "Thêm Không Thành Công";
                    lbThongBao.Visible = true;
                }
            }

            catch (Exception ex)
            {
                lbThongBao.Text = "Thêm Không Thành Công";
                lbThongBao.Visible = true;
                throw ex;
            }

            DeleteHinhAnh(linkTemp);
            linkTemp = "";
            link = "";
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //lay thong tin tu textbox
                int mahoatdong = int.Parse(Request.QueryString["id"]);

                BUSHoatDong BUSHoatDong = new BUSHoatDong();
                HOATDONG hoatdong = BUSHoatDong.TimKiem(mahoatdong);

                //xac nhan truoc khi xoa
              
              
                    //Goi ham xoa

                    BUSDangKyHoatDong BUSDangKyHoatDong = new BUSDangKyHoatDong();
                    BUSDangKyHoatDong.Xoa(mahoatdong);

                    if (BUSHoatDong.Xoa(mahoatdong) == 0)
                    {
                        //Thong bao
                        lbThongBao.Text = "Xóa Thành Công";
                        lbThongBao.Visible = true;
                        DeleteHinhAnh(link);
                        link = "";
                        Response.Redirect("~/administration/HoatDong.aspx");
                    }
                    else
                    {
                        lbThongBao.Text = "Xóa Không Thành Công";
                        lbThongBao.Visible = true;
                    }
                
             
            }

            catch 
            {
                lbThongBao.Text = "Xóa Không Thành Công";
                lbThongBao.Visible = true;
            }
        }
        #endregion

        protected void DeleteHinhAnh(string path)
        {
            try
            {
                FileInfo theFile = new FileInfo(Server.MapPath(path));
                if (theFile.Exists)
                {
                    File.Delete(Server.MapPath(path));
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (FileNotFoundException)
            {

            }
            catch (System.Exception)
            {

            }
        }

        protected string RenameHinhAnh(string oldPath, string newName)
        {
            try
            {
                FileInfo theFile = new FileInfo(Server.MapPath(oldPath));
                if (theFile.Exists)
                {
                    string originalFileName = oldPath;
                    int pointIndex = originalFileName.LastIndexOf('.');
                    string extension = originalFileName.Substring(pointIndex, originalFileName.Length - pointIndex);

                    string fileName = defaultLink + newName + extension;

                    File.Move(Server.MapPath(oldPath), Server.MapPath(fileName));

                    return fileName;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (FileNotFoundException)
            {
                return "";
            }
            catch (System.Exception)
            {
                return "";
            }
        }

        protected void btLoad_Click(object sender, EventArgs e)
        {
            if (FileUpload.FileName != "")
            {
                string originalFileName = FileUpload.FileName;
                int pointIndex = originalFileName.LastIndexOf('.');
                string extension = originalFileName.Substring(pointIndex, originalFileName.Length - pointIndex);

                string textFileName = "temp";

                string fileName = textFileName + extension;


                string savePath = Server.MapPath(defaultLink) + fileName;

                FileUpload.SaveAs(savePath);

                image.ImageUrl = defaultLink + fileName;
                image.Visible = true;

                linkTemp = image.ImageUrl;
            }
            else
            {
                linkTemp = "";
            }
        }

        protected void XoaDKHoatDong()
        {
            int mahoatdong = int.Parse(Request.QueryString["id"]);
        }
    }
}