using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using communityThrive2.Models.communityThriveDeploymentModels;



namespace communityThrive2.Controllers.DataControllers
{
    public class ct2GeoLocationDataController
    {
        public static SqlDatabase db;


        public ct2GeoLocationDataController(string connectionstring)
        {
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
                    db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["ctConnectionString"].ToString());
                }
            }
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
            // Readies stored proc from server.
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
            catch(Exception ex)
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

            if (stateID == 0 )
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

    }
}