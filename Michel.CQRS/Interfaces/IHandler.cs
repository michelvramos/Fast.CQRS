using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Interfaces
{
    /// <summary>
    /// Interface for a command handler.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandler<T> where T : ICommand
    {
        /// <summary>
        /// Handle a command of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="command">A command to execute</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<ICommandResult> Handle(T command, CancellationToken cancellationToken);
    }
}
