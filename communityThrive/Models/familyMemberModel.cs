using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace communityThrive2.Models
{
    public class familyMemberModel
    {
        public int familyMemberID { get; set; }

        public int recipientIDFK { get; set; }

        public recipientModel recipient { get; set; }

        public int familyMemberGender { get; set; }

        public int familyMemberAge { get; set; }

        public bool isSpouse { get; set; }


    }
}