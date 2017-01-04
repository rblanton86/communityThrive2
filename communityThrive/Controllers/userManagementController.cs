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

        public ActionResult sendRequest()
        {

            //this happens after alejandros user creation if they dont want to create a company they are routed here
            return View();
        }

        public ActionResult sendRequestNo()
        {
            //perform this action if a user does not want to join a company 
            return Redirect("~/Home/Index");

        }

        public ActionResult companyChoice()
        {
            ViewBag.stateModel = companyChoicePopulateState();
            //ViewBag.cityModel = companyChoicePopulateCity();

            return View();
        }

        public SelectList companyChoicePopulateState()
        {

            SelectList stateModel;

            ct2GeoLocationDataController gldc = new ct2GeoLocationDataController("DefaultConnection");

            stateModel = gldc.GetListStates();

            return new SelectList(stateModel,"Value","Text");
        }

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
