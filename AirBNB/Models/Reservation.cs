﻿using AirBNB.Models.DAL;
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
        private int userID;
        private string from;
        private string to;

        public Reservation(int id,int apartmentID, int userID, string from, string to)
        {
            this.id = id;
            this.ApartmentID = apartmentID;
            this.UserID = userID;
            this.From = from;
            this.To = to;
        }

        public Reservation(int apartmentID, int userID, string from, string to)
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

        public int reserveApartment()
        {
            DataServices ds = new DataServices();
            return ds.makeReservation(this);
        }
    }
}