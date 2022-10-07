using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SalesManage.Forms
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            ConnectionLINQDataContext db = new ConnectionLINQDataContext();
            tableView.DataSource = db.bans.Select(nv => nv);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void TableForm_Load(object sender, EventArgs e)
        {

        }

        private void tableView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dtgr = this.tableView.Rows[e.RowIndex];
                    textBox1.Text = dtgr.Cells[0].Value.ToString();
                    comboBox1.Text = dtgr.Cells[1].Value.ToString();
                }

            }
            catch
            {


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
                {
                    string ma = textBox1.Text;
                    string name = comboBox1.Text;

                    ban nv = new ban();
                    nv.Soban = int.Parse(ma);
                    nv.Tinhtrang = name;

                    db.bans.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm bàn mới thành công!");
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
                var tt = (from u in db.bans
                          where u.Soban.Equals(textBox1.Text)
                          select u.Tinhtrang).FirstOrDefault();
                if (tt.Equals("Trống"))
                {
                    string ma = textBox1.Text;
                    string name = comboBox1.Text;
                    ban nv = db.bans.Where(p => p.Soban.Equals(ma)).SingleOrDefault();
                    nv.Soban = int.Parse(ma);
                    nv.Tinhtrang = name;

                }
                else
                {
                    MessageBox.Show("Bàn hiện tại đang có người!");
                }
                db.SubmitChanges();

            }

            LoadData();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals("Trống"))
            {
                MessageBox.Show("Bàn hiện tại đang có người!");

            }
            else
            {
                using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
                {

                    string manv = textBox1.Text;
                    ban nv = db.bans.Where(p => p.Soban.Equals(manv)).FirstOrDefault();
                    db.bans.DeleteOnSubmit(nv);
                    db.SubmitChanges();
                }
            }

            LoadData();
        }
    }
}
