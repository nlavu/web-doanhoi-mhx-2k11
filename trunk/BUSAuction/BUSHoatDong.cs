using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSHoatDong
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<HOATDONG> SelectHOATDONGsAll()
        {
            DAOHoatDong HOATDONG = new DAOHoatDong();
            return HOATDONG.SelectHOATDONGsAll();
        }

        public int Them(HOATDONG lpDTO)
        {
            DAOHoatDong HOATDONG = new DAOHoatDong();
            return HOATDONG.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOHoatDong HOATDONG = new DAOHoatDong();
            return HOATDONG.Xoa(machungtu);
        }

        public int CapNhat(HOATDONG lpDTO)
        {
            DAOHoatDong HOATDONG = new DAOHoatDong();
            return HOATDONG.CapNhat(lpDTO);
        }

        public HOATDONG TimKiem(int iMaHoatDong)
        {
            DAOHoatDong HOATDONG = new DAOHoatDong();
            return HOATDONG.TimKiem(iMaHoatDong);
        }

#endregion
        #region //Lê Văn Long: lấy hoạt động theo loại
        public List<HOATDONG> LayHoatDongTheoLoai(int iMaLoai)
        {
            try
            {
                DAOHoatDong daoHoatDong = new DAOHoatDong();
                return daoHoatDong.SelectHOATDONGByLoai(iMaLoai);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Tuấn 5/8/2010: Tìm kiếm hoạt động theo tên
        public List<HOATDONG> TimKiemTen(string tenhoatdong)
        {
            DAOHoatDong HOATDONG = new DAOHoatDong();
            return HOATDONG.TimKiemTen(tenhoatdong);
        }
        #endregion
    }
}
