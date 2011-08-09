using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSAlbum
    {
        #region Ham chung: Load Them Xoa Capnhat Timkiem 15/07/2010
        public List<ALBUM> SelectALBUMsAll()
        {
            DAOAlbum ALBUM = new DAOAlbum();
            return ALBUM.SelectALBUMsAll();
        }

        public int Them(ALBUM lpDTO)
        {
            DAOAlbum ALBUM = new DAOAlbum();
            return ALBUM.Them(lpDTO);
        }

        public int Xoa(int machungtu)
        {
            DAOAlbum ALBUM = new DAOAlbum();
            return ALBUM.Xoa(machungtu);
        }

        public int CapNhat(ALBUM lpDTO)
        {
            DAOAlbum ALBUM = new DAOAlbum();
            return ALBUM.CapNhat(lpDTO);
        }

        public ALBUM TimKiem(int machungtu)
        {
            DAOAlbum ALBUM = new DAOAlbum();
            return ALBUM.TimKiem(machungtu);
        }
        #endregion
    }
}
