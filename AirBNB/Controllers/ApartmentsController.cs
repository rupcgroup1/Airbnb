﻿using AirBNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirBNB.Controllers
{
    public class ApartmentsController : ApiController
    {
        [HttpGet]
        [Route("api/Apartments/tinyGet")]
        public List<Apartment> tinyGet()
        {
            Apartment apartment = new Apartment();
            return apartment.getTinyList();
        }

        [HttpGet]
        [Route("api/Apartments/propertyTypeGet")]
        public List<Apartment> propertyTypeGet()
        {
            Apartment apartment = new Apartment();
            return apartment.getAllPropertyType();
        }

        // GET api/<controller>/5
        public Apartment Get(int id)
        {
            Apartment a = new Apartment();
            return a.getApartmentByID(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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