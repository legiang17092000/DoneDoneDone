using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        DataTable dtTeacher = new DataTable();
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            DanhSach();
        }
        public void DanhSach()
        {
            //dtTeacher = new DataTable();
            dtTeacher.Clear();//xóa dữ liệu cũ
            //lấy dữ liệu từ sql vô
            dtTeacher = Libs.Database.Data.ExcuteToDataTable("GVDanhSachGV", CommandType.StoredProcedure);
            dgvStudent.DataSource = dtTeacher; //đổ dữ liệu vô datagridview
            dgvStudent.ClearSelection();
            dgvStudent.CurrentCell = null;
        }
    }
}
