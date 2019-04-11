using SecurityClass.Classes;
using SecurityClass.Models;
//using SecurityWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using SecurityWeb.Common;
using SecurityClass.Builders;
using SecurityWeb.Models;

namespace SecurityWeb.Controllers
{
    public class ApplicationsController : Controller
    {
        // --------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult AppsIndexMain()
        {
            List<AppSystem> appSystems = SecAppManager.GetAppsAll();
            List<ViewAppSystem> model = appSystems.ConvertAll(x => new ViewAppSystem(x));
            return View(model);
        }

        // --------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult EditApplication(string appGuid)
        {
            AppSystem appSystem = SecAppManager.GetAppByGuid(appGuid);
            ViewAppSystem model = new ViewAppSystem(appSystem);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditApplication(FormCollection model, string Create, string Delete, string Save)
        {
            System.Threading.Thread.Sleep(1000);

            if (!ModelState.IsValid)
            {
                Dictionary<String, String> err_list = GetModelErrors.GetErrors(ModelState);
                dynamic errorMessage = new { param1 = err_list.ToList()[0].Key, param2 = err_list.ToList()[0].Value };
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                return Json(errorMessage, JsonRequestBehavior.AllowGet);
            }

            try
            {
                AppSystem tmpSystem = new AppBuilder().Build(model.ToJSON());
                dynamic jsonMessage;
                if (!String.IsNullOrEmpty(Delete))
                {
                    SecAppManager.Delete(tmpSystem);
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    jsonMessage = new { param1 = "Deleted", param2 = tmpSystem.Name };
                    return Json(jsonMessage, JsonRequestBehavior.AllowGet);
                }
                else if (!String.IsNullOrEmpty(Create))
                {
                    AppSystem newSystem = SecAppManager.Create(tmpSystem);
                    string appJson = newSystem.ToJSON();
                    jsonMessage = new {
                        param1 = "Created",
                        newSystem.Id,
                        newSystem.AppId,
                        newSystem.Name,
                        newSystem.Desc,
                        CreateDate = newSystem.CreateDate.ToShortDateString() + " " + newSystem.CreateDate.ToShortTimeString(),
                        UpdateDate = newSystem.UpdateDate.ToShortDateString() + " " + newSystem.UpdateDate.ToShortTimeString()
                    };
                    return Json(jsonMessage, JsonRequestBehavior.AllowGet);
                }
                else if (!String.IsNullOrEmpty(Save))
                {
                    AppSystem updSystem = SecAppManager.Update(tmpSystem);
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    jsonMessage = new
                    {
                        param1 = "Updated",
                        updSystem.Id,
                        updSystem.AppId,
                        updSystem.Name,
                        updSystem.Desc,
                        CreateDate = updSystem.CreateDate.ToShortDateString() + " " + updSystem.CreateDate.ToShortTimeString(),
                        UpdateDate = updSystem.UpdateDate.ToShortDateString() + " " + updSystem.UpdateDate.ToShortTimeString()
                    };
                    return Json(jsonMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
                    jsonMessage = new { param1 = "Error", param2 = "Uknown function call" };
                    return Json(jsonMessage, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {
                dynamic jsonMessage;
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                string errMessage = ExceptionProcs.GetExceptionMessage(ex);
                if (errMessage.Contains("duplicate"))
                { jsonMessage = new { param1 = "Error", param2 = "Already Exists" }; }
                else
                { jsonMessage = new { param1 = "Error", param2 = errMessage }; }
                return Json(jsonMessage, JsonRequestBehavior.AllowGet);
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

            var jsonMessage = new { appGuid, applicationName = appSystem.Name, rolesCount = rolesCount.ToString(), usersCount = usersCount.ToString() };
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(jsonMessage, JsonRequestBehavior.AllowGet);

        }

        // --------------------------------------------------------------------------------------
        [HttpPost]
        public JsonResult DeleteApplication(string appGuid)
        {
            AppSystem appSystem = SecAppManager.GetAppByGuid(appGuid);
            SecAppManager.Delete(appSystem);

            var jsonMessage = new { appGuid };
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(jsonMessage, JsonRequestBehavior.AllowGet);
        }

    }
}