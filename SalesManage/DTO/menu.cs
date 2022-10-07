using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DTO
{
   public class menu
    {
        public menu(string foodName, int count, float price, string date,float totalPrice = 0)
        {
            this.Servicename = foodName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
            this.Date = date;
        }

        public menu(DataRow row)
        {
            this.Servicename = row["TYPE_SERVICE"].ToString();
            this.Count = (int)row["soluong"];
            this.Price = (float)Convert.ToDouble(row["PRICE"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
            this.Date = row["CREATE_BILL"].ToString();
        }
        private float totalPrice;
        private float price;
        private int count;
        private string servicename;
        private string date;
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public float Price { get => price; set => price = value; }
        public int Count { get => count; set => count = value; }
        public string Servicename { get => servicename; set => servicename = value; }
        public string Date { get => date; set => date = value; }
    }
}
