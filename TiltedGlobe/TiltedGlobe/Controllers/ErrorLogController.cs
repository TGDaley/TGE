using System.Web.Mvc;
using Fulcrum.Runtime.Web;

namespace TiltedGlobe.Web.Controllers
{
	[Authorize]
	[RoutePrefix("sys/errors")]
	public class ErrorLogController : DefaultErrorLogController
	{
		[Route("capture")]
		[AllowAnonymous]
		public override ActionResult Capture(string errorMessage)
		{
			return base.Capture(errorMessage);
		}
	}
}