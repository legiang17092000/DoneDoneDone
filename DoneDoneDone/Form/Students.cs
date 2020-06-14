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

        bool _isNew = true; //chưa dùng nó đâu
        DataTable dtStudent = new DataTable();

        private void FormStudents_Load(object sender, EventArgs e)
        {
            DanhSach();
        }

        public void DanhSach()
        {
            dtStudent = new DataTable();
            dtStudent.Clear();//xóa dữ liệu cũ
                              //lấy dữ liệu từ sql vô
            dtStudent = Libs.Database.Data.ExcuteToDataTable("HSThongTinHocSinh", CommandType.StoredProcedure);
            dgvStudent.DataSource = dtStudent; //đổ dữ liệu vô datagridview
            dgvStudent.ClearSelection();
            dgvStudent.CurrentCell = null;
        }


        #region Show Data vào textbox
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _isNew = false;
            int numrow;
            numrow = e.RowIndex;
            txtTen.Text = dgvStudent.Rows[numrow].Cells[1].Value.ToString();
            txtID.Text = dgvStudent.Rows[numrow].Cells[0].Value.ToString();
            txtGioiTinh.Text = dgvStudent.Rows[numrow].Cells[2].Value.ToString();
            txtCMND.Text = dgvStudent.Rows[numrow].Cells[3].Value.ToString();
            txtNgaySinh.Text = dgvStudent.Rows[numrow].Cells[4].Value.ToString();
            txtEmail.Text = dgvStudent.Rows[numrow].Cells[5].Value.ToString();
            txtSDT.Text = dgvStudent.Rows[numrow].Cells[6].Value.ToString();
            txtIDclass.Text = dgvStudent.Rows[numrow].Cells[7].Value.ToString();

        }
        #endregion

        #region Xóa hàng (hàm DeleteData và btnDelete)
        private void DeleteData()
        {
            
                //Bước 1: Tạo Parameter cần thiết
                SqlParameter[] sqlParams = {
                         new SqlParameter("@IDStu",txtID.Text.Trim())};
                //Bước 2: Thực thi Stored Procedure
                Libs.Database.Data.ExecuteNonQuery("HSXoaHocSinh", CommandType.StoredProcedure, sqlParams);
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                DanhSach(); // Làm mới dữ liệu
            
        }
        private void btnDeleta_Click_1(object sender, EventArgs e)
        {
            DeleteData();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {//cái này là làm trống txt
            txtTen.Text = "";
            txtID.Text = "";
            txtGioiTinh.Text = "";
            txtCMND.Text = "";
            txtNgaySinh.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtIDclass.Text = "";
            _isNew = true;
        }

        #region thêm mới data   -Hàm update và btnSave
        private void UpdateData()
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@IDStu",txtID.Text.Trim()),
                new SqlParameter("@Ten", txtTen.Text.Trim()),
                new SqlParameter("@GioiTinh",txtGioiTinh.Text.Trim()),
                new SqlParameter("@SoCMND",txtCMNDsvsa.Text.Trim()),
                new SqlParameter("@NgaySinh",txtNgaySinh.Text.Trim()),
                new SqlParameter("@TaiKhoanEmail",txtEmail.Text.Trim()),
                new SqlParameter("@SDT",txtSDT.Text.Trim()),
                new SqlParameter("@IDClass",txtIDclass.Text.Trim())
            };

            Libs.Database.Data.ExecuteNonQuery("HSThemMoi", CommandType.StoredProcedure, sqlParams);
            MessageBox.Show("Đã thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

            DanhSach(); // Làm mới dữ liệu
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateData();
            DanhSach();
        }

        #endregion


        #region Cập nhật data   -Hàm update và btnSave
        private void UpdateData2()
        {

            {
                SqlParameter[] sqlParam1 = {
                new SqlParameter("@IDStu",txtID.Text.Trim()),
                new SqlParameter("@Ten", txtTen.Text.Trim()),
                new SqlParameter("@GioiTinh",txtGioiTinh.Text.Trim()),
                new SqlParameter("@SoCMND",txtCMNDsvsa.Text.Trim()),
                new SqlParameter("@NgaySinh",txtNgaySinh.Text.Trim()),
                new SqlParameter("@TaiKhoanEmail",txtEmail.Text.Trim()),
                new SqlParameter("@SDT",txtSDT.Text.Trim()),
                new SqlParameter("@IDClass",txtIDclass.Text.Trim())
            };

                Libs.Database.Data.ExecuteNonQuery("HSCapNhatProfile", CommandType.StoredProcedure, sqlParam1);
                MessageBox.Show("Đã Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

                //else MessageBox.Show("ID Student không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                DanhSach(); // Làm mới dữ liệu


            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData2();
            DanhSach();
        }

        #endregion


    }
}
