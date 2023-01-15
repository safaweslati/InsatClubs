using Microsoft.AspNetCore.Mvc;
using InsatClub.Data;
using InsatClub.Models;
using InsatClub.Data.Repository;
using System.Reflection.Metadata.Ecma335;
using System.Net.Http.Headers;

namespace InsatClub.Controllers
{
    public class AdministrateurController : Controller
    {
        //public ClubsInsatContext? context = 
        public IEventRepository repo = new EventRepository(new ClubsInsatContext());

        public IActionResult Index()
        {
            var id = HttpContext.Session.GetString("AdminId");
            if (id == null)
            {
                return RedirectToAction("Index","Home");
            }

            int Id = int.Parse(id);

            var events = repo.GetAllEventsForClub(Id).ToList();

            Club c = repo.FindClub(Id);
            ViewBag.club = c;
            

            return View(events);

            

        }
        public IActionResult AddEvent()
        {
            if (HttpContext.Session.GetString("AdminId") is null )
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["title"] = "Add";

                return View();
            }

        }
        [HttpPost]
        public IActionResult AddEvent(Event model,int id)
        {
            
                if (ModelState.IsValid)
                {
                    ViewData["event"] = "ok";
                model.ClubId=id;    
                repo.Add(model);
                    repo.save();
                return RedirectToAction("Index", "Administrateur");

            }

            return View(model);
            

        }

        public IActionResult Edit_Event(int id)
        {
          
                var model = repo.Get(id);
                return View(model);
            
            
        }
        [HttpPost]
        public IActionResult Edit_Event(int id,Event e)
        {
            
                repo.Update(id,e);
                repo.save();
                ViewData["update"] = "ok";
                return RedirectToAction("Index", "Administrateur");
            
        }
        public IActionResult Delete_Event(int id)
        {
            Event e= repo.Get(id);  
            repo.Remove(e);
            repo.save();
            ViewData["delete"] = "ok";
            return RedirectToAction("Index", "Administrateur");
        }




    }
}
