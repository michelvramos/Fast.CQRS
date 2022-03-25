using System;
using System.Threading.Tasks;
using CQRSCore.Interfaces;

namespace CQRSCore.Implementation
{
    /// <summary>
    /// Base class for command handler.
    /// </summary>
    public abstract class HandlerBase
    {
        /// <summary>
        /// Handles a command with will be performed by a provided function.
        /// </summary>
        /// <typeparam name="T">Data type which will be returned by a given command.</typeparam>
        /// <param name="command">A command to be executed.</param>
        /// <param name="func">A function wich will perform the work.</param>
        /// <returns>Returns a <seealso cref="ICommandResult"/> object.</returns>
        protected ICommandResult Handle<T>(Command command, Func<T> func)
        {
            ValidateInput(command, func, out CommandResult inputValidation);

            if (!inputValidation.Success)
            {
                return inputValidation;
            }

            try
            {
                return CommandResult.Ok("", func());
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return CommandResult.Fail(ex.Message);
                }

                Exception inner = ex;

                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }

                return CommandResult.Fail(inner.Message);
            }
        }

        /// <summary>
        /// Used for handling I/O bound work. Handles command with will be performed by a provided function.
        /// </summary>
        /// <typeparam name="T">Data type which will be returned by a given command.</typeparam>
        /// <param name="command">A command to be executed.</param>
        /// <param name="func">An async function wich will perform the work. The handler will await the function.</param>
        /// <returns>Returns a <seealso cref="ICommandResult"/> object.</returns>
        protected async Task<ICommandResult> HandleAsync<T>(Command command, Func<Task<T>> func)
        {
            ValidateInput(command, func, out CommandResult inputValidation);

            if (!inputValidation.Success)
            {
                return inputValidation;
            }

            try
            {
                return CommandResult.Ok("", await func().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return CommandResult.Fail(ex.Message);
                }

                Exception inner = ex;

                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }

                return CommandResult.Fail(inner.Message);
            }
        }

        /// <summary>
        /// Used for handling I/O bound work. Handles command with will be performed by a provided function.
        /// </summary>
        /// <typeparam name="T">Data type which will be returned by a given command.</typeparam>
        /// <param name="command">A command to be executed.</param>
        /// <param name="func">An async function wich will perform the work. The handler will perform Task.Run(<paramref name="func"/>) and await the function.</param>
        /// <returns>Returns a <seealso cref="ICommandResult"/> object.</returns>
        protected async Task<ICommandResult> HandleAsyncInBackground<T>(Command command, Func<T> func)
        {

            ValidateInput(command, func, out CommandResult inputValidation);

            if (!inputValidation.Success)
            {
                return inputValidation;
            }

            try
            {
                var t = Task.Run(func).ConfigureAwait(false);
                await t;
                T result = t.GetAwaiter().GetResult();
                return CommandResult.Ok("", result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return CommandResult.Fail(ex.Message);
                }

                Exception inner = ex;

                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }

                return CommandResult.Fail(inner.Message);
            }
        }
        
        private static void ValidateInput<T>(in Command command, in Func<T> func, out CommandResult result)
        {
            
            if (command == null)
            {
                result = CommandResult.Fail("Command parameter can not be null");
                return;
            }

            if (func == null)
            {
                result = CommandResult.Fail("Command function can not be null");
                return;
            }

            command.Validate();

            if (!command.Valid)
            {
                result= CommandResult.Fail(command.NotificationsMessage());
                return;
            }

            result = CommandResult.Ok();
        }
    }
}
