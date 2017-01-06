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
        public ActionResult Login(loginModel loginCredentials)
        {
            //    ////create an instance of the user
             userModel currentUser = new userModel();
            //    ////create instance of userDataController
            ct2UserDataController userDataController = new ct2UserDataController("");

            //    ////send login credentials to userDataController and set returned user to our current instance
            currentUser = userDataController.GetLogin(loginCredentials);
            //    ////call LoggedIn
            //LoggedIn(currentUser);

            //return RedirectToAction("userHome", "userCommunity");

            //if (currentUser == null)
            //{
            //    return View("userLogin");
            //}
            //else if (currentUser.companyIDFK > 0)

            //{
            //    return RedirectToAction("companyHome");  
            //}
            //else
            //{
            return RedirectToAction("userHome", "userCommunity");
            //}
            //userCommunityController ucController = new userCommunityController();

            //return ucController.userHome();
        }

        /// <summary>
        /// if user login is not in the system return back to current view if not continue logging in
        /// </summary>

        [HttpPost]
        public ActionResult LoggedIn(userModel currentUser)
        {

            if (currentUser == null)
            {
                return View("userLogin");
            }
            else if (currentUser.companyIDFK > 0)

            {
                return RedirectToAction("companyHome");  // switch ifs
                //determine if current user belongs to a company

                //if user doesn't belong to a company send user to userHome

                //if user does belong to a company send user to companyHome
            }
            else
            {
                return RedirectToAction("userHome", "userCommunity");
            }

        }

        /*
        * Begin User Creation
        * */
        //GET:/UserManagement/userRegister

        public ActionResult userRegister(ct2UserDataController CreateUser)
        {
            return View();
        }
        //POST: /UserManagement/userRegister
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            userModel usMod = new userModel();
            roleModel roMod = new roleModel();
            companyModel compModel = new companyModel();
            geoLocationModel geoLoca = new geoLocationModel();
            cityModel citMod = new cityModel();

            usMod.firstName = form["firstName"];
            usMod.lastName = form["lastName"];
            usMod.emailAddress = form["emailAddress"];
            usMod.streetAddress = form["streetAddress"];
            citMod.cityDescription = form["cityIDFK"];
            geoLoca.stateDescription = form["stateIDFK"];
            usMod.zipcode = Convert.ToInt32(form["zipcode"]);

            return View();
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
