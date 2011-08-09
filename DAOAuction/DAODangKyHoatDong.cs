using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAODangKyHoatDong
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<DANGKYHOATDONG_getallResult> SelectDANGKYHOATDONGsAll()
        {
            List<DANGKYHOATDONG_getallResult> list = new List<DANGKYHOATDONG_getallResult>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<DANGKYHOATDONG_getallResult> lp = db.DANGKYHOATDONG_getall();
                foreach (DANGKYHOATDONG_getallResult DANGKYHOATDONG in lp)
                {
                    DANGKYHOATDONG_getallResult var1 = new DANGKYHOATDONG_getallResult();
                    var1.MaHoatDong = DANGKYHOATDONG.MaHoatDong ;
                    var1.MaNguoiDung  = DANGKYHOATDONG.MaNguoiDung ;
                    var1.Username = DANGKYHOATDONG.Username;
                    var1.TenHoatDong = DANGKYHOATDONG.TenHoatDong;

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
        public int Them(DANGKYHOATDONG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.DANGKYHOATDONG_add(
                    lpDTO.MaNguoiDung ,
                    lpDTO.MaHoatDong 
                    );

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Xoa(DANGKYHOATDONG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.DANGKYHOATDONG_delete(
                    lpDTO.MaNguoiDung,
                    lpDTO.MaHoatDong
                    );
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(DANGKYHOATDONG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.DANGKYHOATDONG_update(
                    lpDTO.MaNguoiDung,
                    lpDTO.MaHoatDong
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DANGKYHOATDONG TimKiem(int manguoidung)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.DANGKYHOATDONGs
                            where (ng.MaNguoiDung == manguoidung)
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
       /* public DANGKYHOATDONG TimKiem(int manguoidung, int mahoatdong)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.DANGKYHOATDONGs
                            where (ng.MaNguoiDung == manguoidung && ng.MaHoatDong == mahoatdong)
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
        }*/

        public List<DANGKYHOATDONG_get_MaHoatDongResult> SelectDANGKYHOATDONGs_HoatDong(int mahoatdong)
        {
            List<DANGKYHOATDONG_get_MaHoatDongResult> list = new List<DANGKYHOATDONG_get_MaHoatDongResult>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<DANGKYHOATDONG_get_MaHoatDongResult> lp = db.DANGKYHOATDONG_get_MaHoatDong(mahoatdong);
                foreach (DANGKYHOATDONG_get_MaHoatDongResult DANGKYHOATDONG in lp)
                {
                    DANGKYHOATDONG_get_MaHoatDongResult var1 = new DANGKYHOATDONG_get_MaHoatDongResult();
                    var1.TenHoatDong = DANGKYHOATDONG.TenHoatDong;
                    var1.Username = DANGKYHOATDONG.Username;
                    var1.HoTen = DANGKYHOATDONG.HoTen;
                    var1.MaNguoiDung = DANGKYHOATDONG.MaNguoiDung;
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
        #endregion


        #region Duy HamBoSung 29/7/2010
        public List<DANGKYHOATDONG> SelectDANGKYHOATDONGbyMASV(int MaNguoiDung)
        {
            List<DANGKYHOATDONG> dsDKHoatDong = new List<DANGKYHOATDONG>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<DANGKYHOATDONG_selectbySinhVienResult> lp = db.DANGKYHOATDONG_selectbySinhVien(MaNguoiDung);
                foreach (DANGKYHOATDONG_selectbySinhVienResult aDKHoatDong in lp)
                {
                    DANGKYHOATDONG var1 = new DANGKYHOATDONG();
                    var1.MaHoatDong = aDKHoatDong.MaHoatDong;
                    var1.MaNguoiDung = aDKHoatDong.MaNguoiDung;
                    dsDKHoatDong.Add(var1);
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
            return dsDKHoatDong;
        }

        public DANGKYHOATDONG TimKiem(int manguoidung, int mahoatdong)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.DANGKYHOATDONGs
                            where (ng.MaNguoiDung == manguoidung && ng.MaHoatDong == mahoatdong)
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

        #region nghia bổ sung
        public int Xoa(int mahoatdong)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
               db.DANGKYHOATDONG_xoa(mahoatdong);
               db.SubmitChanges();
               return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}
