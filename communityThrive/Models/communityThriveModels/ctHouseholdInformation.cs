using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctHouseholdInformation
    {
        public int householdInformation { get; set; }

        public int familyID { get; set; }

        public int householdIncome { get; set; }

        public bool isEmployed { get; set; }
    }
    public class ctHouseholdInformationList : DbContext
    {
        public DbSet<ctHouseholdInformation> ctHouseholdInformations { get; set; }
    }
}