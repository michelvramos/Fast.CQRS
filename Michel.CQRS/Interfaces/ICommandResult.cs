namespace CQRS.Interfaces
{
    /// <summary>
    /// Interface of an command result.
    /// </summary>
    public interface ICommandResult
    {
        /// <summary>
        /// <inheritdoc cref="Implementation.CommandResult.Success"/>
        /// </summary>
        bool Success { get; set; }
        /// <summary>
        /// <inheritdoc cref="Implementation.CommandResult.Message"/>
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// <inheritdoc cref="Implementation.CommandResult.Data"/>
        /// </summary>
        object Data { get; set; }
    }
}
