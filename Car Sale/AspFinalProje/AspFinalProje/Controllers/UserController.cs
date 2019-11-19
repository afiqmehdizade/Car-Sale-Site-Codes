using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProje.ViewModels;
using AspFinalProje.Models;
using AspFinalProje.DATA;
using static AspFinalProje.FileExtensions.FileExtensions;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AspFinalProje.Controllers
{
    [AuthoizationFilter]
    public class UserController : Controller
    {
        AspFinalContext _context;
        public UserController()
        {
            _context = new AspFinalContext();
        }

        public ActionResult Index()
        {
            var user = Session["lguser"] as User;
            return View(_context.Adverts.Where(m => m.UserId == user.Id).ToList());
        }

        public ActionResult Detail(int? id)
        {
            if (id == null) return HttpNotFound();

            var dbadvert = _context.Adverts.Find(id);

            if (dbadvert == null) return HttpNotFound();


            return View(dbadvert);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            var dbcar = _context.Avtomobils.Find(id);
            if (dbcar == null) return HttpNotFound();
            var propcity = _context.Adverts.First(m => m.AvtomobilId == dbcar.Id);
            var user = Session["lguser"] as AspFinalProje.Models.User;
            if (propcity.UserId != user.Id) return HttpNotFound();

            dbcar.sitild = propcity.CityId;
            ViewBag.Oils = new SelectList(_context.Oils, "Id", "YanacaqAdi");
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "CityName");

            return View(dbcar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Image,ModelId,Photo,MadeYear" +
            ",EngineCapacity,KiloMetre,Color,OilId,Context,Price,sitild")]Avtomobil auto)
        {
            ViewBag.Oils = new SelectList(_context.Oils, "Id", "YanacaqAdi");
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "CityName");


            if (!ModelState.IsValid) return View(auto);


            if (Convert.ToUInt32(auto.MadeYear) > DateTime.Now.Year)
            {
                ModelState.AddModelError("MadeYear", "Duzgun tarix daxil edin");
                return View(auto);
            }
            if (auto.sitild == 0)
            {
                ModelState.AddModelError("errorCity", "Şəhəri daxil edin");
                return View(auto);
            }

            var dbcity = _context.Cities.Find(auto.sitild);
            if (dbcity == null) return HttpNotFound();



            var dboil = _context.Oils.Find(auto.OilId);
            if (dboil == null) return HttpNotFound();

            if (auto.Photo != null)
            {
                if (!auto.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Duzgun fayl secin");
                    return View(auto);
                }

                if (DeleteImage(Server.MapPath("~/Images/cars"), auto.Image))
                {
                    auto.Image = auto.Photo.SaveImage("cars");
                }
            }
            _context.Entry(auto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var currentadvert = _context.Adverts.Find(auto.Id);

            currentadvert.CityId = auto.sitild;
            currentadvert.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return Redirect("/Home/Index");
        }


        public ActionResult Create()
        {
            ViewBag.Markas = new SelectList(_context.Markas, "Id", "MarkaName");
            ViewBag.Oils = new SelectList(_context.Oils, "Id", "YanacaqAdi");
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "CityName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Photo,ModelId,MadeYear," +
            "EngineCapacity,KiloMetre" +
            ",Color,OilId,TransMission," +
            "Context,Price,sitild")]Avtomobil auto)
        {
            ViewBag.Markas = new SelectList(_context.Markas, "Id", "MarkaName");
            ViewBag.Oils = new SelectList(_context.Oils, "Id", "YanacaqAdi");
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "CityName");

            if (!ModelState.IsValid) return View(auto);
            if (Convert.ToUInt32(auto.MadeYear) > DateTime.Now.Year)
            {
                ModelState.AddModelError("MadeYear", "Duzgun tarix daxil edin");
                return View(auto);
            }
            if (auto.Photo == null)
            {
                ModelState.AddModelError("Photo", "Sekli daxil edin");
                return View(auto);
            }
            if (!auto.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Duzgun fayl secin");
                return View(auto);
            }
            if (auto.sitild == 0)
            {
                ModelState.AddModelError("errorCity", "Şəhəri daxil edin");
                return View(auto);
            }

            var dbcity = _context.Cities.Find(auto.sitild);
            if (dbcity == null) return HttpNotFound();

            var dbmodel = _context.Models.Find(auto.ModelId);
            if (dbmodel == null) return HttpNotFound();

            var dboil = _context.Oils.Find(auto.OilId);
            if (dboil == null) return HttpNotFound();



            auto.Image = auto.Photo.SaveImage("cars");

            _context.Avtomobils.Add(auto);
            await _context.SaveChangesAsync();
            var user = Session["lguser"] as AspFinalProje.Models.User;
            _context.Adverts.Add(new Advert
            {
                AvtomobilId = auto.Id,
                UserId = user.Id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CityId = auto.sitild,
                IsVip = false
            });
            await _context.SaveChangesAsync();
            return Redirect("/Home/Index");
        }


    }
}