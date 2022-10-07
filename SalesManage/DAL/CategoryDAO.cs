using Nhom01.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nhom01.DAL
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }
        public List<CategoryDTO> GetListCategory()
        {
            List<CategoryDTO> list = new List<CategoryDTO>();

            string query = "select * from se";

            DataTable data = DataP.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                CategoryDTO category = new CategoryDTO(item);
                list.Add(category);
            }

            return list;
        }
        public void DelCategory()
        {
            string query = "exec DEL_DUPLICATE";

            DataP.Instance.ExcuteNonQuery(query);
        }
    }
}
