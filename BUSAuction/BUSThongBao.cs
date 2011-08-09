using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSThongBao
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<THONGBAO> SelectTHONGBAOsAll()
        {
            DAOThongBao THONGBAO = new DAOThongBao();
            return THONGBAO.SelectTHONGBAOsAll();
        }

        public int Them(THONGBAO lpDTO)
        {
            DAOThongBao THONGBAO = new DAOThongBao();
            return THONGBAO.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOThongBao THONGBAO = new DAOThongBao();
            return THONGBAO.Xoa(machungtu);
        }

        public int CapNhat(THONGBAO lpDTO)
        {
            DAOThongBao THONGBAO = new DAOThongBao();
            return THONGBAO.CapNhat(lpDTO);
        }

        public THONGBAO TimKiem(int machungtu)
        {
            DAOThongBao THONGBAO = new DAOThongBao();
            return THONGBAO.TimKiem(machungtu);
        }
        #endregion


        #region Nhi: Lay Thong Bao THeo Ma Hoat Dong
        public List<THONGBAO> LayThongBaoTheoMaHoatDong(int MaHoatDong)
        {
            DAOThongBao THONGBAO = new DAOThongBao();
            return THONGBAO.LayThongBaoTheoMaHoatDong(MaHoatDong);
        }
        #endregion

        #region Nhi: Select All Thong Bao (New)
        public List<THONGBAO_getall_newResult> SelectTHONGBAOsAll_New()
        {
            DAOThongBao ThongBaoDAO = new DAOThongBao();
            return ThongBaoDAO.SelectTHONGBAOsAll_New();
        }
        #endregion
    }
}
