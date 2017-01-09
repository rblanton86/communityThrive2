using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Web;
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveCompany()
        {
            companyModel model = new companyModel();
            byte[] byteArray = null;

            foreach (string upload in Request.Files)
            {
                
                string filename = Request.Files[upload].FileName;
                BinaryReader binaryReader = new BinaryReader(Request.Files[upload].InputStream);
                byteArray = binaryReader.ReadBytes((Request.Files[upload].ContentLength));
                
            }

            cityModel companyCity = new cityModel();
            companyCity.cityID = 1;
            companyCity.cityDescription = "Dallas";
            model.companyLocation = companyLocation;
            model.companyName = Request.Form["companyName"];
            model.companyDescription = Request.Form["companyDescription"];
            model.companyDemographic = Request.Form["companyDemographic"];
            model.companyLogo = byteArray;
            model.companyLocation = companyLocation;

            ct2CompanyDataController companyDC = new ct2CompanyDataController("");
            companyDC.CreateCompany(model);

            companyDC.insertCompanyLogo(model);



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

            public ActionResult CompanyHome()
            {
            return View();
            }
        }
}