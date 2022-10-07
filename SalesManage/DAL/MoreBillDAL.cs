using Nhom01.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DAL
{
   public class MoreBillDAL
    {
        private static MoreBillDAL instance;

        public static MoreBillDAL Instance
        {
            get { if (instance == null) instance = new MoreBillDAL(); return MoreBillDAL.instance; }
            private set { MoreBillDAL.instance = value; }
        }

        private MoreBillDAL() { }
        public List<MoreBillDTO> GetListBillInfo(int id)
        {
            List<MoreBillDTO> listBillInfo = new List<MoreBillDTO>();

            DataTable data = DataP.Instance.ExcuteQuery("SELECT * FROM MoreBILL WHERE id_bill = " + id);

            foreach (DataRow item in data.Rows)
            {
                MoreBillDTO info = new MoreBillDTO(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
        public void InsertBillInfo(int idBill, int idse, int count)
        {
            DataP.Instance.ExcuteNonQuery("exec INSERTMOREBILL @idbill , @idse , @count", new object[] { idBill, idse, count });
        }
    }
}
