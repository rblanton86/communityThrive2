using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using communityThrive2.Models;
using communityThrive2.Models.communityThriveModels;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.Entity;
using communityThrive2.DataControllers;

namespace communityThrive2.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            contentDataController itemContentDC = new contentDataController();

            //itemContentDC.createCategory(1,"square boxes",true,false);
            //itemContentDC.createCategory(1, "round boxes", true, false);
            //itemContentDC.createCategory(1, "empty boxes", true, false);
            //itemContentDC.createCategory(2, "full boxes", true, false);

            return View();

            
        }
        public ActionResult BasicLayout()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult About(string userInput)
        {

            int userinputz = Convert.ToInt32(userInput);

            contentDataController itemContentDC = new contentDataController();

            //List<companyModel> itemDataList = itemContentDC.readItem(userinputz);

            return View();

        }



        public ActionResult Contact()
        {
            return View();
        }
    }
}