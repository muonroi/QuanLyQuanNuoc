
using Nhom01.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SalesManage.Forms
{

    public partial class ShiftForm : Form
    {

        public ShiftForm()
        {
            InitializeComponent();
            LoadData();
            LoadCategory();
            LoadCategory2();
        }

        void LoadData()
        {
            ConnectionLINQDataContext db = new ConnectionLINQDataContext();
            tableView.DataSource = from x in db.CATRUCs
                                   join xx in db.nhanviens on x.IDnhanvien equals xx.MANV
                                   select new
                                   {
                                       x.ID,
                                       x.IDnhanvien,
                                       x.ca,
                                       x.ngaytruc
                                   };
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }


        private void ShiftForm_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(DataP.Instance.connectSTR);
        void LoadCategory2()
        {
            conn.Open();
            string sql = "SELECT manv FROM nhanvien";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            comboBox1.DataSource = dt.Tables[0];
            comboBox1.DisplayMember = "manv";
        }
        void LoadCategory()
        {
            conn.Open();
            string sql = "SELECT ca FROM catruc";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            comboBox1.DataSource = dt.Tables[0];
            comboBox1.DisplayMember = "ca";
        }
        private void tableView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = tableView.CurrentRow.Index;
                comboBox2.Text = tableView.Rows[i].Cells[2].Value.ToString();
                comboBox1.Text = tableView.Rows[i].Cells[1].Value.ToString();
                dateTimePicker1.Value = (DateTime)tableView.Rows[i].Cells[3].Value;
            }
            catch
            {

             
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
                {
                    DateTime dt = dateTimePicker1.Value;
                    string namenv = comboBox1.Text;
                    string name = comboBox2.Text;
                    CATRUC nv = new CATRUC();
                    nv.IDnhanvien = int.Parse(namenv);
                    nv.ngaytruc = dt;
                    nv.ca = name;
                    db.CATRUCs.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm ca mới thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra! vui lòng thử lại \n" + ex.Message);
            }

            LoadData();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có chắc chắn xóa ca trực này không?", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
                {
                    string manv = tableView.SelectedCells[0].OwningRow.Cells["idnhanvien"].Value.ToString();
                    CATRUC nv = db.CATRUCs.Where(p => p.IDnhanvien.Equals(manv)).FirstOrDefault();
                    db.CATRUCs.DeleteOnSubmit(nv);
                    db.SubmitChanges();
                }
            }
            LoadData();
        }
    }
}
