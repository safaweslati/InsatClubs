using Microsoft.AspNetCore.Mvc;
using InsatClub.Data;

namespace InsatClub.Controllers
{
    public class AdministrateurController : Controller
    {
        public ClubsInsatContext context = new ClubsInsatContext();

        public IActionResult Index()
        {
           var id =  HttpContext.Session.GetString("AdminId");
            if(id == null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                var admin = context.Administrateurs.Find(id);
                var club = admin.Club;
                return View(club);


            }

        }
    }
}
