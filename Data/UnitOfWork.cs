using InsatClub.Data;
using WebApplication5.Data;

namespace WebApplication5.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClubsInsatContext _clubsInsatContext;
        public INotifAARepository NotifAA { get; private set; }
        public INotifAERepository NotifAE { get; private set; }
        public INotifARepository NotifA { get; private set; }
        public INotifERepository NotifE { get; private set; }
        public IEventRepository Event { get; private set; }
        public UnitOfWork(ClubsInsatContext clubsInsatContext)
            this._appicationDbContext = applicationDbContext;
            NotifAA = new INotifAARepository(applicationDbContext);
        }
        public bool Complete()
        {
            try
            {
                int result = _applicationDbContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }

}