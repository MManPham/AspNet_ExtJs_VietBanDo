using GetStartAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetStartAspNet.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var emailId = User.Identity.Name;
            using (MyDatabaseEntities1 dc = new MyDatabaseEntities1())
            {
                var accountLogin = dc.Users.Where(user => user.EmailID == emailId).FirstOrDefault();

                if (accountLogin != null) return View();
            }
            return HttpNotFound();
        }

        [Authorize]
        public ActionResult FindDirects()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult MyDirection()
        {
            ViewBag.Message = "My Direction Page.";

            return View();
        }
    }
}