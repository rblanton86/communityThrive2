using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctCompany
    {
        public int companyID { get; set; }

        public string companyName { get; set; }

        public string companyDescription { get; set; }

        public string companyLocation { get; set; }

        public string companyDemographic { get; set; }
    }
    public class ctCompanyList : DbContext
    {
        public DbSet<ctCompany> ctCompanies { get; set; }
    }
}