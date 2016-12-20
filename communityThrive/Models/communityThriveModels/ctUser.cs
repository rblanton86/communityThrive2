using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctUser
    {
        public int userID { get; set; }

        public int roleID { get; set; }

        public int companyID { get; set; }

        public string emailAddress { get; set; }

        public string userPassword { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string phoneNumber { get; set; }

        public string userAddress { get; set; }

        public int userTypeID { get; set; }
    }
    public class ctUsersList : DbContext
    {
        public DbSet<ctUser> ctUserz { get; set; }
    }
}