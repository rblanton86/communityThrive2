using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using communityThrive2.Models;

namespace communityThrive2.Controllers
{
    public class ct2UserDataController
    {
        public static SqlDatabase db;

        public ct2UserDataController(string connectionstring)
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
        public userModel CreateUser(userModel currentUser)
        {
            ///uses create procedure to insert values into the model parameters
            DbCommand create_User = db.GetStoredProcCommand("sp_createct2User");
            db.AddInParameter(create_User, "@userID", DbType.Int32, currentUser.userID);
            db.AddInParameter(create_User, "@roleIDFK", DbType.Int32, currentUser.roleIDFK);
            db.AddInParameter(create_User, "@role", DbType.Int32, currentUser.role);
            db.AddInParameter(create_User, "@companyIDFK", DbType.Int32, currentUser.companyIDFK);
            db.AddInParameter(create_User, "@company", DbType.Int32, currentUser.company);
            db.AddInParameter(create_User, "@emailAddress", DbType.Int32, currentUser.emailAddress);
            db.AddInParameter(create_User, "@userPassword", DbType.Int32, currentUser.userPassword);
            db.AddInParameter(create_User, "@firstName", DbType.Int32, currentUser.firstName);
            db.AddInParameter(create_User, "@lastName", DbType.Int32, currentUser.lastName);
            db.AddInParameter(create_User, "@phoneNumber", DbType.Int32, currentUser.phoneNumber);
            db.AddInParameter(create_User, "@streetAddress", DbType.Int32, currentUser.streetAddress);
            db.AddInParameter(create_User, "@cityIDFK", DbType.Int32, currentUser.cityIDFK);
            db.AddInParameter(create_User, "@stateIDFK", DbType.Int32, currentUser.stateIDFK);
            //db.AddInParameter(create_User, "@geoLocation", DbType.Object, currentUser.geoLocation);
            db.AddInParameter(create_User, "@zipcode", DbType.Int32, currentUser.zipcode);
            return currentUser;
        }


        public List<userModel> GetListUser()
        {
            ///uses read procedure by primary ID and returns corresponding values
            DbCommand get_User = db.GetStoredProcCommand("sp_selectct2User");
            db.AddInParameter(get_User, "@userID", DbType.Int32);
            DataSet ds = db.ExecuteDataSet(get_User);

            var userData = (from drRow in ds.Tables[0].AsEnumerable()
                               select new userModel()
                               {
                                   userID = drRow.Field<int>("userID"),
                                   roleIDFK= drRow.Field<int>("roleIDFK"),
                                   role = drRow.Field<roleModel>("role"),
                                   companyIDFK= drRow.Field<int>("companyIDFK"),
                                   company = drRow.Field<companyModel>("company"),
                                   userTypeIDFK = drRow.Field<int>("userTypeIDFK"),
                                   emailAddress = drRow.Field<string>("emailAddress"),
                                   userPassword = drRow.Field<string>("userPassword"),
                                   firstName = drRow.Field<string>("firstName"),
                                   lastName = drRow.Field<string>("LastName"),
                                   phoneNumber = drRow.Field<string>("phoneNumber"),
                                   streetAddress = drRow.Field<string>("streetAddress"),
                                   cityIDFK = drRow.Field<int>("cityIDFK"),
                                   //geoLocation = drRow.Field<geoLocationModel>("geoLocation"),

                               }).ToList();
            return userData;
        }
        public bool UpdateListuser(userModel selectedUser)
        {
            ///uses update procedure to make changes to parameter values
            Boolean success = false;
            DbCommand update_User = db.GetStoredProcCommand("sp_updatect2User");

            db.AddInParameter(update_User, "@userID", DbType.Int32, selectedUser.userID);
            db.AddInParameter(update_User, "@roleIDFK", DbType.Int32, selectedUser.roleIDFK);
            db.AddInParameter(update_User, "@role", DbType.Int32, selectedUser.role);
            db.AddInParameter(update_User, "@companyIDFK", DbType.Int32, selectedUser.companyIDFK);
            db.AddInParameter(update_User, "@company", DbType.Int32, selectedUser.company);
            db.AddInParameter(update_User, "@emailAddress", DbType.Int32, selectedUser.emailAddress);
            db.AddInParameter(update_User, "@userPassword", DbType.Int32, selectedUser.userPassword);
            db.AddInParameter(update_User, "@firstName", DbType.Int32, selectedUser.firstName);
            db.AddInParameter(update_User, "@lastName", DbType.Int32, selectedUser.lastName);
            db.AddInParameter(update_User, "@phoneNumber", DbType.Int32, selectedUser.phoneNumber);
            db.AddInParameter(update_User, "@streetAddress", DbType.Int32, selectedUser.streetAddress);
            db.AddInParameter(update_User, "@cityIDFK", DbType.Int32, selectedUser.cityIDFK);
            db.AddInParameter(update_User, "@stateIDFK", DbType.Int32, selectedUser.stateIDFK);
            db.AddInParameter(update_User, "@geoLocation", DbType.Object, selectedUser.geolocation);
            db.AddInParameter(update_User, "@zipcode", DbType.Int32, selectedUser.zipcode);

            success = Convert.ToBoolean(update_User.ExecuteNonQuery());


            return success;
        }
        public bool DeleteUser(userModel deleteUser)
        {
            ///uses delete procedure to remove list and all its values by the primary ID
            DbCommand delete_User = db.GetStoredProcCommand("sp_deletect2User");

            db.AddInParameter(delete_User, "@companyID", DbType.Int32, deleteUser.userID);

            db.AddOutParameter(delete_User, "@success", DbType.Boolean, 1);

            bool success;
            try
            {
                db.ExecuteNonQuery(delete_User);
                success = Convert.ToBoolean(db.GetParameterValue(delete_User, "@success"));
            }
            catch
            {
                success = false;
            }

            return success;
        }
    }
}