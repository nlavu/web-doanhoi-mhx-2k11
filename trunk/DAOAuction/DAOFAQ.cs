using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DTOAuction;
using System.Configuration;

namespace DAOAuction
{
    public class DAOFAQ
    {
        // lấy danh sách các câu hỏi:
        public List<CAUHOITHUONGGAP> LayDanhSachTatCaCauHoi()
        {
            List<CAUHOITHUONGGAP> lstCauHoi = new List<CAUHOITHUONGGAP>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {

                ISingleResult<FAQ_getallCauHoiResult> lp = db.FAQ_getallCauHoi();
                foreach (FAQ_getallCauHoiResult CAUHOITHUONGGAP in lp)
                {
                    CAUHOITHUONGGAP var1 = new CAUHOITHUONGGAP();
                    var1.MaCauHoi = CAUHOITHUONGGAP.MaCauHoi;
                    var1.NoiDungCauHoi = CAUHOITHUONGGAP.NoiDungCauHoi;
                    lstCauHoi.Add(var1);
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

            return lstCauHoi;
        }

        // lấy câu trả lời dựa vào câu hỏi được chọn:
        public CAUHOITHUONGGAP TimKiem(int MaCauHoi)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);

                var query = from faq in db.CAUHOITHUONGGAPs
                            where ( faq.MaCauHoi == MaCauHoi )
                            select faq;
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

        // lấy tất cả câu hỏi thường gặp:
        public List<CAUHOITHUONGGAP> getAll_FAQ()
        {
            List<CAUHOITHUONGGAP> lst_FAQ = new List<CAUHOITHUONGGAP>();
            using (LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString))
            {
                ISingleResult<FAQ_getallFAQResult> lp = db.FAQ_getallFAQ();
                foreach (FAQ_getallFAQResult CAUHOITHUONGGAP in lp)
                {
                    CAUHOITHUONGGAP var1 = new CAUHOITHUONGGAP();
                    var1.MaCauHoi = CAUHOITHUONGGAP.MaCauHoi;
                    var1.NoiDungCauHoi = CAUHOITHUONGGAP.NoiDungCauHoi;
                    var1.CauTraLoi = CAUHOITHUONGGAP.CauTraLoi;
                    lst_FAQ.Add(var1);
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

            return lst_FAQ;
        }

        // Thêm Câu hỏi thường gặp
        public int ThemFAQ(string noidungcauhoi, string cautraloi)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.FAQ_add(noidungcauhoi,
                   cautraloi
                   );
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        // Xóa câu hỏi thường gặp
        public int XoaFAQ(int macauhoi)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.FAQ_del(macauhoi);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        // Sửa câu hỏi thường gặp
        public int SuaFAQ(int macauhoi,string noidungcauhoi, string cautraloi)
        {
            try
            {
                LinQDataContext db = new LinQDataContext(global::DAOAuction.Properties.Settings.Default.webdoantruongConnectionString);
                db.FAQ_modify(macauhoi, noidungcauhoi, cautraloi);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
