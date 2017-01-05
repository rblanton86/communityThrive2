using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using communityThrive2.Controllers.DataControllers;
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

        //This is the user selection if they would like to join a company //sendRequest View//
        public ActionResult sendRequest()
        {

            //this happens after alejandros user creation if they dont want to create a company they are routed here
            return View();
        }

        //This action is performed if the user selects they do not want to join a company
        public ActionResult sendRequestNo()
        {
            //re-routes the user to the home page because they cant preform any other actions
            return Redirect("~/Home/Index");

        }

        //this is the selection where the user finds the company they wish to send a requets too
        public ActionResult companyChoice()
        {
            ViewBag.stateModel = companyChoicePopulateState();
            //ViewBag.cityModel = companyChoicePopulateCity();

            return View();
        }

        //this method populates the state list for the companyChoice view
        public SelectList companyChoicePopulateState()
        {

            SelectList stateModel;

            ct2GeoLocationDataController gldc = new ct2GeoLocationDataController("DefaultConnection");

            stateModel = gldc.GetListStates();

            return new SelectList(stateModel,"Value","Text");
        }

        //this method populates the city table based on the state selected
        //public SelectList companyChoicePopulateCity()
        //{

        //    SelectList cityModel;

        //    ct2GeoLocationDataController gldc = new ct2GeoLocationDataController("DefaultConnection");

        //    cityModel = gldc.GetListCities();

        //    return new SelectList(cityModel, "cityID", "cityDescription");
        //}



        /// <summary>
        /// end of the user request to join a company methods.
        /// </summary>


    }

}
