using AirBNB.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB.Models
{
    public class Apartment
    {
        private int id;
        private string name;
        private string description;
        private string neighborhoodOverview;
        private string picture;
        private int hostID;
        private string since;
        private int hostResponseTime;
        private string hostNeighbourhood;
        private string location;
        private double x;
        private double y;
        private string propertyType;
        private string roomType;
        private string bathroomsText;
        private int bedrooms;
        private int beds;
        private string amenities;
        private int price;
        private int minNights;
        private int maxNights;
        private int availability365;
        private int numOfReviews; 
        private string lastReview;
        private double reviewRating;
        private double reviewCleanliness;
        private double reviewCommunication;
        private double reviewLocation;
        private double reviewValue;
        private int numOfRentals;
        private int numOfCancel;
        //private Review[] reviews;


        public Apartment()
        {

        }

        public Apartment(int id, string name, string description, string neighborhoodOverview, string picture, int hostID, string since, int hostResponseTime, string hostNeighbourhood, string location, double x, double y, string propertyType, string roomType, string bathroomsText, int bedrooms, int beds, string amenities, int price, int minNights, int maxNights, int availability365, int numOfReviews, string lastReview, double reviewRating, double reviewCleanliness, double reviewCommunication, double reviewLocation, double reviewValue, int numOfRentals, int numOfCancel)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.neighborhoodOverview = neighborhoodOverview;
            this.picture = picture;
            this.hostID = hostID;
            this.Since = since;
            this.hostResponseTime = hostResponseTime;
            this.hostNeighbourhood = hostNeighbourhood;
            this.location = location;
            this.x = x;
            this.y = y;
            this.propertyType = propertyType;
            this.roomType = roomType;
            this.bathroomsText = bathroomsText;
            this.bedrooms = bedrooms;
            this.beds = beds;
            this.amenities = amenities;
            this.price = price;
            this.minNights = minNights;
            this.maxNights = maxNights;
            this.availability365 = availability365;
            this.numOfReviews = numOfReviews;
            this.lastReview = lastReview;
            this.reviewRating = reviewRating;
            this.reviewCleanliness = reviewCleanliness;
            this.reviewCommunication = reviewCommunication;
            this.reviewLocation = reviewLocation;
            this.reviewValue = reviewValue;
            this.numOfRentals = numOfRentals;
            this.numOfCancel = numOfCancel;
        }

        // for first render.
        public Apartment(int id, string name, string description, string picture, string hostNeighbourhood, string location, int price, int numOfReviews, double reviewRating)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.picture = picture;
            this.hostNeighbourhood = hostNeighbourhood;
            this.location = location;
            this.price = price;
            this.numOfReviews = numOfReviews;
            this.reviewRating = reviewRating;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string NeighborhoodOverview { get => neighborhoodOverview; set => neighborhoodOverview = value; }
        public string Picture { get => picture; set => picture = value; }
        public int HostID { get => hostID; set => hostID = value; }
        public int HostResponseTime { get => hostResponseTime; set => hostResponseTime = value; }
        public string HostNeighbourhood { get => hostNeighbourhood; set => hostNeighbourhood = value; }
        public string Location { get => location; set => location = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public string PropertyType { get => propertyType; set => propertyType = value; }
        public string RoomType { get => roomType; set => roomType = value; }
        public string BathroomsText { get => bathroomsText; set => bathroomsText = value; }
        public int Bedrooms { get => bedrooms; set => bedrooms = value; }
        public int Beds { get => beds; set => beds = value; }
        public string Amenities { get => amenities; set => amenities = value; }
        public int Price { get => price; set => price = value; }
        public int MinNights { get => minNights; set => minNights = value; }
        public int MaxNights { get => maxNights; set => maxNights = value; }
        public int Availability365 { get => availability365; set => availability365 = value; }
        public int NumOfReviews { get => numOfReviews; set => numOfReviews = value; }
        public string LastReview { get => lastReview; set => lastReview = value; }
        public double ReviewRating { get => reviewRating; set => reviewRating = value; }
        public double ReviewCleanliness { get => reviewCleanliness; set => reviewCleanliness = value; }
        public double ReviewCommunication { get => reviewCommunication; set => reviewCommunication = value; }
        public double ReviewLocation { get => reviewLocation; set => reviewLocation = value; }
        public double ReviewValue { get => reviewValue; set => reviewValue = value; }
        public int NumOfRentals { get => numOfRentals; set => numOfRentals = value; }
        public int NumOfCancel { get => numOfCancel; set => numOfCancel = value; }
        public string Since { get => since; set => since = value; }


        //Getting a tiny apartments list to show in home page.
        public List<Apartment> getTinyList()
        {
            DataServices ds = new DataServices();
            return ds.getTinyList();
             
        }

    }
}