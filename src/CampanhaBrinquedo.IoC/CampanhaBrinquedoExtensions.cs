using CampanhaBrinquedo.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Campanhabrinquedo.IoC
{
    public static class CampanhaBrinquedoExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                    .RegisterOptions(configuration)
                    .RegisterRepositories()
                    .RegisterServiceApp();
        }
    }
}
