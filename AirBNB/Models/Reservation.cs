using AirBNB.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB.Models
{
    public class Reservation
    {
        private int id;
        private int apartmentID;
        private int hostID;
        private int userID;
        private string from;
        private string to;
        private int price;
        private int nights;
        private string apartmentName;

        public Reservation(int id,int apartmentID, int hostID, int userID, string from, string to, int price, int nights, string apartmentName)
        {
            this.Id = id;
            this.ApartmentID = apartmentID;
            this.HostID = hostID;
            this.UserID = userID;
            this.From = from;
            this.To = to;
            this.ApartmentName = apartmentName;
            this.Price = price;
            this.Nights = nights;
        }

        public Reservation(int id, string from, string to, int price, int nights, string apartmentName)
        {
            this.From = from;
            this.To = to;
            this.Id = id;
            this.ApartmentName = apartmentName;
            this.Price = price;
            this.Nights = nights;

        }

        public Reservation(int userId, string from, string to, int apartmentID, string apartmentName, int hostId, int price)
        {
            this.From = from;
            this.To = to;
            this.UserID = userId;
            this.ApartmentName = apartmentName;
            this.HostID = hostId;
            this.ApartmentID = apartmentID;
            this.Price = price;

        }
        public Reservation(int apartmentID, int hostID, int userID, string from, string to)
        {
            this.ApartmentID = apartmentID;
            this.HostID = hostID;
            this.UserID = userID;
            this.From = from;
            this.To = to;
        }

        public Reservation(int apartmentID,string from, string to)
        {
            this.ApartmentID = apartmentID;
            this.UserID = userID;
            this.From = from;
            this.To = to;
        }

        public Reservation()
        {
       
        }

        public int ApartmentID { get => apartmentID; set => apartmentID = value; }
        public int UserID { get => userID; set => userID = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public int Id { get => id; set => id = value; }
        public int HostID { get => hostID; set => hostID = value; }
        public int Price { get => price; set => price = value; }
        public int Nights { get => nights; set => nights = value; }
        public string ApartmentName { get => apartmentName; set => apartmentName = value; }

        public int reserveApartment(Apartment a)
        {
            DataServices ds = new DataServices();
            return ds.makeReservation(a,this);
        }

    
    }
}