using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOCauHoiKhaoSat
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<CAUHOIKHAOSAT> SelectCAUHOIKHAOSATsAll()
        {
            List<CAUHOIKHAOSAT> list = new List<CAUHOIKHAOSAT>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<CAUHOIKHAOSAT_getallResult> lp = db.CAUHOIKHAOSAT_getall();
                foreach (CAUHOIKHAOSAT_getallResult CAUHOIKHAOSAT in lp)
                {
                    CAUHOIKHAOSAT var1 = new CAUHOIKHAOSAT();
                    var1.MaCauHoiKhaoSat  = CAUHOIKHAOSAT.MaCauHoiKhaoSat ;
                    var1.NoiDung  = CAUHOIKHAOSAT.NoiDung ;
                    var1.BiKhoa  = CAUHOIKHAOSAT.BiKhoa ;

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
        public int Them(CAUHOIKHAOSAT lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                 db.CAUHOIKHAOSAT_add(
                    lpDTO.NoiDung ,
                    lpDTO.BiKhoa  
                    );
                 return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Xoa(int macauhoikhaosat)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.CAUHOIKHAOSAT_delete(macauhoikhaosat);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(CAUHOIKHAOSAT lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.CAUHOIKHAOSAT_update(
                    lpDTO.MaCauHoiKhaoSat,
                    lpDTO.NoiDung,
                    lpDTO.BiKhoa 
                    );
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public CAUHOIKHAOSAT TimKiem(int macauhoikhaosat)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.CAUHOIKHAOSATs
                            where (ng.MaCauHoiKhaoSat  == macauhoikhaosat)
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

        #region Quoc Minh: Lay Cau Hoi Khong Khoa

        public CAUHOIKHAOSAT layCauHoiKhongKhoa()
        {
            List<CAUHOIKHAOSAT> list = new List<CAUHOIKHAOSAT>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<CAUHOIKHAOSAT_cauHoiKhongKhoaResult> lp = db.CAUHOIKHAOSAT_cauHoiKhongKhoa();
                foreach (CAUHOIKHAOSAT_cauHoiKhongKhoaResult CAUHOIKHAOSAT in lp)
                {
                    CAUHOIKHAOSAT var1 = new CAUHOIKHAOSAT();
                    var1.MaCauHoiKhaoSat = CAUHOIKHAOSAT.MaCauHoiKhaoSat;
                    var1.NoiDung = CAUHOIKHAOSAT.NoiDung;
                    var1.BiKhoa = CAUHOIKHAOSAT.BiKhoa;

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
                return list.First();
            else
                return null;
        }
        #endregion
    }
}
