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
Description: Data Controller, all CRUD's, for INVENTORYITEM
Author: Alejandro Castillo   
Date: 12/15/2016
Change History: created 1:11 12/15/16  
=============================================*/
namespace communityThrive2.Controllers.DataControllers
{
    public class ct2InventoryItemDataController
    {
        public static SqlDatabase db;


        //public ct2InventoryItemDataController()
        //{//Check is the database is empty or not. If empty will declare your database your connection. 
        //            if (db == null)
        //    {
        //        db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["communityThriveConnectionString"].ToString());
        //    }
        //}
        public ct2InventoryItemDataController(string connectionString)
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

        //Complete CRUD for inventoryItem Model
        public DataSet Get_ListInventoryItem(inventoryItemModel currentInventoryItem)
        {//~~~~~~~~~~~ READ INVENTORY ITEM
            DbCommand get_InventoryItem = db.GetStoredProcCommand("sp_readInventoryItem");

            db.AddInParameter(get_InventoryItem, "@itemID", DbType.Int32, currentInventoryItem.itemID);

            DataSet ds = db.ExecuteDataSet(get_InventoryItem);

            return ds; //RETURNS DATASET TO READ
            
        }
        public Boolean Create_ListInventoryItem(inventoryItemModel currentInventoryItem)
        {//~~~~~~~~~ CREATE INVENTORY ITEM
            Boolean success = false;

            DbCommand Create_InventoryItem = db.GetStoredProcCommand("sp_CreateInventoryItem");
            db.AddInParameter(Create_InventoryItem, "@inventoryIDFK", DbType.Int32, currentInventoryItem.inventoryIDFK);
            db.AddInParameter(Create_InventoryItem, "@categoryIDFK", DbType.Int32, currentInventoryItem.categoryIDFK);
            db.AddInParameter(Create_InventoryItem, "@itemName", DbType.String, currentInventoryItem.itemName);
            db.AddInParameter(Create_InventoryItem, "@itemPrice", DbType.Int32, currentInventoryItem.itemPrice);
            db.AddInParameter(Create_InventoryItem, "@itemDescription", DbType.String, currentInventoryItem.itemDescription);
            db.AddInParameter(Create_InventoryItem, "@itemUPC", DbType.Int32, currentInventoryItem.itemUPC);

            success = Convert.ToBoolean(Create_InventoryItem.ExecuteNonQuery());


            return success;//RETURNS IF COMPLETED CORRECTLY 
        }


        public Boolean Update_ListInventoryItem(inventoryItemModel currentInventoryItem)
        {//~~~~~~~~~ UPDATE INVENTORY ITEM
            Boolean success = false;

            DbCommand Update_InventoryItem = db.GetStoredProcCommand("sp_UpdateInventoryItem");
            db.AddInParameter(Update_InventoryItem, "@inventoryIDFK", DbType.Int32, currentInventoryItem.inventoryIDFK);
            db.AddInParameter(Update_InventoryItem, "@categoryIDFK", DbType.Int32, currentInventoryItem.categoryIDFK);
            db.AddInParameter(Update_InventoryItem, "@itemName", DbType.String, currentInventoryItem.itemName);
            db.AddInParameter(Update_InventoryItem, "@itemPrice", DbType.Int32, currentInventoryItem.itemPrice);
            db.AddInParameter(Update_InventoryItem, "@itemDescription", DbType.String, currentInventoryItem.itemDescription);
            db.AddInParameter(Update_InventoryItem, "@itemUPC", DbType.Int32, currentInventoryItem.itemUPC);

            success = Convert.ToBoolean(Update_InventoryItem.ExecuteNonQuery());


            return success;//RETURNS IF COMPLETED CORRECTLY 
        }
        public Boolean Delete_ListInventoryItem(inventoryItemModel currentEvent)
        {//~~~~~~~~~ DELETE INVENTORY ITEM
            Boolean success = false;

            DbCommand Delete_InventoryItem = db.GetStoredProcCommand("sp_DeleteInventoryItem");

            db.AddInParameter(Delete_InventoryItem, "@itemID", DbType.Int32, currentEvent.itemID);

            DataSet ds = db.ExecuteDataSet(Delete_InventoryItem);

            success = Convert.ToBoolean(Delete_InventoryItem.ExecuteNonQuery());


            return success;//RETURNS IF COMPLETED CORRECTLY 
        }
    }
}