using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class receiptModel
    {
        public int receiptID { get; set; }

        public int userIDFK { get; set; }

        public userModel user { get; set; }

        public int donationIDFK { get; set; }

        public donationModel donation { get; set; }

    }
}