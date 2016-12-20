using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class categoryModel
    {
        public int categoryID { get; set; }

        public int categoryParentID { get; set; }

        public string categoryDescription { get; set; }

        public bool isUserDefined { get; set; }

        public bool isDeleted { get; set; }

        public DateTime dateAdded { get; set; }
    }
}