using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class userModel
    {
        
        public int userID { get; set; }

        public int roleIDFK { get; set; }

        public roleModel role { get; set; }

        public int companyIDFK { get; set; }

        public companyModel company { get; set; }

        public int userTypeIDFK { get; set; }

        public string emailAddress { get; set; }

        public string userPassword { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string phoneNumber { get; set; }

        public string streetAddress { get; set; }
      
        public int cityIDFK { get; set; }

        public int stateIDFK { get; set; }

        public geoLocationModel geolocation { get; set; }

        public int zipcode { get; set; }


    }
}