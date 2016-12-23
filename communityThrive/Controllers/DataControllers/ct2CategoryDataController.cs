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
    public class ct2CategoryDataController
    {
        public static SqlDatabase db;

        public ct2CategoryDataController(string connectionString)
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
                    db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["ctConnectionString"].ToString());
                }
            }
        }

        /// Matt Spezia
        /// 12/15/2016
        /// Read procedure Data Controller
        

        public List<categoryModel> GetListCategories()
        {
            DbCommand sp_readCt2Category = db.GetStoredProcCommand("sp_readCt2Category");

            DataSet ds = db.ExecuteDataSet(sp_readCt2Category);

            var categories = (from drRow in ds.Tables[0].AsEnumerable()
                              select new categoryModel
                              {

                                  categoryID = drRow.Field<int>("categoryID"),
                                  dateAdded = drRow.Field<DateTime>("dateAdded"),
                                  categoryParentID = drRow.Field<int>("parentID"),
                                  isUserDefined = drRow.Field<bool>("isUserDefined"),
                                  isDeleted = drRow.Field<bool>("isDeleted"),
                                  categoryDescription = drRow.Field<string>("descripton"),


                              }).ToList();

            return categories;
        }

        /// Create Procedure Data Controller
        public int createCategory(categoryModel currentCategory)
        {
            int success = 0;

            DbCommand sp_ct2CreateCategory = db.GetStoredProcCommand("sp_Createct2Category");
            sp_ct2CreateCategory.Connection = db.CreateConnection();
            sp_ct2CreateCategory.Connection.Open();

            
            db.AddInParameter(sp_ct2CreateCategory, "@categoryParentID", SqlDbType.Int, currentCategory.categoryParentID);
            db.AddInParameter(sp_ct2CreateCategory, "@isUserDefined", SqlDbType.Bit, currentCategory.isUserDefined);
            db.AddInParameter(sp_ct2CreateCategory, "@isDeleted", SqlDbType.Bit, currentCategory.isDeleted);
            db.AddInParameter(sp_ct2CreateCategory, "@dateAdded", SqlDbType.DateTime, currentCategory.dateAdded);
            db.AddInParameter(sp_ct2CreateCategory, "@categoryDescription", SqlDbType.VarChar, currentCategory.categoryDescription);




            //sp_ct2CreateCategory.Connection.;
            success = sp_ct2CreateCategory.ExecuteNonQuery();
            return success;

        }

        ///Delete Procedure Data Controller
        public int deleteCategory(categoryModel currentCategory)
        {
            int success;

            DbCommand sp_ct2DeleteCategory = db.GetStoredProcCommand("sp_ct2DeleteCategory");
            db.AddInParameter(sp_ct2DeleteCategory, "@categoryID", SqlDbType.Int, currentCategory.categoryID);

            success = sp_ct2DeleteCategory.ExecuteNonQuery();
            return success;
        }

        

}
}