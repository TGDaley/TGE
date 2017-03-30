using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TiltedGlobe.App;
using TiltedGlobe.Migrations;

namespace TiltedGlobe
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			
			RouteTable.Routes.MapMvcAttributeRoutes();
			
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
			
			ViewEngines.Engines.Clear();
			
			ViewEngines.Engines.Add(new RazorViewEngine
			{
				PartialViewLocationFormats = new[]
				{
					"~/Modules/{1}/{0}.cshtml",
					"~/Modules/{0}.cshtml"
				},
				ViewLocationFormats = new[]
				{
					"~/Modules/{1}/{0}.cshtml",
					"~/Modules/{0}.cshtml"
				}
			});
		}
	}
}
