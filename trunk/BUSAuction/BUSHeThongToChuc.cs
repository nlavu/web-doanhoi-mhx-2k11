using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSHeThongToChuc
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<HETHONGTOCHUC> SelectHETHONGTOCHUCsAll()
        {
            DAOHeThongToChuc HETHONGTOCHUC = new DAOHeThongToChuc();
            return HETHONGTOCHUC.SelectHETHONGTOCHUCsAll();
        }

        public int Them(HETHONGTOCHUC lpDTO)
        {
            DAOHeThongToChuc HETHONGTOCHUC = new DAOHeThongToChuc();
            return HETHONGTOCHUC.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOHeThongToChuc HETHONGTOCHUC = new DAOHeThongToChuc();
            return HETHONGTOCHUC.Xoa(machungtu);
        }

        public int CapNhat(HETHONGTOCHUC lpDTO)
        {
            DAOHeThongToChuc HETHONGTOCHUC = new DAOHeThongToChuc();
            return HETHONGTOCHUC.CapNhat(lpDTO);
        }

        public HETHONGTOCHUC TimKiem(int machungtu)
        {
            DAOHeThongToChuc HETHONGTOCHUC = new DAOHeThongToChuc();
            return HETHONGTOCHUC.TimKiem(machungtu);
        }
        #endregion
    }
}
