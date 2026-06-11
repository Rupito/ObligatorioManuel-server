using Microsoft.AspNetCore.Mvc;
using StellarMinds.Models;
using System.Diagnostics;

namespace StellarMinds.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
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
}
