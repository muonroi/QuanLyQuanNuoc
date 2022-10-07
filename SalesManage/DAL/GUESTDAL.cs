using Nhom01.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom01.DAL
{
   public class GUESTDAL
   {
        private static GUESTDAL instance;
        public static GUESTDAL Instance
        {
            get { if (instance == null) instance = new GUESTDAL(); return GUESTDAL.instance; }
            private set { GUESTDAL.instance = value; }
        }
        private GUESTDAL() { }
        public bool InserGuest(string firstname, string lastname, int cmnd, string sex, string reverRoom, int numberroom)
        {
            string query = "EXEC INSERT_GUEST @FIRSTNAME , @LASTNAME , @CMND , @SEX , @BOOKROOMDATE , @NUMBERROOM";
            int result = DataP.Instance.ExcuteNonQuery(query, new object[] { firstname, lastname, cmnd, sex,reverRoom, numberroom});
            return result > 0;
        }
    }
}
