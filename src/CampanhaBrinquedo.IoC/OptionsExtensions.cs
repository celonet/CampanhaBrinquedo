using CampanhaBrinquedo.CrossCutting.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CampanhaBrinquedo.IoC
{
    public static class OptionsExtensions
    {
        public static IServiceCollection RegisterOptions(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<JwtIssuerOptions>(options => configuration.GetSection("JwtIssuerOptions").Bind(options));
        }
    }
}
