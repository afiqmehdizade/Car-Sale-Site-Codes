using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProje.DATA;
using AspFinalProje.ViewModels;

namespace AspFinalProje.Controllers
{
    public class CarController : Controller
    {
        private readonly AspFinalContext _context;
        public CarController()
        {
            _context = new AspFinalContext();
        }
        // GET: Car
        public ActionResult Detail(int? id)
        {
          
            if (id == null) return HttpNotFound();

            var advert = _context.Adverts.Find(id);
            if (advert == null) return HttpNotFound();
            ForLayout vm = new ForLayout
            {
                vmadvert = advert,
                news = _context.News.OrderByDescending(m => m.CreatedAt).Take(5).ToList(),
                adverts = _context.Adverts.Where(m=>m.Id!=id).ToList()
            };

            return View(vm);
        }
    }
}