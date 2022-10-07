using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SalesManage.Forms
{
    public partial class Employee : Form
    {
        
        public Employee()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            ConnectionLINQDataContext db = new ConnectionLINQDataContext();
            EmployeeView.DataSource = db.nhanviens.Select(nv => nv);
        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
          
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
          
        }

        private void EmployeeView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            //this.EmployeeView.Columns["ID"].Visible = false;
        }

        private void showBtn_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dtgr = this.EmployeeView.Rows[e.RowIndex];
                    label6.Text = dtgr.Cells[0].Value.ToString();
                    textTennv.Text = dtgr.Cells[1].Value.ToString();
                    if (dtgr.Cells[2].FormattedValue.ToString().Equals("Nam"))
                          radioButton1.Checked = true;
                    else
                            radioButton2.Checked = true;
                    textBoxphone.Text = dtgr.Cells[3].Value.ToString();
                   
                }

            }
            catch (Exception)
            {

                
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
                {
                    string ma = label6.Text;
                    string name = textTennv.Text;
                    string phone = textBoxphone.Text;
                    string gender = radioButton1.Checked == true ? radioButton1.Text : radioButton2.Text;
                    nhanvien nv = new nhanvien();
                    nv.MANV = int.Parse(ma);
                    nv.TENHANVIEN = name;
                    nv.DIENTHOAI = phone;
                    nv.GIOITINH = gender;
                    db.nhanviens.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm nhân viên thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra! vui lòng thử lại \n" + ex.Message);
            }
            LoadData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
            {
                string id = EmployeeView.SelectedCells[0].OwningRow.Cells["MANV"].Value.ToString();
                string ma = label6.Text;
                string name = textTennv.Text;
                string phone = textBoxphone.Text;
                string gender = radioButton1.Checked == true ? radioButton1.Text : radioButton2.Text;
                nhanvien nv = db.nhanviens.Where(p => p.MANV.Equals(id)).SingleOrDefault();
                nv.MANV = Convert.ToInt32(ma);
                nv.TENHANVIEN = name;
                nv.DIENTHOAI = phone;
                nv.GIOITINH = gender;
                db.SubmitChanges();
                MessageBox.Show("Sua nhân viên thành công!");

            }
            LoadData();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
            {
                string manv = label6.Text;
                nhanvien nv = db.nhanviens.Where(p => p.MANV.Equals(manv)).FirstOrDefault();
                db.nhanviens.DeleteOnSubmit(nv);
                db.SubmitChanges();
                MessageBox.Show("Xoa nhân viên thành công!");

            }
            LoadData();
        }
    }
}
