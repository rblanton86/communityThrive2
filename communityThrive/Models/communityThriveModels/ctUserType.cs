using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctUserType
    {
        public int userTypeID { get; set; }

        public string userTypeDescription { get; set; }
    }
    public class ctUserTypeList : DbContext
    {
        public DbSet<ctUserType> ctUserTypes { get; set; }
    }
}