using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Nhom01.DTO
{
   public class DataP
    {
        //connection string: chuỗi kết nối để cho code c# nó hiểu cơ sở dữ liệu nó cần làm việc
        // là cái nào
        private static DataP instance;
        public string connectSTR = @"Data Source=.;Initial Catalog=QuanLyQuanCaFe;Integrated Security=True";

        public static DataP Instance { get { if (instance == null) instance = new DataP(); return DataP.instance; } private set => instance = value; }
        private DataP() { }
        //thực thi câu truy vấn => trả về 1 cái dữ liệu dạng bảng
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }
        // trả ra dữ liệu dạng số nguyên
        // dùng cho việc update, insert, delete
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data;

            using (SqlConnection connection = new SqlConnection(connectSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }

            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}
