using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctDonation
    {
        public int donationID { get; set; }

        public int userID { get; set; }

        public DateTime dateSubmitted { get; set; }

        public string describe { get; set; }

        public string notes { get; set; }

        public int eventID { get; set; }
    }
    public class ctDonationList : DbContext
    {
        public DbSet<ctDonation> ctDonations { get; set; }
    }
}