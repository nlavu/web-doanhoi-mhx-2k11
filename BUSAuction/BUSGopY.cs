using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOAuction;
using DTOAuction;

namespace BUSAuction
{
    public class BUSGopY
    {
        public int Them(GOPY lpDTO)
        {
            DAOGopY GopY = new DAOGopY();
            return GopY.Them(lpDTO);
        }
        public List<GOPY> LayDSGopY()
        {
            DAOGopY GopY = new DAOGopY();
            return GopY.SelectGopYsAll();
        }
        public GOPY LayGopYTheoMa(int magopy)
        {
            DAOGopY GopY = new DAOGopY();
            return GopY.TimKiem(magopy);
        }
    }
}
