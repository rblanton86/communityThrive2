using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using communityThrive2.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.Entity;

namespace communityThrive2.DataControllers
{
    public class contentDataController
    {


        public static SqlDatabase db;

        /// <summary>
        /// Constructor that defines the db connection, the database connection is held in the Web.config
        /// </summary>
        public contentDataController()
        {
            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            }
        }
        ///<summary>
        ///End of the constructor for the contentDataController
        /// </summary>

        /// <summary>
        /// This is the beginning of the CRUD stored procs for the ctItem tables
        /// </summary>
        public void createItem(string itemName, int itemPrice, string itemDescription, int itemUPC, int iventoryID, int categoryID)
        {
            DbCommand get_itemData = db.GetStoredProcCommand("sp_CreateItem");


            db.AddInParameter(get_itemData, "@itemName", DbType.String, itemName);
            db.AddInParameter(get_itemData, "@itemPrice", DbType.Int32, itemPrice);
            db.AddInParameter(get_itemData, "@itemDescription", DbType.String, itemDescription);
            db.AddInParameter(get_itemData, "@itemUPC", DbType.Int32, itemUPC);
            db.AddInParameter(get_itemData, "@iventoryID", DbType.Int32, iventoryID);
            db.AddInParameter(get_itemData, "@categoryID", DbType.Int32, categoryID);

            DataSet ds = db.ExecuteDataSet(get_itemData);

        }


       
        public void updateItem(int itemID, string itemName, int itemPrice, string itemDescription, int itemUPC, int iventoryID, int categoryID)
        {
            DbCommand get_itemData = db.GetStoredProcCommand("sp_UpdateItem");

            db.AddInParameter(get_itemData, "@itemID", DbType.Int32, itemID);
            db.AddInParameter(get_itemData, "@itemName", DbType.String, itemName);
            db.AddInParameter(get_itemData, "@itemPrice", DbType.Int32, itemPrice);
            db.AddInParameter(get_itemData, "@itemDescription", DbType.String, itemDescription);
            db.AddInParameter(get_itemData, "@itemUPC", DbType.Int32, itemUPC);
            db.AddInParameter(get_itemData, "@iventoryID", DbType.Int32, iventoryID);
            db.AddInParameter(get_itemData, "@categoryID", DbType.Int32, categoryID);

            DataSet ds = db.ExecuteDataSet(get_itemData);


        }
        
        /// <summary>
        /// This is the end of the CRUD stored procs for the ctItem tables
        /// </summary>


        ///<summary>
        ///
        /// This is the beggining of the category makeshift controllers
        /// 
        /// </summary>


        public void createCategory(int categoryParentID, string categoryDescription, bool isUserDefined, bool isDeleted)
        {
            DbCommand create_categoryData = db.GetStoredProcCommand("sp_CreateCategory");


            //connection.AddInParameter(create_categoryData, "@categoryID", DbType.Int32, categoryID);
            db.AddInParameter(create_categoryData, "@categoryParentID", DbType.Int32, categoryParentID);
            db.AddInParameter(create_categoryData, "@categoryDescription", DbType.String, categoryDescription);
            db.AddInParameter(create_categoryData, "@isUserDefined", DbType.Boolean, isUserDefined);
            db.AddInParameter(create_categoryData, "@isDeleted", DbType.Boolean, isDeleted);



            DataSet ds = db.ExecuteDataSet(create_categoryData);



        }

        public List<categoryModel> readCategory(int userReadInput)
        {

            DbCommand get_itemData = db.GetStoredProcCommand("sp_ReadCategory");

            db.AddInParameter(get_itemData, "@categoryID", DbType.Int32, userReadInput);

            DataSet ds = db.ExecuteDataSet(get_itemData);

            var categoryInfo = (from daRow in ds.Tables[0].AsEnumerable()
                                select new categoryModel()
                                {

                                    categoryID = userReadInput,
                                    categoryParentID = daRow.Field<int>("categoryParentID"),
                                    categoryDescription = daRow.Field<string>("categoryDescription"),
                                    isUserDefined = daRow.Field<bool>("isUserDefined"),
                                    isDeleted = daRow.Field<bool>("isDeleted"),
                                    dateAdded = daRow.Field<DateTime>("dateAdded")



                                }).ToList();

            return categoryInfo;

        }

        ///<summary>
        ///
        /// This is the end of the makeshift category controllers
        /// 
        /// </summary>



        ///<summary>
        ///
        /// The beggining of the company controllers
        /// 
        /// </summary>


        public List<companyModel> readCompany(int userReadInput)
        {

            DbCommand get_itemData = db.GetStoredProcCommand("sp_ReadCompany");

            db.AddInParameter(get_itemData, "@companyID", DbType.Int32, userReadInput);

            DataSet ds = db.ExecuteDataSet(get_itemData);

            var companyInfo = (from daRow in ds.Tables[0].AsEnumerable()
                                select new companyModel()
                                {

                                    companyID = userReadInput,
                                    companyName = daRow.Field<string>("companyName"),
                                    companyDescription = daRow.Field<string>("companyDescription"),
                                    //companyLocation = daRow.Field<string>("companyLocation"),
                                    companyDemographic = daRow.Field<string>("companyDemographic")
                                    



                                }).ToList();

            return companyInfo;

        }
        public companyModel CreateCompany(companyModel currentCompany)
        {
            ///uses create procedure to insert values into the model parameters
            DbCommand create_Company = db.GetStoredProcCommand("sp_createct2Company");
            db.AddInParameter(create_Company, "@companyID", DbType.Int32, currentCompany.companyID);
            db.AddInParameter(create_Company, "@companyName", DbType.String, currentCompany.companyName);
            //db.AddInParameter(create_Company, "@stateID", DbType.Int32, currentCompany.stateID);
            //db.AddInParameter(create_Company, "@cityID", DbType.Int32, currentCompany.cityID);
            db.AddInParameter(create_Company, "@companyDemographic", DbType.Int32, currentCompany.companyDemographic);
            return currentCompany;
        }


        public List<companyModel> GetListCompanies()
        {
            ///uses read procedure by company ID and returns corresponding values
            DbCommand get_Company = db.GetStoredProcCommand("sp_selectct2Company");
            db.AddInParameter(get_Company, "@companyID", DbType.Int32);
            DataSet ds = db.ExecuteDataSet(get_Company);

            var companyData = (from drRow in ds.Tables[0].AsEnumerable()
                               select new companyModel()
                               {
                                   companyID = drRow.Field<int>("companyID"),
                                   companyName = drRow.Field<string>("companyName"),
                                   companyDescription = drRow.Field<string>("companyDescription"),
                                   //stateID = drRow.Field<geoLocationModel>("stateID"),
                                   companyDemographic = drRow.Field<string>("companyDemographic")

                               }).ToList();
            return companyData;
        }
        public bool UpdateListcompany(companyModel selectedCompany)
        {
            ///uses update procedure to make changes to parameter values
            Boolean success = false;
            DbCommand update_Company = db.GetStoredProcCommand("sp_updatect2Company");

            db.AddInParameter(update_Company, "@companyID", DbType.Int32, selectedCompany.companyID);
            db.AddInParameter(update_Company, "@companyName", DbType.String, selectedCompany.companyName);
            db.AddInParameter(update_Company, "@companyDescription", DbType.String, selectedCompany.companyDescription);
            //db.AddInParameter(update_Company, "@stateID", DbType.Int32, selectedCompany.stateID);
            //db.AddInParameter(update_Company, "@cityID", DbType.Int32, selectedCompany.cityID);
            db.AddInParameter(update_Company, "@companyDemographic", DbType.String, selectedCompany.companyDemographic);

            success = Convert.ToBoolean(update_Company.ExecuteNonQuery());


            return success;
        }
        public bool DeleteCompany(companyModel deleteCompany)
        {
            ///uses delete procedure to remove company and all its values by the company ID
            DbCommand delete_Company = db.GetStoredProcCommand("sp_deletect2Company");

            db.AddInParameter(delete_Company, "@companyID", DbType.Int32, deleteCompany.companyID);

            db.AddOutParameter(delete_Company, "@success", DbType.Boolean, 1);

            bool success;
            try
            {
                db.ExecuteNonQuery(delete_Company);
                success = Convert.ToBoolean(db.GetParameterValue(delete_Company, "@success"));
            }
            catch
            {
                success = false;
            }

            return success;
        }
        public donationModel CreateCompany(donationModel currentDonation)
        {
            ///uses create procedure to insert values into the model parameters
            DbCommand create_Donation = db.GetStoredProcCommand("sp_createct2Donation");
            db.AddInParameter(create_Donation, "@donationID", DbType.Int32, currentDonation.donationID);
            db.AddInParameter(create_Donation, "@userIDFK", DbType.String, currentDonation.userIDFK);
            db.AddInParameter(create_Donation, "@user", DbType.Int32, currentDonation.user);
            db.AddInParameter(create_Donation, "@eventIDFK", DbType.Int32, currentDonation.eventIDFK);
            db.AddInParameter(create_Donation, "@events", DbType.Int32, currentDonation.events);
            db.AddInParameter(create_Donation, "@dateSubmitted", DbType.Int32, currentDonation.dateSubmitted);
            db.AddInParameter(create_Donation, "@donationDescription", DbType.Int32, currentDonation.donationDescription);
            db.AddInParameter(create_Donation, "@donationNotes", DbType.Int32, currentDonation.donationNotes);
            return currentDonation;
        }


        public List<donationModel> GetListDonation()
        {
            ///uses read procedure by company ID and returns corresponding values
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
                                    events = drRow.Field<eventModel>("user"),
                                    dateSubmitted = drRow.Field<DateTime>("dateSubmitted"),
                                    donationDescription = drRow.Field<string>("donationDescription"),
                                }).ToList();
            return donationData;
        }

            public List<cityModel> GetListCities(int stateIDFK)
            {
                // Readies stored proc from server.
                DbCommand GetCities = db.GetStoredProcCommand("GetCities");

                db.AddInParameter(GetCities, "@stateIDFK", DbType.String, stateIDFK);

                // Executes stored proc to return values into a DataSet.
                DataSet ds = db.ExecuteDataSet(GetCities);

                // Takes values from DataSet and places results in a SelectList.
                // This select list is used for the search autocomplete boxes on the client_update page.
                var cities = (from drRow in ds.Tables[0].AsEnumerable()
                              select new cityModel()
                              {

                                  cityID = drRow.Field<int>("cityID"),
                                  cityDescription = drRow.Field<string>("cityDescription"),

                              }).ToList();

                return cities;
            }

            public List<geoLocationModel> GetListStates(int stateID)
            {
                // Reads stored proc from server.
                DbCommand GetStates = db.GetStoredProcCommand("GetStates");

                db.AddInParameter(GetStates, "@stateID", DbType.String, stateID);

                // Executes stored proc to return values into a DataSet.
                DataSet ds = db.ExecuteDataSet(GetStates);

                // Takes values from DataSet and places results in a SelectList.
                // This select list is used for the search autocomplete boxes on the client_update page.
                var states = (from drRow in ds.Tables[0].AsEnumerable()
                              select new geoLocationModel()
                              {

                                  stateID = drRow.Field<int>("stateID"),
                                  stateDescription = drRow.Field<string>("stateDescription"),

                              }).ToList();

                return states;
            }

            ///Create Procedure Data Controller

            public int createGeoLocationCity(geoLocationModel currentLocation)
            {
                int success;

                try
                {
                    DbCommand sp_createct2GeoLocationCity = db.GetStoredProcCommand("sp_createct2GeoLocationCity");
                    sp_createct2GeoLocationCity.Connection = db.CreateConnection();
                    sp_createct2GeoLocationCity.Connection.Open();


                    foreach (cityModel city in currentLocation.cities)
                    {
                        db.AddInParameter(sp_createct2GeoLocationCity, "@cityDescription", SqlDbType.VarChar, city.cityDescription);
                        db.AddInParameter(sp_createct2GeoLocationCity, "@stateIDFK", SqlDbType.VarChar, currentLocation.stateID);

                        success = sp_createct2GeoLocationCity.ExecuteNonQuery();

                    }

                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }

            }

            public int createGeoLocationState(geoLocationModel currentLocation)
            {
                int stateID = 0;
                int cityID = 0;

                DbCommand sp_createct2GeoLocationState = db.GetStoredProcCommand("sp_createct2GeoLocationState");
                sp_createct2GeoLocationState.Connection = db.CreateConnection();
                sp_createct2GeoLocationState.Connection.Open();

                db.AddInParameter(sp_createct2GeoLocationState, "@stateDescription", SqlDbType.VarChar, currentLocation.stateDescription);

                stateID = sp_createct2GeoLocationState.ExecuteNonQuery();

                if (stateID == 0)
                {
                    // do nothing
                }
                else
                {
                    currentLocation.stateID = stateID;
                    cityID = createGeoLocationCity(currentLocation);
                }

                return stateID;

            }

            ///Update Procedure Data Controller

            public bool UpdateCity(cityModel currentCity)
            {
                DbCommand sp_updatect2GeoLocationCity = db.GetStoredProcCommand("sp_updatect2GeoLocationCity");

                db.AddInParameter(sp_updatect2GeoLocationCity, "@cityID", SqlDbType.Int, currentCity.cityID);
                db.AddInParameter(sp_updatect2GeoLocationCity, "@cityDescription", SqlDbType.VarChar, currentCity.cityDescription);

                return false;
            }

            public bool UpdateState(geoLocationModel currentState)
            {
                DbCommand sp_updatect2GeoLocationState = db.GetStoredProcCommand("sp_updatect2GeoLocationState");

                db.AddInParameter(sp_updatect2GeoLocationState, "@stateID", SqlDbType.Int, currentState.stateID);
                db.AddInParameter(sp_updatect2GeoLocationState, "@stateDescription", SqlDbType.VarChar, currentState.stateDescription);

                return false;
            }

            /// Delete Procedure Data Controller

            public bool DeleteCity(cityModel removingCity)
            {
                DbCommand sp_deletect2GeoLocationCity = db.GetStoredProcCommand("sp_deletect2GeoLocationCity");

                db.AddInParameter(sp_deletect2GeoLocationCity, "@cityID", SqlDbType.Int, removingCity.cityID);
                db.AddOutParameter(sp_deletect2GeoLocationCity, "@success", SqlDbType.Int, 1);

                bool success;
                try
                {
                    db.ExecuteNonQuery(sp_deletect2GeoLocationCity);
                    success = Convert.ToBoolean(db.GetParameterValue(sp_deletect2GeoLocationCity, "@success"));
                }
                catch (Exception e)
                {
                    success = false;
                    throw;
                }

                return success;
            }




            public bool DeleteState(geoLocationModel removingState)
            {
                DbCommand sp_deletect2GeoLocationState = db.GetStoredProcCommand("sp_deletect2GeoLocationState");

                db.AddInParameter(sp_deletect2GeoLocationState, "@stateID", SqlDbType.Int, removingState.stateID);

                return false;

            }

        public List<roleModel> GetListRoles(int roleID)
        {
            // Readies stored proc from server.
            DbCommand GetRoles = db.GetStoredProcCommand("GetRoles");

            db.AddInParameter(GetRoles, "@roleID", DbType.String, roleID);

            // Executes stored proc to return values into a DataSet.
            DataSet ds = db.ExecuteDataSet(GetRoles);

            // Takes values from DataSet and places results in a SelectList.
            // This select list is used for the search autocomplete boxes on the client_update page.
            var roles = (from drRow in ds.Tables[0].AsEnumerable()
                         select new roleModel()
                         {

                             roleID = drRow.Field<int>("roleID"),
                             roleDescription = drRow.Field<string>("roleDescription"),

                         }).ToList();

            return roles;
        }

        ///Create Procedure Data Controller

        public int createRole(roleModel currentRole)
        {
            int success;

            DbCommand sp_createct2Roles = db.GetStoredProcCommand("sp_createct2Roles");
            sp_createct2Roles.Connection = db.CreateConnection();
            sp_createct2Roles.Connection.Open();

            db.AddInParameter(sp_createct2Roles, "@roleDescription", SqlDbType.VarChar, currentRole.roleDescription);

            success = sp_createct2Roles.ExecuteNonQuery();

            return success;

        }

        ///Update Procedure Data Controller

        public bool UpdateRole(roleModel currentRole)
        {
            DbCommand sp_updatect2Roles = db.GetStoredProcCommand("sp_updatect2Roles");

            db.AddInParameter(sp_updatect2Roles, "@roleID", SqlDbType.Int, currentRole.roleID);
            db.AddInParameter(sp_updatect2Roles, "@roleDescription", SqlDbType.VarChar, currentRole.roleDescription);

            return false;
        }

        /// Delete Procedure Data Controller

        public bool DeleteRole(roleModel removingRole)
        {
            DbCommand sp_deletect2Roles = db.GetStoredProcCommand("sp_deletect2Roles");

            db.AddInParameter(sp_deletect2Roles, "@roleID", SqlDbType.Int, removingRole.roleID);


            return false;
        }

        public List<stockModel> GetListStocks(int stockID)
        {
            // Readies stored proc from server.
            DbCommand GetStocks = db.GetStoredProcCommand("GetStocks");

            db.AddInParameter(GetStocks, "@stockID", DbType.String, stockID);

            // Executes stored proc to return values into a DataSet.
            DataSet ds = db.ExecuteDataSet(GetStocks);

            // Takes values from DataSet and places results in a SelectList.
            // This select list is used for the search autocomplete boxes on the client_update page.
            var stocks = (from drRow in ds.Tables[0].AsEnumerable()
                          select new stockModel()
                          {

                              stockQuantity = drRow.Field<int>("stockQuantity"),
                              category = drRow.Field<categoryModel>("category"),

                          }).ToList();

            return stocks;
        }

        ///Create Procedure Data Controller

        public int createStock(stockModel currentStock)
        {
            int success;

            DbCommand sp_createct2Stock = db.GetStoredProcCommand("sp_createct2Stock");
            sp_createct2Stock.Connection = db.CreateConnection();
            sp_createct2Stock.Connection.Open();

            db.AddInParameter(sp_createct2Stock, "@categoryIDFK", SqlDbType.Int, currentStock.category);
            db.AddInParameter(sp_createct2Stock, "@stockQuantity", SqlDbType.Int, currentStock.stockQuantity);
            db.AddInParameter(sp_createct2Stock, "@locationCode", SqlDbType.VarChar, currentStock.locationCode);

            success = sp_createct2Stock.ExecuteNonQuery();

            return success;

        }

        ///Update Procedure Data Controller

        public bool UpdateStock(stockModel currentStock)
        {
            DbCommand sp_updatect2Stock = db.GetStoredProcCommand("sp_updatect2Stock");

            db.AddInParameter(sp_updatect2Stock, "@stockID", SqlDbType.Int, currentStock.stockID);
            db.AddInParameter(sp_updatect2Stock, "@categoryIDFK", SqlDbType.Int, currentStock.category);
            db.AddInParameter(sp_updatect2Stock, "@stockQuantity", SqlDbType.Int, currentStock.stockQuantity);
            db.AddInParameter(sp_updatect2Stock, "@locationCode", SqlDbType.VarChar, currentStock.locationCode);

            return false;
        }

        /// Delete Procedure Data Controller

        public bool DeleteStock(stockModel removingStock)
        {
            DbCommand sp_deletect2Stock = db.GetStoredProcCommand("sp_deletect2Stock");

            db.AddInParameter(sp_deletect2Stock, "@stockID", SqlDbType.Int, removingStock.stockID);

            return false;

        }
    }
}






