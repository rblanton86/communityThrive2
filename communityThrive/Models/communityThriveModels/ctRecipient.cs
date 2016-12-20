using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctRecipient
    {
        public int recipientID { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int gender { get; set; }
    }
    public class ctRecipientList : DbContext
    {
        public DbSet<ctRecipient> ctRecipients { get; set; }
    }
}