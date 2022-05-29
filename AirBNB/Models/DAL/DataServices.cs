using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AirBNB.Models.DAL
{
    public class DataServices
    {

        private SqlConnection Connect()
        {
            // read the connection string from the web.config file
            string connectionString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            // create the connection to the db
            SqlConnection con = new SqlConnection(connectionString);

            // open the database connection
            con.Open();

            return con;

        }

        // The first get for presentetion some apartments.
        public List<Apartment> getTinyList()
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateSelectCommand(con);

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Apartment> tinyList = new List<Apartment>();

            
            while (dr.Read())
            {
                int id = Convert.ToInt16(dr["id"]);
                string description = dr["description"].ToString();
                string name = dr["name"].ToString();
                int hostId = Convert.ToInt16(dr["hostId"]);
                string existSince = dr["existSince"].ToString();
                string pic = dr["pic"].ToString();
                string propType = dr["propType"].ToString(); 
                int bedrooms = Convert.ToInt16(dr["bedrooms"]);
                string bathrooms_text = dr["bathrooms_text"].ToString();
                int beds = Convert.ToInt16(dr["beds"]);
                int price = Convert.ToInt16(dr["price"]);
                string address = dr["address"].ToString();
                string city = dr["city"].ToString();
                double x = Convert.ToDouble(dr["x"]);
                double y = Convert.ToDouble(dr["y"]);
                string aboutHost = dr["aboutHost"].ToString();
                string amenities = dr["amenities"].ToString();
                int numOfReviews = Convert.ToInt16(dr["numOfReviews"]);
                int maxNights = Convert.ToInt16(dr["maxNights"]);
                int minNights = Convert.ToInt16(dr["minNights"]);
                double ReviewsScore = Convert.ToDouble(dr["ReviewsScore"]);
                tinyList.Add(new Apartment(id,description,name,hostId,existSince,pic,propType,bedrooms,bathrooms_text,beds,price,minNights,maxNights,numOfReviews,amenities,aboutHost,x,y,city,address, ReviewsScore));
            }

            con.Close();
            return tinyList;
        }

        // Get top 6 apartments by reviews score.
        private SqlCommand CreateSelectCommand(SqlConnection con)
        {

            SqlCommand command = new SqlCommand();
            command.CommandText = "SPgetTinyList";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }
    }
}