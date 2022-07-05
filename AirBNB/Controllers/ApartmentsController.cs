using AirBNB.Models;
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
        [Route("api/Apartments/getByProp/{propType}")]
        public List<Apartment> getListByPropertyType(string propType)
        {
            Apartment apartment = new Apartment();
            return apartment.getAllApartmentsByPropertyType(propType);
        }

        [HttpGet]
        [Route("api/Apartments/search/{keyword}/{from}/{to}/{minP}/{maxP}/{minD}/{maxD}/{beds}/{rating}")]
        public List<Apartment> getListBySearch(string keyword, string from, string to, int minP, int maxP, double minD, double maxD, int beds, double rating)
        {
            if (keyword == "Any") keyword = "";
            Apartment apartment = new Apartment();
            return apartment.getAllApartmentsBySearch(keyword, from, to, minP, maxP, minD, maxD, beds, rating);
        }

        [HttpGet]
        [Route("api/Apartments/propertyTypeGet")]
        public List<Apartment> propertyTypeGet()
        {
            Apartment apartment = new Apartment();
            return apartment.getAllPropertyType();
        }

        [HttpGet]
        [Route("api/Apartments/getAllApartments")]
        public List<Apartment> getAllApartments()
        {
            Apartment apartment = new Apartment();
            return apartment.getAllApartments();
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