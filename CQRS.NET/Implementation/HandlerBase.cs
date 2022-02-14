using CQRS.Interfaces;
using System;
using System.Threading.Tasks;

namespace CQRS.Implementation
{
    /// <summary>
    /// Base class for command handler.
    /// </summary>
    public class HandlerBase
    {
        /// <summary>
        /// Handles a command with will be performed by a provided function.
        /// </summary>
        /// <typeparam name="T">Data type which will be returned by a given command.</typeparam>
        /// <param name="command">A command to be executed.</param>
        /// <param name="func">An async function wich will perform the work. The handler will await the function.</param>
        /// <returns>A command result object</returns>
        protected virtual async Task<ICommandResult> Handle<T>(Command command, Func<Task<T>> func)
        {
            if (command == null)
            {
                return CommandResult.Fail("Command parameter can not be null");
            }

            if (func == null)
            {
                return CommandResult.Fail("Command function can not be null");
            }

            command.Validate();

            if (!command.Valid)
            {
                return CommandResult.Fail(command.NotificationsMessage());
            }

            try
            {
                return CommandResult.Ok("", await func());
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return CommandResult.Fail(ex.Message);
                }

                Exception inner = ex;

                while(inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }

                return CommandResult.Fail(inner.Message);
            }
        }
    }
}
