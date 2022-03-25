namespace CQRSCore.Interfaces
{
    /// <summary>
    /// Command interface
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// <inheritdoc cref="Implementation.Command.Validate"/>
        /// </summary>
        void Validate();
    }
}
