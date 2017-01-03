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
    public class ct2RecipientDataController
    {
        public static SqlDatabase db;

        public ct2RecipientDataController(string connectionstring)
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
        public recipientModel CreateRecpient(recipientModel currentRecipient)
        {
            ///uses create procedure to insert values into the model parameters
            DbCommand create_Recipient = db.GetStoredProcCommand("sp_createct2Recipient");
            db.AddInParameter(create_Recipient, "@recipientID", DbType.Int32, currentRecipient.recipientID);
            db.AddInParameter(create_Recipient, "@firstName", DbType.String, currentRecipient.firstName);
            db.AddInParameter(create_Recipient, "@lastName", DbType.String, currentRecipient.lastName);
            db.AddInParameter(create_Recipient, "@recipientGender", DbType.Int32, currentRecipient.recipientGender);
            return currentRecipient;
        }


        public List<recipientModel> GetListRecipient()
        {
            ///uses read procedure by primary ID and returns corresponding values
            DbCommand get_Recipient = db.GetStoredProcCommand("sp_selectct2Recipient");
            db.AddInParameter(get_Recipient, "@recipientID", DbType.Int32);
            DataSet ds = db.ExecuteDataSet(get_Recipient);

            var recipientData = (from drRow in ds.Tables[0].AsEnumerable()
                               select new recipientModel()
                               {
                                   recipientID = drRow.Field<int>("recipientID"),
                                   firstName = drRow.Field<string>("firstName"),
                                   lastName = drRow.Field<string>("lastName"),
                                   recipientGender = drRow.Field<int>("recipientGender"),

                               }).ToList();
            return recipientData;
        }
        public bool UpdateListrecipient(recipientModel selectedRecipient)
        {
            ///uses update procedure to make changes to parameter values
            Boolean success = false;
            DbCommand update_Recipient = db.GetStoredProcCommand("sp_updatect2Recipient");

            db.AddInParameter(update_Recipient, "@recipientID", DbType.Int32, selectedRecipient.recipientID);
            db.AddInParameter(update_Recipient, "@firstName", DbType.String, selectedRecipient.firstName);
            db.AddInParameter(update_Recipient, "@lastName", DbType.String, selectedRecipient.lastName);
            db.AddInParameter(update_Recipient, "@recipientGender", DbType.Int32, selectedRecipient.recipientGender);

            success = Convert.ToBoolean(update_Recipient.ExecuteNonQuery());


            return success;
        }
        public bool DeleteRecipient(recipientModel deleteRecipient)
        {
            ///uses delete procedure to remove list and all its values by the primary ID
            DbCommand delete_Recipient = db.GetStoredProcCommand("sp_deletect2Recipient");

            db.AddInParameter(delete_Recipient, "@recipientID", DbType.Int32, deleteRecipient.recipientID);

            db.AddOutParameter(delete_Recipient, "@success", DbType.Boolean, 1);

            bool success;
            try
            {
                db.ExecuteNonQuery(delete_Recipient);
                success = Convert.ToBoolean(db.GetParameterValue(delete_Recipient, "@success"));
            }
            catch
            {
                success = false;
            }

            return success;
        }
    }
}