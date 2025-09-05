using Microsoft.AspNetCore.Mvc;
using IlacTakip.Data;
using IlacTakip.ViewModels;
using IlacTakip.Models;

namespace IlacTakip.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Basit admin kontrolü
                var admin = _context.Admins
                    .FirstOrDefault(a => a.Email == model.Email && a.Sifre == model.Password && a.AktifMi);

                if (admin != null)
                {
                    // Session'da admin bilgisini sakla
                    HttpContext.Session.SetString("AdminId", admin.Id.ToString());
                    HttpContext.Session.SetString("AdminName", $"{admin.Ad} {admin.Soyad}");
                    
                    // Son giriş tarihini güncelle
                    admin.SonGirisTarihi = DateTime.Now;
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Admin");
                }

                ModelState.AddModelError(string.Empty, "E-posta veya şifre hatalı.");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
} 