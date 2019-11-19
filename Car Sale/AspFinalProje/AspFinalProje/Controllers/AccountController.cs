using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AspFinalProje.DATA;
using AspFinalProje.Models;

namespace AspFinalProje.Controllers
{
    public class AccountController : Controller
    {
        AspFinalContext _context;
        public AccountController()
        {
            _context = new AspFinalContext();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(string email, string password,bool? asAdmin = false)
        {
            if (string.IsNullOrEmpty(email.Trim()) || string.IsNullOrEmpty(password.Trim()))
            {
                ModelState.AddModelError("loginError", "Email və ya Parol Yanlışdır");
                return View();
            }

            try
            {
                MailAddress mailAddress = new MailAddress(email);
            }
            catch (Exception)
            {

                ModelState.AddModelError("loginError", "Duzgun Email Daxil Edin");
                return View();
            }

            if (asAdmin == true)
            {
                var admin = _context.adminSettings.FirstOrDefault(m => m.Email == email.Trim());

                if (admin == null)
                {
                    ModelState.AddModelError("loginError", "Email və ya Parol Yanlışdır");
                    return View();
                }

                if (!Crypto.VerifyHashedPassword(admin.Password, password.Trim()))
                {
                    ModelState.AddModelError("loginError", "Email və ya Parol Yanlışdır");
                    return View();
                }

                Session["admin"] = admin;


                return RedirectToAction("Dashboard", "Admin");
            }

            var dbuser = _context.Users.FirstOrDefault(m => m.Email == email.Trim());

            if (dbuser == null)
            {
                ModelState.AddModelError("loginError", "Email və ya Parol Yanlışdır");
                return View();
            }

            if (!Crypto.VerifyHashedPassword(dbuser.Password, password.Trim()))
            {
                ModelState.AddModelError("loginError", "Email və ya Parol Yanlışdır");
                return View();
            }

            Session["lguser"] = dbuser;


            return RedirectToAction("Index", "Home");

        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Registration(User user)
        {
            if (!ModelState.IsValid) return View(user);
            var dbuser = _context.Users.FirstOrDefault(m=>m.Email == user.Email);
            if (dbuser != null)
            {
                ModelState.AddModelError("Email", "Bu email artıq mövcuddur!");
                return View(user);
            }
            
            if (user.Password != user.ConfirmPassword)
            {
                ModelState.AddModelError("Password", "Parol Təkralanan parolla uyğun deyil");
                return View(user);
            }
            if (user.Phone.Length != 9)
            {
                ModelState.AddModelError("Phone", "Telefon nomresini duzgun daxil edin");
                return View(user);
            }

            user.Password = user.ConfirmPassword = Crypto.HashPassword(user.ConfirmPassword);
            user.Phone = "+994" + user.Phone;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            Session["lguser"] = user;

            return Redirect("/Home/Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
