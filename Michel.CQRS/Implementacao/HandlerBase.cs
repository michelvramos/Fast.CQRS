using CQRS.Interfaces;
using System;
using System.Threading.Tasks;

namespace CQRS.Implementacao
{
    public class HandlerBase
    {
        protected virtual async Task<ICommandResult> Handle<T>(Command command, Func<Task<T>> func)
        {
            if (command == null)
            {
                return CommandResult.Fail("Parâmetro command é obrigatório");
            }

            command.Validate();

            if (!command.Valid)
            {
                return CommandResult.Fail(command.NotificationsMessage());
            }

            try
            {
                return CommandResult.Success("", await func());
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }
    }
}
