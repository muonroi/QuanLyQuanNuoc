using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SalesManage.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        OpenFileDialog open;
        private void Signinbtn_Click(object sender, EventArgs e)
        {   
            try
            {
                string tk = usertxt.Text;
                string mk = passtxt.Text;
                int pos = 0;
           
                ConnectionLINQDataContext us = new ConnectionLINQDataContext();
            
                var check = from u in us.users
                             select new
                             {
                                 user = u.UserName,
                                 pass = u.Password,
                                 pos = u.priority
                             };
                //SELECT * FROM USERS
                var flag = 1;
                foreach (var item in check)
                    if (item.user == tk && item.pass == mk)
                    {
                        flag = 0;
                        //1
                        pos = (int)item.pos;
                        break;
                    }
                if (flag == 0)
                {
                    //lay quyen cua user vua dang nhap truyen vao form main
                    Mainmenu main = new Mainmenu(pos);
                    main.Size = new Size(1260, 620);
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu chưa chính xác!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SignUpbtn_Click(object sender, EventArgs e)
        {
           
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
