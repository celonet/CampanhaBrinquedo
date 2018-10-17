using Microsoft.Extensions.DependencyInjection;

namespace Campanhabrinquedo.IoC
{
    public static class CampanhaBrinquedoExtensions
    {
        public static IServiceCollection RegisterContainerServices(this IServiceCollection services)
        {
            return services
                //.RegisterAutoMapper()
                .RegisterService()
                .RegisterRepositories();
        }
    }
}
