using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentApp.Models
{
    /*************************************************************
     * Class used to handle Review database ineteractions 
    ************************************************************/
    public class ReviewDBHandle : AbstractConnection
    { 
        /*************************************************************
         * Adds a new Review with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool AddReview(Review review)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.AddReview", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            if(review.ScreenName == null)
            {
                review.ScreenName = "Anonymous";
            }
            cmd.Parameters.AddWithValue("@ClassId", review.ClassId);
            cmd.Parameters.AddWithValue("@ScreenName", review.ScreenName);
            cmd.Parameters.AddWithValue("@Description", review.Description);
            cmd.Parameters.AddWithValue("@Rating", review.Rating);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /*************************************************************
         * Views all Reviews with the stored procedure.
         * Returns a list of students to show in an index
        ************************************************************/
        public List<Review> GetReviews()
        {
            Connection();
            List<Review> reviewlist = new List<Review>();

            SqlCommand cmd = new SqlCommand("Project.GetAllReviews", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            ClassDBHandle classDBHandle = new ClassDBHandle();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                reviewlist.Add(
                    new Review
                    {
                        ReviewId = Convert.ToInt32(dr["ReviewId"]),
                        ClassId = Convert.ToInt32(dr["ClassId"]),
                        ClassName = Convert.ToString(dr["ClassName"]),
                        ScreenName = Convert.ToString(dr["ScreenName"]),
                        Description = Convert.ToString(dr["Description"]),
                        Rating = Convert.ToInt32(dr["Rating"])
                    });
            }
            return reviewlist;
        }

        /*************************************************************
         * Shows a Review's details with the stored procedure.
         * Returns the particular student to show
        ************************************************************/
        public Review GetReviewDetails(int id)
        {
            Connection();
            Review review = new Review();

            SqlCommand cmd = new SqlCommand("Project.GetReviewDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ReviewId", id);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            ClassDBHandle classDBHandle = new ClassDBHandle();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                return new Review
                {
                    ReviewId = Convert.ToInt32(dr["ReviewId"]),
                    ClassId = Convert.ToInt32(dr["ClassId"]),
                    ClassName = Convert.ToString(dr["ClassName"]),
                    ScreenName = Convert.ToString(dr["ScreenName"]),
                    Description = Convert.ToString(dr["Description"])
                };
            }
            else
            {
                return null;
            }
        }

        /*************************************************************
         * Updates a particular Review with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool UpdateDetails(Review review)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.UpdateReview", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@ReviewId", review.ReviewId);
            cmd.Parameters.AddWithValue("@ClassId", review.ClassId);
            cmd.Parameters.AddWithValue("@ScreenName", review.ScreenName);
            cmd.Parameters.AddWithValue("@Description", review.Description);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /*************************************************************
         * Deletes a particular Review with the stored procedure.
         * Returns if 1 or more rows were affected or not for success
        ************************************************************/
        public bool DeleteReview(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.DeleteReview", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@ReviewId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        /**********************************
         * Gets Reviews based on class id
         * Returns List<Review> based on the class id
         */
         public List<Review> GetReviewsByClassId(int id)
         {
            Connection();
            SqlCommand cmd = new SqlCommand("Project.GetReviewFromClassId", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ClassId", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            List<Review> reviewlist = new List<Review>();
            foreach (DataRow dr in dt.Rows)
            {
                reviewlist.Add(
                    new Review
                    {
                        ReviewId = Convert.ToInt32(dr["ReviewId"]),
                        ClassId = Convert.ToInt32(dr["ClassId"]),
                        ScreenName = Convert.ToString(dr["ScreenName"]),
                        Description = Convert.ToString(dr["Description"]),
                        Rating = Convert.ToInt32(dr["Rating"])
                    });
            }
            return reviewlist;
         }
    }
}