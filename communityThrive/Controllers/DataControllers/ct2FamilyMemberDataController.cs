using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Web.Mvc;
using System.Web.Configuration;

using communityThrive2.Models;

namespace communityThrive2.Controllers.DataControllers
{
    public class ct2FamilyMemberDataController
    {
        public static SqlDatabase db;

        public ct2FamilyMemberDataController()
        {

            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["ctConnectionString"].ToString());
            }
        }

        public List<familyMemberModel> GetListFamilyMembers()
        {
            DbCommand sp_readCt2FamilyMember = db.GetStoredProcCommand("sp_readct2FamilyMember");

            DataSet ds = db.ExecuteDataSet(sp_readCt2FamilyMember);

            var familyMembers = (from drRow in ds.Tables[0].AsEnumerable()
                                 select new familyMemberModel
                                 {
                                     familyMemberID = drRow.Field<int>("familyMemberID"),
                                     recipientIDFK = drRow.Field<int>("recipientIDFK"),
                                     recipient = drRow.Field<recipientModel>("recipient"),
                                     familyMemberGender = drRow.Field<int>("familyMemberGender"),
                                     familyMemberAge = drRow.Field<int>("familyMemberAge"),
                                     isSpouse = drRow.Field<bool>("isSpouse")


                                 }).ToList();

            return familyMembers;
        }

        /// Create Procedure Data Controller
        public int createFamilyMember(familyMemberModel currentFamilyMember)
        {
            int success;

            DbCommand sp_createCt2FamilyMember = db.GetStoredProcCommand("sp_createCt2FamilyMember");

            db.AddInParameter(sp_createCt2FamilyMember, "@familyMemberID", SqlDbType.Int, currentFamilyMember.familyMemberID);

            success = sp_createCt2FamilyMember.ExecuteNonQuery();

            return success;
        }

        ///Delete Procedure Data Controller
        public int deleteFamilyMember(familyMemberModel currentFamilyMember)
        {
            int success;

            DbCommand sp_deleteFamilyMember = db.GetStoredProcCommand("sp_deleteCt2FamilyMember");

            db.AddInParameter(sp_deleteFamilyMember, "@familyMemberID", SqlDbType.Int, currentFamilyMember.familyMemberID);

            success = sp_deleteFamilyMember.ExecuteNonQuery();

            return success;
        }

    }
}