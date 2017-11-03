using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using dbsrvc.Models.NHibernate;
using dbsrvc.Models;
using NHibernate;

namespace dbsrvc
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

			System.Web.Mvc.AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			FilterConfig.RegisterGlobalFilters(System.Web.Mvc.GlobalFilters.Filters);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			using(ISession session = NHibernateHelper.OpenSession()) {
				var word = new Word { Id = 0, Value = "anyvalue" };
				session.SaveOrUpdate(word);
			}
		}
    }
}
