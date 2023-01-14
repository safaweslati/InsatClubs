using InsatClub.Data;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class NotifARepository : Repository<NotifsAdministration>, INotifARepository
    {
        private readonly UniversityContext context;
        public NotifARepository(ClubsInsatContext context) : base(context)
        {
            this.context = context;
        }
    }
}