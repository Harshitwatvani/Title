using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Titles.Controllers
{
    [Authorize]
    public class TitleController : Controller
    {
        // GET: Title
        pubsEntities pubsEntities = new pubsEntities();
        public ActionResult Title()
        {
            return View(pubsEntities.titles.ToList()) ;
        }
    }
}