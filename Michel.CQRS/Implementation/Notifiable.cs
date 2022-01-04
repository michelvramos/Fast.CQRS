using CQRS.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation
{
    public abstract class Notifiable : INotifiable
    {

        private readonly List<Notification> _notifications = new List<Notification>();
        public IReadOnlyCollection<Notification> Notifications { get => _notifications.ToArray(); }

        public bool Valid { get => !Notifications.Any(); }

        public void AddNotification(Notification notification)
        {
            if (notification != null)
            {
                _notifications.Add(notification);
            }
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                if (notification != null)
                {
                    _notifications.Add(notification);
                }
            }
        }

        public string NotificationsMessage() =>
            string.Join("; ", Notifications.Select(x => x.Message));
    }
}
