using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctStock
    {
        public int stockID { get; set; }

        public int itemID { get; set; }

        public int quantity { get; set; }

        public string locationCode { get; set; }

        public int categoryID { get; set; }

        public int inventoryID { get; set; }
    }
    public class ctStockList : DbContext
    {
        public DbSet<ctStock> ctStocks { get; set; }
    }
}