using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using communityThrive2.Models;

namespace communityThrive2.Controllers
{
    public class RegisterUserController : Controller
    {
        // GET: RegisterUser
        //[HttpPost]
        public ActionResult userRegister()
        {
            userModel usMod = new userModel();
            roleModel roMod = new roleModel();
            companyModel compModel = new companyModel();
            geoLocationModel geoLoca = new geoLocationModel();

            return View();
        }
    }
}