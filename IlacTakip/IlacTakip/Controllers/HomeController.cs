using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IlacTakip.Models;

namespace IlacTakip.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Giriş yapmışsa admin paneline yönlendir
        if (HttpContext.Session.GetString("AdminId") != null)
        {
            return RedirectToAction("Index", "Admin");
        }

        // Giriş yapmamışsa login sayfasına yönlendir
        return RedirectToAction("Login", "Account");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
