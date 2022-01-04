using CQRS.Implementacao;
using System.Collections.Generic;

namespace CQRS.Interfaces
{
    public interface INotifiable
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        bool Valid { get; }
        void AddNotification(Notification notification);
        void AddNotifications(IEnumerable<Notification> notifications);
        string NotificationsMessage();
    }
}
