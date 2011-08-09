using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOHinhAnh
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<HINHANH> SelectHINHANHsAll()
        {
            List<HINHANH> list = new List<HINHANH>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                
                ISingleResult<HINHANH_getallResult> lp = db.HINHANH_getall();
                foreach (HINHANH_getallResult HINHANH in lp)
                {
                    HINHANH var1 = new HINHANH();
                    var1.MaHinhAnh  = HINHANH.MaHinhAnh ;
                    var1.DuongDan  = HINHANH.DuongDan   ;
                    var1.MaAlbum  = HINHANH.MaAlbum ;

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
        public int Them(HINHANH lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                 db.HINHANH_add(
                    lpDTO.DuongDan ,
                    lpDTO.MaAlbum  
                    );
                 return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Xoa(int mahinhanh)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.HINHANH_delete(mahinhanh);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(HINHANH lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.HINHANH_update(
                    lpDTO.MaHinhAnh,
                    lpDTO.DuongDan,
                    lpDTO.MaAlbum
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public HINHANH TimKiem(int mahinhanh)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.HINHANHs
                            where (ng.MaHinhAnh == mahinhanh)
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
