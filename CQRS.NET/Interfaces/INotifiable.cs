using System.Collections.Generic;
using CQRS.Implementation;

namespace CQRS.Interfaces
{
    /// <summary>
    /// Interface of an notifiable object
    /// </summary>
    public interface INotifiable
    {
        /// <summary>
        /// <inheritdoc cref="Implementation.Notifiable.Notifications"/>
        /// </summary>
        IReadOnlyCollection<Notification> Notifications { get; }

        /// <summary>
        /// <inheritdoc cref="Implementation.Notifiable.Valid"/>
        /// </summary>
        bool Valid { get; }

        /// <summary>
        /// <inheritdoc cref="Implementation.Notifiable.AddNotification(Notification)"/>
        /// </summary>
        void AddNotification(Notification notification);

        /// <summary>
        /// <inheritdoc cref="Implementation.Notifiable.AddNotification(string, string)"/>
        /// </summary>
        void AddNotification(string property, string message);

        /// <summary>
        /// <inheritdoc cref="Implementation.Notifiable.AddNotifications(IEnumerable{Notification})"/>
        /// </summary>
        void AddNotifications(IEnumerable<Notification> notifications);

        /// <summary>
        /// <inheritdoc cref="Implementation.Notifiable.NotificationsMessage"/>
        /// </summary>
        string NotificationsMessage();
    }
}
