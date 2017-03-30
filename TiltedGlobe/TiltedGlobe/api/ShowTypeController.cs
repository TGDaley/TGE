using System;
using System.Collections.Generic;
using System.Linq;
using TiltedGlobe.App;
using TiltedGlobe.App.Show;

namespace TiltedGlobe.Api
{
    public class ShowTypeController : BaseApiController<ShowType, Models.ShowTypeViewModel>
    {
	    public ShowTypeController(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
	    {
	    }

	    protected override List<Models.ShowTypeViewModel> Entities
        {
            get
            {
                return
                Database.Set<ShowType>().Select(entity =>
                          new Models.ShowTypeViewModel
                          {
                              Id = entity.Id,
                              Name = entity.Name
                              
                          }).ToList();
            }
        }

        protected override IEnumerable<ShowType> Save(IEnumerable<Models.ShowTypeViewModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
