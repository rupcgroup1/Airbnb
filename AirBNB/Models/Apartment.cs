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
        private string pic;
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
        private double x;
        private double y;
        private string city;
        private string address;
        //private Review[] reviews;

        public Apartment(int id, string description, string name, int hostID, string existSince, string pic, string propType, int bedrooms, string bathrooms_text, int beds, int price, int minNights, int maxNights, int numOfReviews, string amenities, string aboutHost, double x, double y, string city, string address)
        {
            this.Id = id;
            this.Description = description;
            this.Name = name;
            this.HostID = hostID;
            this.ExistSince = existSince;
            this.Pic = pic;
            this.PropType = propType;
            this.Bedrooms = bedrooms;
            this.Bathrooms_text = bathrooms_text;
            this.Beds = beds;
            this.Price = price;
            this.MinNights = minNights;
            this.MaxNights = maxNights;
            this.NumOfReviews = numOfReviews;
            this.Amenities = amenities;
            this.AboutHost = aboutHost;
            this.X = x;
            this.Y = y;
            this.City = city;
            this.Address = address;
        }

        public Apartment()
        {

        }

        /// Getters & Setters
        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
        public int HostID { get => hostID; set => hostID = value; }
        public string ExistSince { get => existSince; set => existSince = value; }
        public string Pic { get => pic; set => pic = value; }
        public string PropType { get => propType; set => propType = value; }
        public int Bedrooms { get => bedrooms; set => bedrooms = value; }
        public string Bathrooms_text { get => bathrooms_text; set => bathrooms_text = value; }
        public int Beds { get => beds; set => beds = value; }
        public int Price { get => price; set => price = value; }
        public int MinNights { get => minNights; set => minNights = value; }
        public int MaxNights { get => maxNights; set => maxNights = value; }
        public int NumOfReviews { get => numOfReviews; set => numOfReviews = value; }
        public string Amenities { get => amenities; set => amenities = value; }
        public string AboutHost { get => aboutHost; set => aboutHost = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        

        //Getting a tiny apartments list to show in home page.
        public List<Apartment> getTinyList()
        {
            DataServices ds = new DataServices();
            return ds.getTinyList();
             
        }

    }
}