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
    public class ct2StockDataController
    {
        public static SqlDatabase db;


        public ct2StockDataController()
        {
            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["ctConnectionString"].ToString());
            }
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