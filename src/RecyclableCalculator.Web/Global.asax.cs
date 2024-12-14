using AutoMapper;
using RecyclableCalculator.Core.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RecyclableCalculator.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
			var mapper = config.CreateMapper();

			AreaRegistration.RegisterAllAreas();
			UnityConfig.RegisterComponents();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
