using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class inventoryItemModel
    {
        public int itemID { get; set; }

        public int inventoryIDFK { get; set; }

        public int categoryIDFK { get; set; }

        public string itemName { get; set; }

        public int itemPrice { get; set; }

        public string itemDescription { get; set; }

        public int itemUPC { get; set; }


    }
}