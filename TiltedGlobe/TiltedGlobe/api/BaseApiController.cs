using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TiltedGlobe.App;
using TiltedGlobe.App.User;
using TiltedGlobe.Models;

namespace TiltedGlobe.Api
{
	public abstract class BaseApiController<TEntity, TModel> : ApiController
	{
		private readonly ApplicationDbContext _applicationDbContext;

		private readonly ApplicationRoleManager _appRoleManager = null;

		private readonly ApplicationUserManager _appUserManager = null;

		private ModelFactory _modelFactory;

		protected BaseApiController(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		protected ApplicationRoleManager AppRoleManager
		{
			get { return _appRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>(); }
		}

		protected ApplicationUserManager AppUserManager
		{
			get { return _appUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
		}

		protected ApplicationDbContext Database
		{
			get { return _applicationDbContext; }
		}

		protected abstract List<TModel> Entities { get; }

		protected ModelFactory TheModelFactory
		{
			get
			{
				if (_modelFactory == null)
				{
					_modelFactory = new ModelFactory(this.Request, this.AppUserManager);
				}
				return _modelFactory;
			}
		}

		[HttpGet]
		public IHttpActionResult Get()
		{
			return Ok(Entities);
		}

		[HttpPost]
		public IHttpActionResult Post(IEnumerable<TModel> models)
		{
			var e = Save(models);
			Database.SaveChanges();
			return Ok(e);
		}

		protected IHttpActionResult GetErrorResult(IdentityResult result)
		{
			if (result == null)
			{
				return InternalServerError();
			}

			if (!result.Succeeded)
			{
				if (result.Errors != null)
				{
					foreach (string error in result.Errors)
					{
						ModelState.AddModelError("", error);
					}
				}

				if (ModelState.IsValid)
				{
					// No ModelState errors are available to send, so just return an empty BadRequest.
					return BadRequest();
				}

				return BadRequest(ModelState);
			}

			return null;
		}

		protected abstract IEnumerable<TEntity> Save(IEnumerable<TModel> models);
	}
}
