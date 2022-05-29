using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AirBNB.Models.DAL
{
    public class DataServices
    {


        public List<Apartment> getTinyList()
        {
            List<Apartment> tinyList = new List<Apartment>();

            return tinyList;
        }

        private SqlCommand CreateSelectUsersCommand(SqlConnection con)
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