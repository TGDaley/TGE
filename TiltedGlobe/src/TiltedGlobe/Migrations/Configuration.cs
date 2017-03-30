using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TiltedGlobe.App;
using TiltedGlobe.App.Show;
using TiltedGlobe.App.User;

namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

	public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var user = new ApplicationUser()
            {
                UserName = "aquinc@gmail.com",
                Email = "aquinc@gmail.com",
                EmailConfirmed = true,
                FirstName = "Initial",
                LastName = "Admin",
                CompanyName = "Company Name",
                CompanyAddress = "Company Address",
                City = "City",
                State = "ST",
                Country = "USA",
                PostalCode = "111111",
                CompanyPhone = "9999999999"
            };

            manager.Create(user, "Abcd1234");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Producer" });
                roleManager.Create(new IdentityRole { Name = "Viewer" });
                roleManager.Create(new IdentityRole { Name = "CommercialViewer" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            var adminUser = manager.FindByName("aquinc@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Producer", "Admin" });
            
            //LoadShowTypesAndGenres(context);
        }

        private void LoadShowTypesAndGenres(ApplicationDbContext context)
        {
            var concerts = "Concert,Alternative Music,Blues,Classical Music,Country Music,Dance Music,Easy Listening,Electronic Music,European Music (Folk / Pop),Hip Hop / Rap,Indie Pop,Inspirational (incl. Gospel),Asian Pop (J-Pop' K-pop),Jazz,Latin Music,New Age,Opera,Pop (Popular music),R&amp;B / Soul,Reggae,Rock,Singer / Songwriter (inc; Folk),World Music / Beats";
            var lectures =
                "Lecture,Agriculture,Architecture and Planning,Arts,Biological Sciences,Business,Communications,Computer and Information Sciences,Education,Engineering,Environmental Sciences,Health Care,Languages and Literature,Law,Mathematics &amp; Statistics,Mechanics and Repair,Military Science,Philosophy and Religion,Physical Sciences,Protective Services,Psychology &amp; Counseling,Recreation &amp; Fitness,Services,Skilled Trades and Construction,Social Sciences &amp; Liberal Arts,Social Services,Transnportation";
            var theaters = "Theater,Comedy,Drama,Performance Art,Tragedy,Musical,Opera";
            var sports = "Sports,Abseiling,Aerobatics,Aikido,Air Racing,Airsoft,Aquathlon,Aquatics,Archery,Arm Wrestling,Artistic Billiards,Autocross,Autograss,Automobile Racing,Ba Game,Badminton,Bagatelle,Ballroom Dancing,Bando,Bandy,Base Jumping,Baseball,Basketball,Beach Volleyball,Biathlon,Bobsleigh,Bocce Ball,Body Building,Boomerang,Bowling,Boxing,Bull Fighting,Camping,Canoeing,Caving,Cheerleading,Chess,Classical Dance,Cricket,Cross Country Running,Cross Country Skiing,Curling,Cycling,Darts,Decathlon,Diving,Dog Sledding,Dog Training,Down Hill Skiing,Equestrianism,Falconry,Fencing,Figure Skating,Fishing,Flag Football,Foosball,Football,Fox Hunting,Golf,Gymnastics,Hand Ball,Hang Gliding,High Jump,Hiking,Hockey,Horseshoes,Hot Air Ballooning,Hunting,Ice Skating,Inline Skating,Jai Alai,Judo,Karate,Kayaking,Knee Boarding,Lacrosse,Land Sailing,Log Rolling,Long Jump,Luge,Modern Dance,Modern Pentathlon,Motorcycle Racing,Mountain Biking,Mountaineering,Netball,Paint Ball,Para Gliding,Parachuting,Petanque,Pool Playing,Power Walking,Quad Biking,Racquetball,Remote Control Boating,River Rafting,Rock Climbing,Rodeo Riding,Roller Skating,Rowing,Rugby,Sailing,Scuba Diving,Shooting,Shot Put,Shuffleboard,Skateboarding,Skeet Shooting,Snooker,Snow Biking,Snow Boarding,Snow Shoeing,Snow Sledding,Soccer,Sombo,Speed Skating,Sport Fishing,Sport Guide,Sprint Running,Squash,Stunt Plane Flying,Sumo Wrestling,Surfing,Swimming,Synchronized Swimming,Table Tennis,Taekwondo,Tchoukball,Tennis,Track and Field,Trampolining,Triathlon,Tug of War,Volleyball,Water Polo,Water Skiing,Weight Lifting,Wheelchair Basketball,White Water Rafting,Wind Surfing,Wrestling,Wushu,Yachting,Yoga";
            var showGenreInfo = new List<string> {concerts, lectures, theaters, sports};
            foreach (var sg in showGenreInfo)
            {
                var showType = sg.Substring(0, sg.IndexOf(','));
                context.Set<ShowType>().Add(
                    new ShowType
                    {
                        Name = showType,
                        Genres = new List<Genre>(),
                        CreatedTimeStamp = DateTime.UtcNow,
                        UpdatedTimeStamp = DateTime.UtcNow
                    });
            }
            context.SaveChanges();
            foreach (var sg in showGenreInfo)
            {
                var showTypeString = sg.Substring(0, sg.IndexOf(','));
                var genres = sg.Substring(sg.IndexOf(',') + 1);
                var showType = context.Set<ShowType>().Single(st => st.Name == showTypeString);
                foreach (var genre in genres.Split(','))
                {
                    context.Set<Genre>().Add(
                        new Genre
                        {
                            Name = genre,
                            ShowType =showType,
                            CreatedTimeStamp = DateTime.UtcNow,
                            UpdatedTimeStamp = DateTime.UtcNow
                        });
                }
            }
            context.SaveChanges();
        }
    }
}
