using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctUserRole
    {
        public int ctUserRoleID { get; set; }

        public int roleID { get; set; }
    }
    public class ctRserRoleList : DbContext
    {
        public DbSet<ctUserRole> ctUserRoles { get; set; }
    }
}