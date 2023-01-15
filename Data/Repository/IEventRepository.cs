using InsatClub.Models;
using InsatClub.Data.Repository;

namespace InsatClub.Data.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        
            Club FindClub(int id);   
            IEnumerable<Event> GetAllEventsForClub(int id);
            void Update(int id,Event e);
            void save();
        }
    
}
