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

        [HttpPost]
        public ActionResult sendRequest(bool yesorno)
        {
            if (yesorno == false)
            {
                return View("Index","Home");
            }
            else if (yesorno == true)
            {
                return View(); //the page for then choosing the company would go here
            }
            else
            {
                return View();
            }

        }
    }
}