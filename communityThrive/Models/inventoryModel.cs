using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class inventoryModel
    {
        public int inventoryID { get; set; }

        public int donationIDFK { get; set; }

        public donationModel donation { get; set; }

        public int categoryIDFK { get; set; }

        public categoryModel category { get; set; }

        public int inventoryQuantity { get; set; }

        public string inventoryDescription { get; set; }


    }
}