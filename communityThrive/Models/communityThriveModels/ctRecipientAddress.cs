using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctRecipientAddress
    {
        public int ctRecipientAddressID { get; set; }

        public int recipientID { get; set; }

        public string streetName { get; set; }

        public string cityName { get; set; }

        public string stateName { get; set; }

        public int zipcode { get; set; }
    }
    public class ctRecipientAddressList : DbContext
    {
        public DbSet<ctRecipientAddress> ctRecipientAddrezz { get; set; }
    }
}