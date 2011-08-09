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
using System.Collections.Generic;
using System.Web.UI.MobileControls;
using ExcelCOM = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;

namespace WebDoanHoi_layout.wuc
{
    public partial class wucDangKyHoatDong_HD : System.Web.UI.UserControl
    {
        string fileSave;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Đăng Ký Hoạt Động";

            if (!IsPostBack)
            {
                int soDong = LoadDangKyHoatDong();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewDangKyHoatDong.HeaderStyle.CssClass = "headerstyle";
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewDangKyHoatDong.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadDangKyHoatDong()
        {
            List<DANGKYHOATDONG_get_MaHoatDongResult> lt = new List<DANGKYHOATDONG_get_MaHoatDongResult>();

            BUSDangKyHoatDong BUSDangKyHoatDong = new BUSDangKyHoatDong();

            lt = BUSDangKyHoatDong.SelectDANGKYHOATDONGs_HoatDong(int.Parse(Request.QueryString["id"]));
            if (lt.Count > 0)
            {
                this.GridViewDangKyHoatDong.DataSource = lt;
                GridViewDangKyHoatDong.DataBind();
                PanelDanhSach.Visible = true;
                PanelMessage.Visible = false;
                return lt.Count;
            }
            else
            {
                PanelDanhSach.Visible = false;
                PanelMessage.Visible = true;
                return 0;
            }
        }

        //Chon Phan Trang Theo y nguoi dung: 5, 10, 15, 20,..
        protected void DropDownListPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewDangKyHoatDong.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadDangKyHoatDong();
            FilterSTT(SoDong, GridViewDangKyHoatDong.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewDangKyHoatDong_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewDangKyHoatDong.PageIndex = e.NewPageIndex;
            int SoDong = LoadDangKyHoatDong();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }

        protected void btExport_Click(object sender, EventArgs e)
        {
            BUSHoatDong bushoatdong = new BUSHoatDong();
            HOATDONG hoatdong = bushoatdong.TimKiem(int.Parse(Request.QueryString["id"]));
            fileSave = "Chi_Tiet_Dang_Ky_Hoat_Dong_" + hoatdong.TenHoatDong + ".xls";

            ExportToExcel();

            Response.Redirect("~\\Download\\" + fileSave);
        }

        protected void ExportToExcel()
        {
            string path = Server.MapPath("Download\\" + fileSave);

            try
            {
                FileInfo theFile = new FileInfo(path);
                if (theFile.Exists)
                {
                    File.Delete(path);
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


            ExcelCOM.Application app = new ExcelCOM.Application();
            ExcelCOM.Workbook workbook = app.Workbooks.Add(ExcelCOM.XlWBATemplate.xlWBATWorksheet);
            ExcelCOM.Worksheet sheet = (ExcelCOM.Worksheet)workbook.Worksheets[1];

            try
            {
                sheet.Name = "Chi Tiết Đăng Ký Hoạt Động";

                WriteTitle(sheet);
                WriteDataGridView(sheet);

                app.Visible = false;

                workbook.SaveAs(path, ExcelCOM.XlFileFormat.xlWorkbookNormal,
                                null, null, false, false,
                                ExcelCOM.XlSaveAsAccessMode.xlExclusive,
                                false, false, false, false, false);

                workbook.Close(false, false, false);
                app.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            catch (Exception)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                return;
            }
        }

        protected void WriteTitle(ExcelCOM.Worksheet worksheet)
        {
            BUSHoatDong bushoatdong = new BUSHoatDong();
            HOATDONG hoatdong = bushoatdong.TimKiem(int.Parse(Request.QueryString["id"]));

            ExcelCOM.Range sheetTitle = (ExcelCOM.Range)worksheet.get_Range("A1", "D1");
            sheetTitle.MergeCells = true;
            sheetTitle.Value2 = "Chi Tiết Đăng Ký Hoạt Động " + hoatdong.TenHoatDong;
            sheetTitle.Font.Bold = true;
            sheetTitle.Font.Size = 20;
            sheetTitle.HorizontalAlignment = ExcelCOM.XlHAlign.xlHAlignCenter;
            sheetTitle.Rows.AutoFit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheetTitle);

            for (int i = 0; i < GridViewDangKyHoatDong.Columns.Count; i++)
            {
                WriteIndexColumn(worksheet, 3, i + 1, GridViewDangKyHoatDong.Columns[i].ToString());
            }
        }

        protected void WriteIndexColumn(ExcelCOM.Worksheet worksheet, int rowIndex, int colIndex, object value)
        {
            ExcelCOM.Range rng = (ExcelCOM.Range)worksheet.Cells[rowIndex, colIndex];
            rng.Select();
            rng.Value2 = value.ToString();
            rng.Columns.EntireColumn.AutoFit();
            rng.Rows.EntireRow.AutoFit();
            rng.Borders.Weight = ExcelCOM.XlBorderWeight.xlThin;
            rng.Borders.LineStyle = ExcelCOM.XlLineStyle.xlContinuous;
            rng.Borders.ColorIndex = ExcelCOM.XlColorIndex.xlColorIndexAutomatic;
            rng.Font.Bold = true;
            rng.Font.Underline = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
        }

        protected void WriteDataGridView(ExcelCOM.Worksheet worksheet)
        {
            int rowIndex = 4;
            int colIndex = 1;

            for (int i = 0; i < GridViewDangKyHoatDong.Rows.Count; i++)
            {
                for (int j = 0; j < GridViewDangKyHoatDong.Columns.Count; j++)
                {
                    WriteData(worksheet, i + rowIndex, j + colIndex, GridViewDangKyHoatDong.Rows[i].Cells[j].Text);
                }

                BUSNguoiDung busnguoidung = new BUSNguoiDung();
                NGUOIDUNG nguoidung = busnguoidung.TimKiem(GridViewDangKyHoatDong.Rows[i].Cells[1].Text);
                WriteData(worksheet, i + rowIndex, 3, nguoidung.HoTen);
            }
        }

        protected void WriteData(ExcelCOM.Worksheet worksheet, int rowIndex, int colIndex, object value)
        {
            ExcelCOM.Range rng = (ExcelCOM.Range)worksheet.Cells[rowIndex, colIndex];
            rng.Select();
            rng.Value2 = value.ToString();
            rng.Columns.EntireColumn.AutoFit();
            rng.Rows.EntireRow.AutoFit();
            rng.Borders.Weight = ExcelCOM.XlBorderWeight.xlThin;
            rng.Borders.LineStyle = ExcelCOM.XlLineStyle.xlContinuous;
            rng.Borders.ColorIndex = ExcelCOM.XlColorIndex.xlColorIndexAutomatic;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
        }
    }
}