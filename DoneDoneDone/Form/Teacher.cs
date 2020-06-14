using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace DoneDoneDone
{
    public partial class FormTeacher : Form
    {

        public FormTeacher()
        {
            InitializeComponent();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //khoan nha,cái sự kiện này bị sai á

        }
        DataTable dtTeacher;
        bool _isNew = true;

        public void FormTeacher_Load(object sender, EventArgs e)
        {
            DanhSach();
        }
        public void DanhSach()
        {
            dtTeacher = new DataTable();
            dtTeacher.Clear();//xóa dữ liệu cũ
            //lấy dữ liệu từ sql vô
            dtTeacher = Libs.Database.Data.ExcuteToDataTable("GVDanhSachGV", CommandType.StoredProcedure);
            dgvTeacher.DataSource = dtTeacher; //đổ dữ liệu vô datagridview
            dgvTeacher.ClearSelection();
            dgvTeacher.CurrentCell = null;
        }

        #region Sự kiện thêm mới data - AddnewData và btnAdd
        private void AddNewData()
        {
            txtEmail.Text = "";
            txtGioiThieu.Text = "";
            txtGioiTinh.Text = "";
            txtName.Text = "";
            txtSDT.Text = "";
            txtID.Text = "";
            txtNgaySinh.Text = "";
            _isNew = true;
        }

        private void btnAddNewData_Click(object sender, EventArgs e)
        {
            AddNewData();
        }
        #endregion







        #region Sự kiện click vào Row để show Data => error
        private void dgvTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ShowData();
        }
        //Show data ở ô đã chọn vào các ô textbox chỉnh sửa
        //Lỗi ko có column ở DGV nên ko chon được
        private void ShowData()
        {
            /*int numrow;
 numrow = e.RowIndex;
 textBox1.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();*/
            if (dgvTeacher.Rows.Count > 0)
            {
                _isNew = false;// chuyển sang tình trạng cập nhật dữ liệu
                int position = dgvTeacher.CurrentRow.Index; // Lấy vị trí của dòng mà select
                txtID.Text = dgvTeacher.Rows[position].Cells["@IDTeacher"].Value.ToString();
                txtName.Text = dgvTeacher.Rows[position].Cells["@Ten"].Value.ToString();
                txtNgaySinh.Text = dgvTeacher.Rows[position].Cells["@NgaySinh"].Value.ToString();
                txtEmail.Text = dgvTeacher.Rows[position].Cells["@TaiKhoanEmail"].Value.ToString();
                txtSDT.Text = dgvTeacher.Rows[position].Cells["@SDT"].Value.ToString();
                txtGioiTinh.Text = dgvTeacher.Rows[position].Cells["@GioiTinh"].Value.ToString();
                txtGioiThieu.Text = dgvTeacher.Rows[position].Cells["@GioiThieu"].Value.ToString();
            }
        }
        #endregion

        #region Cập nhật data (thêm mới và cập nhật)  -Hàm update và btnSave
        private void UpdateData()
        {
            SqlParameter[] sqlParams = {
                         new SqlParameter("@IDTeacher",txtID.Text.Trim()),
                         new SqlParameter("@Ten",txtName.Text.Trim()),
                         new SqlParameter("@NgaySinh",txtNgaySinh.Text.Trim()),
                         new SqlParameter("@TaiKhoanEmail",txtEmail.Text.Trim()),
                         new SqlParameter("@SDT", txtSDT.Text.Trim()),
                         new SqlParameter("@GioiTinh", txtGioiTinh.Text.Trim()),
                         new SqlParameter("@GioiThieu", txtGioiThieu.Text.Trim())
                };
            if (_isNew == true)
            {
                // Thêm mới dữ liệu
                sqlParams[0] = null;
                //Bước 2: Thực thi Stored Procedure
                Libs.Database.Data.ExecuteNonQuery("GVThemMoi", CommandType.StoredProcedure, sqlParams);
                MessageBox.Show("Đã thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                // Cập nhật dữ liệu
                //Bước 2: Thực thi Stored Procedure
                Libs.Database.Data.ExecuteNonQuery("GVCapNhatProfile", CommandType.StoredProcedure, sqlParams);
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            DanhSach(); // Làm mới dữ liệu
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
        #endregion

        #region Xóa hàng (hàm DeleteData và btnDelete)
        private void DeleteData()
        {
            if (_isNew == false)
            {
                //Bước 1: Tạo Parameter cần thiết
                SqlParameter[] sqlParams = {
                         new SqlParameter("@IDTeacher",txtID.Text.Trim())};
                //Bước 2: Thực thi Stored Procedure
                Libs.Database.Data.ExecuteNonQuery("GVXoaGiaoVien", CommandType.StoredProcedure, sqlParams);
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                DanhSach(); // Làm mới dữ liệu
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void btnDeleta_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        #endregion
    }
}



