using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using communityThrive2.Models;

namespace communityThrive2.Controllers.DataControllers
{
    public class ct2CompanyDataController
    {
        public static SqlDatabase db;

        public ct2CompanyDataController(string connectionstring)
        {
            if (connectionstring.Length > 0)
            {
                db = new SqlDatabase(connectionstring);
            }
            else
            {
                if (db == null)
                {
                    db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                }
            }
        }
        public companyModel CreateCompany(companyModel currentCompany)
        {
            ///uses create procedure to insert values into the model parameters
            DbCommand create_Company = db.GetStoredProcCommand("sp_createct2Company");
            db.AddInParameter(create_Company, "@companyID", DbType.Int32, currentCompany.companyID);
            db.AddInParameter(create_Company, "@companyName", DbType.String, currentCompany.companyName);
            db.AddInParameter(create_Company, "@stateID", DbType.Int32, currentCompany.companyLocation.stateID);
            db.AddInParameter(create_Company, "@cityID", DbType.Int32, currentCompany.companyLocation.selectedCity.cityID);
            db.AddInParameter(create_Company, "@companyDemographic", DbType.Int32, currentCompany.companyDemographic);
            return currentCompany;
        }


        public List<companyModel> GetListCompanies()
        {
            ///uses read procedure by primary ID and returns corresponding values
            DbCommand get_Company = db.GetStoredProcCommand("sp_selectct2Company");
            db.AddInParameter(get_Company, "@companyID", DbType.Int32);
            DataSet ds = db.ExecuteDataSet(get_Company);

            var companyData = (from drRow in ds.Tables[0].AsEnumerable()
                               select new companyModel()
                               {
                                   companyID = drRow.Field<int>("companyID"),
                                   companyName = drRow.Field<string>("companyName"),
                                   companyDescription = drRow.Field<string>("companyDescription"),
                                   //companyLocation = drRow.Field<geoLocationModel>("stateID"),
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
            db.AddInParameter(update_Company, "@stateID", DbType.Int32, selectedCompany.companyLocation.stateID);
            db.AddInParameter(update_Company, "@cityID", DbType.Int32, selectedCompany.companyLocation.selectedCity.cityID);
            db.AddInParameter(update_Company, "@companyDemographic", DbType.String, selectedCompany.companyDemographic);

            success = Convert.ToBoolean(update_Company.ExecuteNonQuery());


            return success;
        }
        public bool DeleteCompany(companyModel deleteCompany)
        {
            ///uses delete procedure to remove list and all its values by the primary ID
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getCompanyLogo"></param>
        /// <returns></returns>
        public byte[] getCompanyLogo(companyModel getCompanyLogo)
        {
            byte[] image;
            ///uses read procedure to get company logo
            DbCommand get_CompanyLogo = db.GetStoredProcCommand("sp_readCt2CompanyLogo");

            db.AddInParameter(get_CompanyLogo, "@companyLogo", DbType.Binary, getCompanyLogo.companyLogo);

            image = (byte[])get_CompanyLogo.ExecuteScalar();

            return image;
          
        }

        public bool insertCompanyLogo(companyModel currentCompany)
        {
            bool success = false;

            DbCommand insert_CompanyLogo = db.GetStoredProcCommand("sp_createCt2CompanyLogo");

            db.AddInParameter(insert_CompanyLogo, "@companyIDFK", DbType.Int32, currentCompany.companyID);
            db.AddInParameter(insert_CompanyLogo, "@companyLogo", DbType.Binary, currentCompany.companyLogo);

            if(db.ExecuteNonQuery(insert_CompanyLogo)>0)
            {
                success = true;
            }
            else { success = false; }

            return success;
        }
    }
}