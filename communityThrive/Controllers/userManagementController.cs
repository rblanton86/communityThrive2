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

        //[HttpPost]
        //public ActionResult Login(loginModel login)
        //{
        //    string email = login.emailAddress;
        //    string password = login.userPassword;

        //    return View(login);
        //}

        /// <summary>
        /// if user login is in the system, continue logging in if not return back to current view
        /// </summary>

        [HttpPost]
        public ActionResult LoggedIn(ct2UserDataController currentUser)
        {

            if (currentUser == null)
            {
                return RedirectToAction("userLoginChoice");
            }
            else
            {
                return View("userLogin");
            }

        }

        public ActionResult userLoginChoice()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult LogInChoice()
        {
            //if ()
            //{
            //    return RedirectToAction("Company Homepage");
            //}

            //else
            //{
            //    return RedirectToAction("Manage Company");
            //}

            return View();
        }

        /*
        * Begin User Creation
        * */
        //GET:/UserManagement/userRegister

        public ActionResult userRegister()
        {
            
            return View();
        }


        //POST: /UserManagement/userRegister
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            userModel usMod = new userModel();
            ct2UserDataController inputCurrentUser = new ct2UserDataController("");


            usMod.firstName = form["currentModel.firstName"];
            usMod.lastName = form["currentModel.lastName"].ToString();
            usMod.phoneNumber =form["currentModel.phoneNumber"].ToString();
            usMod.emailAddress = form["currentModel.emailAddress"].ToString();
            usMod.streetAddress = form["currentModel.streetAddress"].ToString();
            //citMod.cityIDFK = form["cityIDFK"];
            //geoLoca.stateDescription = form["stateIDFK"];
            usMod.zipcode = Convert.ToInt32(form["currentModel.zipcode"].ToString());
            usMod.userPassword = form["currentModel.userPassword"].ToString();

            usMod = inputCurrentUser.CreateUser(usMod);

            return Redirect("~/companyChoice/userManagement");
                
        }

       

        ///<summary>
        /// ending of user register form
        /// </summary>
                
        /// <summary>
        /// begining of the user request to join a company methods.
        /// </summary>

        public ActionResult sendRequest()
        {

            //this happens after alejandros user creation if they dont want to create a company they are routed here
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
