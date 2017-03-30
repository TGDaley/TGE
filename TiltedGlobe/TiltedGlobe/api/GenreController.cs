using System;
using System.Collections.Generic;
using System.Linq;
using TiltedGlobe.Api.Models;
using TiltedGlobe.App;
using TiltedGlobe.App.Show;

namespace TiltedGlobe.Api
{
    public class GenreController : BaseApiController<GenreViewModel, GenreViewModel>
    {
	    public GenreController(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
	    {
	    }

	    protected override List<GenreViewModel> Entities
        {
            get
            {
                return
                    Database.Set<Genre>().Select(entity =>
                        new GenreViewModel
                        {
                            Id = entity.Id,
                            Name = entity.Name,
                            ShowTypeId =Database.Set<ShowType>().FirstOrDefault(st => st.Id == entity.ShowType.Id).Id
                        }).ToList();
            }
        }

        protected override IEnumerable<GenreViewModel> Save(IEnumerable<Models.GenreViewModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
