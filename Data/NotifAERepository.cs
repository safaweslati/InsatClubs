using InsatClub.Data;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class NotifAERepository : Repository<NotifsAdministrateurFromEtudiant>, INotifAERepository
    {
        private readonly UniversityContext context;
        public NotifAERepository(ClubsInsatContext context) : base(context)
        {
            this.context = context;
        }
    }
}