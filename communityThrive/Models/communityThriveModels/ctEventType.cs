using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctEventType
    {
        public int eventTypeID { get; set; }

        public string eventTypeDescription { get; set; }

        public string designation { get; set; }
    }
    public class ctCEventType : DbContext
    {
        public DbSet<ctEventType> ctEventTypes { get; set; }
    }
}