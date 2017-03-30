using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Xml;

namespace TiltedGlobe.Common.Security.Claims
{
	// See https://code.msdn.microsoft.com/vstudio/Claims-Based-Authorization-89cf736e/sourcecode?fileId=54328&pathId=1068860546
	public class PolicyConfigReader
	{
		private static readonly Expression<Func<ClaimsPrincipal, bool>> AllowAccessForDefaultPagePolicy = (icp) => true;

		private static readonly Expression<Func<ClaimsPrincipal, bool>> DefaultPolicy = (icp) => false;

		/// <summary>
		///   Delegate that checks if the associated claimsPrincipal has the claim specified
		/// </summary>
		private static readonly HasClaimDelegate HasClaim = (p, claimType, claimValue)
			=> p.Claims.Any(c => c.Type == claimType &&
			                     c.ValueType == ClaimValueTypes.String &&
			                     c.Value == claimValue);

		/// <summary>
		///   Creates an instance of the policy reader
		/// </summary>
		public PolicyConfigReader()
		{
		}

		private delegate bool HasClaimDelegate(ClaimsPrincipal p, string claimType, string claimValue);

		/// <summary>
		///   Read the policy as a LINQ expression
		/// </summary>
		/// <param name="rdr">XmlDictionaryReader for the policy Xml</param>
		/// <returns></returns>
		public Expression<Func<ClaimsPrincipal, bool>> ReadPolicy(XmlDictionaryReader rdr)
		{
			if (rdr.Name != "policy")
			{
				throw new InvalidOperationException("Invalid policy document");
			}

			rdr.Read();

			if (!rdr.IsStartElement())
			{
				rdr.ReadEndElement();
				// There are no claims inside this policy which means allow access to the page. 
				return AllowAccessForDefaultPagePolicy;
			}
			// 
			// Instantiate a parameter for the ClaimsPrincipal so it can be evaluated against 
			// each claim constraint. 
			//  
			var subject = Expression.Parameter(typeof(ClaimsPrincipal), "subject");
			var result = readNode(rdr, subject);

			rdr.ReadEndElement();

			return result;
		}

		/// <summary>
		///   Read the And Node
		/// </summary>
		/// <param name="rdr">XmlDictionaryReader of the policy Xml</param>
		/// <param name="subject">ClaimsPrincipal subject</param>
		/// <returns>A LINQ expression created from the And node</returns>
		private Expression<Func<ClaimsPrincipal, bool>> ReadAnd(XmlDictionaryReader rdr, ParameterExpression subject)
		{
			rdr.Read();

			var lambda1 = Expression.AndAlso(
				Expression.Invoke(readNode(rdr, subject), subject),
				Expression.Invoke(readNode(rdr, subject), subject));

			rdr.ReadEndElement();

			var lambda2 = Expression.Lambda<Func<ClaimsPrincipal, bool>>(lambda1, subject);
			return lambda2;
		}

		/// <summary>
		///   Read the claim node
		/// </summary>
		/// <param name="rdr">XmlDictionaryReader of the policy Xml</param>
		/// <returns>A LINQ expression created from the claim node</returns>
		private Expression<Func<ClaimsPrincipal, bool>> readClaim(XmlDictionaryReader rdr)
		{
			var claimType = rdr.GetAttribute("claimType");
			var claimValue = rdr.GetAttribute("claimValue");

			Expression<Func<ClaimsPrincipal, bool>> hasClaim = (icp) => HasClaim(icp, claimType, claimValue);

			rdr.Read();

			return hasClaim;
		}

		/// <summary>
		///   Read the policy node
		/// </summary>
		/// <param name="rdr">XmlDictionaryReader for the policy Xml</param>
		/// <param name="subject">ClaimsPrincipal subject</param>
		/// <returns>A LINQ expression created from the policy</returns>
		private Expression<Func<ClaimsPrincipal, bool>> readNode(XmlDictionaryReader rdr, ParameterExpression subject)
		{
			Expression<Func<ClaimsPrincipal, bool>> policyExpression;

			if (!rdr.IsStartElement())
			{
				throw new InvalidOperationException("Invalid Policy format.");
			}

			switch (rdr.Name)
			{
				case "and":
					policyExpression = ReadAnd(rdr, subject);
					break;
				case "or":
					policyExpression = ReadOr(rdr, subject);
					break;
				case "claim":
					policyExpression = readClaim(rdr);
					break;
				default:
					policyExpression = DefaultPolicy;
					break;
			}

			return policyExpression;
		}

		/// <summary>
		///   Read the Or Node
		/// </summary>
		/// <param name="rdr">XmlDictionaryReader of the policy Xml</param>
		/// <param name="subject">ClaimsPrincipal subject</param>
		/// <returns>A LINQ expression created from the Or node</returns>
		private Expression<Func<ClaimsPrincipal, bool>> ReadOr(XmlDictionaryReader rdr, ParameterExpression subject)
		{
			rdr.Read();

			var lambda1 = Expression.OrElse(
				Expression.Invoke(readNode(rdr, subject), subject),
				Expression.Invoke(readNode(rdr, subject), subject));

			rdr.ReadEndElement();

			var lambda2 = Expression.Lambda<Func<ClaimsPrincipal, bool>>(lambda1, subject);
			return lambda2;
		}
	}
}
