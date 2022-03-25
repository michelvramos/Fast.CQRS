namespace CQRS.Implementation
{
    /// <summary>
    /// A class to indicated invalid data in a command paramenter.
    /// </summary>
    public sealed class Notification
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string Property { get; private set; }
        /// <summary>
        /// A user-friendly self described message about the error.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Creates an instance of notification.
        /// </summary>
        /// <param name="property"><inheritdoc cref="Property"/></param>
        /// <param name="message"><inheritdoc cref="Message"/></param>
        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}
