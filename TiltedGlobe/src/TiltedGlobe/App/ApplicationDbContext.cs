using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TiltedGlobe.App.Show;
using TiltedGlobe.App.User;

namespace TiltedGlobe.App
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TiltedGlobe", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        private DbSet<Show.Show> Shows { get; set; }
        private DbSet<ShowType> ShowType { get; set; }
        private DbSet<Genre> Genre { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}