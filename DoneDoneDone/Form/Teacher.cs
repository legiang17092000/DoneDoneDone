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
        TeacherBLL bllTeacher;
        public FormTeacher()
        {
            InitializeComponent();
            bllTeacher = new TeacherBLL();
        }
        DataTable dtTeacher;
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //khoan nha,cái sự kiện này bị sai á
        
        }



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
            dataGridView1.DataSource = dtTeacher; //đổ dữ liệu vô datagridview
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }
# region INSERT
        private void TeacherInsert()
        {
            SqlParameter[] SParam = {
                new SqlParameter("@IDTeacher",txtID.Text.Trim() ),
                new SqlParameter("@Ten", txtName.Text.Trim()),
                new SqlParameter("@NgaySinh",txtNgaySinh.Text.Trim()),
                new SqlParameter("@TaiKhoanEmail",txtEmail.Text.Trim()),
                new SqlParameter("@SDT",txtSDT.Text.Trim()),
                new SqlParameter("@GioiTinh",txtGioiTinh.Text.Trim()),
                new SqlParameter("@GioiThieu",txtGioiThieu.Text.Trim())
            };
            Libs.Database.Data.ExecuteNonQuery("GVThemMoi", CommandType.StoredProcedure, SParam);
            MessageBox.Show("Add new teacher succesfully", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            TeacherInsert();
        }
        //DataSet GetListGiaoVien()
        //{
        //    DataSet data = new DataSet();

        //    string query = "Select*From tblTeacher";
        //    //SqlConnection ==> Sau khi sài xong là bỏ
        //    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
        //    {

        //        connection.Open();
        //        SqlCommand command = new SqlCommand(query, connection);

        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        adapter.Fill(data);
        //        connection.Close();
        //    }


        //        //SqlCommand
        //        //SqlDataAdapter



        //        return data;
        //}

        //private DataTable GetTeacherList()
        //{
        //    DataTable dtTeacher = new DataTable();
        //    string conString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(conString))

        //    using (SqlCommand cmd = new SqlCommand("GVDanhSachGV", con))
        //    {
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        dtTeacher.Load(reader);
        //    }
        //    return dtTeacher;
        //}

    }

}

