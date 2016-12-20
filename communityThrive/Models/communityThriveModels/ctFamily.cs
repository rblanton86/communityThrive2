using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctFamily
    {
        public int familyID { get; set; }

        public int recipientID { get; set; }

        public int gender { get; set; }

        public int age { get; set; }

        public bool isSpouse { get; set; }
    }
    public class ctFamilysList : DbContext
    {
        public DbSet<ctFamily> ctFamilies { get; set; }
    }
}