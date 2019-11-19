using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProje.Models;
using AspFinalProje.DATA;
using AspFinalProje.ViewModels;
using System.Threading.Tasks;

namespace AspFinalProje.Controllers
{
    public class AJAXController : Controller
    {
        AspFinalContext _context;
        public AJAXController()
        {
            _context = new AspFinalContext();
        }

        // GET: AJAX
        public ActionResult LoadCars(int? id = 0)
        {
            if (id != 0)
            {
                var DBCar = _context.Adverts.Where(m => m.Avtomobil.Model.MarkaId == id).ToList();
                if (DBCar == null)
                {
                    return HttpNotFound();
                }
                return PartialView("_LoadCars", DBCar);
            }
            else
            {
                return PartialView("_LoadCars", _context.Adverts.OrderByDescending(m => m.UpdatedAt).OrderByDescending(m => m.IsVip == true).ToList());
            }
        }

        public ActionResult LoadModels(int? id)
        {
            if (id == null) return HttpNotFound();

            var DBMarka = _context.Markas.Find(id);

            if (DBMarka == null) return HttpNotFound();

            var dbmodels = _context.Models.Where(m => m.MarkaId == DBMarka.Id);

            return PartialView("_LoadModels",dbmodels);




           
        }

        public async Task< ActionResult> DeletePost(int id)
        {
            var dbcar = _context.Avtomobils.Find(id);

            if (dbcar == null)
            {
                return Json(new {
                    status = 304,
                    error = "Id duzgun deyil",
                    data = HttpNotFound()
                }, JsonRequestBehavior.AllowGet);
            }
            
            var advert = _context.Adverts.Find(id);


            var user = Session["lguser"] as AspFinalProje.Models.User;
            if (advert.UserId != user.Id)
            {
                return Json(new
                {
                    status = 304,
                    error = "Hal hazirki istifadeci sorqunu yanlis gonderdi",
                    data = HttpNotFound(),
                }, JsonRequestBehavior.AllowGet);
            }

            _context.Avtomobils.Remove(dbcar);
            _context.Adverts.Remove(advert);

            await _context.SaveChangesAsync();

            return Json(new {
                status = 200,
                error = "",
                data = Url.Action("Index", "Home"),
                
            },JsonRequestBehavior.AllowGet);
        }

    }
}