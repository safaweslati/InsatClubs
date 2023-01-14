using InsatClub.Data;
using InsatClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InsatClub.Controllers
{
    public class StudentsController : Controller
    {
        public ClubsInsatContext context = new ClubsInsatContext();

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Event()
        {
            return View(context);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}