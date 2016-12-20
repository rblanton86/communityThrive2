using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class geoLocationModel
    {
        public int stateID { get; set; }

        public string stateDescription { get; set; }

        public cityModel selectedCity { get; set; }

        public List<cityModel> cities { get; set; }
    }
}