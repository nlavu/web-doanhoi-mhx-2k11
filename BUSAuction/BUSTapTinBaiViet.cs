using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSTapTinBaiViet
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<TAPTINBAIVIET> SelectTAPTINBAIVIETsAll()
        {
            DAOTapTinBaiViet TAPTINBAIVIET = new DAOTapTinBaiViet();
            return TAPTINBAIVIET.SelectTAPTINBAIVIETsAll();
        }

        public int Them(TAPTINBAIVIET lpDTO)
        {
            DAOTapTinBaiViet TAPTINBAIVIET = new DAOTapTinBaiViet();
            return TAPTINBAIVIET.Them(lpDTO);
        }

        public int Xoa(int maTapTin)
        {
            DAOTapTinBaiViet TAPTINBAIVIET = new DAOTapTinBaiViet();
            return TAPTINBAIVIET.Xoa(maTapTin);
        }

        public int CapNhat(TAPTINBAIVIET lpDTO)
        {
            DAOTapTinBaiViet TAPTINBAIVIET = new DAOTapTinBaiViet();
            return TAPTINBAIVIET.CapNhat(lpDTO);
        }
        #endregion
        #region tin
        public TAPTINBAIVIET TimKiemMaTapTin(int maTapTin)
        {
            DAOTapTinBaiViet TAPTINBAIVIET = new DAOTapTinBaiViet();
            return TAPTINBAIVIET.TimKiemMaTapTin(maTapTin);
        }
        public List<TAPTINBAIVIET> TimKiemMaBaiViet(int maBaiViet)
        {
            DAOTapTinBaiViet TAPTINBAIVIET = new DAOTapTinBaiViet();
            return TAPTINBAIVIET.TimKiemMaBaiViet(maBaiViet);
        }
        public TAPTINBAIVIET TimKiemTenTapTin(string tenTapTin)
        {
            DAOTapTinBaiViet TAPTINBAIVIET = new DAOTapTinBaiViet();
            return TAPTINBAIVIET.TimKiemTenTapTin(tenTapTin);
        }
        public int TimSoLuongTapTin()
        {
            int sl;

            DAOTapTinBaiViet TAPTINBAIVIET = new DAOTapTinBaiViet();
            List<TAPTINBAIVIET> listTapTin = TAPTINBAIVIET.SelectTAPTINBAIVIETsAll();
            sl = listTapTin.Count;

            return sl;
        }

        public List<TAPTINBAIVIET> getLichLamViec()
        {
            DAOTapTinBaiViet TAPTINBAIVIET = new DAOTapTinBaiViet();
            return TAPTINBAIVIET.getLichLamViec();
        }
        public int getMaBaiVietLichLamViec()
        {
            DAOTapTinBaiViet llv = new DAOTapTinBaiViet();
            return llv.getMaBaiVietLichLamViec();
        }
        #endregion
        
    }
}
