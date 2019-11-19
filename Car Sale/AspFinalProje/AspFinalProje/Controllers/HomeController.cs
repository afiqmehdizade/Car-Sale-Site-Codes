using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using AspFinalProje.DATA;
using AspFinalProje.Models;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using AspFinalProje.ViewModels;

namespace AspFinalProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly AspFinalContext _context;
        public HomeController()
        {
            _context = new AspFinalContext();
        }

        public ActionResult test()
        {
            return Content(Crypto.HashPassword("admin123"));
        }

        public ActionResult Index()
        {
            ForLayout vm = new ForLayout {

                adverts = _context.Adverts.OrderByDescending(m => m.UpdatedAt).OrderByDescending(m => m.IsVip == true).ToList(),
                markas = _context.Markas.ToList(),
                news = _context.News.OrderByDescending(m => m.CreatedAt).Take(5).ToList()
            };
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var s = "cars / bmw - x6.jpg".Split('/')[1];
            return Content(s);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Layoute()
        {
            return View(_context.Markas.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }


    }
}
