using InsatClub.Models;

namespace InsatClub.Data.Repository
{
    public class EventRepository : Repository<Event> , IEventRepository 
    {
        public EventRepository(ClubsInsatContext _Context) : base(_Context)
        {
        }
        public IEnumerable<Event> GetAllEventsForClub(int id)
        {
            Club c = FindClub(id);
            var events = _Context.Events.Where(e => e.ClubId == c.Id).ToList();
            return events;
        }


        public Club FindClub(int id)
        {
            var admin = _Context.Administrateurs.Find((long)id);
                return  _Context.Clubs.Find(admin.ClubId);
        }
        public void Update(int Id, Event e)
        {

            Event ev = Get(Id);

            ev.Nom = e.Nom;
            ev.Date = e.Date;
            ev.Img = e.Img;
      
        
        }
        public void save()
        {
            _Context.SaveChanges();
        }
    }
}
