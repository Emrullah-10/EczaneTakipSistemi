using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IlacTakip.Data;
using IlacTakip.Models;
using IlacTakip.ViewModels;

namespace IlacTakip.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Session kontrolü için helper method
        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("AdminId") != null;
        }

        public async Task<IActionResult> Index()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var model = new AdminDashboardViewModel
            {
                ToplamIlac = await _context.Ilaclar.CountAsync(),
                ToplamPersonel = await _context.Personeller.CountAsync(p => p.AktifMi),
                ToplamMaasGideri = await _context.Personeller.Where(p => p.AktifMi).SumAsync(p => p.Maas),
                
                // Stok uyarıları (stok miktarı 10'dan az olanlar)
                StokUyarisiIlaclar = await _context.Ilaclar
                    .Where(i => i.StokMiktari < 10)
                    .Take(5)
                    .ToListAsync(),
                
                // Son kullanma tarihi uyarıları (30 gün içinde son kullanma tarihi gelenler)
                SonKullanmaUyarisiIlaclar = await _context.Ilaclar
                    .Where(i => i.SonKullanmaTarihi.HasValue && 
                               i.SonKullanmaTarihi.Value <= DateTime.Now.AddDays(30))
                    .Take(5)
                    .ToListAsync(),
                
                ToplamIlacDegeri = await _context.Ilaclar.SumAsync(i => i.Fiyat * i.StokMiktari),
                AktifPersonelSayisi = await _context.Personeller.CountAsync(p => p.AktifMi)
            };

            return View(model);
        }

        // İlaç İşlemleri
        public async Task<IActionResult> Ilaclar()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var ilaclar = await _context.Ilaclar.ToListAsync();
            return View(ilaclar);
        }

        [HttpGet]
        public IActionResult IlacEkle()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IlacEkle(IlacEkleViewModel model)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                var ilac = new Ilac
                {
                    Ad = model.Ad,
                    Aciklama = model.Aciklama,
                    Fiyat = model.Fiyat,
                    StokMiktari = model.StokMiktari,
                    BarkodNumarasi = model.BarkodNumarasi,
                    SonKullanmaTarihi = model.SonKullanmaTarihi,
                    OlusturmaTarihi = DateTime.Now
                };

                _context.Ilaclar.Add(ilac);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "İlaç başarıyla eklendi.";
                return RedirectToAction(nameof(Ilaclar));
            }

            return View(model);
        }

        // Personel İşlemleri
        public async Task<IActionResult> Personeller()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var personeller = await _context.Personeller.ToListAsync();
            return View(personeller);
        }

        [HttpGet]
        public IActionResult PersonelEkle()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PersonelEkle(PersonelEkleViewModel model)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                var personel = new Personel
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    Telefon = model.Telefon,
                    Pozisyon = model.Pozisyon,
                    Maas = model.Maas,
                    IseBaslamaTarihi = model.IseBaslamaTarihi,
                    AktifMi = true,
                    OlusturmaTarihi = DateTime.Now
                };

                _context.Personeller.Add(personel);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Personel başarıyla eklendi.";
                return RedirectToAction(nameof(Personeller));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PersonelSil(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var personel = await _context.Personeller.FindAsync(id);
            if (personel != null)
            {
                _context.Personeller.Remove(personel);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Personel başarıyla silindi.";
            }

            return RedirectToAction(nameof(Personeller));
        }
    }
} 