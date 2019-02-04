using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentApp.Models
{
    /*************************************************************
     * Class used to handle ClassType database ineteractions 
     ************************************************************/
    public class ClassTypeDBHandle : AbstractConnection
    {

        /*************************************************************
         * Views all ClassTypes with the stored procedure.
         * Returns a list of students to show in an index
        ************************************************************/
        public List<ClassType> GetClassTypes()
        {
            Connection();
            List<ClassType> classTypeList = new List<ClassType>();

            SqlCommand cmd = new SqlCommand("Project.GetAllClassTypes", con)
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
                classTypeList.Add(
                    new ClassType
                    {
                        ClassTypeId = Convert.ToInt32(dr["ClassTypeId"]),
                        Type = Convert.ToString(dr["Type"])
                    });
            }
            return classTypeList;
        }

        public List<ClassTypeViewModel> ClassTypeCount()
        {
            Connection();
            List<ClassTypeViewModel> classTypeList = new List<ClassTypeViewModel>();

            SqlCommand cmd = new SqlCommand("Project.NumberofClassesbyType", con)
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
                classTypeList.Add(
                    new ClassTypeViewModel
                    {
                        ClassTypeId = Convert.ToInt32(dr["ID"]),
                        Type = Convert.ToString(dr["Type"]),
                        NumberClasses = Convert.ToInt32(dr["NumberOfClasses"]),
                    });
            }
            return classTypeList;
        }
    }
}