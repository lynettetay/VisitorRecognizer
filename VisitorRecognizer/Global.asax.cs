using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace VisitorRecognizer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
            //{
            //    ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
            //        ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            //});
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            BundleMobileConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();
        }
    }
}
