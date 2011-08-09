using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOChuyenMuc
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<CHUYENMUC> SelectCHUYENMUCsAll()
        {
            List<CHUYENMUC> list = new List<CHUYENMUC>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<CHUYENMUC_getallResult> lp = db.CHUYENMUC_getall();
                foreach (CHUYENMUC_getallResult CHUYENMUC in lp)
                {
                    CHUYENMUC var1 = new CHUYENMUC();
                    var1.MaChuyenMuc = CHUYENMUC.MaChuyenMuc;
                    var1.TenChuyenMuc = CHUYENMUC.TenChuyenMuc;
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
        public List<CHUYENMUC> SelectCHUYENMUCsAll_exception()
        {
            List<CHUYENMUC> list = new List<CHUYENMUC>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<CHUYENMUC_getallResult> lp = db.CHUYENMUC_getall();
                foreach (CHUYENMUC_getallResult CHUYENMUC in lp)
                {
                    if (CHUYENMUC.TenChuyenMuc == "Thông tin hoạt động")
                        continue;
                    CHUYENMUC var1 = new CHUYENMUC();
                    var1.MaChuyenMuc = CHUYENMUC.MaChuyenMuc;
                    var1.TenChuyenMuc = CHUYENMUC.TenChuyenMuc;

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
        public int Them(CHUYENMUC lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                 db.CHUYENMUC_add(
                    lpDTO.TenChuyenMuc
                    );
                 return 1;
            }
            catch 
            {
                return 0;
            }
        }

        public int Xoa(int machuyenmuc)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.CHUYENMUC_delete(machuyenmuc);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(CHUYENMUC lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
               db.CHUYENMUC_update(
                    lpDTO.MaChuyenMuc,
                    lpDTO.TenChuyenMuc
                    );
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public CHUYENMUC TimKiem(int machuyenmuc)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.CHUYENMUCs
                            where (ng.MaChuyenMuc  == machuyenmuc)
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

        #region Nhi: Lay Chuyen Muc Theo Ma Bai Viet

        public CHUYENMUC LayChuyenMucTheoBaiViet(int MaLoaiBaiViet)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from cm in db.CHUYENMUCs
                            join lbv in db.LOAIBAIVIETs on cm.MaChuyenMuc equals lbv.MaChuyenMuc
                            where lbv.MaLoaiBaiViet == MaLoaiBaiViet
                            select cm;
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

        #region Tin: Tim chuyen muc theo ten
        public CHUYENMUC TimKiemTen(string tenChuyenMuc)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from cm in db.CHUYENMUCs
                            where cm.TenChuyenMuc == tenChuyenMuc
                            select cm;
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
