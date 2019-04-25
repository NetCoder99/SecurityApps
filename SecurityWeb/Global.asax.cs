using SecurityWeb.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecurityWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            if (new HttpRequestWrapper(Context.Request).IsAjaxRequest())
            {
                HttpContext.Current.Session["exception"] = exception;
                return;
            }

            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();
            httpContext.Response.TrySkipIisCustomErrors = true;

            InvokeErrorAction(httpContext, exception);
        }

        void InvokeErrorAction(HttpContext httpContext, Exception exception)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = "Index";
            routeData.Values["exception"] = exception;
            using (var controller = new ErrorController())
            {
                ((IController)controller).Execute(
                new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
        }

    }
}
