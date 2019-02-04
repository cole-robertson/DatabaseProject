using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentApp.Models
{
    /*************************************************************
     * Class used to handle Instructor database ineteractions 
    ************************************************************/
    public class InstructorDBHandle : AbstractConnection
    {
        /*************************************************************
         * Adds a new Instructor with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool AddInstructor(Instructor instructor)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.AddInstructor", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FirstName", instructor.FirstName);
            cmd.Parameters.AddWithValue("@LastName", instructor.LastName);
            cmd.Parameters.AddWithValue("@Email", instructor.Email);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /*************************************************************
         * Views all Instructors with the stored procedure.
         * Returns a list of students to show in an index
        ************************************************************/
        public List<Instructor> GetInstructors()
        {
            Connection();
            List<Instructor> Instructorlist = new List<Instructor>();

            SqlCommand cmd = new SqlCommand("Project.GetAllInstructors", con)
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
                Instructorlist.Add(
                    new Instructor
                    {
                        InstructorId = Convert.ToInt32(dr["InstructorId"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Email = Convert.ToString(dr["Email"])
                    });
            }
            return Instructorlist;
        }

        /*************************************************************
         * Shows a Instructor's details with the stored procedure.
         * Returns the particular student to show
        ************************************************************/
        public Instructor GetInstructorDetails(int id)
        {
            Connection();
            Instructor Instructor = new Instructor();

            SqlCommand cmd = new SqlCommand("Project.GetInstructorDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@InstructorId", id);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Instructor
                {
                    InstructorId = Convert.ToInt32(dr["InstructorId"]),
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

        /*************************************************************
         * Updates a particular Instructor with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool UpdateDetails(Instructor instructor)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.UpdateInstructor", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@InstructorId", instructor.InstructorId);
            cmd.Parameters.AddWithValue("@FirstName", instructor.FirstName);
            cmd.Parameters.AddWithValue("@LastName", instructor.LastName);
            cmd.Parameters.AddWithValue("@Email", instructor.Email);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /*************************************************************
         * Deletes a particular Instructor with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool DeleteInstructor(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("DeleteInstructor", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@InstructorId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public decimal GetInstructorsAvgRating(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.GetInstructorAverage", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@InstructorId", id);

            con.Open();
            object i = cmd.ExecuteScalar();
            
            con.Close();
            if (default(object) == i)
            {
                return (decimal)0.0;
            }
            return (decimal)i;
        }

        public List<InstructorClassReviewViewModel> AverageRatings(int range)
        {
            Connection();
            List<InstructorClassReviewViewModel> Instructorlist = new List<InstructorClassReviewViewModel>();

            SqlCommand cmd = new SqlCommand("Project.AverageInstructorRating", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Range", range);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Instructor instructorModel = new Instructor
                {
                    Fullname = Convert.ToString(dr["InstructorName"]),
                    InstructorId = Convert.ToInt32(dr["Instructor"])
                };
                Instructorlist.Add(
                    new InstructorClassReviewViewModel(
                        instructorModel,
                        Convert.ToDecimal(dr["InstructorAverage"]),
                        null));
            }
            return Instructorlist;
        }
    }
}