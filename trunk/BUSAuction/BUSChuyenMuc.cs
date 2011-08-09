using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSChuyenMuc
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<CHUYENMUC> SelectCHUYENMUCsAll()
        {
            DAOChuyenMuc CHUYENMUC = new DAOChuyenMuc();
            return CHUYENMUC.SelectCHUYENMUCsAll();
        }
        public List<CHUYENMUC> SelectCHUYENMUCsAll_exception()
        {
            DAOChuyenMuc CHUYENMUC = new DAOChuyenMuc();
            return CHUYENMUC.SelectCHUYENMUCsAll_exception();
        }
        public int Them(CHUYENMUC lpDTO)
        {
            DAOChuyenMuc CHUYENMUC = new DAOChuyenMuc();
            return CHUYENMUC.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOChuyenMuc CHUYENMUC = new DAOChuyenMuc();
            return CHUYENMUC.Xoa(machungtu);
        }

        public int CapNhat(CHUYENMUC lpDTO)
        {
            DAOChuyenMuc CHUYENMUC = new DAOChuyenMuc();
            return CHUYENMUC.CapNhat(lpDTO);
        }

        public CHUYENMUC TimKiem(int machungtu)
        {
            DAOChuyenMuc CHUYENMUC = new DAOChuyenMuc();
            return CHUYENMUC.TimKiem(machungtu);
        }
        #endregion

        #region Nhi:Lay CHUYENMUC theo loai bai viet

        public CHUYENMUC LayChuyenMucTheoBaiViet(int maloaibaiviet)
        {
            DAOChuyenMuc CHUYENMUC = new DAOChuyenMuc();
            return CHUYENMUC.LayChuyenMucTheoBaiViet(maloaibaiviet);
        }
        #endregion

        #region Tin: Tim chuyen muc theo ten
        public CHUYENMUC TimKiemTen(string tenchuyenmuc)
        {
            DAOChuyenMuc CHUYENMUC = new DAOChuyenMuc();
            return CHUYENMUC.TimKiemTen(tenchuyenmuc);
        }
        #endregion
    }
}
