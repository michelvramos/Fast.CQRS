using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command, CancellationToken cancellationToken);
    }
}
