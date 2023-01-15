using InsatClub.Data;
using InsatClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;



namespace InsatClub.Controllers
{
    public class HomeController : Controller
    {
        public int x = 300;
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
        public IActionResult Events()
        {
            return View(context);
        }

        public IActionResult Sign_up()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sign_up(Etudiant etd)
        {
            if (ModelState.IsValid)
            {
                etd.Id = x;
                context.Etudiants.Add(etd);
                context.SaveChanges();
                HttpContext.Session.SetString("EtudiantId", etd.Id.ToString());
                x++;
                return RedirectToAction("Clubs", "Students");
            }
            else
            {
                ViewData["Data"] = "vrai";

                return View(etd);
          }
              
        }
        public IActionResult Log_In_Etud()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Log_In_Etud(Etudiant etd)
        {
            if (etd.Email == null || etd.MotDePasse == null)
            {
                ViewData["NoData"] = "vrai";
                return View(etd);
            }
            else
            {
                var e = context.Etudiants.Where(e => e.Email==etd.Email && e.MotDePasse == etd.MotDePasse);
                if (e.SingleOrDefault() == null)
                {
                   
                        ViewData["NoAcc"] = "vrai";
                        return View(etd);
                    
                }
                else
                {
                    HttpContext.Session.SetString("EtudiantId", etd.Id.ToString());
                    return RedirectToAction("Event", "Students");

                }

            }

        }
        public IActionResult Log_In_Admin()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Log_In_Admin(Administrateur admin)
        {
            if (admin.Email == null || admin.MotDePasse == null)
            {
                ViewData["NoData"] = "vrai";
                return View(admin);
            }
            else
            {
                var e = context.Administrateurs.Where(e => e.Email == admin.Email && e.MotDePasse == admin.MotDePasse);
                if (e.SingleOrDefault() == null)
                {

                    ViewData["NoAcc"] = "vrai";
                    return View(admin);

                }
                else
                {
                    HttpContext.Session.SetString("AdminId", e.First().Id.ToString());
                    return RedirectToAction("Index", "Administrateur");

                }

            }

        }
        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("EtudiantId", "");
            HttpContext.Session.SetString("AdminId", "");
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}