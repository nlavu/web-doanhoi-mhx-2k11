using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSDangKyMuonPhong
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<DANGKYMUONPHONG> SelectDANGKYMUONPHONGsAll()
        {
            DAODangKyMuonPhong DANGKYMUONPHONG = new DAODangKyMuonPhong();
            return DANGKYMUONPHONG.SelectDANGKYMUONPHONGsAll();
        }

        public int Them(DANGKYMUONPHONG lpDTO)
        {
            DAODangKyMuonPhong DANGKYMUONPHONG = new DAODangKyMuonPhong();
            return DANGKYMUONPHONG.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAODangKyMuonPhong DANGKYMUONPHONG = new DAODangKyMuonPhong();
            return DANGKYMUONPHONG.Xoa(machungtu);
        }

        public int CapNhat(DANGKYMUONPHONG lpDTO)
        {
            DAODangKyMuonPhong DANGKYMUONPHONG = new DAODangKyMuonPhong();
            return DANGKYMUONPHONG.CapNhat(lpDTO);
        }

        public DANGKYMUONPHONG TimKiem(int machungtu)
        {
            DAODangKyMuonPhong DANGKYMUONPHONG = new DAODangKyMuonPhong();
            return DANGKYMUONPHONG.TimKiem(machungtu);
        }

// 	public List<NGUOIDUNG_DANGKYMUONPHONG_layUsernameTheoMaNguoiDungResult> DangKyMuonPhongVoiUsername(int manguoidung)
//         {
//             DAODangKyMuonPhong DANGKYMUONPHONG = new DAODangKyMuonPhong();
//             return DANGKYMUONPHONG.DangKyMuonPhongVoiUsername(manguoidung);
//         }
        #endregion

    #region Duy HamBoSung 29/7/2010
    public List<DANGKYMUONPHONG> TimKiemDANGKYMUONPHONGtheoSV(int MaSV)
    {
        DAOAuction.DAODangKyMuonPhong dkMuonPhong = new DAODangKyMuonPhong();
        return dkMuonPhong.SelectDANGKYMUONPHONGbySinhVien(MaSV);
    }
    #endregion 

    #region HMinh HamBoSung 3/8/2010
    public List<DANGKYMUONPHONG> SelectDANGKYMUONPHONGBYDATE(DateTime NgayXoa)
    {
        DAODangKyMuonPhong DANGKYMUONPHONG = new DAODangKyMuonPhong();
        return DANGKYMUONPHONG.SelectDANGKYMUONPHONGBYDATE(NgayXoa);
    }
    #endregion

    public List<DANGKYMUONPHONG_getallwithNameUserResult> SelectDANGKYMUONPHONGsAllwithNameUser()
    {
        DAODangKyMuonPhong DANGKYMUONPHONG = new DAODangKyMuonPhong();
        return DANGKYMUONPHONG.SelectDANGKYMUONPHONGsAllwithNameUser();
    }

    }
}
