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
    public partial class FormStudents : Form
    {
        public FormStudents()
        {
            InitializeComponent();
        }
        DataTable dtStu = new DataTable();
        private void FormStudents_Load(object sender, EventArgs e)
        {
            DanhSach();
        }

        public void DanhSach()
        {
            dtStu = new DataTable();
            dtStu.Clear();//xóa dữ liệu cũ
                              //lấy dữ liệu từ sql vô
            dtStu = Libs.Database.Data.ExcuteToDataTable("HSThongTinHocSinh", CommandType.StoredProcedure);
            dgvStudent.DataSource = dtStu; //đổ dữ liệu vô datagridview
            dgvStudent.ClearSelection();
            dgvStudent.CurrentCell = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentInsert();
            DanhSach();
        }
        public void StudentInsert()
        {
            SqlParameter[] SParam = {
                new SqlParameter("@IDStu",txtID.Text.Trim() ),
                new SqlParameter("@Ten", txtTen.Text.Trim()),
                new SqlParameter("@GioiTinh",txtGioiTinh.Text.Trim()),
                new SqlParameter("@SoCMND",txtCMND.Text.Trim()),
                new SqlParameter("@NgaySinh",txtNgaySinh.Text.Trim()),
                new SqlParameter("@TaiKhoanEmail",txtEmail.Text.Trim()),
                new SqlParameter("@SDT",txtSDT.Text.Trim()),
                new SqlParameter("@IDClass",txtIDclass.Text.Trim())

            };
            Libs.Database.Data.ExecuteNonQuery("HSThemMoi", CommandType.StoredProcedure, SParam);
            MessageBox.Show("Add new student succesfully", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
