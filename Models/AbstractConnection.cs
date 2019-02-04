using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace StudentApp.Models
{
    public abstract class AbstractConnection
    {
        /*************************************************************
         * Varibles to establish connection to the database
        ************************************************************/
        protected SqlConnection con;
        protected void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();
            con = new SqlConnection(constring);
        }
    }
}