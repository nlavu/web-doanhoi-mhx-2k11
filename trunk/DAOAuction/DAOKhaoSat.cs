using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOKhaoSat
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<KHAOSAT> SelectKHAOSATsAll()
        {
            List<KHAOSAT> list = new List<KHAOSAT>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<KHAOSAT_getallResult> lp = db.KHAOSAT_getall();
                foreach (KHAOSAT_getallResult KHAOSAT in lp)
                {
                    KHAOSAT var1 = new KHAOSAT();
                    var1.MaDapAn  = KHAOSAT.MaDapAn ;
                    var1.MaYKKS  = KHAOSAT.MaYKKS ;
                    var1.YKienKhac  = KHAOSAT.YKienKhac ;

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
        public int Them(KHAOSAT lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.KHAOSAT_add(
                    lpDTO.MaDapAn ,
                    
                    lpDTO.YKienKhac 
                    );

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Xoa(KHAOSAT lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.KHAOSAT_delete(
                    lpDTO.MaYKKS
                    );
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(KHAOSAT lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.KHAOSAT_update(
                  
                    lpDTO.MaDapAn,
                  
                    lpDTO.YKienKhac,
                      lpDTO.MaYKKS
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public KHAOSAT TimKiem(int macauhoi)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.KHAOSATs
                            where (ng.MaDapAn  == macauhoi)
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

        #region Nhi: 

   
     
        #endregion
    }
}
