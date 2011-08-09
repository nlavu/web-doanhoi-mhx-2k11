using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAODangKyMuonPhong
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<DANGKYMUONPHONG> SelectDANGKYMUONPHONGsAll()
        {
            List<DANGKYMUONPHONG> list = new List<DANGKYMUONPHONG>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<DANGKYMUONPHONG_getallResult> lp = db.DANGKYMUONPHONG_getall();
                foreach (DANGKYMUONPHONG_getallResult DANGKYMUONPHONG in lp)
                {
                    DANGKYMUONPHONG var1 = new DANGKYMUONPHONG();
                    var1.MaDangKy = DANGKYMUONPHONG.MaDangKy;
                    var1.MaNguoiDung = DANGKYMUONPHONG.MaNguoiDung;
                    var1.NgaySuDung = DANGKYMUONPHONG.NgaySuDung;
                    var1.SoLuong = DANGKYMUONPHONG.SoLuong;
                    var1.MucDich = DANGKYMUONPHONG.MucDich;
                    var1.DonViMuon = DANGKYMUONPHONG.DonViMuon;
                    var1.NgayDangKy = DANGKYMUONPHONG.NgayDangKy;
                    var1.KQPhong = DANGKYMUONPHONG.KQPhong;
                    var1.KetQua = DANGKYMUONPHONG.KetQua;
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
        public int Them(DANGKYMUONPHONG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.DANGKYMUONPHONG_add(
                    lpDTO.MaNguoiDung,
                    lpDTO.NgayDangKy,
                    lpDTO.NgaySuDung,
                    lpDTO.SoLuong,
                    lpDTO.MucDich,
                    lpDTO.DonViMuon,
                    lpDTO.KQPhong,
                    lpDTO.TGBatDau,
                    lpDTO.TGKetThuc,
                    lpDTO.KetQua
                    );
                return 1;
            }
            catch 
            {
                return 0;
            }
        }

        public int Xoa(int madangky)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.DANGKYMUONPHONG_delete(madangky);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(DANGKYMUONPHONG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.DANGKYMUONPHONG_update(
                    lpDTO.MaDangKy,
                    
                    lpDTO.MaNguoiDung,
                    lpDTO.NgayDangKy,
                    lpDTO.NgaySuDung,
                    lpDTO.SoLuong,
                    lpDTO.MucDich,
                    lpDTO.DonViMuon,
                    lpDTO.KQPhong,
                    lpDTO.TGBatDau,
                    lpDTO.TGKetThuc,
                    lpDTO.KetQua
                    );
                db.SubmitChanges();
                return 0;
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DANGKYMUONPHONG TimKiem(int madangky)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.DANGKYMUONPHONGs
                            where (ng.MaDangKy == madangky)
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

//         public List<NGUOIDUNG_DANGKYMUONPHONG_layUsernameTheoMaNguoiDungResult> DangKyMuonPhongVoiUsername(int manguoidung)
//         {
//             List<NGUOIDUNG_DANGKYMUONPHONG_layUsernameTheoMaNguoiDungResult> list = new List<NGUOIDUNG_DANGKYMUONPHONG_layUsernameTheoMaNguoiDungResult>();
//             using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
//             {
//                 ISingleResult<NGUOIDUNG_DANGKYMUONPHONG_layUsernameTheoMaNguoiDungResult> lp = db.NGUOIDUNG_DANGKYMUONPHONG_layUsernameTheoMaNguoiDung(manguoidung);
//                 foreach (NGUOIDUNG_DANGKYMUONPHONG_layUsernameTheoMaNguoiDungResult DANGKYMUONPHONG in lp)
//                 {
//                     NGUOIDUNG_DANGKYMUONPHONG_layUsernameTheoMaNguoiDungResult var1 = new NGUOIDUNG_DANGKYMUONPHONG_layUsernameTheoMaNguoiDungResult();
//                     var1.MaDangKy = DANGKYMUONPHONG.MaDangKy;
//                     var1.Username = DANGKYMUONPHONG.Username;
//                     var1.NgayMuon = DANGKYMUONPHONG.NgayMuon;
//                     var1.SoLuong = DANGKYMUONPHONG.SoLuong;
//                     var1.MucDich = DANGKYMUONPHONG.MucDich;
//                     var1.DonViMuon = DANGKYMUONPHONG.DonViMuon;
//                     var1.Phong = DANGKYMUONPHONG.Phong;
//                     var1.TGTu = DANGKYMUONPHONG.TGTu;
//                     var1.TGDen = DANGKYMUONPHONG.TGDen;
// 
//                     list.Add(var1);
//                 }
//                 try
//                 {
//                     // Save the changes.
//                     db.SubmitChanges();
//                 }
//                 // Detect concurrency conflicts.
//                 catch (ChangeConflictException)
//                 {
//                     // Resolve conflicts.
//                     db.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
//                 }
//             }
// 
//             return list;
//         }
        #endregion

        #region Duy HamBoSung 29/7/2010
        public List<DANGKYMUONPHONG> SelectDANGKYMUONPHONGbySinhVien(int MaSV)
        {
            List<DANGKYMUONPHONG> dsDKMuonPhong = new List<DANGKYMUONPHONG>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<DANGKYMUONPHONG_selectBySinhVienResult> lp = db.DANGKYMUONPHONG_selectBySinhVien(MaSV);
                foreach (DANGKYMUONPHONG_selectBySinhVienResult DANGKYMUONPHONG in lp)
                {
                    DANGKYMUONPHONG var1 = new DANGKYMUONPHONG();
                    var1.MaDangKy = DANGKYMUONPHONG.MaDangKy;
                    var1.MaNguoiDung = DANGKYMUONPHONG.MaNguoiDung;
                    var1.TGBatDau = DANGKYMUONPHONG.TGBatDau;
                    var1.TGKetThuc = DANGKYMUONPHONG.TGKetThuc;
                    var1.NgaySuDung = DANGKYMUONPHONG.NgaySuDung;
                    var1.SoLuong = DANGKYMUONPHONG.SoLuong;
                    var1.MucDich = DANGKYMUONPHONG.MucDich;
                    var1.DonViMuon = DANGKYMUONPHONG.DonViMuon;
                    var1.KQPhong = DANGKYMUONPHONG.KQPhong;
                    var1.NgayDangKy = DANGKYMUONPHONG.NgayDangKy;
                    var1.KetQua = DANGKYMUONPHONG.KetQua;
                    dsDKMuonPhong.Add(var1);
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
            return dsDKMuonPhong;
        }
        #endregion

        #region HMinh HamBoSung 3/8/2010
        public List<DANGKYMUONPHONG> SelectDANGKYMUONPHONGBYDATE(DateTime NgayXoa)
        {
            List<DANGKYMUONPHONG> list = new List<DANGKYMUONPHONG>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<DANGKYMUONPHONG> lp = db.DANGKYMUONPHONG_getbydate(NgayXoa);
                foreach (DANGKYMUONPHONG DANGKYMUONPHONG in lp)
                {
                    DANGKYMUONPHONG var1 = new DANGKYMUONPHONG();
                    var1.MaDangKy = DANGKYMUONPHONG.MaDangKy;
                    var1.MaNguoiDung = DANGKYMUONPHONG.MaNguoiDung;
                    var1.NgaySuDung = DANGKYMUONPHONG.NgaySuDung;
                    var1.SoLuong = DANGKYMUONPHONG.SoLuong;
                    var1.MucDich = DANGKYMUONPHONG.MucDich;
                    var1.DonViMuon = DANGKYMUONPHONG.DonViMuon;
                    var1.KQPhong = DANGKYMUONPHONG.KQPhong;
                    var1.NgayDangKy = DANGKYMUONPHONG.NgayDangKy;
                    var1.KetQua = DANGKYMUONPHONG.KetQua;

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

        public List<DANGKYMUONPHONG_getallwithNameUserResult> SelectDANGKYMUONPHONGsAllwithNameUser()
        {
            List<DANGKYMUONPHONG_getallwithNameUserResult> list = new List<DANGKYMUONPHONG_getallwithNameUserResult>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<DANGKYMUONPHONG_getallwithNameUserResult> lp = db.DANGKYMUONPHONG_getallwithNameUser();
                foreach (DANGKYMUONPHONG_getallwithNameUserResult DANGKYMUONPHONG in lp)
                {
                    DANGKYMUONPHONG_getallwithNameUserResult var1 = new DANGKYMUONPHONG_getallwithNameUserResult();
                    var1.MaDangKy = DANGKYMUONPHONG.MaDangKy;
                    var1.HoTen = DANGKYMUONPHONG.HoTen;
                    var1.NgayDangKy = DANGKYMUONPHONG.NgayDangKy;
                    var1.NgaySuDung = DANGKYMUONPHONG.NgaySuDung;
                    var1.SoLuong = DANGKYMUONPHONG.SoLuong;
                    var1.MucDich = DANGKYMUONPHONG.MucDich;
                    var1.DonViMuon = DANGKYMUONPHONG.DonViMuon;
                    var1.KQPhong = DANGKYMUONPHONG.KQPhong;
                    var1.MaNguoiDung = DANGKYMUONPHONG.MaNguoiDung;
                    var1.TGBatDau = DANGKYMUONPHONG.TGBatDau;
                    var1.TGKetThuc = DANGKYMUONPHONG.TGKetThuc;
                    var1.KQPhong = DANGKYMUONPHONG.KQPhong;
                    var1.KetQua = DANGKYMUONPHONG.KetQua;
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

    }
}