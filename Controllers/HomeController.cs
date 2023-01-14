using InsatClub.Data;
using InsatClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InsatClub.Controllers
{
    public class HomeController : Controller
    {
        public ClubsInsatContext context = new ClubsInsatContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clubs()
        {
            return View(context);
        }
        public IActionResult Log_In()
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