namespace WebApplication5.Data
{
    public interface IUnitOfWork : IDisposable
    {
        INotifAARepository NotifAA { get; }
        INotifAERepository NotifAE { get; }
        INotifARepository NotifA { get; }
        INotifERepository NotifEA { get; }
        IEventRepository Event { get; }

        bool Complete();
    }
}
