using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSNguoiDung
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<NGUOIDUNG_getallResult> SelectNGUOIDUNGsAll()
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.SelectNGUOIDUNGsAll ();
        }

        public int Them(NGUOIDUNG lpDTO)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.Xoa(machungtu);
        }

        public int CapNhat(NGUOIDUNG lpDTO)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.CapNhat(lpDTO);
        }

        public int CapNhatWhitOutPass(NGUOIDUNG lpDTO)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.CapNhatWhitOutPass(lpDTO);
        }

        public NGUOIDUNG TimKiem(int machungtu)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.TimKiem(machungtu);
        }
        #endregion
        public NGUOIDUNG TimKiem(string tennguoidung, string password)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.TimKiem(tennguoidung, password);
        }

        public NGUOIDUNG TimKiemTheoUsernameVaEmail(string username, string email)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.TimKiemTheoUsernameVaEmail(username, email);
        }

        public NGUOIDUNG TimKiem(string username)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.TimKiem(username);
        }
        public List<NGUOIDUNG> TimKiem(string username, int flag)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.TimKiem(username, flag);
        }
        public List<NGUOIDUNG> TimKiemHT(string hoten, int flag)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.TimKiemHT(hoten, flag);
        }
        public List<NGUOIDUNG> TimKiem(string username, string hoten, int flag)
        {
            DAONguoiDung NGUOIDUNG = new DAONguoiDung();
            return NGUOIDUNG.TimKiem(username, hoten, flag);
        }

        // Lê Văn Long
        public string EncryptPassword(string password)
        {
            DAONguoiDung daoNguoiDung = new DAONguoiDung();
            return daoNguoiDung.EncryptPassword(password);
        }
    }
}
