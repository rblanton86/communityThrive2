using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Web.Mvc;
using System.Web.Configuration;

using communityThrive2.Models;

namespace communityThrive2.Controllers.DataControllers
{
    public class ct2ReceiptDataController
    {
        public static SqlDatabase db;

        public ct2ReceiptDataController()
        {

            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["ctConnectionString"].ToString());
            }
        }

        public List<receiptModel> GetListReceipts()
        {
            DbCommand sp_readCt2Receipt = db.GetStoredProcCommand("sp_ReadCt2Receipt");

            DataSet ds = db.ExecuteDataSet(sp_readCt2Receipt);

            var receipts = (from drRow in ds.Tables[0].AsEnumerable()
                            select new receiptModel
                            {

                                receiptID = drRow.Field<int>("receiptID"),
                                user = drRow.Field<userModel>("user"),
                                userIDFK = drRow.Field<int>("userIDFK"),
                                donationIDFK = drRow.Field<int>("donationIDFK"),
                                donation = drRow.Field<donationModel>("donation")



                            }).ToList();

            return receipts;
        }

        /// Create Procedure Data Controller
        
        public int createReceipt(receiptModel currentReceipt)
        {
            int success;

            DbCommand sp_CreateCt2Receipt = db.GetStoredProcCommand("sp_CreateCt2Receipt");

            db.AddInParameter(sp_CreateCt2Receipt, "@receiptID", SqlDbType.Int, currentReceipt.receiptID);

            success = sp_CreateCt2Receipt.ExecuteNonQuery();

            return success;
        } 

        /// Delete Procedure Data Controller
        public int deleteReceipt(receiptModel currentReceipt)
        {
            int success;

            DbCommand sp_DeleteCt2Receipt = db.GetStoredProcCommand("sp_DeleteCt2Receipt");

            db.AddInParameter(sp_DeleteCt2Receipt, "@receiptID", SqlDbType.Int, currentReceipt.receiptID);

            success = sp_DeleteCt2Receipt.ExecuteNonQuery();

            return success;
        }

    }
}