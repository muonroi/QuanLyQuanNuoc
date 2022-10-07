using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom01.DTO
{
   public class GUEST
    {
        public GUEST(int id, string firstname, string lastname, int cmnd, string sex,string bookDate, string reverRoom, int numberroom, int idbill)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Cmnd = cmnd;
            this.Sex = sex;
            this.Bookdate = bookDate;
            this.Reverdate = reverRoom;
            this.Numberroom = numberroom;
            this.Idbill = idbill;
        }
        private int id;
        private string firstname;
        private string lastname;
        private int cmnd;
        private string sex;
        private string bookdate;
        private string reverdate;
        private int numberroom;
        private int idbill;

        public int Id { get => id; set => id = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public int Cmnd { get => cmnd; set => cmnd = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Bookdate { get => bookdate; set => bookdate = value; }
        public string Reverdate { get => reverdate; set => reverdate = value; }
        public int Numberroom { get => numberroom; set => numberroom = value; }
        public int Idbill { get => idbill; set => idbill = value; }
    }
}
