namespace CQRS.Interfaces
{
    /// <summary>
    /// Interface of an command result.
    /// </summary>
    public interface ICommandResult
    {
        /// <summary>
        /// <inheritdoc cref="Implementation.CommandResult.Sucess"/>
        /// </summary>
        bool Sucess { get; set; }
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
