using System.Web.Mvc;

namespace MMDB.ServiceFaker.Web.Areas.fake
{
	public class fakeAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "fake";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"fake_default",
				"fake/{*url}",
				new { controller="CatchAll", action = "Index" }
			);
		}
	}
}
