using Nhom01.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DAL
{
   public class BillDAL
    {
        private static BillDAL instance;

        public static BillDAL Instance
        {
            get { if (instance == null) instance = new BillDAL(); return BillDAL.instance; }
            private set { BillDAL.instance = value; }
        }

        private BillDAL() { }
        public int GetBillIDByRoomID(int id)
        {
            DataTable data = DataP.Instance.ExcuteQuery("SELECT * FROM Bill WHERE Bill.NUMER_ROOM = " + id + " AND status = 0");

            if (data.Rows.Count > 0)
            {
                BILLDTO bill = new BILLDTO(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }
        public void InsertBill(int idroom)
        {
            DataP.Instance.ExcuteNonQuery("exec INSERTBILL @numberroom", new object[] {idroom });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataP.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
        public void checkout(int id)
        {
            string query = "UPDATE dbo.Bill SET status = 1 WHERE id = " + id;
            DataP.Instance.ExcuteNonQuery(query);
        }
    }
}
