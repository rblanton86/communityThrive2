using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class eventModel
    {
        public int eventID { get; set; }

        public string eventDescription { get; set; }

        public DateTime eventDateTime { get; set; }

        public int eventTypeIDFK { get; set; }

        public string eventTypeDescription { get; set; }

        public string eventDesignation { get; set; }

    }
}