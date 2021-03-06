﻿using System;
using System.Collections.Generic;
using Fulcrum.Common.JsonSchema;
using Fulcrum.Core;

namespace Fulcrum.Runtime.Api.Results.CommandPublication
{
	public class CommandCompleteOrPendingResult
	{
		public CommandCompleteOrPendingResult(ICommandPublicationRecord record)
		{
			Created = record.Created;
			Id = record.Id;
			Status = record.Status;
			Updated = record.Updated;
			CommandName = record.PortableCommand.ClrTypeName;
			QueryReferences = record.QueryReferences;

			Links = new List<JsonLink>()
			{
				new JsonLink(string.Format("/api/commands/publication-registry/{0}", Id), "details"),
				new JsonLink("/api/commands/", "home")
			};

			foreach (var reference in QueryReferences)
			{
				var queryUrl = string.Format("/api/queries/{0}/results?id={1}",
					reference.QueryName, reference.QueryParameter);

				Links.Add(new JsonLink(queryUrl, "query-reference"));
			}
		}

		public string CommandName { get; set; }

		public DateTime Created { get; private set; }

		public Guid Id { get; private set; }

		public IList<JsonLink> Links { get; private set; }

		public IList<IdentifierQueryReference> QueryReferences { get; private set; }

		public CommandPublicationStatus Status { get; private set; }

		public DateTime? Updated { get; private set; }
	}
}
