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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        DataTable dtTeacher;
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            DanhSach();
        }
        public void DanhSach()
        {
            dtTeacher = new DataTable();
            dtTeacher.Clear();//xóa dữ liệu cũ
            //lấy dữ liệu từ sql vô
            dtTeacher = Libs.Database.Data.ExcuteToDataTable("GVDanhSachGV", CommandType.StoredProcedure);
            dataGridView1.DataSource = dtTeacher; //đổ dữ liệu vô datagridview
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }
    }
}
