using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DTO
{
    public class RoomDTO
    {
        public RoomDTO(DataRow datarow)
        {
            this.Number_room = (int)datarow["SOBAN"];
            this.Type_room = datarow["tinhtrang"].ToString();
        }
        private int number_room;
        public int Number_room { get => number_room; set => number_room = value; }
        private string type_room;
        public string Type_room { get => type_room; set => type_room = value; }
        private string status;
        public string Status { get => status; set => status = value; } 
        
    }
}
