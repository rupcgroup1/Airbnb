using AirBNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace AirBNB.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("api/Users/checkUser")]
        // POST api/<controller>/5
        public User checkExist([FromBody]User u)
        {
            return u.checkUser();
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/Users/insertUser")]
        public int Post([FromBody]User u)
        {
            return u.insertUser();
        }

        [HttpPost]
        [Route("api/Users/bookApartment/${apartmentID}/${fromDate}/${toDate}/${minNights}/${maxNights}")]
        public int Post(int apartmentID,string fromDate,string toDate,int minNights,int maxNights)
        {
            Apartment a = new Apartment(minNights, maxNights);
            Reservation r = new Reservation(apartmentID, fromDate, toDate);

            return r.reserveApartment(a);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}