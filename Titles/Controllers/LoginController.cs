using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;

namespace Titles.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        pubsEntities entities = new pubsEntities();
        
        [Authorize]
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Login()
        {
            employee employee = new employee();
            return View(employee);
        }
        [HttpPost]
        public ActionResult Login(employee employee)
        {
            int myUser = entities.employees.Where((u) => u.emp_id == employee.emp_id && u.fname == employee.fname).Count();
            employee e = entities.employees.Find(employee.emp_id);
            
                if (myUser==1)
                {
                    FormsAuthentication.SetAuthCookie(employee.emp_id, false);
                TempData.Add("c", "1");
                return RedirectToAction("Home");
                }
            
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            TempData.Remove("c");
            return RedirectToAction("Login");
        }
    }
}