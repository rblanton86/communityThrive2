using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using communityThrive2.Models;

namespace communityThrive2.Controllers.DataControllers
{
    public class ct2DonationDataController
    {
        public static SqlDatabase db;

        public ct2DonationDataController(string connectionstring)
        {
            if (connectionstring.Length > 0)
            {
                db = new SqlDatabase(connectionstring);
            }
            else
            {
                if (db == null)
                {
                    db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                }
            }
        }
        public donationModel CreateCompany(donationModel currentDonation)
        {
            ///uses create procedure to insert values into the model parameters
            DbCommand create_Donation = db.GetStoredProcCommand("sp_createct2Donation");
            db.AddInParameter(create_Donation, "@donationID", DbType.Int32, currentDonation.donationID);
            db.AddInParameter(create_Donation, "@userIDFK", DbType.Int32, currentDonation.userIDFK);
            db.AddInParameter(create_Donation, "@user", DbType.Object, currentDonation.user);
            db.AddInParameter(create_Donation, "@eventIDFK", DbType.Int32, currentDonation.eventIDFK);
            db.AddInParameter(create_Donation, "@events", DbType.Object, currentDonation.events);
            db.AddInParameter(create_Donation, "@dateSubmitted", DbType.DateTime, currentDonation.dateSubmitted);
            db.AddInParameter(create_Donation, "@donationDescription", DbType.String, currentDonation.donationDescription);
            db.AddInParameter(create_Donation, "@donationNotes", DbType.String, currentDonation.donationNotes);
            return currentDonation;
        }


        public List<donationModel> GetListDonation()
        {
            ///uses read procedure by primary ID and returns corresponding values
            DbCommand get_Donation = db.GetStoredProcCommand("sp_selectct2Donation");
            db.AddInParameter(get_Donation, "@donationID", DbType.Int32);
            DataSet ds = db.ExecuteDataSet(get_Donation);

            var donationData = (from drRow in ds.Tables[0].AsEnumerable()
                               select new donationModel()
                               {
                                   donationID = drRow.Field<int>("donationID"),
                                   userIDFK = drRow.Field<int>("userIDFK"),
                                   user = drRow.Field<userModel>("user"),
                                   eventIDFK = drRow.Field<int>("eventIDFK"),
                                  events = drRow.Field<eventModel>("events"),
                                  dateSubmitted = drRow.Field<DateTime>("dateSubmitted"),
                                  donationDescription = drRow.Field<string>("donationDescription"),
                               }).ToList();
            return donationData;
        }
        public bool UpdateListdonation(donationModel selectedDonation)
        {
            ///uses update procedure to make changes to parameter values
            Boolean success = false;
            DbCommand update_Donation = db.GetStoredProcCommand("sp_updatect2Company");

            db.AddInParameter(update_Donation, "@donationID", DbType.Int32, selectedDonation.donationID);
            db.AddInParameter(update_Donation, "@userIDFK", DbType.Int32, selectedDonation.userIDFK);
            db.AddInParameter(update_Donation, "@user", DbType.Object, selectedDonation.user);
            db.AddInParameter(update_Donation, "@eventIDFK", DbType.Int32, selectedDonation.eventIDFK);
            db.AddInParameter(update_Donation, "@events", DbType.Object, selectedDonation.events);
            db.AddInParameter(update_Donation, "@dateSubmitted", DbType.DateTime, selectedDonation.dateSubmitted);
            db.AddInParameter(update_Donation, "@donationDescription", DbType.String, selectedDonation.donationDescription);
            db.AddInParameter(update_Donation, "@donationNotes", DbType.String, selectedDonation.donationNotes);

            success = Convert.ToBoolean(update_Donation.ExecuteNonQuery());


            return success;
        }
        public bool DeleteDonation(donationModel deleteDonation)
        {
            ///uses delete procedure to remove list and all its values by the primary ID
            DbCommand delete_Donation = db.GetStoredProcCommand("sp_deletect2Donation");

            db.AddInParameter(delete_Donation, "@donationID", DbType.Int32, deleteDonation.donationID);

            db.AddOutParameter(delete_Donation, "@success", DbType.Boolean, 1);

            bool success;
            try
            {
                db.ExecuteNonQuery(delete_Donation);
                success = Convert.ToBoolean(db.GetParameterValue(delete_Donation, "@success"));
            }
            catch
            {
                success = false;
            }

            return success;
        }
    }
}