using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SampleMvcFramework
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //Main fn of UR Application. Similar to Web Forms. 
        //Patterns of the URL are called as ROUTES. The Config for UR routes will be registered here. 
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
