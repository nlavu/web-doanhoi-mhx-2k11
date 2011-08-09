using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSKhaoSat
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<KHAOSAT> SelectKHAOSATsAll()
        {
            DAOKhaoSat KHAOSAT = new DAOKhaoSat();
            return KHAOSAT.SelectKHAOSATsAll();
        }

        public int Them(KHAOSAT lpDTO)
        {
            DAOKhaoSat KHAOSAT = new DAOKhaoSat();
            return KHAOSAT.Them(lpDTO);
        }

        public int Xoa(KHAOSAT  lpDTO)
        {
            DAOKhaoSat KHAOSAT = new DAOKhaoSat();
            return KHAOSAT.Xoa(lpDTO );
        }

        public int CapNhat(KHAOSAT lpDTO)
        {
            DAOKhaoSat KHAOSAT = new DAOKhaoSat();
            return KHAOSAT.CapNhat(lpDTO);
        }

        public KHAOSAT TimKiem(int machungtu)
        {
            DAOKhaoSat KHAOSAT = new DAOKhaoSat();
            return KHAOSAT.TimKiem(machungtu);
        }
        #endregion

        #region Nhi
      
        #endregion
    }
}
