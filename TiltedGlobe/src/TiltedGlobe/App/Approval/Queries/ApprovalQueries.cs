using System.Collections.Generic;
using Fulcrum.Core;
using TiltedGlobe.App.Approval.Domain.Repositories;
using TiltedGlobe.App.Approval.Queries.Projections;

namespace TiltedGlobe.App.Approval.Queries
{
	public class ApprovalQueries : IQuery
	{
		private readonly ApprovalRecordRepository _repo;

		public ApprovalQueries(ApprovalRecordRepository repo)
		{
			_repo = repo;
		}

		public IList<ApprovalRecordProjection> GetApprovedContent(int producerId)
		{
			// use repo to query for entity ApprovalRecord and project it into result

			var records = _repo.GetApprovalsForProducer(producerId);

			return new List<ApprovalRecordProjection>();
		}
		
	}
}