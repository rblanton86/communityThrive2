using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Windows;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using communityThrive2.Controllers.DataControllers;
using communityThrive2.Models;

namespace communityThrive2.Controllers
{
    public class CompanyController : Controller

    {
            public ActionResult CreateCompany()
            {

            return View();
            }
                
            public ActionResult SaveCompany(companyModel model)
        {

            cityModel companyCity = new cityModel();
            companyCity.cityID = 1;
            companyCity.cityDescription = "Dallas";

            List<cityModel> companyCities = new List<cityModel>();
            companyCities.Add(companyCity);
            
            geoLocationModel companyLocation = new geoLocationModel();
            companyLocation.locationID = 1;
            companyLocation.stateID = 1;
            companyLocation.stateDescription = "Texas";
            companyLocation.cities = companyCities;
            companyLocation.selectedCity = companyCity;

            model.companyLocation = companyLocation;

            ct2CompanyDataController companyDC = new ct2CompanyDataController("");
            companyDC.CreateCompany(model);

            return View(model);
        }

            // GET: Company
            public ActionResult ManageCompany(companyModel company)
            {

                return View(company);
            }
            public ActionResult Save(companyModel model)
            {

                return Json("Success");
            }
        }
}