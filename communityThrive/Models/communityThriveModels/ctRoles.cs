using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctRoles
    {
        public int rolesID { get; set;}

        public string roleDescription { get; set; }
    }
    public class ctRolesList : DbContext
    {
        public DbSet<ctRoles> ctRolez { get; set; }
    }
}