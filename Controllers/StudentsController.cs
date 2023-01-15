using InsatClub.Data;
using InsatClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InsatClub.Controllers
{
    public class StudentsController : Controller
    {
        public ClubsInsatContext context = new ClubsInsatContext();
        public static int x=10;

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
                return RedirectToAction("Index", "Home");
            }
            return View(context);
        }
        
        public IActionResult Notifications()
        {
            var id = HttpContext.Session.GetString("EtudiantId");
            if(id==null)
            {
                ViewBag.noSession = true;
                return RedirectToAction("Index", "Home");
            }
            long Id = Convert.ToInt64(id);
            return View(context.Etudiants.Find(Id));
        }

        public IActionResult Clubs( )
        {
            var id = HttpContext.Session.GetString("EtudiantId");
            if (id == null)
            {
                ViewBag.noSession = true;
                return RedirectToAction("Index", "Home");
            }
            return View(context);
        }
        public IActionResult MyClubs()
        {
           var  id = HttpContext.Session.GetString("EtudiantId");
            if (id == null)
            {
                ViewBag.noSession = true;
                return RedirectToAction("Index", "Home");
            }
            long Id = Convert.ToInt64(id);
            var e = context.Etudiants.Find(Id);
            /* var student = context.Etudiants
                          .Include(s => s.IdClubs)
                       .FirstOrDefault(s => s.Id == Id);
             Debug.WriteLine(student.IdClubs.Count);*/

            //context.Entry(e).Collection(s => s.IdClubs).Load();
            

            return View(e.IdClubs);
        }
        public IActionResult JoinClub(long Id)
        {
            var id = HttpContext.Session.GetString("EtudiantId");
            if (id == null)
            {
                ViewBag.noSession = true;
                return RedirectToAction("Index", "Home");
            }
            long IdE = Convert.ToInt64(id);
            Etudiant? e = context.Etudiants.Find(IdE);
            var club = context.Clubs.Find(Id);
            var admin = context.Administrateurs
       .Where(a => a.ClubId == Id)
       .Select(a => a.Id)
       .ToList();
            //List<Administrateur> admin = (List<Administrateur>)club.Administrateurs;
            ViewBag.info = "ok";
            string s = string.Format(" l'etudiant {0} {1} veut rejoindre votre club ! voici son e-mail: {2}",e.Nom, e.Prenom,e.Email);
            NotifsAdministrateurFromEtudiant notif = new NotifsAdministrateurFromEtudiant();
            x++;
            notif.Id = x;
            
            notif.Titre = "demande d'ajout";
            notif.Contenu = s;
            notif.AdministrateurId = admin.ElementAt(0);
            notif.EtudiantId = IdE;
            context.NotifsAdministrateurFromEtudiants.Add(notif);
            context.SaveChanges();


            return RedirectToAction("Clubs", "Students");
        }
        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}