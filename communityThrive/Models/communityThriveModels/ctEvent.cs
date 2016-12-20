using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctEvent
    {
        public int eventsID { get; set; }

        public int eventTypeID { get; set; }

        public string eventDescription { get; set; }

        public DateTime eventDateTime { get; set; }
    }
    public class ctEventList : DbContext
    {
        public DbSet<ctEvent> ctEvents { get; set; }
    }
}