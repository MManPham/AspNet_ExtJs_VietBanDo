using GetStartAspNet.Models;
using GetStartAspNet.Services;
using GetStartAspNet.vbd_services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxPro;

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

        [HttpPost]
        public ActionResult Index(SearchDirectModel search)
        {
            if (search.keySearch != null)
            {
                MyMapSerVices map_services = new MyMapSerVices();
                try
                {
                    search.results = map_services.SearchAll(search.keySearch, 1);
                }
                catch (Exception e)
                {
                    ViewBag.hasResult = false;
                    ViewBag.message = "Error:" + e.ToString();
                }
                if (search.results == null || search.results.Length == 0)
                {
                    ViewBag.hasResult = false;
                    ViewBag.message = "No result!";
                    return View(search);
                }
                else
                {
                    ViewBag.hasResult = true;
                    return View(search);
                }

            }
            else
            {
                ViewBag.hasResult = false;
                ViewBag.message = "search key not found!";
                return View();
            }
        }

        [Authorize]
        public ActionResult FindDirects()
        {
            MyMapSerVices map_services = new MyMapSerVices();
            
            Point a = new Point();
            a.Latitude = 14.072644954380323;
            a.Longitude = 108.43505859375;

            Point b = new Point();
            b.Latitude = 14.30696949782579;
            b.Longitude = 108.0615234375;

            var points = new Point[2];
            points[0] = a;
            points[1] = b;
            var test = map_services.FindShortPath(points, 0);
          
            
            return View();
        }

        [HttpGet]
        public JsonResult SearchDirect(string keySearch )
        {
            
            SearchDirectModel search = new SearchDirectModel();
            search.keySearch = keySearch;
             MyMapSerVices map_services = new MyMapSerVices();
            search.results = map_services.SearchAll(search.keySearch, 1);
            return Json(search, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult MyDirection()
        {
            ViewBag.Message = "My Direction Page.";

            return View();
        }
    }
}