using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSCore.Interfaces
{
    /// <summary>
    /// Interface for a command handler.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandlerAsync<T> where T : ICommand
    {
        /// <summary>
        /// Handle a command of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="command">A command to execute</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<ICommandResult> HandleAsync(T command, CancellationToken cancellationToken);
    }
}
