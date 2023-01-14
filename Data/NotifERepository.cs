using InsatClub.Data;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class NotifERepository : Repository<NotifsEtudiant>, INotifERepository
    {
        private readonly UniversityContext context;
        public NotifERepository(ClubsInsatContext context) : base(context)
        {
            this.context = context;
        }
    }
}