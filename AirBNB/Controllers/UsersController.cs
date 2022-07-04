﻿using AirBNB.Models;
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
        [Route("api/Users/bookApartment/{apartmentID}/{hostId}/{id}/{from}/{to}/{minNights}/{maxNights}/{price}")]
        public int Post(int apartmentID, int hostId, int id ,string from,string to,int minNights,int maxNights, int price)
        {
            Apartment a = new Apartment(minNights, maxNights, price);
            Reservation r = new Reservation(apartmentID,hostId,id ,from, to);

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