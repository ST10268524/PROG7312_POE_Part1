using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MunicipalServices.Models;

namespace MunicipalServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // placeholders for later
        public ActionResult Announcements()
        {
            ViewBag.Message = "Coming soon.";
            return View();
        }

        public ActionResult Status()
        {
            ViewBag.Message = "Coming soon.";
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
