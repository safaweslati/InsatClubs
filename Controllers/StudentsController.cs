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
           // ViewBag.id = HttpContext.Session.GetString("EtudiantId");
           string? id = HttpContext.Session.GetString("EtudiantId");
            if (id == null)
            {
                ViewBag.noSession = true;
                return RedirectToRoute("default");
            }
            return View(context);
        }
        
        public IActionResult Notifications()
        {
            var id = HttpContext.Session.GetString("EtudiantId");
            if(id==null)
            {
                ViewBag.noSession = true;
                return RedirectToRoute("default");
            }
           

            return View(context.Etudiants.Find(id));
        }

        public IActionResult Clubs( )
        {
            var id = HttpContext.Session.GetString("EtudiantId");
            if (id == null)
            {
                ViewBag.noSession = true;
                return RedirectToRoute("default");
            }
            return View(context);
        }
        public IActionResult MyClubs()
        {
           var  id = HttpContext.Session.GetString("EtudiantId");
            if (id == null)
            {
                ViewBag.noSession = true;
                return RedirectToRoute("default");
            }
            return View(context.Etudiants.Find(id).IdClubs);
        }
        public IActionResult JoinClub()
        {
            var id = HttpContext.Session.GetString("EtudiantId");
            if (id == null)
            {
                ViewBag.noSession = true;
                return RedirectToRoute("default");
            }

            return View();
        }
        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}