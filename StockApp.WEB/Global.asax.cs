using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using StockApp.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StockApp.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //внедрение зависимостей
            NinjectModule viewModule = new NinjectRegistrations();
            NinjectModule serviceModule = new StockApp.BLL.Util.NinjectRegistrations();
            var kernel = new StandardKernel(viewModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
