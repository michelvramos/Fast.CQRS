using CQRS.Interfaces;

namespace CQRS.Implementation
{
    /// <summary>
    /// Rapresents the result of a command.
    /// </summary>
    public class CommandResult : ICommandResult
    {
        /// <summary>
        /// True if command was succeed, otherwise false.
        /// </summary>
        public bool Sucess { get; set; }
        /// <summary>
        /// A simple self explanatory message, if required.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data returned by this command, if required.
        /// </summary>
        public object Data { get; set; }

        public CommandResult() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sucess"><inheritdoc cref="Sucess"/></param>
        /// <param name="message"><inheritdoc cref="Message"/></param>
        /// <param name="data"><inheritdoc cref="Data"/></param>
        public CommandResult(bool sucess, string message, object data = null)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Create a succeed CommandResult object.
        /// </summary>
        /// <param name="message"><inheritdoc cref="Message"/> </param>
        /// <param name="data"><inheritdoc cref="Data"/></param>
        /// <returns>A CommandResult instance with <c>Success = true</c>, a message and custom data.</returns>
        public static CommandResult Success(string message = "", object data = null)
        {
            return new CommandResult(true, message, data);
        }

        /// <summary>
        /// Create a failed CommandResult object.
        /// </summary>
        /// <param name="message"><inheritdoc cref="Message"/> </param>
        /// <param name="data"><inheritdoc cref="Data"/></param>
        /// <returns>A CommandResult instance with <c>Success = false</c>, a message and custom data.</returns>
        public static CommandResult Fail(string message = "", object data = null)
        {
            return new CommandResult(false, message, data);
        }
    }
}
