using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctCategory
    {
        public int categoryID { get; set; }

        public DateTime dateAdded { get; set; }

        public int parentID { get; set; }

        public bool isUserDefined { get; set; }

        public bool isDeleted { get; set; }

        public string catDescription { get; set; }
    }

    public class ctCategoriesList : DbContext
    {
        public DbSet<ctCategory> ctCategories { get; set; }
    }

}