using Nhom01.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DAL
{
    public class MenuDAL
    {
        private static MenuDAL instance;

        public static MenuDAL Instance
        {
            get { if (instance == null) instance = new MenuDAL(); return MenuDAL.instance; }
            private set { MenuDAL.instance = value; }
        }
        private MenuDAL() { }
        public List<menu> GetListMenuByTable(int id)
        {
            List<menu> listMenu = new List<menu>();

            string query = @"exec USP_GetBill @room";
            DataTable data = DataP.Instance.ExcuteQuery(query, new object[] {id});

            foreach (DataRow item in data.Rows)
            {
                menu menu = new menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
