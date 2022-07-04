using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
                int accommodates = Convert.ToInt16(dr["accommodates"]);
                int price = Convert.ToInt32(dr["price"]);
                int numOfReviews = Convert.ToInt16(dr["numOfReviews"]);
                double reviewRating = Convert.ToDouble(dr["reviewRating"]);
                int bedrooms = Convert.ToInt16(dr["bedrooms"]);
                tinyList.Add(new Apartment(id,name, description, picture, price, numOfReviews, reviewRating, bedrooms, accommodates));

            }

            con.Close();
            return tinyList;
        }

        // Get top 6 apartments by reviews score.
        private SqlCommand CreateSelectCommand(SqlConnection con)
        {

            SqlCommand command = new SqlCommand();
            command.CommandText = "PSPgetTinyList";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        public List<Apartment> getAllPropertyType()
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateSelectgetAllPropertyTypeCommand(con);

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Apartment> list = new List<Apartment>();


            while (dr.Read())
            {
                string propertyType = dr["propertyType"].ToString();
                int count = Convert.ToInt16(dr["count"]);
                string picture = getPicturePropertyType(propertyType);
                list.Add(new Apartment(propertyType,count,picture));
            }

            con.Close();
            return list;
        }

        private SqlCommand CreateSelectgetAllPropertyTypeCommand(SqlConnection con)
        {

            SqlCommand command = new SqlCommand();
            command.CommandText = "PSPgetAllPropertyType";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        public string getPicturePropertyType(string propertyType)
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateSelectPicturePropertyTypeCommand(con, propertyType);

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            string picture = "";

            while (dr.Read())
            {
                picture = dr["picture"].ToString();
            }

            con.Close();
            return picture;
        }

        private SqlCommand CreateSelectPicturePropertyTypeCommand(SqlConnection con, string propertyType)
        {

            SqlCommand command = new SqlCommand();
            command.CommandText = "PSPgetPictureByPropertyType";
            command.Parameters.AddWithValue("@propertyType", propertyType);
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        public Apartment getApartmentByID(int id)
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateSelectApartmentByIdCommand(con, id);

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            Apartment a = null;

            while (dr.Read())
            {
                string name = dr["name"].ToString();
                string description = dr["description"].ToString();
                string picture = dr["picture"].ToString();
                int minNights = Convert.ToInt16(dr["minNights"]);
                int price = Convert.ToInt32(dr["price"]);
                int numOfReviews = Convert.ToInt16(dr["numOfReviews"]);
                double reviewRating = Convert.ToDouble(dr["reviewRating"]);
                int bedrooms = Convert.ToInt16(dr["bedrooms"]);
                string neighborhoodOverview = dr["neighborhoodOverview"].ToString();
                int hostID = Convert.ToInt32(dr["hostId"]);
                string since = dr["since"].ToString();
                string hostResponseTime = dr["hostResponseTime"].ToString();
                string hostNeighbourhood = dr["hostNeighbourhood"].ToString();
                string location = dr["location"].ToString();
                double x = Convert.ToDouble(dr["x"]);
                double y = Convert.ToDouble(dr["y"]);
                string propertyType = dr["propertyType"].ToString();
                int accommodates = Convert.ToInt16(dr["accommodates"]);
                string roomType = dr["roomType"].ToString();
                string bathroomsText = dr["bathroomsText"].ToString();
                int beds = Convert.ToInt16(dr["beds"]);

                string amenitiesArr = dr["amenities"].ToString();
                JArray jarr = JArray.Parse(amenitiesArr);
                List<string> amenities = new List<string>();
                foreach (string item in jarr)
                    amenities.Add(item.ToString());

                int maxNights = Convert.ToInt16(dr["maxNights"]);
                int availability365 = Convert.ToInt16(dr["availability365"]);
                string lastReview = dr["lastReview"].ToString();
                double reviewCleanliness = Convert.ToDouble(dr["reviewCleanliness"]);
                double reviewCommunication = Convert.ToDouble(dr["reviewCommunication"]);
                double reviewLocation = Convert.ToDouble(dr["reviewLocation"]);
                double distance = Convert.ToDouble(dr["distance"]);
                int hostVerified = Convert.ToInt16(dr["hostVerified"]);

                a = new Apartment(id, name, description, neighborhoodOverview, picture, hostID, since, hostResponseTime, hostNeighbourhood,location, x, y, propertyType, accommodates, roomType, bathroomsText, bedrooms, beds, amenities, price, minNights, maxNights, availability365, numOfReviews, lastReview, reviewRating, reviewCleanliness, reviewCommunication, reviewLocation, distance, hostVerified);
            }

            con.Close();
            if (a != null)
                return a;
            return null;


        }

        private SqlCommand CreateSelectApartmentByIdCommand(SqlConnection con, int id)
        {

            SqlCommand command = new SqlCommand();
            command.CommandText = "PSPgetApartmentByID";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }


        public List<Review> getAllApartmentReviews(int id)
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateSelectgetAllApartmentReviewsCommand(con,id);

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Review> reviews = new List<Review>();


            while (dr.Read())
            {
                int revId = Convert.ToInt32(dr["id"]);
                string reviewerName = dr["reviewer_name"].ToString();
                string revComments = dr["comments"].ToString();
                int reviewerID = Convert.ToInt32(dr["reviewer_id"]);
                string date = dr["date"].ToString();

                reviews.Add(new Review(id, revId, date, reviewerID, reviewerName, revComments));
            }

            con.Close();
            return reviews;
        }

        private SqlCommand CreateSelectgetAllApartmentReviewsCommand(SqlConnection con, int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "PSPgetAllApartmentReviews";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds
            return command;
        }

        // Get apartments by search.
        public List<Apartment> getAllApartmentsBySearch(string keyword, string from, string to, int minP, int maxP, double minD, double maxD, int beds, double rating)
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateSelectCommandBySearch(con,keyword, from, to, minP, maxP, minD / (double)1000, maxD / (double)1000, beds, rating);

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Apartment> apartmentsList = new List<Apartment>();


            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["name"].ToString();
                string description = dr["description"].ToString();
                string picture = dr["picture"].ToString();
                int accommodates = Convert.ToInt16(dr["accommodates"]);
                int price = Convert.ToInt32(dr["price"]);
                int numOfReviews = Convert.ToInt16(dr["numOfReviews"]);
                double reviewRating = Convert.ToDouble(dr["reviewRating"]);
                int bedrooms = Convert.ToInt16(dr["bedrooms"]);
                apartmentsList.Add(new Apartment(id, name, description, picture, price, numOfReviews, reviewRating, bedrooms, accommodates));
            }

            con.Close();
            return apartmentsList;
        }

        private SqlCommand CreateSelectCommandBySearch(SqlConnection con, string keyword, string from, string to, int minP, int maxP, double minD, double maxD, int beds, double rating)
        {

            SqlCommand command = new SqlCommand();
            command.CommandText = "PSPget";
            Console.WriteLine(minP);
            command.Parameters.AddWithValue("@keyWord", keyword);
            command.Parameters.AddWithValue("@pTo", minP);
            command.Parameters.AddWithValue("@pFrom", maxP);
            command.Parameters.AddWithValue("@dateFrom", from);
            command.Parameters.AddWithValue("@dateTo", to);
            command.Parameters.AddWithValue("@disFrom", minD);
            command.Parameters.AddWithValue("@disTo", maxD);
            command.Parameters.AddWithValue("@beds", beds);
            command.Parameters.AddWithValue("@rating", rating);
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        //Insert User to the database.
        public int insertUser(User u)
        {
            // Connect
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateInsertCommand(con, u);

            // Execute
            int numAffected = command.ExecuteNonQuery();

            // Close Connection

            con.Close();

            return numAffected;
        }

        //Creating insert command for insert a new company.
        private SqlCommand CreateInsertCommand(SqlConnection con, User u)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@username", u.Username);
            command.Parameters.AddWithValue("@password", u.Password);
            command.Parameters.AddWithValue("@email", u.Email);
            command.CommandText = "PSPInsertUser";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }


        // Get user and search if exist.
        public User checkUser(User u)
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateSelectCommand(con, u);

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            User u1 = null;
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["id"]);
                string username = dr["username"].ToString();
                string password = dr["password"].ToString();
                string email = dr["email"].ToString();
                string registeredFrom = dr["registeredFrom"].ToString();
                int numOfRentals = Convert.ToInt32(dr["numOfRentals"]);
                int totalIncome = Convert.ToInt16(dr["totalIncome"]);
                int numOfCancelation = Convert.ToInt16(dr["numOfCancelation"]);
                u1 = new User(id, email, password, username, numOfRentals, totalIncome, numOfCancelation, registeredFrom);
            }

            
            con.Close();
            return u1;
        }

        //Creating get command for search exist user.
        private SqlCommand CreateSelectCommand(SqlConnection con, User u)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@username", u.Username);
            command.Parameters.AddWithValue("@password", u.Password);
            command.Parameters.AddWithValue("@email", u.Email);
            command.CommandText = "PSPcheckUserExist";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }


        
        // Get apartments by property type.
        public List<Apartment> getAllApartmentsByPropertyType(string propertyType)
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateSelectCommand(con, propertyType);

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Apartment> list = new List<Apartment>();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["name"].ToString();
                string description = dr["description"].ToString();
                string picture = dr["picture"].ToString();
                int accommodates = Convert.ToInt16(dr["accommodates"]);
                int price = Convert.ToInt32(dr["price"]);
                int numOfReviews = Convert.ToInt16(dr["numOfReviews"]);
                double reviewRating = Convert.ToDouble(dr["reviewRating"]);
                int bedrooms = Convert.ToInt16(dr["bedrooms"]);
                list.Add(new Apartment(id, name, description, picture, price, numOfReviews, reviewRating, bedrooms, accommodates));

            }

            con.Close();
            return list;
        }

        //Creating get command for apartments by property type.
        private SqlCommand CreateSelectCommand(SqlConnection con, string propertyType)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@propType", propertyType);
            command.CommandText = "PSPgetApartmentsByPropType";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        //Make reservation
        public int makeReservation(Apartment a, Reservation r)
        {
            // Connect
            SqlConnection con = Connect();

            // Check if this reservation is available.
            // If the return value is 0 then the apartment is available.
            if (checkReservation(a,r) != 0)
                return -1;

            // Update host and user total income.
            updateTotalIncome(a,r);

            // Create Command
            SqlCommand command = CreateReservationCommand(con, r);

            // Execute
            int numAffected = command.ExecuteNonQuery();

            // Close Connection

            con.Close();

            return numAffected;
        }

        //Creating insert command for insert a new company.
        private SqlCommand CreateReservationCommand(SqlConnection con, Reservation r)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@apartmentID", r.ApartmentID);
            command.Parameters.AddWithValue("@hostID", r.HostID);
            command.Parameters.AddWithValue("@userID", r.UserID);
            command.Parameters.AddWithValue("@fromDate", r.From);
            command.Parameters.AddWithValue("@toDate", r.To);
            command.CommandText = "PSPreserveApartment";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        // Get apartment id if the reservation is available.
        public int checkReservation(Apartment a, Reservation r)
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateCheckReservationCommand(con, a, r);

            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            // If id stays 0 then the apartment is available.
            int id = 0;

            while (dr.Read())
                id = Convert.ToInt32(dr["apartmentId"]);

            con.Close();
            return id;
        }

        //Creating select command for check availablty of reservation.
        private SqlCommand CreateCheckReservationCommand(SqlConnection con, Apartment a, Reservation r)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@apartmentID", r.ApartmentID);
            command.Parameters.AddWithValue("@minNights", a.MinNights);
            command.Parameters.AddWithValue("@maxNights", a.MaxNights);
            command.Parameters.AddWithValue("@dateFrom", r.From);
            command.Parameters.AddWithValue("@dateTo", r.To);
            command.CommandText = "PSPreservationAvailable";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        // Update total income of user and host
        public int updateTotalIncome(Apartment a, Reservation r)
        {
            // Connect
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateUpdateCommand(con, a, r);

            // Execute
            int numAffected = command.ExecuteNonQuery();

            // Close Connection
            con.Close();

            return numAffected;
        }

        //Creating update command for total income of user and the host.
        private SqlCommand CreateUpdateCommand(SqlConnection con, Apartment a, Reservation r)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@userId", r.UserID);
            command.Parameters.AddWithValue("@hostId", r.HostID);
            command.Parameters.AddWithValue("@fromDate", r.From);
            command.Parameters.AddWithValue("@toDate", r.To);
            command.Parameters.AddWithValue("@price", a.Price);
            command.CommandText = "PSPupdateIncome";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

    }
}