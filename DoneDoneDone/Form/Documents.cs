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
    public partial class FormDocuments : Form
    {
        public FormDocuments()
        {
            InitializeComponent();
        }

        DataTable dtDocument;
        bool _isNew = true;

        private void FormDocument_Load(object sender, EventArgs e)
        {
            LoadDocument();
        }
        public void LoadDocument()
        {
            dtDocument = new DataTable();
            dtDocument.Clear();//xóa dữ liệu cũ
            //lấy dữ liệu từ sql vô
            dtDocument = Libs.Database.Data.ExcuteToDataTable("GVDanhSachGV", CommandType.StoredProcedure);
            dgvDocument.DataSource = dtDocument; //đổ dữ liệu vô datagridview
            dgvDocument.ClearSelection();
            dgvDocument.CurrentCell = null;
        }

        #region Sự kiện thêm mới data - AddnewData và btnAdd
        private void AddNewData()
        {
            txtIdDocument.Text = "";
            txtName.Text = "";
            _isNew = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewData();
        }

        #endregion

        #region Sự kiện click vào Row để show Data => error
        private void dgvDocument_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ShowData();
        }
        //Show data ở ô đã chọn vào các ô textbox chỉnh sửa
        //Lỗi ko có column ở DGV nên ko chon được
        private void ShowData()
        {
            if (dgvDocument.Rows.Count > 0)
            {
                _isNew = false;// chuyển sang tình trạng cập nhật dữ liệu
                int position = dgvDocument.CurrentRow.Index; // Lấy vị trí của dòng mà select
                txtIdDocument.Text = dgvDocument.Rows[position].Cells["@IDTeacher"].Value.ToString();
                txtName.Text = dgvDocument.Rows[position].Cells["@Ten"].Value.ToString();                
            }
        }
        #endregion

        #region Cập nhật data (thêm mới và cập nhật)  -Hàm update và btnSave
        private void UpdateData()
        {
            SqlParameter[] sqlParams = {
                         new SqlParameter("@IDTeacher",txtIdDocument.Text.Trim()),
                         new SqlParameter("@Ten",txtName.Text.Trim())
                         
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
            LoadDocument(); // Làm mới dữ liệu
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
                         new SqlParameter("@IDTeacher",txtIdDocument.Text.Trim())};
                //Bước 2: Thực thi Stored Procedure
                Libs.Database.Data.ExecuteNonQuery("GVXoaGiaoVien", CommandType.StoredProcedure, sqlParams);
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                LoadDocument(); // Làm mới dữ liệu
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
