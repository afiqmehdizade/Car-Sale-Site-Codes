using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspFinalProje.DATA;
using AspFinalProje.Models;
using AspFinalProje.FileExtensions;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AspFinalProje.Areas.Admin.Controllers
{[isAdmin]
    public class NewsController : Controller
    {
        AspFinalContext _context;
        public NewsController()
        {
            _context = new AspFinalContext();
        }
        // GET: Admin/News
        public ActionResult Index()
        {
            return View(_context.News.ToList());
        }

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,Content,Photo")]New neww)
        {
            if (!ModelState.IsValid) return HttpNotFound();

            if (neww.Photo == null)
            {
                ModelState.AddModelError("Photo", "Fotonu secin");
                return View();
            }

            if (!neww.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Foto düzgün seçilməyib");
                return View();
            }

            neww.Image = neww.Photo.SaveImage("news");

            neww.CreatedAt = DateTime.Now;

            _context.News.Add(neww);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var dbnew = _context.News.Find(id);

            if (dbnew == null) return HttpNotFound();

            return View(dbnew);


        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CreatedAt,Image,Title,Content,Photo")]New neww)
        {
            if (!ModelState.IsValid) return HttpNotFound();


            if (neww.Photo != null)
            {
                if (!neww.Photo.IsImage())
                {

                    ModelState.AddModelError("Photo", "Foto düzgün seçilməyib");
                    return View();

                }

                if (FileExtensions.FileExtensions.DeleteImage(Server.MapPath("~/Images/news"), neww.Image))
                {
                    neww.Image = neww.Photo.SaveImage("news");
                }
            }

            _context.Entry(neww).State = EntityState.Modified;
           await _context.SaveChangesAsync();

            return RedirectToAction("Index");


        }



        public async Task<ActionResult>Delete(int? id )
        {
            if (id == null) return HttpNotFound();

            var dbnew = _context.News.Find(id);

            if (dbnew == null) return HttpNotFound();

            if (FileExtensions.FileExtensions.DeleteImage(Server.MapPath("~/Images/news"), dbnew.Image))
            {
                _context.News.Remove(dbnew);
            }
            _context.News.Remove(dbnew);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
       
    }
}