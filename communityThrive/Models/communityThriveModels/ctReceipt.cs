using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace communityThrive2.Models.communityThriveModels
{
    public class ctReceipt
    {
        public int ctReceiptID { get; set; }

        public int userID { get; set; }

        public int itemList { get; set; }
    }
    public class ctReceiptList : DbContext
    {
        public DbSet<ctReceipt> ctReceipts { get; set; }
    }
}