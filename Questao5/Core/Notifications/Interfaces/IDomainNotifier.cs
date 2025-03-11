using Questao5.Core.Notifications.Model;

namespace Questao5.Core.Notifications.Interfaces
{
    public interface IDomainNotifier
    {
        void Add(DomainNotification notification);

        List<DomainNotification> GetNotifications();

        bool HasNotification();
    }
}
