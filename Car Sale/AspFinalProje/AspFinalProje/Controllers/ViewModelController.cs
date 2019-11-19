using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProje.ViewModels;
using AspFinalProje.DATA;

namespace AspFinalProje.Controllers
{
    public class ViewModelController : Controller
    {
        AspFinalContext _context;
        public ViewModelController()
        {
            _context = new AspFinalContext();
        }
        // GET: ViewModel
        public ActionResult Index()
        {
            return View();
        }
    }
}