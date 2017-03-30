using System;
using System.Runtime.Remoting.Contexts;
using Fulcrum.Common;
using Fulcrum.Core;
using TiltedGlobe.App.Approval.Commands;

namespace TiltedGlobe.App.Approval.CommandHandlers
{
	public class ApprovalHandlers :
		ICommandHandler<ApproveContent>,
		ILoggingSource
	{
		public void Handle(ApproveContent command)
		{
			// look up content by id

			// mark it approved

			// save it

		}
	}
}