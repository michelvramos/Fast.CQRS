using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CQRS.Interfaces
{
    /// <summary>
    /// Interface for dependency injection
    /// </summary>
    public interface IInjector
    {
        /// <summary>
        /// You must implement the dependendy injection of your services using the provided service collection and configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        Task Inject(IServiceCollection services, IConfiguration configuration);
    }
}
