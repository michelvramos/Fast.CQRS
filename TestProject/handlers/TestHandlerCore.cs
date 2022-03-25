using System.Threading;
using System.Threading.Tasks;
using CQRSCore.Implementation;
using CQRSCore.Interfaces;
using TestProject.commands;
using TestProject.service;

namespace TestProject.handlers
{
    public class TestHandlerCore : HandlerBase,
        IHandler<TestHandleCommand>,
        IHandlerAsync<TestAsyncIOCommand>,
        IHandlerAsync<TestAsyncCpuCommand>
    {

        private readonly FakeService service;

        public TestHandlerCore()
        {
            service = new FakeService();
        }
        public ICommandResult Handle(TestHandleCommand command, CancellationToken cancellationToken)
        {
            return Handle(command, () =>
            {
                return service.IsAdult(command.Age);
            });
        }

        public Task<ICommandResult> HandleAsync(TestAsyncIOCommand command, CancellationToken cancellationToken)
        {
            return HandleAsync(command, async () =>
            {
                return await service.DownloadData(command.Url);
            });
        }

        public Task<ICommandResult> HandleAsync(TestAsyncCpuCommand command, CancellationToken cancellationToken)
        {
            return HandleAsyncInBackground(command, () =>
            {
                return service.CountPrimeNumbers(command.MaxPrime, cancellationToken);
            });
        }
    }
}
