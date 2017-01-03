using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Windows;
using communityThrive2.Models;

namespace communityThrive2.Controllers
{
    public class CompanyController : Controller
        
    {
        // GET: Company
        public ActionResult ManageCompany()
        {
            return View();
        }
    }
}