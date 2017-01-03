using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace communityThrive2.Controllers
{
    public class userRequestController : Controller
    {

        public ActionResult sendRequest()
        {
            return View();
        }

        public ActionResult sendRequestYes()
        {
            //perform this action if the user wants to join a company
            return Redirect("~/userRequest/companyChoice");

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

    }
}