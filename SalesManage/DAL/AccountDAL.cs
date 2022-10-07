using Nhom01.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DAL
{
   
    public class AccountDAL
    {
        private static AccountDAL instance;

        public static AccountDAL Instance { get { if (instance == null) instance = new AccountDAL(); return AccountDAL.instance; } private set => instance = value; }

        private AccountDAL() { }
        public bool login(string user, string pass)
        {
            //store
            string query = @"EXEC USP_LOGIN @USERNAME , @PASSWORD";
            DataTable result = DataP.Instance.ExcuteQuery(query,new object[] {user,pass});
            return result.Rows.Count > 0;
        }
        public ACCOUNTDTO getusername(string user)
        {
            string query = "SELECT * FROM ACCOUNT WHERE USERNAME = N'"+ user + "' ";
            DataTable data = DataP.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new ACCOUNTDTO(item);
            }
            return null;
        }
        public bool Changepass(string user, string pass)
        {
            string query = "UPDATE ACCOUNT SET PASSWORDS = N'"+pass+"' WHERE USERNAME = N'"+user+"'";
            int result  = DataP.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool Adduser(string user, string pass, int access)
        {
            string query = "INSERT ACCOUNT (USERNAME, PASSWORDS, ACCESS) VALUES(N'"+ user + "','"+pass+"',"+access+")";
            int result = DataP.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
