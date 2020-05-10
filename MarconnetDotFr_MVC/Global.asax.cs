using MarconnetDotFr_MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarconnetDotFr_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Clear();

                var rd = new RouteData();
                rd.Values["controller"] = "Home";
                rd.Values["action"] = "Index";

                var rc = new RequestContext(new HttpContextWrapper(Context), rd);
                var c = ControllerBuilder.Current.GetControllerFactory().CreateController(rc, "Home");
                c.Execute(rc);
            }
        }
    }
}
