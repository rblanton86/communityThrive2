using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class donationModel
    {
        
        public int donationID { get; set; }

        public int userIDFK { get; set; }

        public userModel user { get; set; }

        public int eventIDFK { get; set; }

        public eventModel events { get;set; }

        public DateTime dateSubmitted { get; set; }

        public string donationDescription { get; set; }

        public string donationNotes { get; set; }


    }
}