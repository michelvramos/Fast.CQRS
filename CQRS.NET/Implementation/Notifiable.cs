using CQRS.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation
{
    /// <summary>
    /// Use this class to notify errors about a command.
    /// </summary>
    public abstract class Notifiable : INotifiable
    {

        private readonly List<Notification> _notifications = new List<Notification>();

        /// <summary>
        /// Error notifications, if any.
        /// </summary>
        public IReadOnlyCollection<Notification> Notifications { get => _notifications.ToArray(); }


        /// <summary>
        /// True if the object is valid, i.e., contains no notifications.
        /// </summary>
        public bool Valid { get => !Notifications.Any(); }

        /// <summary>
        /// Adds a notification
        /// </summary>
        /// <param name="notification">An instance of notification class.</param>
        public void AddNotification(Notification notification)
        {
            if (notification != null)
            {
                _notifications.Add(notification);
            }
        }

        /// <summary>
        /// Adds a list of notifications.
        /// </summary>
        /// <param name="notifications">A list of notifications.</param>
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

        /// <summary>
        /// Returns a semicolon <c>(;)</c> separated list of notifications.
        /// </summary>
        /// <returns></returns>
        public string NotificationsMessage() =>
            string.Join(";", Notifications.Select(x => x.Message));
    }
}
