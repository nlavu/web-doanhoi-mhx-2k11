using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;
using System.Security.Cryptography;

namespace DAOAuction
{
    public class DAONguoiDung
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<NGUOIDUNG_getallResult> SelectNGUOIDUNGsAll()
        {
            List<NGUOIDUNG_getallResult> list = new List<NGUOIDUNG_getallResult>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<NGUOIDUNG_getallResult> lp = db.NGUOIDUNG_getall();
                foreach (NGUOIDUNG_getallResult NGUOIDUNG in lp)
                {
                    NGUOIDUNG_getallResult var1 = new NGUOIDUNG_getallResult();
                    var1.MaNguoiDung = NGUOIDUNG.MaNguoiDung;
                    var1.Username = NGUOIDUNG.Username;
                    var1.Password = NGUOIDUNG.Password;
                    var1.HoTen = NGUOIDUNG.HoTen;
                    var1.Email = NGUOIDUNG.Email;
                    var1.MaVaiTro = NGUOIDUNG.MaVaiTro;
                    var1.TenLoaiVaiTro = NGUOIDUNG.TenLoaiVaiTro;

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
        public int Them(NGUOIDUNG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.NGUOIDUNG_add(
                   lpDTO.Username,
                   EncryptPassword(lpDTO.Password),
                   lpDTO.HoTen,
                   lpDTO.Email,
                   lpDTO.MaVaiTro
                   );
                return 1;
            }
            catch 
            {
                return 0;
            }
        }
        public int Xoa(int manguoidung)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.NGUOIDUNG_delete(manguoidung);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int CapNhat(NGUOIDUNG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.NGUOIDUNG_update(
                    lpDTO.MaNguoiDung,
                    lpDTO.Username,
                    EncryptPassword(lpDTO.Password),
                    lpDTO.HoTen,
                    lpDTO.Email,
                    lpDTO.MaVaiTro
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int CapNhatWhitOutPass(NGUOIDUNG lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.NGUOIDUNG_update(
                    lpDTO.MaNguoiDung,
                    lpDTO.Username,
                    lpDTO.Password,
                    lpDTO.HoTen,
                    lpDTO.Email,
                    lpDTO.MaVaiTro
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public NGUOIDUNG TimKiem(int manguoidung)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.NGUOIDUNGs
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
        #endregion
        #region Tuấn 5/8/2010 Tìm kiếm người dùng theo từa lưa :D
        public NGUOIDUNG TimKiem(string tennguoidung, string password)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                string EncryptedPassword = EncryptPassword(password);

                var query = from ng in db.NGUOIDUNGs
                            where (ng.Username == tennguoidung) & (ng.Password == EncryptedPassword)
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

        public NGUOIDUNG TimKiemTheoUsernameVaEmail(string username, string email)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.NGUOIDUNGs
                            where (ng.Username == username && ng.Email == email)
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

        public NGUOIDUNG TimKiem(string username)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.NGUOIDUNGs
                            where (ng.Username == username)
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
        public List<NGUOIDUNG> TimKiem(string username, int flag)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.NGUOIDUNGs
                            where (ng.Username.Contains(username))
                            select ng;
                if (query.Count() > 0)
                    return query.ToList<NGUOIDUNG>();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<NGUOIDUNG> TimKiemHT(string hoten, int flag)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.NGUOIDUNGs
                            where (ng.HoTen.Contains(hoten))
                            select ng;
                if (query.Count() > 0)
                    return query.ToList<NGUOIDUNG>();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<NGUOIDUNG> TimKiem(string username, string hoten, int flag)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.NGUOIDUNGs
                            where (ng.HoTen.Contains(hoten) && ng.Username.Contains(username))
                            select ng;
                if (query.Count() > 0)
                    return query.ToList<NGUOIDUNG>();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Long:13/08/2010
        public string EncryptPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] originalText = ASCIIEncoding.Default.GetBytes(password);
            byte[] cipherText = md5.ComputeHash(originalText);
            return BitConverter.ToString(cipherText);
        }
        #endregion
    }
}
