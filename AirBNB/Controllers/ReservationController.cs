using AirBNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirBNB.Controllers
{
    public class ReservationController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/Reservations/{id}")]
        // GET api/<controller>/5
        public List<Reservation> getReservation(int id)
        {
            Reservation r = new Reservation();
            User u = new User(id);
            return r.getAllUserReservations(id);
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
        [HttpDelete]
        [Route("api/Reservations/cancelReservation")]
        public int Delete([FromBody] Reservation r)
        {
            return r.cancelReservation();
        }
    }
}