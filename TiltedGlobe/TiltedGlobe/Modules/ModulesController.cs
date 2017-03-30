using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiltedGlobe.Modules
{
    public class ModulesController : Controller
    {
        //
        // GET: /Modules/
        public ActionResult Index()
        {
            //when navigation is a direct request via user typing a url directly into the browser
            //or refreshing the page just send back the default view and let the client side handle
            //the state.
            var path = Request.Path.Trim('/');
            if (Request.Headers["X-Requested-With"] != "AngularJS-Routing")
            {
                //for now this is how we will switch between apps
                return path.Trim().ToUpper() == "PRODUCER" ? View(path) : View();
            }
            return PartialView(path);
        }
    }
}