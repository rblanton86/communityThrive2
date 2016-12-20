using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctRecipientDonorTracking
    {
        public int donationTrackingID { get; set; }

        public int recipientID { get; set; }

        public DateTime donationDate { get; set; }

        public int eventsID { get; set; }

        public int stockID { get; set; }
    }
    public class ctRecipientDonorTrackingList : DbContext
    {
        public DbSet<ctRecipientDonorTracking> ctRecipientDonorTrackings { get; set; }
    }
}