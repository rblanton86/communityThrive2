using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using communityThrive2.DataControllers;
using System.Web.Mvc;
using communityThrive2.Models;

namespace communityThrive2.Controllers
{
    public class userCommunityController : Controller
    {
        // GET: userHome
        public ActionResult userHome()
        {

            return View();
        }
    }
}