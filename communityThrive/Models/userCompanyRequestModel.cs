using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class userCompanyRequestModel
    {
        //ct2User table
        public int userID { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string emailAddress { get; set; }

        //end ct2User table

        
    }
}