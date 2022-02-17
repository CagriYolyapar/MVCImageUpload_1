using MVCImageUpload_1.DesignPatterns.SingletonPattern;
using MVCImageUpload_1.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCImageUpload_1.Controllers
{
    public class HomeController : Controller
    {

       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}