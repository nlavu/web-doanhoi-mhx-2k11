using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSBaiHat
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<BAIHAT> SelectBAIHATsAll()
        {
            DAOBaiHat BAIHAT = new DAOBaiHat();
            return BAIHAT.SelectBAIHATsAll();
        }

        public int Them(BAIHAT lpDTO)
        {
            DAOBaiHat BAIHAT = new DAOBaiHat();
            return BAIHAT.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOBaiHat BAIHAT = new DAOBaiHat();
            return BAIHAT.Xoa(machungtu);
        }

        public int CapNhat(BAIHAT lpDTO)
        {
            DAOBaiHat BAIHAT = new DAOBaiHat();
            return BAIHAT.CapNhat(lpDTO);
        }

        public BAIHAT TimKiem(int machungtu)
        {
            DAOBaiHat BAIHAT = new DAOBaiHat();
            return BAIHAT.TimKiem(machungtu);
        }
        #endregion
    }
}
