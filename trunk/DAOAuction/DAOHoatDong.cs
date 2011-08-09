using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOHoatDong
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<HOATDONG> SelectHOATDONGsAll()
        {
            List<HOATDONG> list = new List<HOATDONG>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<HOATDONG_getallResult> lp = db.HOATDONG_getall();
                foreach (HOATDONG_getallResult HOATDONG in lp)
                {
                    HOATDONG var1 = new HOATDONG();
                    var1.MaHoatDong = HOATDONG.MaHoatDong ;
                    var1.TenHoatDong = HOATDONG.TenHoatDong ;
                    var1.NgayDienRa   = HOATDONG.NgayDienRa  ;
                    var1.MaLoaiHoatDong  = HOATDONG.MaLoaiHoatDong ;
                    var1.ThoiGianBatDauDangKy  = HOATDONG.ThoiGianBatDauDangKy ;
                    var1.ThoiGianKetThucDangKy  = HOATDONG.ThoiGianKetThucDangKy ;
                    var1.HinhAnh = HOATDONG.HinhAnh;
                    list.Add(var1);
                }
                try
                {
                    // Save the changes.
                    db.SubmitChanges();
                }
                // Detect concurrency conflicts.
                catch (ChangeConflictException)
                {
                    // Resolve conflicts.
                    db.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
                }
            }

            return list;
        }
        public int Them(HOATDONG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                 db.HOATDONG_add(
                    lpDTO.TenHoatDong,
                    lpDTO.NgayDienRa ,
                    lpDTO.MaLoaiHoatDong ,
                    lpDTO.ThoiGianBatDauDangKy   ,
                    lpDTO.ThoiGianKetThucDangKy  ,
                    lpDTO.HinhAnh
                    );
                 return 1;
            }
            catch (Exception ex)
            {
                throw (ex);
                //return 0;
            }
        }

        public int Xoa(int mahoatdong)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.HOATDONG_delete(mahoatdong);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(HOATDONG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.HOATDONG_update(
                    lpDTO.MaHoatDong,
                    lpDTO.TenHoatDong,
                    lpDTO.NgayDienRa,
                    lpDTO.MaLoaiHoatDong ,
                    lpDTO.ThoiGianBatDauDangKy    ,
                    lpDTO.ThoiGianKetThucDangKy ,
                    lpDTO.HinhAnh
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public HOATDONG TimKiem(int mahoatdong)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.HOATDONGs
                            where (ng.MaHoatDong == mahoatdong)
                            select ng;
                if (query.Count() > 0)
                    return query.First();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
#endregion

        #region Lê Văn Long: lấy hoạt động theo mã
        public List<HOATDONG> SelectHOATDONGByLoai(int iMaLoaiHoatDong)
        {
            List<HOATDONG> KetQua = new List<HOATDONG>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<HOATDONG_GetByLoaiResult> dsHoatDong = db.HOATDONG_GetByLoai(iMaLoaiHoatDong);
                foreach (HOATDONG_GetByLoaiResult HOATDONG in dsHoatDong)
                {
                    HOATDONG aHoatDong = new HOATDONG();
                    aHoatDong.MaHoatDong = HOATDONG.MaHoatDong;
                    aHoatDong.TenHoatDong = HOATDONG.TenHoatDong;
                    aHoatDong.NgayDienRa = HOATDONG.NgayDienRa;
                    aHoatDong.MaLoaiHoatDong = HOATDONG.MaLoaiHoatDong;
                    aHoatDong.ThoiGianBatDauDangKy = HOATDONG.ThoiGianBatDauDangKy;
                    aHoatDong.ThoiGianKetThucDangKy = HOATDONG.ThoiGianKetThucDangKy;
                    aHoatDong.HinhAnh = HOATDONG.HinhAnh;
                    KetQua.Add(aHoatDong);
                }
                try
                {
                    // Save the changes.
                    db.SubmitChanges();
                }
                // Detect concurrency conflicts.
                catch (ChangeConflictException)
                {
                    // Resolve conflicts.
                    db.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
                }
            }

            return KetQua;
        }
        #endregion

        #region Tuấn 5/8/2010: Tìm kiếm hoạt động theo tên
        public List<HOATDONG> TimKiemTen(string tenhoatdong)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.HOATDONGs
                            where (ng.TenHoatDong.Contains(tenhoatdong))
                            select ng;
                if (query.Count() > 0)
                    return query.ToList<HOATDONG>();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

    }
}
