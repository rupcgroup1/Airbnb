﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB.Models
{
    public class User
    {
        private int id;
        private string email;
        private string password;
        private string username;
        private string registeredFrom;
        private static int numOfRentals;
        private static int totalIncome;
        private static int numOfCancelation;

        public User(int id, string email, string password, string username, string registeredFrom)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.username = username;
            this.registeredFrom = registeredFrom;
        }

        public User(string email, string password, string username)
        {
            this.email = email;
            this.password = password;
            this.username = username;
        }

        public User()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
        public string RegisteredFrom { get => registeredFrom; set => registeredFrom = value; }
        public static int NumOfRentals { get => numOfRentals; set => numOfRentals = value; }
        public static int TotalIncome { get => totalIncome; set => totalIncome = value; }
        public static int NumOfCancelation { get => numOfCancelation; set => numOfCancelation = value; }
    }
}