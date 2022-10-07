using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DTO
{
   public class MoreBillDTO
    {
        public MoreBillDTO(int id, int idbill, int idse, int count)
        {
            this.ID = id;
            this.Idbill = idbill;
            this.Idse = idse;
            this.Count = count;
        }

        public MoreBillDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Idbill = (int)row["id_bill"];
            this.Idse = (int)row["id_SE"];
            this.Count = (int)row["COUNT"];
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public int Idbill { get => idbill; set => idbill = value; }
        public int Idse { get => idse; set => idse = value; }
        public int ID { get => iD; set => iD = value; }

        private int idbill;
        private int idse;
        private int iD;

       
    }
}
