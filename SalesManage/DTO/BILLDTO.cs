using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DTO
{
    public class BILLDTO
    {
        public BILLDTO(int id,int status)
        {
            this.ID = id;
            this.Status = status;
        }

        public BILLDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Status = (int)row["status"];
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private int id_guest;
        public int Id_guest { get => id_guest; set => id_guest = value; }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

       
    }
}
