using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using communityThrive2.Models;
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

            return View();
                        
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        
    }
}