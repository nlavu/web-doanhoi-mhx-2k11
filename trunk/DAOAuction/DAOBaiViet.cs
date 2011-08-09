using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOBaiViet
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<BAIVIET> SelectBAIVIETsAll()
        {
            List<BAIVIET> list = new List<BAIVIET>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<BAIVIET_getallResult> lp = db.BAIVIET_getall();
                foreach (BAIVIET_getallResult BAIVIET in lp)
                {
                    BAIVIET var1 = new BAIVIET();
                    var1.MaBaiViet = BAIVIET.MaBaiViet;
                    var1.TieuDe = BAIVIET.TieuDe;
                    var1.NoiDung = BAIVIET.NoiDung;
                    var1.MaLoaiBaiViet = BAIVIET.MaLoaiBaiViet;
                    var1.NgayDang = BAIVIET.NgayDang;
                    var1.HinhAnh = BAIVIET.HinhAnh;
                    var1.TomTat = BAIVIET.TieuDe;
                    if (BAIVIET.CapNhat != null)
                        var1.CapNhat = (DateTime)BAIVIET.CapNhat;
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
        public int Them(BAIVIET lpDTO)
        {
            try
            {

                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.BAIVIET_add(
                   lpDTO.TieuDe,
                   lpDTO.NoiDung,
                   lpDTO.MaLoaiBaiViet,
                   lpDTO.NgayDang,
                   lpDTO.HinhAnh,
                   lpDTO.TomTat, lpDTO.MaNguoiDang, lpDTO.TinNoiBat
                   );
                return 1;
            }
            catch 
            {
                return 0;
            }
        }

        public int Xoa(int mabaiviet)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.BAIVIET_delete(mabaiviet);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(BAIVIET lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
              db.BAIVIET_update(
                    lpDTO.MaBaiViet,
                    lpDTO.TieuDe,
                    lpDTO.NoiDung,
                    lpDTO.MaLoaiBaiViet,
                    lpDTO.NgayDang, lpDTO.CapNhat,
                    lpDTO.HinhAnh,
                    lpDTO.TomTat, lpDTO.TinNoiBat
                    );
              db.SubmitChanges();
              return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public BAIVIET TimKiem(int mabaiviet)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.BAIVIETs
                            where (ng.MaBaiViet == mabaiviet)
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

        #region Nhi: Tim Kiem DS BaiViet Theo Loai Bai Viet, Lấy Bài Viết Mới Nhất
        public List<BAIVIET> TimKiemTheoLoaiBaiViet(int MaLoaiBaiViet)
        {
            List<BAIVIET> list = new List<BAIVIET>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                
//                 ISingleResult<BAIVIET_TimKiemTheoLoaiBaiVietResult> lp = db.BAIVIET_TimKiemTheoLoaiBaiViet(MaLoaiBaiViet);
//                 foreach (BAIVIET_TimKiemTheoLoaiBaiVietResult BAIVIET in lp)
//                 {
//                     BAIVIET var1 = new BAIVIET();
//                     var1.MaBaiViet = BAIVIET.MaBaiViet;
//                     var1.TieuDe = BAIVIET.TieuDe;
//                     var1.NoiDung = BAIVIET.NoiDung;
//                     var1.MaLoaiBaiViet = BAIVIET.MaLoaiBaiViet;
//                     var1.NgayDang = BAIVIET.NgayDang;
//                     var1.HinhAnh = BAIVIET.HinhAnh;
//                     var1.TomTat = BAIVIET.TomTat;
//                     if (BAIVIET.CapNhat != null)
//                         var1.CapNhat = (DateTime)BAIVIET.CapNhat;
//                     list.Add(var1);
//                 }
                var rs = from n in db.BAIVIETs
                         where n.MaLoaiBaiViet == MaLoaiBaiViet
                         orderby n.MaBaiViet descending
                         select n;
                list = rs.ToList();
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
        public List<BAIVIET> LayBaiVietMoiNhat(int SoLuong)
        {
            List<BAIVIET> list = new List<BAIVIET>();
            using (LinQDataContext db = new LinQDataContext())
            {
                ISingleResult<BAIVIET_LayBaiVietMoiNhatResult> lp = db.BAIVIET_LayBaiVietMoiNhat();

                int i = 0;
                foreach(BAIVIET_LayBaiVietMoiNhatResult bv in lp)
                {
                    if (i == SoLuong)
                    {
                        break;
                    }
                    //BAIVIET_LayBaiVietMoiNhatResult bv = temp[i];
                    BAIVIET var1 = new BAIVIET();
                    var1.MaBaiViet = bv.MaBaiViet;
                    var1.TieuDe = bv.TieuDe;
                    var1.NoiDung = bv.NoiDung;
                    var1.MaLoaiBaiViet = bv.MaLoaiBaiViet;
                    var1.NgayDang = bv.NgayDang;
                    var1.HinhAnh = bv.HinhAnh;
                    var1.TomTat = bv.TomTat;                    
                    if (bv.CapNhat!=null)
                        var1.CapNhat = (DateTime)bv.CapNhat;
                    list.Add(var1);
                    i++;
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

        public List<BAIVIET> LayBaiVietMoiNhat()
        {
            return LayBaiVietMoiNhat(5);
        }
        public List<BAIVIET> LayDSBaiVietTheoChuyenMuc(int MaChuyenMuc)
        {
            List<BAIVIET> list = new List<BAIVIET>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                var rs = from n in db.BAIVIETs
                         where n.LOAIBAIVIET.MaChuyenMuc == MaChuyenMuc
                         orderby n.MaBaiViet descending 
                         select n ;
              //  ISingleResult<BAIVIET_LayDSBaiVietTheoChuyenMucResult> lp = db.BAIVIET_LayDSBaiVietTheoChuyenMuc(MaChuyenMuc);
                list = rs.ToList();
//                 foreach (BAIVIET bv in rs)
//                 {
//                     //BAIVIET_LayBaiVietMoiNhatResult bv = temp[i];
//                     BAIVIET var1 = new BAIVIET();
//                     var1.MaBaiViet = bv.MaBaiViet;
//                     var1.TieuDe = bv.TieuDe;
//                     var1.NoiDung = bv.NoiDung;
//                     var1.MaLoaiBaiViet = bv.MaLoaiBaiViet;
//                     var1.NgayDang = bv.NgayDang;
//                     var1.HinhAnh = bv.HinhAnh;
//                     var1.TomTat = bv.TomTat;
//                     if (bv.CapNhat != null)
//                         var1.CapNhat = (DateTime)bv.CapNhat;
//                     list.Add(var1);
// 
//                 }
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
            if (list.Count > 0)
                return list;
            else
                return null;
        }
       
        public List<BAIVIET> LayBaiVietMoiNhatTheoChuyenMuc(int MaChuyenMuc)
        {
            List<BAIVIET> list = new List<BAIVIET>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<BAIVIET_LayTopBaiVietMoiNhatTheoChuyenMucResult> lp = db.BAIVIET_LayTopBaiVietMoiNhatTheoChuyenMuc(MaChuyenMuc);

                
                foreach (BAIVIET_LayTopBaiVietMoiNhatTheoChuyenMucResult bv in lp)
                {
                    //BAIVIET_LayBaiVietMoiNhatResult bv = temp[i];
                    BAIVIET var1 = new BAIVIET();
                    var1.MaBaiViet = bv.MaBaiViet;
                    var1.TieuDe = bv.TieuDe;
                    var1.NoiDung = bv.NoiDung;
                    var1.MaLoaiBaiViet = bv.MaLoaiBaiViet;
                    var1.NgayDang = bv.NgayDang;
                    var1.HinhAnh = bv.HinhAnh;
                    var1.TomTat = bv.TomTat;
                    if (bv.CapNhat != null)
                        var1.CapNhat = (DateTime)bv.CapNhat;
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
            if (list.Count > 0)
                return list;
            else
                return null;

        }
        #endregion
        public List<BAIVIET> LayBaiVietNoiBatMoiNhat(int SoLuong)
        {
            List<BAIVIET> list = new List<BAIVIET>();
            try
 {
	 using (LinQDataContext db = new LinQDataContext(global::DTOAuction.Properties.Settings.Default.doantnConnectionString))
	            {
	                var rs = (from n in db.BAIVIETs
	                          where n.TinNoiBat == true
	                          orderby n.NgayDang descending
	                          select n).Take(SoLuong);
	                foreach (BAIVIET bv in rs)
	                {
	                    list.Add(bv);                 
	                }              
	            }
	
	            return list;
 }
 catch (System.Exception ex)
 {
     return null;
 }
        }
        #region Tuấn 5/8/2010 Tìm Kiếm Bài Viết theo tiêu đề và tóm tắt
        public List<BAIVIET> Search(string tieude, string tomtat)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.BAIVIETs
                            where (ng.TieuDe.Contains(tieude) && ng.TomTat.Contains(tomtat))
                            select ng;
                if (query.Count() > 0)
                    return query.ToList<BAIVIET>();
                else
                    return null;
            }
            catch { return null; }
        }
        #endregion

        #region Đức 5/8/2010
        public List<BAIVIET_getall_newResult> SelectBAIVIETsAll_new()
        {
            LinQDataContext db;

            using (db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                return db.BAIVIET_getall_new().ToList<BAIVIET_getall_newResult>();
            }
            //             try
            //             {
            //                 // Save the changes.
            //                 db.SubmitChanges();
            //             }
            //             // Detect concurrency conflicts.
            //             catch (ChangeConflictException)
            //             {
            //                 // Resolve conflicts.
            //                 db.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
            //             }
            //             return lp;
        }
        #endregion

        #region Tin: Tim kiem theo ten 14/08/2010
        public BAIVIET TimKiemTieuDe(string tieuDe)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.BAIVIETs
                            where (ng.TieuDe == tieuDe)
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

        #region Tin: Tim kiem bai viet theo ma nguoi dung 31/07/2011
        public BAIVIET TimKiemTheoTacGia(int tacgia)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.BAIVIETs
                            where (ng.MaNguoiDang == tacgia)
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

        #region Anh Vu: Tim kiem bai viet theo ma bai viet 05/08/2011
        public BAIVIET TimBaiVietTheoMaBaiViet(int mabaiviet)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.BAIVIETs
                            where (ng.MaBaiViet == mabaiviet)
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
    }
}
