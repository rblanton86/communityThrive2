﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using communityThrive2.Models;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;



namespace communityThrive2.Controllers.DataControllers
{
    public class ct2GeoLocationDataController
    {
        public static SqlDatabase db;

        /// <summary>
        /// The beginning of the ct2GeoLocationDataController constructor
        /// establishes db connection with "DefaultConnection"
        /// </summary>

        public ct2GeoLocationDataController(string connectionstring)
        {
            db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

            if (connectionstring.Length > 0)
            {
                if (db == null)
                {
                    db = new SqlDatabase(connectionstring);
                }
            }
            else
            {
                if (db == null)
                {
                    db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                }
            }
        }

        /// <summary>
        /// the end of the constructor for the geolocation controller
        /// </summary>

        ///<summary>
        ///The beginning GetLocation method that takes information and populates the geolocation model
        /// </summary>
        public List<geoLocationModel> GetLocation(int locationID)
        {
            // Readies stored proc from server.
            DbCommand GetCities = db.GetStoredProcCommand("sp_GetLocation");

            db.AddInParameter(GetCities, "@locationID", DbType.Int32, locationID);

            // Executes stored proc to return values into a DataSet.
            DataSet ds = db.ExecuteDataSet(GetCities);

            var cities = (from drRow in ds.Tables[0].AsEnumerable()
                          select new geoLocationModel()
                          {

                              stateID = drRow.Field<int>("stateID"),
                              stateDescription = drRow.Field<string>("stateDescription"),
                              locationID  = drRow.Field<int>("locationID"),
                              selectedCity = drRow.Field<cityModel>("selectedCity"),
                              cities = drRow.Field<List<cityModel>>("cities")

                          }).ToList();

            return cities;
        }

        ///<summary>
        ///The end of the GetLocation method 
        /// </summary>


        ///<summary>
        ///the begining of the getliststates method 
        /// </summary>
        public SelectList GetListStates()
        {
            // Readies stored proc from server.
            DbCommand GetStates = db.GetStoredProcCommand("sp_GetStates");

            //gets all states from the database
            // Executes stored proc to return values into a DataSet.
            DataSet ds = db.ExecuteDataSet(GetStates);

            var states = (from drRow in ds.Tables[0].AsEnumerable()
                          select new SelectListItem()
                          {

                              Value = drRow.Field<int>("stateID").ToString(),
                              Text = drRow.Field<string>("stateDescription"),

                          }).ToList();

            return new SelectList(states, "Value", "Text");
        }

        public List<companyModel> GetListCompanies(string companyInput)
        {
            // Readies stored proc from server.
            DbCommand GetCompanies = db.GetStoredProcCommand("sp_GetCompany");

            db.AddInParameter(GetCompanies, "@companyName", DbType.String, companyInput);

            //gets all states from the database
            // Executes stored proc to return values into a DataSet.
            DataSet ds = db.ExecuteDataSet(GetCompanies);

            var companies = (from drRow in ds.Tables[0].AsEnumerable()
                          select new companyModel()
                          {

                              companyName = drRow.Field<string>("companyName"),
                              companyDescription = drRow.Field<string>("companyDescription")

                          }).ToList();

            return companies;
        }

        ///<summary>
        ///The end of the GetListStates method 
        /// </summary>

        ///<summary>
        ///The beginning of the GetListCities method that gets all the cities relating to the state selected
        /// </summary>
        public List<cityModel> GetListCities(int cityID)
        {
            // Readies stored proc from server.
            DbCommand GetCities = db.GetStoredProcCommand("sp_GetCities");

            db.AddInParameter(GetCities, "@cityID", DbType.String, cityID);

            // Executes stored proc to return values into a DataSet.
            DataSet ds = db.ExecuteDataSet(GetCities);

            var cities = (from drRow in ds.Tables[0].AsEnumerable()
                          select new cityModel()
                          {

                              cityID = drRow.Field<int>("cityID"),
                              cityDescription = drRow.Field<string>("cityDescription"),

                          }).ToList();

            return cities;
        }

        //beginning of the methods to send a request from a user to a company
        public List<userCompanyRequestModel> sendRequestToCompany(string companyName)
        {
            DbCommand sendRequest = db.GetStoredProcCommand("sp_makeRequest");

            db.AddInParameter(sendRequest, "@companyName", DbType.String, companyName);

            DataSet ds = db.ExecuteDataSet(sendRequest);

            var requests = (from drRow in ds.Tables[0].AsEnumerable()
                          select new userCompanyRequestModel()
                          {

                              userID= drRow.Field<int>("userID"),
                              firstName = drRow.Field<string>("firstName"),
                              lastName = drRow.Field<string>("lastName"),
                              emailAddress = drRow.Field<string>("emailAddress")

                          }).ToList();

            return requests;
        }

        //reads all requests for a certain company 
        public List<userCompanyRequestModel> getRequestsToCompany(string companyName)
        {
            DbCommand getRequests = db.GetStoredProcCommand("sp_getRequests");

            db.AddInParameter(getRequests, "@companyName", DbType.String, companyName);

            DataSet ds = db.ExecuteDataSet(getRequests);

            var requests = (from drRow in ds.Tables[0].AsEnumerable()
                            select new userCompanyRequestModel()
                            {

                                userID = drRow.Field<int>("userID"),
                                firstName = drRow.Field<string>("firstName"),
                                lastName = drRow.Field<string>("lastName"),
                                emailAddress = drRow.Field<string>("emailAddress")

                            }).ToList();

            return requests;
        }


        ///<summary>
        ///The end of the GetListCities method
        /// </summary>



        ///Create Procedure Data Controller

        //public int createGeoLocationCity(geoLocationModel currentLocation)
        //{
        //    int success;

        //    try
        //    {
        //        DbCommand sp_createct2GeoLocationCity = db.GetStoredProcCommand("sp_createct2GeoLocationCity");
        //        sp_createct2GeoLocationCity.Connection = db.CreateConnection();
        //        sp_createct2GeoLocationCity.Connection.Open();


        //        foreach (cityModel city in currentLocation.cities)
        //        {
        //            db.AddInParameter(sp_createct2GeoLocationCity, "@cityDescription", SqlDbType.VarChar, city.cityDescription);
        //            db.AddInParameter(sp_createct2GeoLocationCity, "@stateIDFK", SqlDbType.VarChar, currentLocation.stateID);

        //            success = sp_createct2GeoLocationCity.ExecuteNonQuery();

        //        }

        //        return 1;
        //    }
        //    catch(Exception ex)
        //    {
        //        return 0;
        //    }

        //}

        //public int createGeoLocationState(geoLocationModel currentLocation)
        //{
        //    int stateID = 0;
        //    int cityID = 0;

        //    DbCommand sp_createct2GeoLocationState = db.GetStoredProcCommand("sp_createct2GeoLocationState");
        //    sp_createct2GeoLocationState.Connection = db.CreateConnection();
        //    sp_createct2GeoLocationState.Connection.Open();

        //    db.AddInParameter(sp_createct2GeoLocationState, "@stateDescription", SqlDbType.VarChar, currentLocation.stateDescription);

        //    stateID = sp_createct2GeoLocationState.ExecuteNonQuery();

        //    if (stateID == 0 )
        //    {
        //        // do nothing
        //    }
        //    else
        //    {
        //        currentLocation.stateID = stateID;
        //        cityID = createGeoLocationCity(currentLocation);
        //    }

        //    return stateID;

        //}

        /////Update Procedure Data Controller

        //public bool UpdateCity(cityModel currentCity)
        //{
        //    DbCommand sp_updatect2GeoLocationCity = db.GetStoredProcCommand("sp_updatect2GeoLocationCity");

        //    db.AddInParameter(sp_updatect2GeoLocationCity, "@cityID", SqlDbType.Int, currentCity.cityID);
        //    db.AddInParameter(sp_updatect2GeoLocationCity, "@cityDescription", SqlDbType.VarChar, currentCity.cityDescription);

        //    return false;
        //}

        //public bool UpdateState(geoLocationModel currentState)
        //{
        //    DbCommand sp_updatect2GeoLocationState = db.GetStoredProcCommand("sp_updatect2GeoLocationState");

        //    db.AddInParameter(sp_updatect2GeoLocationState, "@stateID", SqlDbType.Int, currentState.stateID);
        //    db.AddInParameter(sp_updatect2GeoLocationState, "@stateDescription", SqlDbType.VarChar, currentState.stateDescription);

        //    return false;
        //}

        ///// Delete Procedure Data Controller

        //public bool DeleteCity(cityModel removingCity)
        //{
        //    DbCommand sp_deletect2GeoLocationCity = db.GetStoredProcCommand("sp_deletect2GeoLocationCity");

        //    db.AddInParameter(sp_deletect2GeoLocationCity, "@cityID", SqlDbType.Int, removingCity.cityID);
        //    db.AddOutParameter(sp_deletect2GeoLocationCity, "@success", SqlDbType.Int, 1);

        //    bool success;
        //    try
        //    {
        //        db.ExecuteNonQuery(sp_deletect2GeoLocationCity);
        //        success = Convert.ToBoolean(db.GetParameterValue(sp_deletect2GeoLocationCity, "@success"));
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        throw;
        //    }

        //    return success;
        //}




        //public bool DeleteState(geoLocationModel removingState)
        //{
        //    DbCommand sp_deletect2GeoLocationState = db.GetStoredProcCommand("sp_deletect2GeoLocationState");

        //    db.AddInParameter(sp_deletect2GeoLocationState, "@stateID", SqlDbType.Int, removingState.stateID);

        //    return false;

        //}

    }
}