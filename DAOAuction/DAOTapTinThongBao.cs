using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;



namespace DAOAuction
{
    public class DAOTapTinThongBao
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<TAPTINTHONGBAO> SelectTAPTINTHONGBAOsAll()
        {
            List<TAPTINTHONGBAO> list = new List<TAPTINTHONGBAO>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<TAPTINTHONGBAO_getallResult> lp = db.TAPTINTHONGBAO_getall();
                foreach (TAPTINTHONGBAO_getallResult TAPTINTHONGBAO in lp)
                {
                    TAPTINTHONGBAO var1 = new TAPTINTHONGBAO();
                    var1.MaTapTin  = TAPTINTHONGBAO.MaTapTin ;
                    var1.TenTapTin  = TAPTINTHONGBAO.TenTapTin ;
                    var1.DuongDan  = TAPTINTHONGBAO.DuongDan;
                    var1.MaThongBao  = TAPTINTHONGBAO.MaThongBao;

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
        public int Them(TAPTINTHONGBAO lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.TAPTINTHONGBAO_add(
                    lpDTO.TenTapTin ,
                    lpDTO.DuongDan ,
                    lpDTO.MaThongBao 
                    );
                return 1;
            }
            catch 
            {
                return 0;
            }
        }

        public int Xoa(int mataptin)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
               db.TAPTINTHONGBAO_delete(mataptin);
               db.SubmitChanges();
               return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int CapNhat(TAPTINTHONGBAO lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                return db.TAPTINTHONGBAO_update(
                    lpDTO.MaTapTin ,
                    lpDTO.TenTapTin ,
                    lpDTO.DuongDan ,
                    lpDTO.MaThongBao
                    );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public TAPTINTHONGBAO TimKiem(int mataptin)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.TAPTINTHONGBAOs
                            where (ng.MaTapTin == mataptin)
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

        #region Đức Anh: 5/8
        public TAPTINTHONGBAO TimKiemMaThongBao(int mabaiviet)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.TAPTINTHONGBAOs
                            where (ng.MaThongBao == mabaiviet)
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
        public TAPTINTHONGBAO TimKiemTenTapTin(string tenTapTin)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.TAPTINTHONGBAOs
                            where (ng.TenTapTin == tenTapTin)
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
