using InsatClub.Data;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class NotifAARepository : Repository<NotifsAdministrateurFromAdministration>, INotifAARepository
    {
        private readonly UniversityContext context;
        public NotifAARepository(ClubsInsatContext context) : base(context)
        {
            this.context = context;
        }
    }
}