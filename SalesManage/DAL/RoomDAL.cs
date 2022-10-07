using Nhom01.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DAL
{
    public class RoomDAL
    {
        private static RoomDAL instance;
        public static RoomDAL Instance {
            get { if (instance == null) instance = new RoomDAL(); return RoomDAL.instance; }
            private set { RoomDAL.instance = value; }
        }
        private RoomDAL() { }
        public static int TableWidth = 125;
        public static int TableHeight = 125;
        public List<RoomDTO> LoadRoom()
        {
            List<RoomDTO> tableList = new List<RoomDTO>();

            DataTable data = DataP.Instance.ExcuteQuery("SELECT soban,tinhtrang FROM BAN");

            foreach (DataRow item in data.Rows)
            {
                RoomDTO table = new RoomDTO(item);
                tableList.Add(table);
            }

            return tableList;
        }
        public void SwitchTable(int id1, int id2)
        {
            DataP.Instance.ExcuteQuery("USP_SwitchTabel @idTable1 , @idTabel2", new object[] { id1, id2 });
        }
    }
}
