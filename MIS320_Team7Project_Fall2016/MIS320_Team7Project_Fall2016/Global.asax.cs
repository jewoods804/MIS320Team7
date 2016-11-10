using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MIS320_Team7Project_Fall2016.Migrations;

namespace MIS320_Team7Project_Fall2016
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // Database.SetInitializer(new DropCreateDatabaseAlways<FoodContext>());
          

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           // FoodInitializationHandler.Initialize();
            using (var db = new FoodContext())
            {
                
            }
        }
    }
}
