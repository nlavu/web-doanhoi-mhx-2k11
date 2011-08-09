using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSLoaiBaiViet
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<LOAIBAIVIET> SelectLOAIBAIVIETsAll()
        {
            DAOLoaiBaiViet LOAIBAIVIET = new DAOLoaiBaiViet();
            return LOAIBAIVIET.SelectLOAIBAIVIETsAll();
        }

        public int Them(LOAIBAIVIET lpDTO)
        {
            DAOLoaiBaiViet LOAIBAIVIET = new DAOLoaiBaiViet();
            return LOAIBAIVIET.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOLoaiBaiViet LOAIBAIVIET = new DAOLoaiBaiViet();
            return LOAIBAIVIET.Xoa(machungtu);
        }

        public int CapNhat(LOAIBAIVIET lpDTO)
        {
            DAOLoaiBaiViet LOAIBAIVIET = new DAOLoaiBaiViet();
            return LOAIBAIVIET.CapNhat(lpDTO);
        }

        public LOAIBAIVIET TimKiem(int machungtu)
        {
            DAOLoaiBaiViet LOAIBAIVIET = new DAOLoaiBaiViet();
            return LOAIBAIVIET.TimKiem(machungtu);
        }
        #endregion

        #region Nhi: Tìm Kiếm Bài Viết Theo Chuyên Mục 31/7/2010
        public List<LOAIBAIVIET> TimKiemLoaiBaiVietTheoChuyenMuc(int MaChuyenMuc)
        {
            DAOLoaiBaiViet LOAIBAIVIET = new DAOLoaiBaiViet();
            return LOAIBAIVIET.TimKiemLoaiBaiVietTheoChuyenMuc(MaChuyenMuc);
        }
        #endregion

        #region Đức: 5/8/2010
        public List<LOAIBAIVIET_getall_chitietResult> SelectLOAIBAIVIETsAll_chitiet()
        {
            DAOLoaiBaiViet LOAIBAIVIET = new DAOLoaiBaiViet();
            return LOAIBAIVIET.SelectLOAIBAIVIETsAll_chitiet();
        }
        #endregion

        #region Tin: Tim Kiem Loai Bai Viet Theo Ten 14/08/2010
        public LOAIBAIVIET TimKiemTen(string tenLoaiBaiViet)
        {
            DAOLoaiBaiViet LOAIBAIVIET = new DAOLoaiBaiViet();
            return LOAIBAIVIET.TimKiemTen(tenLoaiBaiViet);
        }
        #endregion
    }
}
