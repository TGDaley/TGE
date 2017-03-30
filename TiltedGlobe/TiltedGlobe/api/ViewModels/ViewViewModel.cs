using System;

namespace TiltedGlobe.Api.Models
{
	// TODO: this should be renamed along the form of <Noun><Verb>ViewModel
    public class ViewViewModel
    {
        public int Id { get; set; }
        public DateTime UpdatedTimeStamp { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public int Status { get; set; }
    }
}
