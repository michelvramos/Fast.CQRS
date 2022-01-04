using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CQRS.Interfaces
{
    public interface IInjector
    {
        Task Inject(IServiceCollection services, IConfiguration configuration);
    }
}
