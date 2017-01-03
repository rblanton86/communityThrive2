using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using communityThrive2.Models;

/*============================================= 
Description: Data Controller, all CRUD's, for EVENT
Author: Alejandro Castillo   
Date: 12/15/2016
Change History: created 1:11 12/15/16  
=============================================*/
namespace communityThrive2.Controllers.DataControllers
{
    public class ct2EventDataController
    {
        public static SqlDatabase db;


        //public ct2EventDataController()
        //{
        //    if (db == null)
        //    {
        //        db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["communityThriveConnectionString"].ToString());
        //    }
        //}
        public ct2EventDataController(string connectionString)
        {
            if (connectionString.Length > 0)
            {
                if (db == null)
                {
                    db = new SqlDatabase(connectionString);
                }
            }
            else
            {
                if (db == null)
                {
                    db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["connectionString"].ToString());
                }
            }
        }

        //CRUD FOR EVENT ENTITY
        public DataSet Get_ListEvent(eventModel currentEvent)
        {//~~~~~~~~~ READ EVENT
            DbCommand get_Event = db.GetStoredProcCommand("sp_readEvent");

            db.AddInParameter(get_Event, "@eventID", DbType.Int32, currentEvent.eventID);

            DataSet ds = db.ExecuteDataSet(get_Event);

            return ds;//RETURNS DATA SET FOR EVENT
        }
        public Boolean Create_ListEvent(eventModel currentEvent)
        {//~~~~~~~~~ CREATE EVENT
            Boolean success = false;

            DbCommand Create_Event = db.GetStoredProcCommand("sp_CreateEvent");
            db.AddInParameter(Create_Event, "@eventID", DbType.Int32, currentEvent.eventID);
            db.AddInParameter(Create_Event, "@eventDescription", DbType.String, currentEvent.eventDescription);
            db.AddInParameter(Create_Event, "@eventTypeIDFK", DbType.Int32,currentEvent.eventTypeIDFK);
            db.AddInParameter(Create_Event, "@eventTypeDescription", DbType.String,currentEvent.eventTypeDescription);
            db.AddInParameter(Create_Event, "@eventDesignation", DbType.String,currentEvent.eventDesignation);

            success = Convert.ToBoolean(Create_Event.ExecuteNonQuery());


            return success;//RETURNS IF PROCEDURE WAS A SUCCESS
        }

    
        public Boolean Update_ListEvent(eventModel currentEvent)
        {//~~~~~~~~~ UPDATE EVENT
            Boolean success = false;

            DbCommand Update_Event = db.GetStoredProcCommand("sp_UpdateEvent");
            db.AddInParameter(Update_Event, "@eventID", DbType.Int32, currentEvent.eventID);
            db.AddInParameter(Update_Event, "@eventDescription", DbType.String, currentEvent.eventDescription);
            db.AddInParameter(Update_Event, "@eventTypeIDFK", DbType.Int32, currentEvent.eventTypeIDFK);
            db.AddInParameter(Update_Event, "@eventTypeDescription", DbType.String, currentEvent.eventTypeDescription);
            db.AddInParameter(Update_Event, "@eventDesignation", DbType.String, currentEvent.eventDesignation);

            success = Convert.ToBoolean(Update_Event.ExecuteNonQuery());

            
            return success;//RETURNS SUCCESS IF PROCEDURE WAS PASSED THROUGH
        }
        public Boolean Delete_ListEvent (eventModel currentEvent)
        {//~~~~~~~~~ DELETE EVENT
            Boolean success = false;

            DbCommand Delete_Event = db.GetStoredProcCommand("sp_DeleteEvent");
            db.AddInParameter(Delete_Event, "@eventID", DbType.Int32, currentEvent.eventID);
            DataSet ds = db.ExecuteDataSet(Delete_Event);

            success = Convert.ToBoolean(Delete_Event.ExecuteNonQuery());


            return success;//REUTNRS IF EVENT WAS DELETED SUCCESSFULLYS
        }
    }
}