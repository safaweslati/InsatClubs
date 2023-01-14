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
        public IActionResult Events()
        {
            return View(context);
        }

        public IActionResult Sign_up()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Etudiant model)
        {
            if (ModelState.IsValid)
            {
                context.Etudiants.Add(model);
                context.SaveChanges();
                HttpContext.Session.SetString("EtudiantId", model.Id.ToString());
                return RedirectToAction("Clubs", "Students");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Log_In()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Log_In(Etudiant etd)
        {
            if (etd.Email == null || etd.MotDePasse == null)
            {
                ViewData["NoData"] = "vrai";
                return View(etd);
            }
            else
            {
                var e = context.Etudiants.Where(e => ((e.Email==etd.Email) && (e.MotDePasse==etd.MotDePasse)));
                if (e == null)
                {
                    var e1 = context.Administrateurs.Where(e => ((e.Email == etd.Email) && (e.MotDePasse == etd.MotDePasse)));
                    if (e1 == null)
                    {
                        ViewData["NoAcc"] = "vrai";
                        return View(etd);
                    }
                   else
                    {
                        HttpContext.Session.SetString("AdminId", etd.Id.ToString());
                        return RedirectToAction("Index", "Administrateur");
                    }
                }
                else
                {

                    HttpContext.Session.SetString("EtudiantId", etd.Id.ToString());
                    return RedirectToAction("Notifications", "Students");

                }

            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}