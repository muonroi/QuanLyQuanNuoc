using SalesManage.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManage
{
    public partial class Mainmenu : Form
    {
        private Button currentButton;
       // private Random random;
        private int tempIndex;
        private Form activateForm;
        //lay quyen tu form dang nhap
        public Mainmenu(int pos)
        {
            InitializeComponent();
            //random = new Random();
            //truyen quyen vao ham phan quyen
            access(pos);
           
        }
        // ham phan quyen neu quyen cua user = 1 thi user do la admin con nguoc lai la nhan vien
        void access(int type)
        {
            btnEmployee.Enabled = type == 1;
            pictureBox1.Enabled = type == 1;
            pictureBox2.Enabled = type == 1;
            pictureBox5.Enabled = type == 1;
            pictureBox6.Enabled = type == 1;
            pictureBox7.Enabled = type == 1;
            pictureBox4.Enabled = type == 1;
            btnProduct.Enabled = type == 1;
            button2.Enabled = type == 1;
            button10.Enabled = type == 1;
            button6.Enabled = type == 1;
            button7.Enabled = type == 1;

        }
        private void openChildForm(Form childForm, Object btnSender)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }
           // ActivateButton(btnSender);
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

      
        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelLogo_Click(object sender, EventArgs e)
        {

        }
      

        private void Mainmenu_Load(object sender, EventArgs e)
        {

        }


        private void button13_Click(object sender, EventArgs e)
        {
            Employee ee = new Employee();
            ee.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Employee ee = new Employee();
            ee.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Sản phẩm";
            openChildForm(new Forms.Product(), sender);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Sản phẩm";
            openChildForm(new Forms.Product(), sender);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Hóa đơn";
            openChildForm(new Forms.Bill(), sender);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Hóa đơn";
            openChildForm(new Forms.Bill(), sender);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Thông tin bàn";
            openChildForm(new Forms.TableForm(), sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Thông tin bàn";
            openChildForm(new Forms.TableForm(), sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Ca trực";
            openChildForm(new Forms.ShiftForm(), sender);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Ca trực";
            openChildForm(new Forms.ShiftForm(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SignUpForm sign = new SignUpForm();
            sign.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SignUpForm sign = new SignUpForm();
            sign.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
