using CQRS.Interfaces;

namespace CQRS.Implementacao
{
    public class CommandResult : ICommandResult
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public CommandResult() { }

        public CommandResult(bool sucess, string message, object data = null)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public static CommandResult Success(string message = "", object data = null)
        {
            return new CommandResult(true, message, data);
        }

        public static CommandResult Fail(string message = "", object data = null)
        {
            return new CommandResult(false, message, data);
        }
    }
}
