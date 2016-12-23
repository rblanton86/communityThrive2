using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using communityThrive2.DataControllers;
using communityThrive2.Models;

namespace communityThrive2.Controllers
{
    public class userManagementController : Controller
    {
        // GET: userLogin
        public ActionResult userLogin()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(ct2UserDataController currentUser)
        { 
             
            if(currentUser == null) 
            { 
                return RedirectToAction("LoggedIn");
            }
            else
            {
                return View("userLogin");
            }


        }


    } 
    
}
