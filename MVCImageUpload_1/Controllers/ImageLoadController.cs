using MVCImageUpload_1.CustomTools;
using MVCImageUpload_1.DesignPatterns.SingletonPattern;
using MVCImageUpload_1.Models.Context;
using MVCImageUpload_1.Models.Entities;
using MVCImageUpload_1.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCImageUpload_1.Controllers
{
    public class ImageLoadController : Controller
    {

        MyContext _db;

        public ImageLoadController()
        {
            _db = DBTool.DBInstance;
        }
        // GET: ImageLoad
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestClass testClass,HttpPostedFileBase resim)
        {
            testClass.ImagePath = ImageUploader.UploadImage("/Images/",resim);
            _db.TestClasses.Add(testClass);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListTestClasses()
        {
            ImageLoadVM ivm = new ImageLoadVM
            {
                TestClasses = _db.TestClasses.ToList()
            };

            return View(ivm);
        }
    }
}