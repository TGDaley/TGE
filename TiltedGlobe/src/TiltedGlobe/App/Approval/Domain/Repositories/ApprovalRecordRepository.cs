using System.Collections.Generic;
using Fulcrum.Core.Ddd;
using TiltedGlobe.App.Approval.Domain.Entities;

namespace TiltedGlobe.App.Approval.Domain.Repositories
{
	public class ApprovalRecordRepository : IRepository
	{
		public IList<ApprovalRecord> GetApprovalsForProducer(int producerId)
		{
			return new List<ApprovalRecord>();
		}
	}
}