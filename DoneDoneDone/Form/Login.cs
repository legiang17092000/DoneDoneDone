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

namespace DoneDoneDone
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtUsername.Focus();
            }
            else if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtPassword.Focus();
            }
            else { }

            if (txtUsername.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                kiemtradangnhap();
            }
        }

        private void kiemtradangnhap()
        {
            if (txtUsername.Text=="1" && txtPassword.Text=="1") 
                //|| txtUsername.Text == "admin" && txtPassword.Text == "654321")
            {
                MessageBox.Show("Đăng nhập thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                this.Hide();// ẩn form chạy ngầm
                FormAdmin form1 = new FormAdmin();
                form1.ShowDialog(); 
                this.Close();// đóng form
                
            }
            else
            {
                MessageBox.Show("Username hoặc Password không đúng! Vui lòng nhập lại", "THÔNG BÁO");
                txtUsername.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
