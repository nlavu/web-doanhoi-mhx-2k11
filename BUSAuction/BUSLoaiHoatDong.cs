using System.Collections.Generic;
using System;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSLoaiHoatDong
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<LOAIHOATDONG> SelectLOAIHOATDONGsAll()
        {
            DAOLoaiHoatDong LOAIHOATDONG = new DAOLoaiHoatDong();
            return LOAIHOATDONG.SelectLOAIHOATDONGsAll();
        }

        public int Them(LOAIHOATDONG lpDTO)
        {
            DAOLoaiHoatDong LOAIHOATDONG = new DAOLoaiHoatDong();
            return LOAIHOATDONG.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOLoaiHoatDong LOAIHOATDONG = new DAOLoaiHoatDong();
            return LOAIHOATDONG.Xoa(machungtu);
        }

        public int CapNhat(LOAIHOATDONG lpDTO)
        {
            DAOLoaiHoatDong LOAIHOATDONG = new DAOLoaiHoatDong();
            return LOAIHOATDONG.CapNhat(lpDTO);
        }

        public LOAIHOATDONG TimKiem(int iMaHoatDong)
        {
            DAOLoaiHoatDong LOAIHOATDONG = new DAOLoaiHoatDong();
            return LOAIHOATDONG.TimKiem(iMaHoatDong);
        }

        //Lê Văn Long
        public LOAIHOATDONG TimKiem(string strTenLoai)
        {
            try
            {
                DAOLoaiHoatDong LOAIHOATDONG = new DAOLoaiHoatDong();
                return LOAIHOATDONG.TimKiem(strTenLoai);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
