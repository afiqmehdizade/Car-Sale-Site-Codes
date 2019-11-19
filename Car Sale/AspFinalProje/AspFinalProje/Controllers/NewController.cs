using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProje.DATA;
using AspFinalProje.Models;
using AspFinalProje.ViewModels;


namespace AspFinalProje.Controllers
{
    public class NewController : Controller
    {
        AspFinalContext _context;
        public NewController()
        {
            _context = new AspFinalContext();
        }
        
        public ActionResult Index(int? id)
        {

            if (id == null) return HttpNotFound();

            var news = _context.News.Find(id);

            if (news == null) return HttpNotFound();
            ForLayout vm = new ForLayout
            {
                news = _context.News.Where(m=>m.Id!=id).OrderByDescending(m => m.CreatedAt).Take(5).ToList(),
                 vmnew = news
            };
            return View(vm);
        }
    }
}