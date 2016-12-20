using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctInventory
    {
        public int inventoryID { get; set; }

        public int donationID { get; set; }

        public int quantity { get; set; }

        public string description { get; set; }

        public int categoryID { get; set; }
    }
    public class ctInventoryList : DbContext
    {
        public DbSet<ctInventory> ctInventories { get; set; }
    }
}