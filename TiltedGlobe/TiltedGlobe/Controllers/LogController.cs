using System.Web.Mvc;
using Fulcrum.Runtime.Web;

namespace TiltedGlobe.Web.Controllers
{
	[Authorize]
	[RoutePrefix("sys/log")]
	public class LogController : DefaultLogController
	{
		[Route("writeDebug")]
		[HttpPost]
		public override ActionResult WriteDebug(string message)
		{
			return base.WriteDebug(message);
		}

		[Route("writeFatal")]
		[HttpPost]
		public override ActionResult WriteFatal(string message)
		{
			return base.WriteFatal(message);
		}

		[Route("writeInfo")]
		[HttpPost]
		public override ActionResult WriteInfo(string message)
		{
			return base.WriteInfo(message);
		}

		[Route("writeWarn")]
		[HttpPost]
		public override ActionResult WriteWarn(string message)
		{
			return base.WriteWarn(message);
		}
	}
}
