using CQRS.Interfaces;
using System;
using System.Threading.Tasks;

namespace CQRS.Implementation
{
    public class HandlerBase
    {
        protected virtual async Task<ICommandResult> Handle<T>(Command command, Func<Task<T>> func)
        {
            if (command == null)
            {
                return CommandResult.Fail("Command parameter can not be null");
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
