using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
namespace SalesManage.Forms
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            ConnectionLINQDataContext db = new ConnectionLINQDataContext();
            dataGridView1.DataSource = db.thongkes.Select(p=>p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionLINQDataContext db = new ConnectionLINQDataContext();
            DateTime datefrom = dateTimePicker1.Value;
            DateTime dateto = dateTimePicker2.Value;
            if (!radioButton2.Checked)
            {
                dataGridView1.DataSource = db.thongkes.Where(
                 p => p.ngaylap.Equals(datefrom.Date));
            }
            else
            {
                dataGridView1.DataSource = db.thongkes.Where(
                p => p.ngaylap > datefrom && p.ngaylap < dateto);
              
            }
            double sum_sum = 0;
            int soluong = 0;
            int num_cell = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                num_cell++;
            }
            try
            {
                for (int i = 0; i < num_cell - 1; i++)
                {
                    int sl  = (int)dataGridView1.Rows[i].Cells["soluong"].Value;
                    double sum = (double)dataGridView1.Rows[i].Cells["doanhthu"].Value;
                    sum_sum += sum;
                    soluong += sl;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            CultureInfo culrure = new CultureInfo("vi-VN");
            label2.Text = sum_sum.ToString("c", culrure);
            label3.Text = soluong.ToString();
        }
    }
}
