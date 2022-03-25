using CQRSCore.Interfaces;

namespace CQRSCore.Implementation
{
    /// <summary>
    /// Abstract Command class. All commands must derive from this class.
    /// </summary>
    public abstract class Command : Notifiable, ICommand
    {
        /// <summary>
        /// Performs validation on input paremeters.
        /// </summary>
        public abstract void Validate();
    }
}
