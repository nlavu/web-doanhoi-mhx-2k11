using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAODapAnKhaoSat
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<DAPANKHAOSAT> SelectDAPANKHAOSATsAll()
        {
            List<DAPANKHAOSAT> list = new List<DAPANKHAOSAT>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<DAPANKHAOSAT_getallResult> lp = db.DAPANKHAOSAT_getall();
                foreach (DAPANKHAOSAT_getallResult DAPANKHAOSAT in lp)
                {
                    DAPANKHAOSAT var1 = new DAPANKHAOSAT();
                    var1.MaDapAn  = DAPANKHAOSAT.MaDapAn ;
                    var1.MaCauHoi  = DAPANKHAOSAT.MaCauHoi ;
                    var1.NoiDung  = DAPANKHAOSAT.NoiDung ;

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
        public int Them(DAPANKHAOSAT lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                 db.DAPANKHAOSAT_add(
                    lpDTO.MaCauHoi ,
                    lpDTO.NoiDung 
                    );
                 return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Xoa(int madapankhaosat)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
               db.DAPANKHAOSAT_delete(madapankhaosat);
               db.SubmitChanges();
               return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(DAPANKHAOSAT lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.DAPANKHAOSAT_update(
                    lpDTO.MaDapAn ,
                    lpDTO.MaCauHoi ,
                    lpDTO.NoiDung 
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DAPANKHAOSAT TimKiem(int madapankhaosat)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.DAPANKHAOSATs
                            where (ng.MaDapAn  == madapankhaosat)
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

        #region Quoc Minh: Lay Danh Sach Dap An Theo Ma Cau Hoi
        public List<DAPANKHAOSAT> layDapAnTheoMaCauHoi(int macauhoi)
        {
            List<DAPANKHAOSAT> list = new List<DAPANKHAOSAT>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<DAPANKHAOSAT_layDapAnTheoMaCauHoiResult> lp = db.DAPANKHAOSAT_layDapAnTheoMaCauHoi(macauhoi);
                foreach (DAPANKHAOSAT_layDapAnTheoMaCauHoiResult DAPANKHAOSAT in lp)
                {
                    DAPANKHAOSAT var1 = new DAPANKHAOSAT();
                    var1.MaDapAn = DAPANKHAOSAT.MaDapAn;
                    var1.MaCauHoi = DAPANKHAOSAT.MaCauHoi;
                    var1.NoiDung = DAPANKHAOSAT.NoiDung;

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
