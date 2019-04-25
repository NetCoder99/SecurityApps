using SecurityWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityWeb.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(Exception exception)
        {
            Error errorDetails = new Error();

            // the session variable takes precedence over the argumant
            if (HttpContext.Session["exception"] != null)
            { errorDetails.Set((Exception)HttpContext.Session["exception"]); }
            else
            { errorDetails.Set(exception); }

            return View("Index", errorDetails);
        }

    }
}