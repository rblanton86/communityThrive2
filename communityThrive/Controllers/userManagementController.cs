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

        /// <summary>
        /// begining of the user request to join a company methods.
        /// </summary>

        public ActionResult sendRequest()
        {
            return View();
        }

        public ActionResult sendRequestYes()
        {
            //perform this action if the user wants to join a company
            return Redirect("~/UserManagement/companyChoice");

        }

        public ActionResult sendRequestNo()
        {
            //perform this action if a user does not want to join a company 
            return Redirect("~/Home/Index");

        }

        public ActionResult companyChoice()
        {
            
            return View();
        }

        /// <summary>
        /// end of the user request to join a company methods.
        /// </summary>


    }

}
