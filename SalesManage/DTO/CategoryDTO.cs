using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DTO
{
   public class CategoryDTO
    {
        public CategoryDTO(int id, string name, float price)
        {
           this.ID = id;
           this.Name = name;
           this.Price = price;
        }

        public CategoryDTO(DataRow row)
        {
            this.ID = (int)row["ID_SERVICE"];
            this.Name = row["TYPE_SERVICE"].ToString();
            this.Price = (Double)row["PRICE"];
        }
        private Double price;
        public Double Price 
        {
            get => price; set => price = value; 
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

      
    }
}
