using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{

    public class ctItem1
    {

        public int itemID { get; set; }

        public string itemName { get; set; }

        public int itemPrice { get; set; }

        public string itemDescription { get; set; }

        public int itemUPC { get; set; }

        public int iventoryID { get; set; }

        public int categoryID { get; set; }
    }
    
}