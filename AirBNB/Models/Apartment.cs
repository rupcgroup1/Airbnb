using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB.Models
{
    public class Apartment
    {
        private int id;
        private string description;
        private string name;
        private int hostID;
        private string existSince;
        private string pics;
        private string propType;
        private int bedrooms;
        private string bathrooms_text;
        private int beds;
        private int price;
        private int minNights;
        private int maxNights;
        private int numOfReviews;
        private string amenities;
        private string aboutHost;
        private int x;
        private int y;
        private string city;
        private string address;

        public Apartment(int id, string description, string name, int hostID, string existSince, string pics, string propType, int bedrooms, string bathrooms_text, int beds, int price, int minNights, int maxNights, int numOfReviews, string amenities, string aboutHost, int x, int y, string city, string address)
        {
            this.id = id;
            this.description = description;
            this.name = name;
            this.hostID = hostID;
            this.existSince = existSince;
            this.pics = pics;
            this.propType = propType;
            this.bedrooms = bedrooms;
            this.bathrooms_text = bathrooms_text;
            this.beds = beds;
            this.price = price;
            this.minNights = minNights;
            this.maxNights = maxNights;
            this.numOfReviews = numOfReviews;
            this.amenities = amenities;
            this.aboutHost = aboutHost;
            this.x = x;
            this.y = y;
            this.city = city;
            this.address = address;
        }

        public Apartment()
        {

        }
        //private Review[] reviews;



    }
}