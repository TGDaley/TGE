using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiltedGlobe.Api.Models
{
    public class ShowTypeViewModel : ViewViewModel
    {
        public string Name { get; set; }
        public List<GenreViewModel> Genres { get; set; }
    }
}
