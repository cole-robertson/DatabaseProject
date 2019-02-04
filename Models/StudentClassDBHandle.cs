using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentApp.Models
{
    /*************************************************************
     * Class used to handle StudentClass database ineteractions 
    ************************************************************/
    public class StudentClassDBHandle : AbstractConnection
    {
        /*************************************************************
         * Adds a new StudentClass with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool AddStudentClass(StudentClass studentClass)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.AddStudentClass", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@ClassId", studentClass.ClassId);
            cmd.Parameters.AddWithValue("@StudentId", studentClass.StudentId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /*************************************************************
         * Views all StudentClasses with the stored procedure.
         * Returns a list of StudentClasses to show in an index
        ************************************************************/
        public List<StudentClass> GetStudents()
        {
            Connection();
            List<StudentClass> studentClasslist = new List<StudentClass>();

            SqlCommand cmd = new SqlCommand("Project.GetAllStudentClasses", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentClasslist.Add(
                    new StudentClass
                    {
                        ClassId = Convert.ToInt32(dr["ClassId"]),
                        StudentId = Convert.ToInt32(dr["StudentId"])
                    });
            }
            return studentClasslist;
        }
    }
}