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
    public class DAOGopY
    {
        #region Ngọc Hà: Load ThemTimkiem 28/07/2011
        public List<GOPY> SelectGopYsAll()
        {
            List<GOPY> list = new List<GOPY>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<GOPY_getallResult> lp = db.GOPY_getall();
                foreach (GOPY_getallResult GOPY in lp)
                {
                    GOPY var1 = new GOPY();
                    var1.MaGopY = GOPY.MaGopY;
                    var1.TieuDe = GOPY.TieuDe;
                    var1.NoiDungGopY = GOPY.NoiDungGopY;
                    var1.MSSV = GOPY.MSSV;
                    var1.Email = GOPY.Email;
                    
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
        public int Them(GOPY lpDTO)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.GOPY_add(lpDTO.TieuDe,
                   lpDTO.NoiDungGopY,
                   lpDTO.MSSV,
                   lpDTO.Email
                   );
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public GOPY TimKiem(int magopy)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from ng in db.GOPies
                            where (ng.MaGopY == magopy)
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
