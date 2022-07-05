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
        public List<User> Get()
        {
            User u = new User();
            return u.getAllUsers(); ;
        }


        [HttpGet]
        [Route("api/Users/getResById/{id}")]
        // GET api/<controller>/5
        public Reservation getReservationById(int id)
        {
            User u = new User();
            return u.getReservationById(id);
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
        [Route("api/Users/bookApartment/{apartmentID}/{hostId}/{id}/{from}/{to}/{minNights}/{maxNights}/{price}/{apartmentName}")]
        public int Post(int apartmentID, int hostId, int id ,string from,string to,int minNights,int maxNights, int price, string apartmentName)
        {
            Apartment a = new Apartment(minNights, maxNights, price, apartmentName);
            Reservation r = new Reservation(id, from, to, apartmentID, apartmentName, hostId, price);

            return r.reserveApartment(a);
        }

        

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        
    }
}