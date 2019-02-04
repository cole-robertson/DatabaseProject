using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentApp.Models
{
    /*************************************************************
     * Class used to handle Student database ineteractions 
    ************************************************************/
    public class StudentDBHandle : AbstractConnection
    {
        /*************************************************************
         * Adds a new Student with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/ 
        public bool AddStudent(Student student)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.AddStudent", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            cmd.Parameters.AddWithValue("@LastName", student.LastName);
            cmd.Parameters.AddWithValue("@Email", student.Email);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /*************************************************************
         * Views all Students with the stored procedure.
         * Returns a list of students to show in an index
        ************************************************************/
        public List<Student> GetStudents()
        {
            Connection();
            List<Student> studentlist = new List<Student>();

            SqlCommand cmd = new SqlCommand("Project.GetAllStudents", con)
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
                studentlist.Add(
                    new Student
                    {
                        StudentId = Convert.ToInt32(dr["StudentId"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Email = Convert.ToString(dr["Email"])
                    });
            }
            return studentlist;
        }

        /*************************************************************
         * Shows a Student's details with the stored procedure.
         * Returns the particular student to show
        ************************************************************/
        public Student GetStudentDetails(int id)
        {
            Connection();
            Student student = new Student();

            SqlCommand cmd = new SqlCommand("Project.GetStudentDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@StudentId", id);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            
            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Student
                {
                    StudentId = Convert.ToInt32(dr["StudentId"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    Email = Convert.ToString(dr["Email"])
                };
            }
            else
            {
                return null;
            }
        }

        public List<ClassDetails> GetStudentClassDetails(int studentId)
        {
            Connection();
            Student student = new Student();

            SqlCommand cmd = new SqlCommand("Project.GetFullClassDetailsByStudent", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@StudentId", studentId);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            List<ClassDetails> classDetails = new List<ClassDetails>();

            foreach (DataRow dr in dt.Rows)
            {
                classDetails.Add(new ClassDetails
                {
                    ClassName = Convert.ToString(dr["ClassName"]),
                    ClassId = Convert.ToInt32(dr["ClassId"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    TermName = Convert.ToString(dr["TermName"]),
                    Days = ClassDetails.ConvertBitsToDays(Convert.ToInt32(dr["Days"])),
                    StartTime = TimeSpan.Parse(Convert.ToString(dr["StartTime"])),
                    EndTime = TimeSpan.Parse(Convert.ToString(dr["EndTime"])),
                    Building = Convert.ToString(dr["Building"]),
                    RoomNumber = Convert.ToInt32(dr["RoomNumber"])

                });
            }

            return classDetails;
        }

        /*************************************************************
         * Updates a particular Student with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool UpdateDetails(Student student)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.UpdateStudent", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
            cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            cmd.Parameters.AddWithValue("@LastName", student.LastName);
            cmd.Parameters.AddWithValue("@Email", student.Email);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /*************************************************************
         * Deletes a particular Student with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool DeleteStudent(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@StudentId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
  