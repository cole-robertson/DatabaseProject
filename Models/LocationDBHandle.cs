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
    public class LocationDBHandle : AbstractConnection
    {
        /*************************************************************
         * Adds a new Location with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool AddLocation(Location location)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.AddLocation", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Building", location.Building);
            cmd.Parameters.AddWithValue("@RoomNumber", location.RoomNumber);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /*************************************************************
         * Views all Locations with the stored procedure.
         * Returns a list of students to show in an index
        ************************************************************/
        public List<Location> GetLocations()
        {
            Connection();
            List<Location> Locationlist = new List<Location>();

            SqlCommand cmd = new SqlCommand("Project.GetAllLocations", con)
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
                Locationlist.Add(
                    new Location
                    {
                        LocationId = Convert.ToInt32(dr["LocationId"]),
                        Building = Convert.ToString(dr["Building"]),
                        RoomNumber = Convert.ToInt32(dr["RoomNumber"])
                    });
            }
            return Locationlist;
        }

        /*************************************************************
        * Shows a Location's details with the stored procedure.
        * Returns the particular student to show
       ************************************************************/
        public Location GetLocationDetails(int id)
        {
            Connection();
            Location student = new Location();

            SqlCommand cmd = new SqlCommand("Project.GetLocationDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@LocationId", id);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Location
                {
                    LocationId = Convert.ToInt32(dr["LocationId"]),
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
         * Updates a particular Location with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool UpdateDetails(Location location)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.UpdateLocation", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@LocationId", location.LocationId);
            cmd.Parameters.AddWithValue("@Building", location.Building);
            cmd.Parameters.AddWithValue("@RoomNumber", location.RoomNumber);

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