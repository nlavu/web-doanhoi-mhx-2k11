using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOAlbum
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<ALBUM> SelectALBUMsAll()
        {
            List<ALBUM> list = new List<ALBUM>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<ALBUM_getallResult> lp = db.ALBUM_getall();
                foreach (ALBUM_getallResult ALBUM in lp)
                {
                    ALBUM var1 = new ALBUM();
                    var1.MaAlbum  = ALBUM.MaAlbum ;
                    var1.TenAlbum  = ALBUM.TenAlbum ;

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
        public int Them(ALBUM lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                 db.ALBUM_add(
                    lpDTO.TenAlbum 
                    );
                 return 1;
            }
            catch (Exception ex)
            {
                throw (ex);
                //return 0;
            }
        }

        public int Xoa(int maalbum)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
               db.ALBUM_delete(maalbum);
               db.SubmitChanges();
               return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(ALBUM lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.ALBUM_update(
                    lpDTO.MaAlbum,
                    lpDTO.TenAlbum 
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public ALBUM TimKiem(int maalbum)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.ALBUMs
                            where (ng.MaAlbum  == maalbum)
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
