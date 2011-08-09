using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSCauHoiKhaoSat
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<CAUHOIKHAOSAT> SelectCAUHOIKHAOSATsAll()
        {
            DAOCauHoiKhaoSat CAUHOIKHAOSAT = new DAOCauHoiKhaoSat();
            return CAUHOIKHAOSAT.SelectCAUHOIKHAOSATsAll();
        }

        public int Them(CAUHOIKHAOSAT lpDTO)
        {
            DAOCauHoiKhaoSat CAUHOIKHAOSAT = new DAOCauHoiKhaoSat();
            return CAUHOIKHAOSAT.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOCauHoiKhaoSat CAUHOIKHAOSAT = new DAOCauHoiKhaoSat();
            return CAUHOIKHAOSAT.Xoa(machungtu);
        }

        public int CapNhat(CAUHOIKHAOSAT lpDTO)
        {
            DAOCauHoiKhaoSat CAUHOIKHAOSAT = new DAOCauHoiKhaoSat();
            return CAUHOIKHAOSAT.CapNhat(lpDTO);
        }

        public CAUHOIKHAOSAT TimKiem(int machungtu)
        {
            DAOCauHoiKhaoSat CAUHOIKHAOSAT = new DAOCauHoiKhaoSat();
            return CAUHOIKHAOSAT.TimKiem(machungtu);
        }
        #endregion

        #region Quoc Minh: Lay Cau Hoi Khong Bi Khoa
        static public CAUHOIKHAOSAT layCauHoiKhongKhoa()
        {
            DAOCauHoiKhaoSat CAUHOIKHAOSAT = new DAOCauHoiKhaoSat();
            return CAUHOIKHAOSAT.layCauHoiKhongKhoa();
        }
        #endregion
    }
}
