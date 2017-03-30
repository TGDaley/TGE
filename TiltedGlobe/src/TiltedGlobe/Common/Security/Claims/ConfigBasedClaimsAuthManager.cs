using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Xml;

namespace TiltedGlobe.Common.Security.Claims
{
	// Based on https://code.msdn.microsoft.com/vstudio/Claims-Based-Authorization-89cf736e/sourcecode?fileId=54328&pathId=1068860546
	public class ConfigBasedClaimsAuthManager : ClaimsAuthorizationManager
	{
		private static readonly Dictionary<ResourceAction, Func<ClaimsPrincipal, bool>> Policies =
			new Dictionary<ResourceAction, Func<ClaimsPrincipal, bool>>();

		private readonly PolicyConfigReader _policyConfigReader = new PolicyConfigReader();

		public ConfigBasedClaimsAuthManager()
		{
		}

		// Note that the base impl. always returns true. Nice!
		public override bool CheckAccess(AuthorizationContext pec)
		{
			var access = false;

			try
			{
				var action = pec.Action.First().Value;

				var resource = pec.Resource.First().Value;

				resource = Regex.Replace(resource, "https?://[a-zA-Z\\.]*:?[0-9]*/", "");

				var ra = new ResourceAction(resource, action);

				if (Policies.ContainsKey(ra))
				{
					access = Policies[ra](pec.Principal);
				}
			}
			catch (Exception)
			{
				access = false;
			}

			return access;
		}

		public override void LoadCustomConfiguration(XmlNodeList nodelist)
		{
			if (nodelist == null)
			{
				return;
			}

			foreach (XmlNode node in nodelist)
			{
				// 
				// Initialize the policy cache 
				//
				var reader = XmlDictionaryReader.CreateDictionaryReader(
					new XmlTextReader(new StringReader(node.OuterXml)));
				reader.MoveToContent();

				var resource = reader.GetAttribute("resource");
				var action = reader.GetAttribute("action");

				var policyExpression = _policyConfigReader.ReadPolicy(reader);

				// 
				// Compile the policy expression into a function 
				//
				var policy = policyExpression.Compile();

				// 
				// Insert the policy function into the policy cache 
				//
				Policies[new ResourceAction(resource, action)] = policy;
			}
		}
	}
}
