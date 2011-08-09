using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOHeThongToChuc
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<HETHONGTOCHUC> SelectHETHONGTOCHUCsAll()
        {
            List<HETHONGTOCHUC> list = new List<HETHONGTOCHUC>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
       
                ISingleResult<HETHONGTOCHUC_getallResult> lp = db.HETHONGTOCHUC_getall  ();
                foreach (HETHONGTOCHUC_getallResult HETHONGTOCHUC in lp)
                {
                    HETHONGTOCHUC var1 = new HETHONGTOCHUC();
                    var1.MaBai = HETHONGTOCHUC.MaBai;
                    var1.TieuDe   = HETHONGTOCHUC.TieuDe ;
                    var1.NoiDung  = HETHONGTOCHUC.NoiDung ;

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
        public int Them(HETHONGTOCHUC lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                 db.HETHONGTOCHUC_add(
                    lpDTO.TieuDe ,
                    lpDTO.NoiDung 
                    );
                 return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Xoa(int mabai)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
               db.HETHONGTOCHUC_delete(mabai);
               db.SubmitChanges();
               return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(HETHONGTOCHUC lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.HETHONGTOCHUC_update(
                    lpDTO.MaBai,
                    lpDTO.TieuDe ,
                    lpDTO.NoiDung
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public HETHONGTOCHUC TimKiem(int mabai)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.HETHONGTOCHUCs
                            where (ng.MaBai == mabai)
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
