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
    public class ct2RoleDataController
    {
        public static SqlDatabase db;


        public ct2RoleDataController()
        {
            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["ctConnectionString"].ToString());
            }
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

    }
}