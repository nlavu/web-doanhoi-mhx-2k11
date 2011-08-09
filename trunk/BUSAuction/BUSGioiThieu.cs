using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSGioiThieu
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<GIOITHIEU> SelectGIOITHIEUsAll()
        {
            DAOGioiThieu GIOITHIEU = new DAOGioiThieu();
            return GIOITHIEU.SelectGIOITHIEUsAll();
        }

        public int Them(GIOITHIEU lpDTO)
        {
            DAOGioiThieu GIOITHIEU = new DAOGioiThieu();
            return GIOITHIEU.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOGioiThieu GIOITHIEU = new DAOGioiThieu();
            return GIOITHIEU.Xoa(machungtu);
        }

        public int CapNhat(GIOITHIEU lpDTO)
        {
            DAOGioiThieu GIOITHIEU = new DAOGioiThieu();
            return GIOITHIEU.CapNhat(lpDTO);
        }

        public GIOITHIEU TimKiem(int machungtu)
        {
            DAOGioiThieu GIOITHIEU = new DAOGioiThieu();
            return GIOITHIEU.TimKiem(machungtu);
        }
        #endregion
    }
}
