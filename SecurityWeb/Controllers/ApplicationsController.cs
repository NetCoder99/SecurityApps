using SecurityClass.Classes;
using SecurityClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using Newtonsoft.Json;
using SecurityWeb.Common;
using SecurityClass.Builders;

namespace SecurityWeb.Controllers
{
    public class ApplicationsController : Controller
    {
        // --------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult AppsIndexMain()
        {
            List<AppSystem> appSystems = SecAppManager.GetAppsAll();
            return View(appSystems);
        }

        // --------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult EditApplication(string appGuid)
        {
            AppSystem appSystem = SecAppManager.GetAppByGuid(appGuid);
            return View(appSystem);
        }
        [HttpPost]
        public ActionResult EditApplication(FormCollection model)
        {
            try
            {
                AppSystem tmpSystem = new AppBuilder().Build(model.ToJSON());
                tmpSystem = SecAppManager.Update(tmpSystem);
                return View(tmpSystem);
            }
            catch (Exception ex)
            {
                string errMessage = ExceptionProcs.GetExceptionMessage(ex);
                AppSystem tmpSystem = new AppBuilder().Build(model.ToJSON());
                return View(tmpSystem);
            }
        }


        // --------------------------------------------------------------------------------------
        [HttpGet]
        public JsonResult GetAppCounts(string appGuid)
        {
            int rolesCount = 0;
            int usersCount = 0;

            AppSystem appSystem = SecAppManager.GetAppByGuid(appGuid);
            rolesCount = appSystem.AppRoles.Count();

            foreach (AppRole appRole in appSystem.AppRoles)
            { usersCount += SecUserRoleManager.GetUsersInRole(appRole).Count; }

            var jsonMessage = new {applicationName = appSystem.Name, rolesCount = rolesCount.ToString(), usersCount = usersCount.ToString() };
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(jsonMessage, JsonRequestBehavior.AllowGet);

        }


    }
}