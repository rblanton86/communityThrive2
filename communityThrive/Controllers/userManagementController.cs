using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;
using communityThrive2.Controllers.DataControllers;
using communityThrive2.Models;
using System.Web.Script.Serialization;

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
          
            return LoggedIn(currentUser);
           
        }
        /// <summary>
        /// if user login is not in the system return back to current view if not continue logging in
        /// </summary>

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
            usMod.userPassword = form["currentModel.userPassword"].ToString();

            //companyIDFK
            //roleIDFK
            //userAddress
            //userTypeIDFK

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


        //most likely soon to change due to adding of the zipcode feature into the mix 
        public ActionResult companyChoice()
        {
            //ViewBag.stateModel = companyChoicePopulateState();
            return View();
        }

        [HttpPost]
        public ActionResult companyChoice(string userinput)
        {
            ct2GeoLocationDataController gldc = new ct2GeoLocationDataController("DefaultConnection");

            List<companyModel> compmod = gldc.GetListCompanies(userinput);
            //add a method from gldc to search for the zipcode the user entered, need to make data controller to handle these actions as well as stored proc
            //insert below the dazta that needs to be submitted
            return View(compmod);
        }

        //public ActionResult chosenCompany()
        //{
        //    return View();
        //}

        public ActionResult chosenCompany(string companyName)
        {
            ct2GeoLocationDataController gldc = new ct2GeoLocationDataController("DefaultConnection");

            List<companyModel> compmod2 = gldc.GetListCompanies(companyName);

            return View(compmod2);
        }

        public ActionResult finalChosenCompany(string companyName)
        {
            //write code to send and store user request to company here
            //make a data controller to send the request to the database
            //make a page to display requests for the company 
            //allow the company to assign privilidges for the user
            //need to make a database table to store the requests and then display them to the company 

            return null;
        }

        //public SelectList companyChoicePopulateState()
        //{
        //    SelectList stateModel;

        //    ct2GeoLocationDataController gldc = new ct2GeoLocationDataController("DefaultConnection");

        //    stateModel = gldc.GetListStates();

        //    return new SelectList(stateModel, "Value", "Text");

        //}

        //public ActionResult googlezipcode()
        //{
        //    var mvcName = typeof(Controller).Assembly.GetName();
        //    var isMono = Type.GetType("Mono.Runtime") != null;

        //    ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
        //    ViewData["Runtime"] = isMono ? "Mono" : ".NET";

        //    var googleLocation = GEOCodeAddress("76051");

        //    googleLocation = ViewBag.googleloc;

        //    return View();
        //}

        //public static dynamic GEOCodeAddress(String Address)
        //{
        //    var address = String.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false", Address.Replace(" ", "+"));
        //    var result = new System.Net.WebClient().DownloadString(address);
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    return jss.Deserialize<dynamic>(result);
        //}



        /// <summary>
        /// end of the user request to join a company methods.
        /// </summary>


    }

}
