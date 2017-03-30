using System.Collections.Generic;

namespace TiltedGlobe.App.Show
{
    public class ShowType :Entity
    {
        public string Name { get; set; }
        public List<Genre> Genres { get; set; }
    }
}