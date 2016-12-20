using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class stockModel
    {
        public int stockID { get; set; }

        public categoryModel category { get; set; }

        public inventoryItemModel inventory { get; set; }

        public int stockQuantity { get; set; }

        public string locationCode { get; set; }


    }
}