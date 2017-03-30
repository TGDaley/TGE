using System.ComponentModel.DataAnnotations;
using Fulcrum.Core;

namespace TiltedGlobe.App.Approval.Commands
{
	public class ApproveContent : DefaultCommand
	{
		public string ApproverUsername { get; set; }

		public int ContentToApprove { get; set; }
	}
}
