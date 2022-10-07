using System;
using System.Windows.Forms;

namespace SalesManage.Forms
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
                {
                    string ma = textBox1.Text;
                    string name = textBox2.Text;
                    string phone = textBox3.Text;
                    int pos = radioButton1.Checked == true ? 1 : 0;
                    user nv = new user();
                    nv.Name = ma;
                    nv.UserName = name;
                    nv.Password = phone;
                    nv.priority = pos;
                    db.users.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm tài khoản mới thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tài khoản đã tồn tại ");
            }
        }
    }
}
