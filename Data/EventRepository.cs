using InsatClub.Models;

namespace InsatClub.Data
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly ClubsInsatContext context;
        public EventRepository(ClubsInsatContext context) : base(context)
        {
            this.context = context;
        }
    }
}