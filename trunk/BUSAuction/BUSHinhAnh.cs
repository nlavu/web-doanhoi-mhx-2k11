using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSHinhAnh
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<HINHANH> SelectHINHANHsAll()
        {
            DAOHinhAnh HINHANH = new DAOHinhAnh();
            return HINHANH.SelectHINHANHsAll();
        }

        public int Them(HINHANH lpDTO)
        {
            DAOHinhAnh HINHANH = new DAOHinhAnh();
            return HINHANH.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOHinhAnh HINHANH = new DAOHinhAnh();
            return HINHANH.Xoa(machungtu);
        }

        public int CapNhat(HINHANH lpDTO)
        {
            DAOHinhAnh HINHANH = new DAOHinhAnh();
            return HINHANH.CapNhat(lpDTO);
        }

        public HINHANH TimKiem(int machungtu)
        {
            DAOHinhAnh HINHANH = new DAOHinhAnh();
            return HINHANH.TimKiem(machungtu);
        }
        #endregion
    }
}
