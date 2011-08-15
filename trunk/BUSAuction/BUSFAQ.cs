using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSFAQ
    {
        // lấy danh sách tất cả các câu hỏi:
        public List<CAUHOITHUONGGAP> LayDanhSachTatCaCauHoi()
        {
            DAOFAQ CauHoiThuongGap = new DAOFAQ();
            return CauHoiThuongGap.LayDanhSachTatCaCauHoi();
        }

        // lấy câu trả lời của câu hỏi được chọn:
        public CAUHOITHUONGGAP TimKiem(int maCauHoi)
        {
            DAOFAQ CauHoiThuongGap = new DAOFAQ();
            return CauHoiThuongGap.TimKiem(maCauHoi);
        }

        // lấy tất cả câu hỏi thường gặp:
        public List<CAUHOITHUONGGAP> LayDanhSachTatCaCauHoiThuongGap()
        {
            DAOFAQ CauHoiThuongGap = new DAOFAQ();
            return CauHoiThuongGap.getAll_FAQ();
        }

        // thêm câu hỏi thường gặp:
        public int FAQ_Them(string cauhoi, string cautraloi)
        {
            DAOFAQ CauHoiThuongGap = new DAOFAQ();
            if (CauHoiThuongGap.ThemFAQ(cauhoi, cautraloi) == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // xóa câu hỏi thường gặp:
        public int FAQ_Xoa(int macauhoi)
        {
            DAOFAQ CauHoiThuongGap = new DAOFAQ();
            if (CauHoiThuongGap.XoaFAQ(macauhoi) == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // sửa câu hỏi thường gặp:
        public int FAQ_Sua(int macauhoi, string cauhoi, string cautraloi)
        {
            DAOFAQ CauHoiThuongGap = new DAOFAQ();
            if (CauHoiThuongGap.SuaFAQ(macauhoi, cauhoi, cautraloi) == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
