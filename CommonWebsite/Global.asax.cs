using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CommonWebsite.Infrastructure.Ioc;
using CommonWebsite.Infrastructure.Logging;
using CommonWebsiteService;

namespace CommonWebsite
{
    public class MvcApplication : HttpApplication
    {
        protected void OnApplicationStart()
        {
            Ioc.RegisterInheritedTypes(typeof (ServiceBase).Assembly, typeof (ServiceBase));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Ioc.RegisterInheritedTypes(typeof (IUserService).Assembly, typeof (ServiceBase));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            OnError(exception);
        }

        protected virtual void OnError(Exception exception)
        {
            Logger.Error(exception);
        }
    }
}