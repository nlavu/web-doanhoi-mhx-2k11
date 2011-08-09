using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOGioiThieu
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<GIOITHIEU> SelectGIOITHIEUsAll()
        {
            List<GIOITHIEU> list = new List<GIOITHIEU>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<GIOITHIEU_getallResult> lp = db.GIOITHIEU_getall();
                foreach (GIOITHIEU_getallResult GIOITHIEU in lp)
                {
                    GIOITHIEU var1 = new GIOITHIEU();
                    var1.MaBai  = GIOITHIEU.MaBai ;
                    var1.TieuDe  = GIOITHIEU.TieuDe ;
                    var1.NoiDung  = GIOITHIEU.NoiDung ;

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
        public int Them(GIOITHIEU lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                 db.GIOITHIEU_add(
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

        public int Xoa(int magioithieu)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
               db.GIOITHIEU_delete(magioithieu);
               db.SubmitChanges();
               return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(GIOITHIEU lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.GIOITHIEU_update(
                    lpDTO.MaBai,
                    lpDTO.TieuDe,
                    lpDTO.NoiDung
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public GIOITHIEU TimKiem(int magioithieu)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.GIOITHIEUs
                            where (ng.MaBai  == magioithieu)
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
        //public BAIVIET TimKiem(int mabaiviet)
        //{
        //    try
        //    {
        //        LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

        //        var query = from ng in db.BAIVIETs
        //                    where (ng.MaBaiViet == mabaiviet)
        //                    select ng;
        //        if (query.Count() > 0)
        //            return query.First();
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        #endregion
    }
}
