using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneDoneDone
{
    class TeacherBLL
    {
        TeacherDAL dalTeacher;
        public TeacherBLL()
        {
            dalTeacher = new TeacherDAL();
        }
        public DataTable getAllTeacher()
        {
            return dalTeacher.getAllTeacher();
            
        }
       
    }
}
