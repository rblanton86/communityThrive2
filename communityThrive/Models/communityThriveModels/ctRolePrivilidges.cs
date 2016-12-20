using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctRolePrivilidges
    {
        public int roleFK { get; set; }

        public int privilidgeFK { get; set; }


    }
    public class ctRolePrivilidgesList : DbContext
    {
        public DbSet<ctRolePrivilidges> ctRolePrivilidgez { get; set; }
    }
}