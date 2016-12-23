using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class companyModel
    {
        public int companyID { get; set; }

        public string companyName { get; set; }

        public string companyDescription { get; set; }

        public geoLocationModel companyLocation { get; set; }

        public string companyDemographic { get; set; }

        public byte[] companyLogo { get; set; }

        //add a list to contain the users in the company for reference at a late time

        //public List<ctUser> userCompanyID { get; set; }


    }
}