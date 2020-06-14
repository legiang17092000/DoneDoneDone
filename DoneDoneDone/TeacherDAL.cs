using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DoneDoneDone
{//Quản Lý Giáo Viên
    class TeacherDAL:DataConnection
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        //SqlConnection con;
        public TeacherDAL()
        {
            dc = new DataConnection();

        }
        public DataTable getAllTeacher()
        {
            //SqlConection con = new SqlConnection("YourDatabaseConnectionString");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("YourQuery");
            //cmd.Connection = con;

            //SqlConnection conn = new SqlConnection("Data Source=NGUYENGIANG-IS;Initial Catalog=CSDL_QuanLyTTTA;Integrated Security=True");
            //conn.Open();
            //cmd = new SqlCommand("GVDanhSachGV");
            //cmd.Connection = conn;

            ////B1: Tao cau lenh SQL
            ///
            ////string sql = "select*form tblTeacher";
            ///
            ////B2: Tao ket noi den sql
            ///
            ////SqlConnection conn = new SqlConnection("Data Source=NGUYENGIANG-IS;Initial Catalog=CSDL_QuanLyTTTA;Integrated Security=True");
            ////SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString);
            ///
            ////B3: Khoi tao doi tuong DataAdapter
            //da = new SqlDataAdapter(cmd);

            ////B4: Mo ket noi
            ////
            ////B5: Do du lieu tu sqlDataAdapter vao DataTable
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            ////B6: Dong ket noi
            //conn.Close();
            //return dt;
            SqlConnection connection = new SqlConnection();
            using (connection)
            {
                connection.ConnectionString = GetConnectionString();
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                using (command)
                {
                    command.CommandText = "SELECT*FROM tblTeacher";
                    SqlDataReader reader = command.ExecuteReader();
                    using (reader)
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                        }
                    }
                }

            }
            //da = new SqlDataAdapter(cmd);
             //B4: Mo ket noi
             //
             //B5: Do du lieu tu sqlDataAdapter vao DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //B6: Dong ket noi
            connection.Close();
            return dt;

        }


        public bool InsertTeacher(tblTeacher gv)
        {
            SqlConnection con = dc.GetConnection();
            
            try
            {
                cmd = new SqlCommand("GVThemMoi", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@ID_Teacher", SqlDbType.NChar).Value = gv.ID_Teacher;
                cmd.Parameters.Add("@TeacherName", SqlDbType.NChar).Value = gv.Teacher_Name;
                cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = gv.Birthday;
                cmd.Parameters.Add("@Email", SqlDbType.NChar).Value = gv.Email;
                cmd.Parameters.Add("@Phone", SqlDbType.NChar).Value = gv.Phone;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = gv.Gender;
                cmd.Parameters.Add("@Introduction", SqlDbType.NChar).Value =gv.Introduction;
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }
       // public bool UpdateTeacher

    }
}
