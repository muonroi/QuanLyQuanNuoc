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
    public partial class Product : Form
    {
       
        public Product()
        {
            InitializeComponent();
            loaddata();
        }

        void loaddata()
        {
            ConnectionLINQDataContext db = new ConnectionLINQDataContext();
            ProductView.DataSource = db.douongs.Select(p => p);
        }

        private void ProductView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = ProductView.CurrentRow.Index;
                textTensp.Text = ProductView.Rows[i].Cells[1].Value.ToString();
                numericUpDown1.Text = ProductView.Rows[i].Cells[4].Value.ToString();
                numericUpDown2.Text = ProductView.Rows[i].Cells[3].Value.ToString();
                txtghichu.Text = ProductView.Rows[i].Cells[2].Value.ToString();
            }
            catch
            {
            }
          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void Product_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string name_product = textTensp.Text;
            double price_product = Convert.ToDouble(numericUpDown1.Value);
            int Count_product = Convert.ToInt32(numericUpDown2.Value);
            string more_product = txtghichu.Text;
            using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
            {
                var spht = from x in db.douongs
                           where x.tendouong.Equals(name_product)
                           select new
                           {
                               ten = x.tendouong
                           };
                bool flag = true;
                foreach (var item in spht)
                {
                    if (name_product.Equals(item.ten))
                    {
                        flag = false;
                        break;

                    }
                }
                if (!flag)
                {
                    MessageBox.Show("San pham da ton tai!");

                }
                else if (flag)
                {
                    douong du = new douong();
                    du.tendouong = name_product;
                    du.ghichu = more_product;
                    du.giatien = price_product;
                    du.Soluong = Count_product;
                    db.douongs.InsertOnSubmit(du);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công!");
                }
            }
            loaddata();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string name_product = textTensp.Text;
            double price_product = Convert.ToDouble(numericUpDown1.Value);
            string more_product = txtghichu.Text;
            int Count_product = Convert.ToInt32(numericUpDown2.Value);
            string msp = ProductView.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
            using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
            {
                douong du = db.douongs.Where(p => p.ID.Equals(msp)).FirstOrDefault();
                du.tendouong = name_product;
                du.ghichu = more_product;
                du.giatien = price_product;
                du.Soluong = Count_product;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công!");
            }
            loaddata();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string msp = ProductView.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
            using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
            {
                douong dos = db.douongs.Where(p => p.ID.Equals(msp)).FirstOrDefault();
                db.douongs.DeleteOnSubmit(dos);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công");
            }
            loaddata();
        }
    }
}
