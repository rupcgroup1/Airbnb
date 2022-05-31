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
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["name"].ToString();
                string description = dr["description"].ToString();
                string picture = dr["picture"].ToString();
                int minNights = Convert.ToInt16(dr["minNights"]);
                int price = Convert.ToInt16(dr["price"]);
                int numOfReviews = Convert.ToInt16(dr["numOfReviews"]);
                double reviewRating = Convert.ToDouble(dr["reviewRating"]);
                int bedrooms = Convert.ToInt16(dr["bedrooms"]);
                tinyList.Add(new Apartment(id,name, description, picture, price, numOfReviews, reviewRating, bedrooms, minNights));

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