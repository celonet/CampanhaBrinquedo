using CampanhaBrinquedo.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Campanhabrinquedo.IoC
{
    public static class CampanhaBrinquedoExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return
                services
                    .RegisterRepositories()
                    .RegisterServiceApp();
        }
    }
}
