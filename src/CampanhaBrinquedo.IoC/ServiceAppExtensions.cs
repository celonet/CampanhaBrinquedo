using CampanhaBrinquedo.Application.Services;
using CampanhaBrinquedo.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CampanhaBrinquedo.IoC
{
    public static class ServiceAppExtensions
    {
        public static IServiceCollection RegisterServiceApp(this IServiceCollection service)
        {
            return service
                .AddScoped<ICampaignServiceApp, CampaignService>()
                .AddScoped<IChildServiceApp, ChildService>();
        }
    }
}