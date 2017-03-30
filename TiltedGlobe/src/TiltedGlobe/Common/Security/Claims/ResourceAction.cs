using System;

namespace TiltedGlobe.Common.Security.Claims
{
	// See https://code.msdn.microsoft.com/vstudio/Claims-Based-Authorization-89cf736e/sourcecode?fileId=54328&pathId=1068860546
	public class ResourceAction
	{
		public string Resource;
		public string Action;

		/// <summary> 
		/// Checks if the current instance is equal to the given object by comparing the resource and action values 
		/// </summary> 
		/// <param name="obj">object to compare to</param>
		/// <returns>True if equal, else false.</returns> 
		public override bool Equals(object obj)
		{
			var ra = obj as ResourceAction;

			if (ra != null)
			{
				return ((String.Compare(ra.Resource, Resource, StringComparison.OrdinalIgnoreCase) == 0) && 
					(String.Compare(ra.Action, Action, StringComparison.OrdinalIgnoreCase) == 0));
			}

			return base.Equals(obj);
		}

		/// <summary> 
		/// Gets the hash code. 
		/// </summary> 
		/// <returns>The hash code.</returns> 
		public override int GetHashCode()
		{
			return (Resource + Action).ToLower().GetHashCode();
		}

		/// <summary> 
		/// Creates an instance of ResourceAction class. 
		/// </summary> 
		/// <param name="resource">The resource name.</param>
		/// <param name="action">The action.</param>
		/// <exception cref="ArgumentNullException">when <paramref name="resource"/> is null</exception>
		public ResourceAction(string resource, string action)
		{
			if (string.IsNullOrEmpty(resource))
			{
				throw new ArgumentNullException("resource");
			}

			Resource = resource;
			Action = action;
		}
	}
}
