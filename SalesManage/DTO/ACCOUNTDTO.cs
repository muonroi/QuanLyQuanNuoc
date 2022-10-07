using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DTO
{
   public class ACCOUNTDTO
    {
        string username;
        string password;
        int access;
        public ACCOUNTDTO(string username, string password, int access)
        {
            this.Username = username;
            this.Password = password;
            this.Access = access;

        }
        public ACCOUNTDTO(DataRow row)
        {
            this.Username = row["USERNAME"].ToString();
            this.Password = row["PASSWORDS"].ToString();
            this.Access = (int)row["ACCESS"];
        }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Access { get => access; set => access = value; }
    }
}
