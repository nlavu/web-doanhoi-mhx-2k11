using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSDangKyHoatDong
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<DANGKYHOATDONG_getallResult> SelectDANGKYHOATDONGsAll()
        {
            DAODangKyHoatDong DANGKYHOATDONG = new DAODangKyHoatDong();
            return DANGKYHOATDONG.SelectDANGKYHOATDONGsAll();
        }

        public int Them(DANGKYHOATDONG lpDTO)
        {
            DAODangKyHoatDong DANGKYHOATDONG = new DAODangKyHoatDong();
            return DANGKYHOATDONG.Them(lpDTO);
        }

        public int Xoa(DANGKYHOATDONG lpDTO)
        {
            DAODangKyHoatDong DANGKYHOATDONG = new DAODangKyHoatDong();
            return DANGKYHOATDONG.Xoa(lpDTO);
        }

        public int CapNhat(DANGKYHOATDONG lpDTO)
        {
            DAODangKyHoatDong DANGKYHOATDONG = new DAODangKyHoatDong();
            return DANGKYHOATDONG.CapNhat(lpDTO);
        }

        public DANGKYHOATDONG TimKiem(int manguoidung)
        {
            DAODangKyHoatDong DANGKYHOATDONG = new DAODangKyHoatDong();
            return DANGKYHOATDONG.TimKiem(manguoidung);
        }

       /* public DANGKYHOATDONG TimKiem(int manguoidung, int mahoatdong)
        {
            DAODangKyHoatDong DANGKYHOATDONG = new DAODangKyHoatDong();
            return DANGKYHOATDONG.TimKiem(manguoidung, mahoatdong);
        }*/

        public List<DANGKYHOATDONG_get_MaHoatDongResult> SelectDANGKYHOATDONGs_HoatDong(int mahoatdong)
        {
            DAODangKyHoatDong DANGKYHOATDONG = new DAODangKyHoatDong();
            return DANGKYHOATDONG.SelectDANGKYHOATDONGs_HoatDong(mahoatdong);
        }
        #endregion


        #region Duy HamBoSung 29/7/2010
        public List<DANGKYHOATDONG> TimKiemTheoMaSinhVien(int MaSV)
        {
            DAODangKyHoatDong daoDKHoatDong = new DAODangKyHoatDong();
            return daoDKHoatDong.SelectDANGKYHOATDONGbyMASV(MaSV);
        }

        public DANGKYHOATDONG TimKiem(int manguoidung, int mahoatdong)
        {
            DAODangKyHoatDong DANGKYHOATDONG = new DAODangKyHoatDong();
            return DANGKYHOATDONG.TimKiem(manguoidung, mahoatdong);
        }
        #endregion

        public int Xoa(int mahoatdong)
        {
            DAODangKyHoatDong DANGKYHOATDONG = new DAODangKyHoatDong();
            return DANGKYHOATDONG.Xoa(mahoatdong);
        }
    }
}
