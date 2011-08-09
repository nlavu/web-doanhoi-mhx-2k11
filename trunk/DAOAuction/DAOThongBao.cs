using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOThongBao
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<THONGBAO> SelectTHONGBAOsAll()
        {
            List<THONGBAO> list = new List<THONGBAO>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<THONGBAO_getallResult> lp = db.THONGBAO_getall();
                foreach (THONGBAO_getallResult THONGBAO in lp)
                {
                    THONGBAO var1 = new THONGBAO();
                    var1.MaThongBao  = THONGBAO.MaThongBao ;
                    var1.TieuDe  = THONGBAO.TieuDe ;
                    var1.NoiDung  = THONGBAO.NoiDung ;
                    var1.MaHoatDong  = THONGBAO.MaHoatDong ;
                    var1.NgayDang  = THONGBAO.NgayDang ;
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
        public int Them(THONGBAO lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                 db.THONGBAO_add(
                    lpDTO.TieuDe ,
                    lpDTO.NoiDung ,
                    lpDTO.MaHoatDong ,
                    lpDTO.NgayDang 
                    );
                 return 1;
            }
            catch 
            {
                return 0;
            }
        }

        public int Xoa(int mathongbao)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
               db.THONGBAO_delete(mathongbao);
               db.SubmitChanges();
               return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(THONGBAO lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.THONGBAO_update(
                    lpDTO.MaThongBao,
                    lpDTO.TieuDe,
                    lpDTO.NoiDung,
                    lpDTO.MaHoatDong,
                    lpDTO.NgayDang
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public THONGBAO TimKiem(int mathongbao)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.THONGBAOs
                            where (ng.MaThongBao  == mathongbao)
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


        #region Nhi: Lay Thong Bao Theo Ma Hoat Dong
        public List<THONGBAO> LayThongBaoTheoMaHoatDong(int MaHoatDong)
        {
            List<THONGBAO> list = new List<THONGBAO>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<THONGBAO_LayThongBaoTheoMaHoatDongResult> lp = db.THONGBAO_LayThongBaoTheoMaHoatDong(MaHoatDong);
                foreach (THONGBAO_LayThongBaoTheoMaHoatDongResult THONGBAO in lp)
                {
                    THONGBAO var1 = new THONGBAO();
                    var1.MaThongBao = THONGBAO.MaThongBao;
                    var1.TieuDe = THONGBAO.TieuDe;
                    var1.NoiDung = THONGBAO.NoiDung;
                    var1.MaHoatDong = THONGBAO.MaHoatDong;
                    var1.NgayDang = THONGBAO.NgayDang;
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

        #region Nhi: Select All Thong Bao (New)
        public List<THONGBAO_getall_newResult> SelectTHONGBAOsAll_New()
        {
            List<THONGBAO_getall_newResult> list = new List<THONGBAO_getall_newResult>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<THONGBAO_getall_newResult> lp = db.THONGBAO_getall_new();
                foreach (THONGBAO_getall_newResult THONGBAO in lp)
                {
                    THONGBAO_getall_newResult var1 = new THONGBAO_getall_newResult();
                    var1.MaThongBao = THONGBAO.MaThongBao;
                    var1.TieuDe = THONGBAO.TieuDe;
                    var1.NoiDung = THONGBAO.NoiDung;
                    var1.TenHoatDong = THONGBAO.TenHoatDong;
                    var1.NgayDang = THONGBAO.NgayDang;
                    var1.MaHoatDong = THONGBAO.MaHoatDong;
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
    }
}
