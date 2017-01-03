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
Description: Data Controller, all CRUD's, for INVENTORYS
Author: Alejandro Castillo   
Date: 12/15/2016
Change History: created 1:11 12/15/16  
=============================================*/
namespace communityThrive2.Controllers.DataControllers
{
    public class ct2InventoryDataController
    {
        public static SqlDatabase db;


        //public ct2InventoryDataController()
        //{
        //    if (db == null)
        //    {
        //        db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["communityThriveConnectionString"].ToString());
        //    }
        //}


        public ct2InventoryDataController(string connectionString)
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


        //CRUD FOR INVENTORY ENTITY
        public DataSet Get_ListInventory(inventoryModel currentInventory)
        {//~~~~~~~~~ READ INVENTORY
            DbCommand get_Inventory = db.GetStoredProcCommand("sp_readInventory");

            db.AddInParameter(get_Inventory, "@itemID", DbType.Int32, currentInventory.inventoryID);

            DataSet ds = db.ExecuteDataSet(get_Inventory);

            return ds;//RETURNS DATASET TO READ
        }
        public Boolean Create_ListInventory(inventoryModel currentInventory)
        {//~~~~~~~~~ CREATE INVENTORY 
            Boolean success = false;

            DbCommand Create_Inventory = db.GetStoredProcCommand("sp_CreateInventory");
            db.AddInParameter(Create_Inventory, "@inventoryID", DbType.Int32, currentInventory.inventoryID);
            db.AddInParameter(Create_Inventory, "@donationIDFK", DbType.Int32, currentInventory.donationIDFK);
            db.AddInParameter(Create_Inventory, "@categoryIDFK", DbType.String, currentInventory.categoryIDFK);
            db.AddInParameter(Create_Inventory, "@inventoryQuantity", DbType.Int32, currentInventory.inventoryQuantity);
            db.AddInParameter(Create_Inventory, "@inventoryDescription", DbType.String, currentInventory.inventoryDescription);

            success = Convert.ToBoolean(Create_Inventory.ExecuteNonQuery());


            return success;//RETURNS IF OPERATION WAS A SUCCESS
        }


        public Boolean Update_ListInventory(inventoryModel currentInventory)
        {////~~~~~~~~~ UPDATE INVENTORY 
            Boolean success = false;

            DbCommand Update_Inventory = db.GetStoredProcCommand("sp_UpdateInventoryItem");
            db.AddInParameter(Update_Inventory, "@donationIDFK", DbType.Int32, currentInventory.donationIDFK);
            db.AddInParameter(Update_Inventory, "@categoryIDFK", DbType.String, currentInventory.categoryIDFK);
            db.AddInParameter(Update_Inventory, "@inventoryQuantity", DbType.Int32, currentInventory.inventoryQuantity);
            db.AddInParameter(Update_Inventory, "@inventoryDescription", DbType.String, currentInventory.inventoryDescription);

            success = Convert.ToBoolean(Update_Inventory.ExecuteNonQuery());


            return success;//RETURNS IF OPERATION WAS A SUCCESS
        }
        public Boolean Delete_ListInventory(inventoryModel currentEvent)
        {//~~~~~~~~~ DELETE INVENTORY
            Boolean success = false;

            DbCommand Delete_Inventory = db.GetStoredProcCommand("sp_DeleteInventoryItem");

            db.AddInParameter(Delete_Inventory, "@inventoryID", DbType.Int32, currentEvent.inventoryID);

            DataSet ds = db.ExecuteDataSet(Delete_Inventory);
            //RETURNS IF OPERATION WAS A SUCCESS
            success = Convert.ToBoolean(Delete_Inventory.ExecuteNonQuery());


            return success;
        }
    }
}