using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctPrivilidges
    {
        public int privilidges { get; set; }

        public string privilidgesDescription { get; set; }
    }
    public class ctPrivilidgesList : DbContext
    {
        public DbSet<ctPrivilidges> ctPrivilidgez { get; set; }
    }
}