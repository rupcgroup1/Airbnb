using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB.Models
{
    public class Review
    {
        private int propID;
        private int revID;
        private string date;
        private int reviewerID;
        private string reviewerName;
        private string revComment;

        public Review(int propID, int revID, string date, int reviewerID, string reviewerName, string revComment)
        {
            this.PropID = propID;
            this.RevID = revID;
            this.Date = date;
            this.ReviewerID = reviewerID;
            this.ReviewerName = reviewerName;
            this.RevComment = revComment;
        }

        public Review()
        {

        }

        public int PropID { get => propID; set => propID = value; }
        public int RevID { get => revID; set => revID = value; }
        public string Date { get => date; set => date = value; }
        public int ReviewerID { get => reviewerID; set => reviewerID = value; }
        public string ReviewerName { get => reviewerName; set => reviewerName = value; }
        public string RevComment { get => revComment; set => revComment = value; }
    }
}