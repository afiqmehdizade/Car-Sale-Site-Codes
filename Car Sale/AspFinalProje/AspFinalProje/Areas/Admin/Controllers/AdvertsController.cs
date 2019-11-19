using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProje.DATA;
using AspFinalProje.Models;
using AspFinalProje.FileExtensions;
using System.Threading.Tasks;

namespace AspFinalProje.Areas.Admin.Controllers
{
    [isAdmin]
    public class AdvertsController : Controller
    {
        AspFinalContext _context;
        public AdvertsController()
        {
            _context = new AspFinalContext();
        }
        // GET: Admin/Adverts
        public ActionResult Index()
        {
            return View(_context.Adverts.ToList());
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var dbadv = _context.Adverts.Find(id);

            if (dbadv == null) return HttpNotFound();

            var dbcar = _context.Avtomobils.Find(id);


            if (FileExtensions.FileExtensions.DeleteImage(Server.MapPath("~/Images/cars"), dbcar.Image))
            {
                _context.Adverts.Remove(dbadv);
                _context.Avtomobils.Remove(dbcar);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}