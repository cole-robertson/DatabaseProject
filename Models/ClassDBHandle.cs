using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentApp.Models
{
    /*************************************************************
     * Class used to handle 'Class' database ineteractions 
    ************************************************************/
    public class ClassDBHandle : AbstractConnection
    {
        

        /*************************************************************
         * Adds a new Class with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool AddClass(Class classModel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.AddClass", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@InstructorId", classModel.InstructorId);
            cmd.Parameters.AddWithValue("@LocationId", classModel.LocationId);
            cmd.Parameters.AddWithValue("@TimeId", classModel.TimeId);
            cmd.Parameters.AddWithValue("@TermId", classModel.TermId);
            cmd.Parameters.AddWithValue("@ClassTypeId", classModel.ClassTypeId);
            cmd.Parameters.AddWithValue("@ClassName", classModel.ClassName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /*************************************************************
         * Views all Classes with the stored procedure.
         * Returns a list of classes to show in an index
        ************************************************************/
        public List<ClassDetails> GetClasses()
        {
            Connection();
            List<ClassDetails> classlist = new List<ClassDetails>();

            SqlCommand cmd = new SqlCommand("Project.GetAllFullClassDetails", con)
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
                classlist.Add(
                    new ClassDetails
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
            return classlist;
        }

        public List<ClassDetails> GetFilteredClasses(string firstName, string lastName, string department, string days, string startTime, string endTime, string termName, string termYear, string type)
        {
            Connection();
            List<ClassDetails> classlist = new List<ClassDetails>();

            SqlCommand cmd = new SqlCommand("Project.GetFilteredClasses", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            if(department != "")
            {
                cmd.Parameters.AddWithValue("@Department", department);
            }
            if(firstName != "")
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
            }
            if(lastName != "")
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
            }
            if(startTime != "")
            {
                cmd.Parameters.AddWithValue("@StartTime", startTime);
            }
            if(endTime != "")
            {
                cmd.Parameters.AddWithValue("@EndTime", endTime);
            }
            if ( days != "")
            {
                cmd.Parameters.AddWithValue("@Days", ClassDetails.ConvertDaysToBits(days));
            }
            if(termName != "")
            {
                cmd.Parameters.AddWithValue("@TermName", termName);
            }
            if(termYear != "")
            {
                cmd.Parameters.AddWithValue("@TermYear", termYear);
            }
            if(type != "")
            {
                cmd.Parameters.AddWithValue("@Type", type);
            }

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                classlist.Add(
                    new ClassDetails
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
            return classlist;
        }
            
        /*************************************************************
         * Shows a Class' details with the stored procedure.
         * Returns the particular class to show
        ************************************************************/
        public Class GetClassDetails(int id)
        {
            Connection();
            Class classModel = new Class();

            SqlCommand cmd = new SqlCommand("Project.GetClassDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ClassId", id);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Class
                {
                    ClassId = Convert.ToInt32(dr["ClassId"]),
                    InstructorId = Convert.ToInt32(dr["InstructorId"]),
                    LocationId = Convert.ToInt32(dr["LocationId"]),
                    TimeId = Convert.ToInt32(dr["TimeId"]),
                    TermId = Convert.ToInt32(dr["TermId"]),
                    ClassTypeId = Convert.ToInt32(dr["ClassTypeId"]),
                    ClassName = Convert.ToString(dr["ClassName"])
                };
            }
            else
            {
                return null;
            }
        }

        public ClassDetails GetFullClassDetails(int classId)
        {
            Connection();
            Class classModel = new Class();

            SqlCommand cmd = new SqlCommand("Project.GetFullClassDetailsByClass", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ClassId", classId);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new ClassDetails
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
                };
            }
            else
            {
                return null;
            }
        }



        /*************************************************************
         * Updates a particular Class with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool UpdateDetails(Class classModel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.UpdateClass", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@ClassId", classModel.ClassId);
            cmd.Parameters.AddWithValue("@InstructorId", classModel.InstructorId);
            cmd.Parameters.AddWithValue("@LocationId", classModel.LocationId);
            cmd.Parameters.AddWithValue("@TimeId", classModel.TimeId);
            cmd.Parameters.AddWithValue("@TermId", classModel.TermId);
            cmd.Parameters.AddWithValue("@ClassTypeId", classModel.ClassTypeId);
            cmd.Parameters.AddWithValue("@ClassName", classModel.ClassName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
       /**********************
        * Get all classes taught by instructor id
        **********************/
        public List<ClassDetails> GetClassDetailsByInstructor(int id)
        {
            Connection();
            List<ClassDetails> classlist = new List<ClassDetails>();

            SqlCommand cmd = new SqlCommand("Project.GetFullClassDetailsFromInstructor", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@InstructorId", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                classlist.Add(
                    new ClassDetails
                    {
                        ClassId = Convert.ToInt32(dr["ClassId"]),
                        ClassName = Convert.ToString(dr["ClassName"]),
                        Building = Convert.ToString(dr["Building"]),
                        Days = ClassDetails.ConvertBitsToDays(Convert.ToInt32(dr["Days"])),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        StartTime = TimeSpan.Parse(Convert.ToString(dr["StartTime"])),
                        EndTime = TimeSpan.Parse(Convert.ToString(dr["EndTime"])),
                        TermName = Convert.ToString(dr["TermName"]),
                        RoomNumber = Convert.ToInt32(dr["RoomNumber"])
                    });
            }
            return classlist;
        }

        public List<ClassTermViewModel> GetStudentCount()
        {
            Connection();
            List<ClassTermViewModel> classlist = new List<ClassTermViewModel>();

            SqlCommand cmd = new SqlCommand("Project.GetStudentCount", con)
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
                classlist.Add(
                    new ClassTermViewModel
                    {
                        StudentCount = Convert.ToInt32(dr["Student Count"]),
                        ClassName = Convert.ToString(dr["ClassName"]),
                        TermName = Convert.ToString(dr["TermName"]),
                        TermYear = Convert.ToInt32(dr["TermYear"])
                    });
            }
            return classlist;
        }

        public List<ClassReviewPartViewModel> ReviewParticipation()
        {
            Connection();
            List<ClassReviewPartViewModel> classlist = new List<ClassReviewPartViewModel>();

            SqlCommand cmd = new SqlCommand("Project.ReviewParticipation", con)
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
                int enrolledCount = Convert.ToInt32(dr["TotalEnrolled"]);
                int reviewCount = Convert.ToInt32(dr["TotalReviews"]);
                if(enrolledCount > 0)
                {
                    classlist.Add(
                    new ClassReviewPartViewModel
                    {
                        ClassName = Convert.ToString(dr["ClassName"]),
                        EnrolledCount = enrolledCount,
                        ReviewCount = reviewCount,
                        ReviewPercentage = Convert.ToDecimal(dr["ReviewPercentage"])
                    });
                }
            }
            return classlist;
        }

    }
}