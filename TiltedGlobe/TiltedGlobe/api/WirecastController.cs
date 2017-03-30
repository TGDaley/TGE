using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Serialization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TiltedGlobe.App;
using TiltedGlobe.App.Show;
using TiltedGlobe.App.User;

namespace TiltedGlobe.Api
{
    public class WirecastController : ApiController
    {
        public IHttpActionResult Get()
        {
            var xmlFormatter = Configuration.Formatters.XmlFormatter;
            xmlFormatter.UseXmlSerializer = true;
            return Content(HttpStatusCode.OK, new Destination
            {
                Branding = new Branding
                {
                    Logo =
                        new Logo
                        {
                            Image = ConfigurationManager.AppSettings["wirecastLogo"],
                            Click = ConfigurationManager.AppSettings["wirecastLogoClick"],
                            Location = "destination",
                            Title =
                                new Title {Language = "EN", Text = ConfigurationManager.AppSettings["wirecastTitle"]}
                        },
                },
                ChannelDiscoveryService = new ChannelDiscoveryService
                {
                    Url = ConfigurationManager.AppSettings["wirecastChannelDiscoveryServiceLink"]
                }
            }, xmlFormatter);
        }

        public async Task<IHttpActionResult> Get(string userName, string password)
        {
            var channels = new List<Channel>();
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>(); 
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager) { AllowOnlyAlphanumericUserNames = false, RequireUniqueEmail = true };
            ApplicationUser user = await userManager.FindAsync(userName, password);
            var error = new Error { Code = "0", Title = new Title { Text = "Invalid Usermame or Password.", Language = "EN" } }; ;
            if (user == null)
            {
                error.Code = "1";
            }
            else 
            {
                var db = Request.GetOwinContext().Get<ApplicationDbContext>();
                var shows = db.Set<Show>().Where(u => u.ApplicationUser.Id == user.Id);
                channels = shows.Select(show => new Channel
                {
                    Password = "aaa",
                    UserName = "sss",
                    Type = "adobe",
                    Stream = "dddd",
                    Rtmp = "rtmp://ffff",
                    Text = show.Name,
                    Language = "EN",
                    Title = new Title {Text = show.Name, Language = "EN"}
                }).ToList();
            }
            var xmlFormatter = Configuration.Formatters.XmlFormatter;
            xmlFormatter.UseXmlSerializer = true;
            return Content(HttpStatusCode.OK, new Response
            {
                Error = error,
                Channel = channels
            }, xmlFormatter);
        }

        #region "Wirecast Models"
        [XmlRoot("destination")]
        public class Destination
        {
            [XmlElement("branding")]
            public Branding Branding { get; set; }
            [XmlElement("channel_discovery_service")]
            public ChannelDiscoveryService ChannelDiscoveryService { get; set; }
        }

        public class Branding
        {
            [XmlElement("logo")]
            public Logo Logo { get; set; }

        }
        
        public class Logo
        {
            [XmlAttribute("location")]
            public string Location { get; set; }
            [XmlAttribute("image")]
            public string Image { get; set; }
            [XmlAttribute("click")]
            public string Click { get; set; }
            [XmlElement("title")]
            public Title Title { get; set; }
        }

        public class Title
        {
            [XmlAttribute("text")]
            public string Text { get; set; }
            [XmlAttribute("language")]
            public string Language { get; set; }
        }

        public class ChannelDiscoveryService
        {
            [XmlAttribute("url")]
            public string Url { get; set; }
        }

        [XmlRoot("response")]
        public class Response
        {
            [XmlElement("channel")]
            public List<Channel> Channel { get; set; }
            [XmlElement("error")]
            public Error Error { get; set; }
        }
        
        public class Channel
        {
            [XmlAttribute("rtmp")]
            public string Rtmp { get; set; }
            [XmlAttribute("stream")]
            public string Stream { get; set; }
            [XmlAttribute("type")]
            public string Type { get; set; }
            [XmlAttribute("username")]
            public string UserName { get; set; }
            [XmlAttribute("password")]
            public string Password { get; set; }
            [XmlAttribute("text")]
            public string Text { get; set; }
            [XmlAttribute("laguage")]
            public string Language { get; set; }
            [XmlElement("title")]
            public Title Title { get; set; }
        }

        [XmlRoot("error")]
        public class Error
        {
            [XmlAttribute("code")]
            public string Code { get; set; }

            [XmlElement("title")]
            public Title Title { get; set; }
        }
        #endregion

    }


}
