using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Titles.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        // GET: Author
        pubsEntities pubsEntities = new pubsEntities();
        public ActionResult Author()
        {
            return View(pubsEntities.authors.ToList());
        }
        public ActionResult Select(string id)
        {
            List<titleauthor> titleauthors= pubsEntities.titleauthors.Where((a) => a.au_id == id).ToList();
           List<title> titles = new List<title>();
            foreach (var item in titleauthors)
            {
                titles.Add((title)pubsEntities.titles.ToList().Find((b) => b.title_id == item.title_id));
            }
           // titles=pubsEntities.titles.ToList().Where((b)=>b.title_id)
            return View(titles);
        }
    }
}