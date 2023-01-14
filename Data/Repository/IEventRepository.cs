using InsatClub.Models;
using InsatClub.Data.Repository;

namespace InsatClub.Data.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        
            IEnumerable<Event> GetAllEventsForClub();
            void Update(int id,Event e);
        }
    
}
