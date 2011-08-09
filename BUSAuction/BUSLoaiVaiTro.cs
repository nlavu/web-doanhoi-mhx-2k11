using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSLoaiVaiTro
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<LOAIVAITRO> SelectLOAIVAITROsAll()
        {
            DAOLoaiVaiTro LOAIVAITRO = new DAOLoaiVaiTro();
            return LOAIVAITRO.SelectLOAIVAITROsAll();
        }

        public int Them(LOAIVAITRO lpDTO)
        {
            DAOLoaiVaiTro LOAIVAITRO = new DAOLoaiVaiTro();
            return LOAIVAITRO.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOLoaiVaiTro LOAIVAITRO = new DAOLoaiVaiTro();
            return LOAIVAITRO.Xoa(machungtu);
        }

        public int CapNhat(LOAIVAITRO lpDTO)
        {
            DAOLoaiVaiTro LOAIVAITRO = new DAOLoaiVaiTro();
            return LOAIVAITRO.CapNhat(lpDTO);
        }

        public LOAIVAITRO TimKiem(int machungtu)
        {
            DAOLoaiVaiTro LOAIVAITRO = new DAOLoaiVaiTro();
            return LOAIVAITRO.TimKiem(machungtu);
        }
        #endregion
    }
}
