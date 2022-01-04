using CQRS.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Implementacao
{
    public static class DependencyInjector
    {
        public static Task InjectDependencies(this IServiceCollection services, IConfiguration configuration, IReadOnlyCollection<IInjector> dependencies)
        {
            _ = services == null ? throw new ArgumentNullException(nameof(services))
                : configuration == null ? throw new ArgumentNullException(nameof(configuration))
                : dependencies == null ? throw new ArgumentNullException(nameof(dependencies))
                : true;

            try
            {
                foreach (var svc in dependencies)
                {
                    svc.Inject(services, configuration);
                }
            }
            catch (Exception ex)
            {
                var inner = ex;

                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }

                return Task.FromException(inner);
            }

            return Task.CompletedTask;
        }
    }
}
